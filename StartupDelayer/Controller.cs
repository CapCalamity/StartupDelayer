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

        /// <summary>
        /// Add a Program, by creating the matching dialog for it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Adds a DelayedProgram to the DatagridView
        /// </summary>
        /// <param name="newProg">The DelayedProgram to be added</param>
        private void AddRow(DelayedProgram newProg)
        {
            this.MainForm.AddRow(newProg);
        }

        /// <summary>
        /// Recreates the Datagridview rows
        /// </summary>
        private void RefreshRows()
        {
            this.MainForm.DeleteRows();
            foreach(DelayedProgram dp in this.DelayedPrograms)
            {
                this.AddRow(dp);
            }
        }

        /// <summary>
        /// Loads all Objects from ./objects.dat
        /// </summary>
        public void LoadObjects()
        {
            string fPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\StartupDelayer\\objects.dat";

            if(File.Exists(fPath))
            {
                using(StreamReader sr = new StreamReader(fPath, Encoding.ASCII))
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

        /// <summary>
        /// Creates the ./objects.dat
        /// Truncates if exists, Creates if not
        /// </summary>
        public void WriteStartupFile()
        {
            string[] lines = new string[this.DelayedPrograms.Count];
            int bufferSize = 0;
            byte[] buffer;
            string objectsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\StartupDelayer\\objects.dat";
            string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\StartupDelayer";

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

            if(!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            if(File.Exists(objectsPath))
                File.Delete(objectsPath);

            using(FileStream fstream = File.Open(objectsPath, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
            {
                fstream.Write(buffer, 0, bufferSize);
                fstream.Flush();
            }

            //@TODO: Add a notification for the user, a messagewindow or something...
        }

        /// <summary>
        /// Call the dialog to edit a DelayedProgram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Delete the selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="row">Row index to be deleted. 0 based</param>
        internal void DeleteRow(object sender, EventArgs e, int row)
        {
            this.DelayedPrograms.RemoveAt(row);
            this.RefreshRows();
        }
    }
}