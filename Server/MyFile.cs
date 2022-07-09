using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MyFile
    {
        public string Path { get; private set; }
        public FileInfo Info { get; private set; }
        public TimeSpan LifeTime { get; private set; }
        public MyFile(string path)
        {
            this.Path = path;
            this.Info = new FileInfo(path);
            this.LifeTime = new TimeSpan(0,5,0);
        }

        public void SetLifeTime(TimeSpan lifeTime)
        {
            LifeTime = lifeTime;
            Info = new FileInfo(Path);
        }

        public override string ToString()
        {
            return $"{Info.Name} \t Creation date {Info.CreationTime}";
        }
    }

}
