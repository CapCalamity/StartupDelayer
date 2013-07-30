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
    public partial class FormEditProgram : Form
    {
        internal FormEditProgram(DelayedProgram dp)
        {
            InitializeComponent();

            this.TextBoxName.Text = dp.Name;
            this.TextBoxPath.Text = dp.Path;
            this.NumericUpDownDelay.Value = dp.Delay;
        }

        internal DelayedProgram GetEditedProgram()
        {
            return new DelayedProgram(
                this.TextBoxName.Text, 
                this.TextBoxPath.Text, 
                Convert.ToInt32(this.NumericUpDownDelay.Value));
        }
    }
}