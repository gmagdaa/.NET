using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Syllabus.Syllabuses;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Forms;
using System.Threading;

namespace Syllabus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Database.Instance.openDatabase();
            fill_combobox();

            DataContext = this;


            App.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            System.Windows.MessageBox.Show(e.Exception.Message.ToString());
        }

        public String code;
        public String syllabuses;

        public static string language;
        public static string syllabus_path;
        public static string symbol;

        CSyllabus sylab = new CSyllabus();

        protected List<string> combobox = new List<string>();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            code = Course.Text;            
            language = Language.Text;
            symbol = Symbol.Text;
            if (code != null)
            sylab.create_pdf(code);
            System.Windows.MessageBox.Show("Sylabus został zapisany");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            syllabuses = Code_text.Text;
            language = Language2.Text;
            symbol = Symbol2.Text;
            if (syllabuses != null)
            {
                Thread thr = new Thread(() =>
                {
                    sylab.create_pdfs(syllabuses);
                });
                thr.Start();
            }
            System.Windows.MessageBox.Show("Sylabusy zostały zapisane");
        }



        public void fill_combobox()
        {
            Text.Text = "Wybierz kod i język sylabusu:";
            Text2.Text = "Wpisz kod i wybierz język sylabusu:";
            location.Text = "Przed wygenerowaniem sylabusu wybierz miejsce zapisu:";
            combobox = Database.Instance.get_code();

            for (int i = 0; i < combobox.Count; i++)
                Course.Items.Add(combobox[i]);

          /*  Language.Items.Add("Polski");
            Language.Items.Add("Angielski");

            Language2.Items.Add("Polski");
            Language2.Items.Add("Angielski"); */
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            syllabus_path = dialog.SelectedPath;

            One.Visibility = Visibility;
            More.Visibility = Visibility;
        }
        }
    }
