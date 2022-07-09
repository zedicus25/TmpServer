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
{// save data to registr
    public class ClientNetwork
    {
        private const int PORT = 8008;
        private const string IP_ADDR = "127.0.0.1";
        private IPEndPoint iPEnd;
        private Socket socket;

        private Task readTask;

        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        private int countSendsFiles = 0;
        private int maxSendsFiles = 5;
        private bool isPremium = false;

        private string directoryForSave;
        private string gettingFile;
        private FileStream fileStream;
        public event Action<string> SendMsg;
        public ClientNetwork()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            directoryForSave = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Client";

            if (HasDirectory("Client") == false)
                Directory.CreateDirectory(directoryForSave);

            readTask = new Task(ReadMsg);
            iPEnd = new IPEndPoint(IPAddress.Parse(IP_ADDR), PORT);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(iPEnd);  
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            readTask.Start();
            GetUserData();
        }

        private void GetUserData()
        {

            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\ClientData");
            if(key != null)
            {
                string data = key.GetValue("Data") as string;
                string[] datas = data.Split('|');

                if (datas.Length == 0)
                    return;

                isPremium = bool.Parse(datas[2]);

                maxSendsFiles = isPremium ? 50 : 5;

                DateTime d = DateTime.Parse(datas[1]);
                if (DateTime.Now.Subtract(d).Days >= 1)
                {
                    countSendsFiles = 0;
                }
                else
                {
                    countSendsFiles = int.Parse(datas[0]);
                }

            }
        }

        private void ReadMsg()
        {
            StringBuilder sb = new StringBuilder();
            bool isFile = false;
            string extension = String.Empty;
            string name = String.Empty;
            string path = String.Empty;
            while (!token.IsCancellationRequested)
            {
                do
                {
                    int byteCount = 0;
                    byte[] buffer = new byte[1024];
                    byteCount = socket.Receive(buffer);

                    if (isFile)
                    {
                        fileStream.Write(buffer, 0, byteCount);
                    }

                    if (isFile == false)
                    {
                        sb.Append(Encoding.Unicode.GetString(buffer, 0, byteCount));
                    }
                } while (socket.Available > 0);

                isFile = false;
                fileStream?.Close();

                if (sb.Length > 0)
                {
                    if (sb.ToString().Equals("--notFound"))
                    {
                        SendMsg?.Invoke($"File not found {gettingFile}");
                        if (File.Exists("history.txt"))
                        {
                            List<string> lines = File.ReadAllLines("history.txt").ToList();
                            lines.Remove(gettingFile);
                            File.WriteAllLines("history.txt", lines.ToArray());
                        }
                        sb.Clear();
                        continue;
                    }

                    if (sb[0].Equals('.'))
                    {
                        extension = sb.ToString();
                        isFile = true;
                        name = $"{DateTime.Now.ToString().Replace(':', '_').Replace('.', '_')}_FILE{extension}";
                        path = Path.Combine(directoryForSave, name);
                        fileStream = CreateStream(path);
                    }

                    if((sb[0].Equals('.') == false))
                    {
                        SendMsg?.Invoke(sb.ToString());
                        if (File.Exists("history.txt"))
                            File.AppendAllText("history.txt", sb.ToString() + "\n");
                        else
                            File.WriteAllText("history.txt", sb.ToString() + "\n");
                    }
                    sb.Clear();
                }
            }
        }

        private FileStream CreateStream(string path) => 
            new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);


        public void SendFile(string file)
        {
            if (!file.Equals(String.Empty))
            {
                if(countSendsFiles == maxSendsFiles && isPremium == false)
                {
                    SendMsg?.Invoke("Max count for free use is 5. Send files tommorow!");
                    return;
                }
                if(countSendsFiles == maxSendsFiles && isPremium)
                {
                    SendMsg?.Invoke("Max count for premium use is 50. Send files tommorow!");
                    return;
                }
                string extension = file.Substring(file.LastIndexOf('.'), file.Length - file.LastIndexOf('.'));
                socket.Send(Encoding.Unicode.GetBytes(extension));
                Thread.Sleep(200);
                socket.Send(File.ReadAllBytes(file));

                countSendsFiles++;
            }
        }

        public void GetFile(string file)
        {
            gettingFile = file;
            socket.Send(Encoding.Unicode.GetBytes(file));
        }

        public void EnablePremium()
        {
            if (isPremium)
                return;
            isPremium = true;
            maxSendsFiles = 50;
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

        ~ClientNetwork()
        {
            string data = $"{countSendsFiles}|{DateTime.Now.ToShortDateString()}|{isPremium}";
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("ClientData");
            key = key.OpenSubKey("ClientData", true);
            key.SetValue("Data", data);
            key.Close();

            socket.Close();
            fileStream?.Close();
        }
    }
}
