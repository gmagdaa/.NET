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
    class Title_syl
    {
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        public Paragraph create(string code, string symbol)
        {
            Title_dbo tit = new Title_dbo();
            string title = tit.getData(code, symbol);

            Paragraph par_title = new Paragraph(title, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 20));
            for (int i = 0; i < par_title.Count; i++)
            {
                par_title[i] = new Paragraph(_htmlRegex.Replace(par_title[i].ToString(), string.Empty), FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 20));
            }
            return par_title;

        }

      
    }
}

      