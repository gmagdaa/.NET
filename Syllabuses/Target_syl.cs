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
    class Target_syl
    {
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        protected string language;
        public Paragraph create(string code, string symbol)
        {
            Target_dbo tar = new Target_dbo();
            string target = tar.getData(code, symbol);
            target = target.Replace("\n", " ");
            target = target.Replace("&nbsp;", " ");
            Paragraph par_title = new Paragraph(target, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            for (int i = 0; i < par_title.Count; i++)
            {
                par_title[i] = new Paragraph(_htmlRegex.Replace(par_title[i].ToString(), string.Empty), FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            }
            return par_title;

        }

        public Paragraph create_title()
        {
            string target;
            language = MainWindow.language;
            if (language =="Polski")
            {
            target = "Cel:" + Environment.NewLine;
            }
            else if (language == "Angielski")
            {
            target = "Target:" + Environment.NewLine;
            }
            else
            {
            target = "";
            }
            Paragraph par_title = new Paragraph(target, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 15));
            return par_title;
        }

    }
}
