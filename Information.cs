using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sylabus
{
    public partial class Information : Form
    {
         public List<string> titleList = new List<string>();
  
        public Information(List<string> ti)
        {
            InitializeComponent();
            titleList = ti;
        }

        string text = "";
        private void Information_Load(object sender, EventArgs e)
        {

            label1.Text = "Zostały utworzone Sylabusy:";
            for (int i=0; i< titleList.Count; i++)
            {
                text = text + Environment.NewLine + titleList[i];
            }
            label2.Text = text;
        }
    }
}
