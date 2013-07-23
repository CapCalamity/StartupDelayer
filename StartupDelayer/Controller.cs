using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartupDelayer
{

    class Controller
    {
        private FormMain MainForm { get; set; }

        public Controller()
        {
            this.MainForm = new FormMain();
        }

        public Controller(FormMain form)
        {
            this.MainForm = form;
        }

        public void Run()
        {
            Application.Run(this.MainForm);
        }
    }
}