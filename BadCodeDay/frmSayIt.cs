using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BadCodeDay
{
    public partial class frmSayIt : Form
    {
        public frmSayIt()
        {
            InitializeComponent();
        }

        private void cmdSayIt_Click(object sender, EventArgs e)
        {
            var valueToSay = 0;
            if(Int32.TryParse(txtNumber.Text,out valueToSay))
            {
                var sayIt = new SayIt();
                MessageBox.Show(sayIt.Convert(valueToSay));
            } 
            else
            {
                MessageBox.Show("Not a number");
            }
            
        }

    }
}
