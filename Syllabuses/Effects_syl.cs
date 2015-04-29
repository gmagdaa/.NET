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
    class Effects_syl
    {
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
        protected string language;
        public List <Paragraph> create(int id)
        {
            Effects_dbo ef = new Effects_dbo();
            List<string> effect_list = ef.getData(id);
            List<Paragraph> par_effect = new List<Paragraph>();

            for (int i = 0; i < effect_list.Count; i++)
            {
                effect_list[i] = _htmlRegex.Replace(effect_list[i].ToString(), string.Empty);
                effect_list[i] = effect_list[i].Replace("\n", " ");
                effect_list[i] = effect_list[i].Replace("\r", "");
                effect_list[i] = effect_list[i].Replace("&nbsp;", " ");
            }


            for (int i = 0; i < effect_list.Count; i++)
            {
                par_effect.Add(new Paragraph(" • " + effect_list[i], FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10)));
            }



            return par_effect;
        }

        public Paragraph create_title()
        {
            string effect;
            language = MainWindow.language;
            if (language == "Polski")
            {
                effect = "Efekty nauczania:" + Environment.NewLine;
            }
            else if (language == "Angielski")
            {
                effect = "Effects of teaching:" + Environment.NewLine;
            }
            else
            {
                effect = "";
            }

            Paragraph par_title = new Paragraph(effect, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 15));
            return par_title;
        }
     
    }
}
