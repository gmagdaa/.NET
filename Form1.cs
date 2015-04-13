using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;


namespace Sylabus
{
    public partial class Form1 : Form
    {
        Syllabus sylab = new Syllabus();
        public String code;
        public String syllabuses;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ramykwal14DataSet1.Przedmioty' table. You can move, or remove it, as needed.
            this.przedmiotyTableAdapter.Fill(this.ramykwal14DataSet1.Przedmioty);
        }

        List<string> titleList = new List<string>();

        private void Generuj_Click(object sender, EventArgs e)
        {
            get_code();
            if (syllabuses != "")
            {
                Thread thr = new Thread(() =>
                {
                    sylab.create_pdfs(syllabuses);
                    titleList = sylab.createTitle();

                    
                });
                thr.Start();

                openInformation();

            }
            else
            {
                sylab.create_pdf(code);
                titleList = sylab.createTitle();
                openInformation();
            }   
           
            

        }

        public void get_code()
        {
            code = Przedmioty.Text;
            syllabuses = Przedmiot_text.Text;
        }

        public void openInformation()
        {
            Form inf = new Information(titleList);
            inf.Show();
        }

      
    }
}

