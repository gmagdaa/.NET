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
using Syllabus.DataBase;
using System.Text.RegularExpressions;

namespace Syllabus.Syllabuses
{
    class Contents_syl
    {
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        protected string language;
        public List<Paragraph> create(int id)
        {
            Contents_dbo con = new Contents_dbo(); 
            List<string> content_list = con.getData(id);
            List<Paragraph> par_content = new List<Paragraph>();

            for (int i = 0; i < content_list.Count; i++)
            {
                content_list[i] = _htmlRegex.Replace(content_list[i].ToString(), string.Empty);
                content_list[i] = content_list[i].Replace("\n", " ");
                content_list[i] = content_list[i].Replace("\r", "");
                content_list[i] = content_list[i].Replace("&nbsp;", " ");

            }


            for (int i = 0; i < content_list.Count; i++)
            {
                par_content.Add(new Paragraph(" • " + content_list[i], FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10)));
            }

            return par_content;

        }

        public Paragraph create_title()
        {
            string content;
            language = MainWindow.language;
            if (language == "Polski")
            {
                content = "Treści nauczania:" + Environment.NewLine;
            }
            else if (language == "Angielski")
            {
                content = "Learning content" + Environment.NewLine;
            }
            else
            {
                content = "";
            }

            Paragraph par_title = new Paragraph(content, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 15));
            return par_title;
        }
     
    }
    }
