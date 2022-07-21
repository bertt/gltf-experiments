using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GltfExperiments.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SampleSpecularGlossinessShader.DoIt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SamplePointCloud.DoIt();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SampleAnimation.DoIt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // SampleRotate.DoIt();
        }
    }
}
