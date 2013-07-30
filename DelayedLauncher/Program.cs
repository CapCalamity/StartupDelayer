using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DelayedLauncher
{
    class ProgramStarter
    {
        private string Path { get; set; }
        private int Delay { get; set; }

        public ProgramStarter(string path, int delay)
        {
            this.Path = path;
            this.Delay = delay;
        }

        public void Start()
        {
            Thread.Sleep(this.Delay * 1000);

            Process p = new Process();
            p.StartInfo.FileName = this.Path;

            p.Start();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader sr = new StreamReader("objects.dat"))
            {
                List<string[]> programs = new List<string[]>(10);

                string line = sr.ReadLine();

                do
                {
                    Regex matcher = new Regex("^<(.*)><(.*)><([0-9]*)>;$", RegexOptions.IgnoreCase);
                    Match match = matcher.Match(line);
                    if(match.Success)
                    {
                        programs.Add(new string[2]{
                            match.Groups[2].Value,
                            match.Groups[3].Value
                        });
                    }

                    line = sr.ReadLine();
                }
                while(line != "" && line != null);

                foreach(string[] prog in programs)
                {
                    ProgramStarter ps = new ProgramStarter(prog[0], Convert.ToInt32(prog[1]));

                    Thread t = new Thread(new ThreadStart(ps.Start));
                    t.Start();
                }
            }
        }
    }
}