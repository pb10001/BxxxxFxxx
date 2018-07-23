using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BrainFxxkInterpreter;

namespace BrainFxxkGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void execButton_Click(object sender, EventArgs e)
        {
            outputBox.Text = "";
            var io = new GraphicIO(stdInBox.Text);
            var b = new Brain(sourceBox.Text);
            b.IO = io;
            io.OnWrite += Io_OnWrite;
            try
            {
                b.Fxxk();
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Io_OnWrite(object obj)
        {
            BeginInvoke(new Action(() =>
            {
                outputBox.Text += obj.ToString();
            }));
        }
    }
}
