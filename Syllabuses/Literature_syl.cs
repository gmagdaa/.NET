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

    class Literature_syl
    {
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        protected string language;

        public Paragraph create(int id)
        {
            
            Literature_dbo lit = new Literature_dbo(); 
            string literature = lit.getData(id);
            literature = literature.Replace("\n", " ");
            literature = literature.Replace("&nbsp;", " ");

            Paragraph par_literature = new Paragraph(literature, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            for (int i = 0; i < par_literature.Count; i++)
            {
                par_literature[i] = new Paragraph(_htmlRegex.Replace(par_literature[i].ToString(), string.Empty), FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            }
            return par_literature;

        }

        public Paragraph create_title()
        {
            string literature;
            language = MainWindow.language;
            if (language == "Polski")
            {
                literature = "Literatura:" + Environment.NewLine;
            }
            else if (language == "Angielski")
            {
                literature = "Literature:" + Environment.NewLine;
            }
            else
            {
                literature = "";
            }

            Paragraph par_title = new Paragraph(literature, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 15));
            return par_title;
        }
    }
}
