using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerNetwork
    {
        private readonly int PORT = 8008;
        private IPEndPoint iPEnd;
        private Socket socket;
        private Socket clientSocket;

        private Task listenTask;
        private Task deleteTask;

        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        private string directoryForSave;
        private FileStream fileStream;
        public List<MyFile> Files { get; private set; }

        public event Action<string> AddFile;
        public event Action<string> RemoveFileEvent;

        public ServerNetwork()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            listenTask = new Task(Listen, token);
            deleteTask = new Task(CheckForDelete, token);
            iPEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            directoryForSave = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Server";

            if (HasDirectory("Server") == false)
                Directory.CreateDirectory(directoryForSave);

            Files = new List<MyFile>();
            GetFiles();

            listenTask.Start();
            deleteTask.Start();
            AddToAutoLoad();
        }

        private void AddToAutoLoad()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey myProgKey = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            string progName = "TmpServer.exe";
            string path = Environment.CurrentDirectory + $"\\{progName}";
            myProgKey.SetValue(progName, path);
            myProgKey.Close();
        }

        public void Listen()
        {
            try
            {
                socket.Bind(iPEnd);
                socket.Listen(10);
                clientSocket = socket.Accept();

                StringBuilder sb = new StringBuilder();
                bool isFile = false;
                string extension = String.Empty;
                string fileForGet = String.Empty;
                while (!token.IsCancellationRequested)
                {
                    string name = String.Empty;
                    string path = String.Empty;
                    
                    do
                    {
                        int byteCount = 0;
                        byte[] buffer = new byte[1024];
                        byteCount = clientSocket.Receive(buffer);

                        if (isFile)
                        {
                            fileStream.Write(buffer, 0, byteCount);
                        }

                        if (isFile == false)
                        {
                            sb.Append(Encoding.Unicode.GetString(buffer, 0, byteCount));
                        }
                    } while (clientSocket.Available > 0);

                    isFile = false;
                    if (fileStream != null)
                        fileStream.Close();

                    if (sb.Length > 0)
                    {
                        if (sb[0].Equals('.'))
                        {
                            extension = sb.ToString();
                            isFile = true;
                            name = $"{DateTime.Now.ToString().Replace(':', '_').Replace('.', '_')}_FILE{extension}";
                            clientSocket.Send(Encoding.Unicode.GetBytes(name));
                            path = Path.Combine(directoryForSave, name);
                            fileStream = CreateStream(path);
                            Files.Add(new MyFile(path));
                            AddFile?.Invoke(Files.Last().ToString());
                        }
                        else
                        {
                            fileForGet = sb.ToString();
                            SendFile(fileForGet);
                        }
                        sb.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private FileStream CreateStream(string name) =>
            new FileStream(name, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);


        public void RemoveFile(string path)
        {
            string name = path.Substring(0, path.IndexOf('\t') - 1);
            string file = Path.Combine(directoryForSave, name);

            MyFile f = Files.FirstOrDefault(x => x.Path.Equals(file));
            File.Delete(file);
            Files.Remove(f);
            RemoveFileEvent?.Invoke(f.ToString());
        }

        private void GetFiles()
        {
            foreach (var item in Directory.GetFiles(directoryForSave))
                Files.Add(new MyFile(item));
        }

        private void SendFile(string file)
        {
            string path = Path.Combine(directoryForSave, file);
        

            MyFile f = Files.FirstOrDefault(x => x.Path.Equals(path));
            if (f != null)
            {
                string extension = path.Substring(path.LastIndexOf('.'), path.Length - path.LastIndexOf('.'));
                clientSocket.Send(Encoding.Unicode.GetBytes(extension));
                Thread.Sleep(200);
                clientSocket.Send(File.ReadAllBytes(path));
            }
            else
            {
                clientSocket.Send(Encoding.Unicode.GetBytes("--notFound"));
            }
        }

        private void CheckForDelete()
        {
            while (!token.IsCancellationRequested)
            {
                for (int i = 0; i < Files.Count; i++)
                {
                    if (DateTime.Now.Subtract(Files[i].Info.CreationTime) >= Files[i].LifeTime)
                    {
                        RemoveFile(Files[i].ToString());
                        --i;
                    }
                }
                Thread.Sleep(500);
            }
        }

        public void SetLifeTime(string file, TimeSpan lifeTime)
        {
            string name = file.Substring(0, file.IndexOf('\t') - 1);
            string path = Path.Combine(directoryForSave, name);

            MyFile f = Files.FirstOrDefault(x => x.Path.Equals(path));
            f.SetLifeTime(lifeTime);
        }

        public void SetLifeTimeForAll(TimeSpan lifetime)
        {
            for (int i = 0; i < Files.Count; i++)
                Files[i].SetLifeTime(lifetime);
        }
        private bool HasDirectory(string directory)
        {
            foreach (var item in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
            {
                if (item.Equals(directory))
                {
                    return true;
                }
            }
            return false;
        }

        ~ServerNetwork()
        {
            fileStream?.Close();
            socket?.Close();
            tokenSource.Cancel();
        }
    }
}
