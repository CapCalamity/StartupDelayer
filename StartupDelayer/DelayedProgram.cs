using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StartupDelayer
{
    class DelayedProgram
    {
        public string Name { get; set; }
        public int Delay { get; set; }
        private string _path;

        public string Path
        {
            get { return _path; }
            set
            {
                value.Trim();
                if(value[0] == '\"')
                    value = value.Remove(0, 1);
                if(value[value.Length - 1] == '\"')
                    value = value.Remove(value.Length - 1);
                _path = value;
            }
        }

        public DelayedProgram(string name, string path, int delay)
        {
            this.Name = name;
            this.Path = path;
            this.Delay = delay;
        }

        public DelayedProgram(DelayedProgram prog)
        {
            this.Name = prog.Name;
            this.Path = prog.Path;
            this.Delay = prog.Delay;
        }

        public DelayedProgram(string serialized)
        {
            Regex matcher = new Regex("^<(.*)><(.*)><([0-9]*)>;$", RegexOptions.IgnoreCase);
            Match match = matcher.Match(serialized);
            if(match.Success)
            {
                this.Name = match.Groups[1].Value;
                this.Path = match.Groups[2].Value;
                this.Delay = Convert.ToInt32(match.Groups[3].Value);
            }
        }

        public string GetSerialized()
        {
            return "<" + this.Name + "><" + this.Path + "><" + this.Delay + ">;";
        }
    }
}