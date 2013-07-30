using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace StartupDelayer
{
    //TODO: ability to delete programs
    class Controller
    {
        private FormMain MainForm { get; set; }
        private List<DelayedProgram> DelayedPrograms { get; set; }

        public Controller()
        {
            this.MainForm = new FormMain(this);
            this.DelayedPrograms = new List<DelayedProgram>(10);
        }

        public Controller(FormMain form)
        {
            this.MainForm = form;
            this.DelayedPrograms = new List<DelayedProgram>(10);
        }

        public void Run()
        {
            this.LoadObjects();
            Application.Run(this.MainForm);
        }

        internal void AddProgram(object sender, EventArgs e)
        {
            FormAddProgram fad = new FormAddProgram(this);
            fad.ShowDialog();

            if(fad.DialogResult == DialogResult.OK)
            {
                DelayedProgram newProg = fad.GetNewProgram();
                this.DelayedPrograms.Add(newProg);
                this.AddRow(newProg);
            }
        }

        private void AddRow(DelayedProgram newProg)
        {
            this.MainForm.AddRow(newProg);
        }

        private void RefreshRows()
        {
            this.MainForm.DeleteRows();
            foreach(DelayedProgram dp in this.DelayedPrograms)
            {
                this.AddRow(dp);
            }
        }

        public void LoadObjects()
        {
            if(File.Exists("objects.dat"))
            {
                using(StreamReader sr = new StreamReader("objects.dat", Encoding.ASCII))
                {
                    //initial read...
                    string line = sr.ReadLine();

                    do
                    {
                        DelayedProgram dp = new DelayedProgram(line);
                        this.DelayedPrograms.Add(dp);
                        this.AddRow(dp);
                        line = sr.ReadLine();
                    }
                    while(line != "" && line != null);
                }
            }
        }

        public void WriteStartupFile()
        {
            string[] lines = new string[this.DelayedPrograms.Count];
            int bufferSize = 0;
            byte[] buffer;

            List<byte[]> tmpBuffers = new List<byte[]>();

            for(int i = 0; i < this.DelayedPrograms.Count; ++i)
            {
                DelayedProgram p = this.DelayedPrograms[i];
                lines[i] = p.GetSerialized() + "\n";

                //append byte arrays to a temporary List<>
                tmpBuffers.Add(Encoding.ASCII.GetBytes(lines[i]));
                //save size for later
                bufferSize += Encoding.ASCII.GetByteCount(lines[i]);
            }

            //concat every byte[] in tmpBuffers to one byte[bufferSize]
            buffer = new byte[bufferSize];
            int pos = 0;
            foreach(byte[] b in tmpBuffers)
            {
                b.CopyTo(buffer, pos);
                pos += b.Length;
            }

            if(!File.Exists("objects.dat"))
                File.Create("objects.dat").Close();

            using(FileStream fstream = new FileStream("objects.dat", FileMode.Truncate, FileAccess.Write))
            {
                fstream.Write(buffer, 0, bufferSize);
                fstream.Flush();
            }
        }

        internal void Edit(object sender, DataGridViewCellEventArgs e)
        {
            using(FormEditProgram fe = new FormEditProgram(this.DelayedPrograms[e.RowIndex]))
            {
                fe.ShowDialog();

                if(fe.DialogResult == DialogResult.OK)
                {
                    this.DelayedPrograms[e.RowIndex] = fe.GetEditedProgram();
                    this.RefreshRows();
                }
            }
        }
    }
}