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
    public partial class FormAddProgram : Form
    {
        private Controller _controller;

        internal Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        internal FormAddProgram(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        internal DelayedProgram GetNewProgram()
        {
            DelayedProgram newProg = new DelayedProgram(
                this.TextBoxName.Text,
                this.TextBoxPath.Text,
                Convert.ToInt32(this.NumericUpDownDelay.Value));

            return newProg;
        }
    }
}