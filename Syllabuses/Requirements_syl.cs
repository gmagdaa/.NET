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
    class Requirements_syl
    {
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        protected string language;

        public Paragraph create(string code, string symbol)
        {
            Requirements_dbo req = new Requirements_dbo(); 
            string requirement = req.getData(code, symbol);
            requirement = requirement.Replace("\n", " ");
            requirement = requirement.Replace("&nbsp;", " ");

            Paragraph par_requirement = new Paragraph(requirement, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            for (int i = 0; i < par_requirement.Count; i++)
            {
                par_requirement[i] = new Paragraph(_htmlRegex.Replace(par_requirement[i].ToString(), string.Empty), FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            }
            return par_requirement;
        }

        public Paragraph create_title()
        {
            string requirement;
            language = MainWindow.language;
            if (language == "Polski")
            {
                requirement = "Wymagania do przedmiotu:" + Environment.NewLine;
            }
            else if (language == "Angielski")
            {
                requirement = "Requirements:" + Environment.NewLine;
            }
            else
            {
                requirement = "";
            }
            Paragraph par_title = new Paragraph(requirement, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 15));
            return par_title;
        }

    }
}
