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

namespace Syllabus
{
    class CSyllabus
    {
        protected int id_sylabusu;
        public void create_pdf(String code)
        {
            show_sylabus(code);
        }﻿

        public void create_pdfs(String syllabuses)
        {
            List<string> syllabus_list = Database.Instance.list_syllabuses(syllabuses);
            for (int i = 0; i < syllabus_list.Count; i++)
            {
                show_sylabus(syllabus_list[i]);
            }
        }﻿

        List<Paragraph> effect_list = new List<Paragraph>();
        List<Paragraph> content_list = new List<Paragraph>();



        public string syllabus_path;
        public string language;
        public string symbol;

        public void show_sylabus(string code)
        {
            string syllabus_title = "Sylabus " + code + ".pdf";
            syllabus_path = MainWindow.syllabus_path;
            language = MainWindow.language;
            symbol = MainWindow.symbol;

            if (language == "Polski")
            {
                language = "pl";
            }
            else if (language == "Angielski")
            {
                language = "en";
            }
           /* int dlugosc = syllabus_title.Length;
            dlugosc = dlugosc - 4;
            syllabus_title = syllabus_title.Remove(dlugosc, 4); */

                using (var doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35))
                {
                   // using (var wri = PdfWriter.GetInstance(doc, new FileStream(syllabus_title, FileMode.Create)))
                    using (var wri = PdfWriter.GetInstance(doc, new FileStream(syllabus_path + "\\" + code + " " + symbol + " " + language + ".pdf", FileMode.Create)))
                    {
                        doc.Open();

                    Paragraph new_line = new Paragraph(Environment.NewLine, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 20));
                    id_sylabusu = Database.Instance.get_id(code, symbol);

                    Title_syl tit = new Title_syl();
                    Paragraph par_title = tit.create(code, symbol);
                    doc.Add(par_title);

                    doc.Add(new_line);


                    Target_syl tar = new Target_syl();
                    Paragraph par_target = tar.create_title();
                    doc.Add(par_target);
                    par_target = tar.create(code, symbol);
                    doc.Add(par_target);

                    doc.Add(new_line);

                    Requirements_syl req = new Requirements_syl();
                    Paragraph par_requirement = req.create_title();
                    doc.Add(par_requirement);
                    par_requirement = req.create(code, symbol);
                    doc.Add(par_requirement);

                    doc.Add(new_line);

                    Effects_syl ef = new Effects_syl();
                    Paragraph par_effect = ef.create_title();
                    doc.Add(par_effect);

                    effect_list = ef.create(id_sylabusu);

                    for (int i = 0; i < effect_list.Count; i++)
                        doc.Add(effect_list[i]);

                    doc.Add(new_line);
                    Contents_syl con = new Contents_syl();
                    Paragraph par_content = con.create_title();
                    doc.Add(par_content);

                    content_list = con.create(id_sylabusu);

                    for (int i = 0; i < effect_list.Count; i++)
                        doc.Add(content_list[i]);
                    doc.Add(new_line);

                    Literature_syl lit = new Literature_syl();
                    Paragraph par_literature = lit.create_title();

                    doc.Add(par_literature);
                    par_literature = lit.create(id_sylabusu);


                    doc.Add(par_literature);
                    doc.Close();
                }
            }
               
           // }
           

        }

        PdfPTable table = new PdfPTable(3);
        /*   public void show_table()
           {
            

               PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));

               cell.Colspan = 3;

               cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

               table.AddCell(cell);

               table.AddCell("Col 1 Row 1");

               table.AddCell("Col 2 Row 1");

               table.AddCell("Col 3 Row 1");

               table.AddCell("Col 1 Row 2");

               table.AddCell("Col 2 Row 2");

               table.AddCell("Col 3 Row 2");
           }
           */



    }
}
