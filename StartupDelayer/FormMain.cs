using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupDelayer
{
    public partial class FormMain : Form
    {
        private Controller Controller { get; set; }

        internal FormMain(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        internal void AddRow(DelayedProgram newProg)
        {
            this.ProgramList.Rows.Add(newProg.Name, newProg.Path, newProg.Delay);
        }

        internal void DeleteRows()
        {
            this.ProgramList.Rows.Clear();
        }

        private void ButtonAddProgram_Click(object sender, EventArgs e)
        {
            this.Controller.AddProgram(sender, e);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            this.Controller.WriteStartupFile();
        }

        private void ProgramList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Controller.Edit(sender, e);
        }
    }
}