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
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;

namespace Sylabus
{
    class Syllabus
    {

        DBTitle tit = new DBTitle();
        DBTarget tar = new DBTarget();
        DBRequirement req = new DBRequirement();
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
        List<string> titleList = new List<string>();
        public void show_sylabus(string code)
        {
            //create_syllabus(code);
            string title = tit.getData(code);
            //titleList.Clear();
            titleList.Add(title);
            string target = tar.getData(code);
            string requiment = req.getData(code);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            string syllabus_title = "Sylabus " + code + ".pdf";
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(syllabus_title, FileMode.Create));
            doc.Open();
            Paragraph par_title = new Paragraph(title, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 20));
            doc.Add(par_title);
            String newline = Environment.NewLine;
            Paragraph par_newLine = new Paragraph(newline, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            doc.Add(par_newLine);

            Paragraph par_target = new Paragraph(target, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            doc.Add(par_target);
            doc.Add(par_newLine);

            Paragraph par_requirement = new Paragraph(requirement, FontFactory.GetFont(FontFactory.TIMES_ROMAN, BaseFont.CP1250, 10));
            doc.Add(par_requirement);

            string imagepath = "kwiatek.jpg";
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath);
            doc.Add(gif);

           // show_table();
            //doc.Add(table);
            doc.Close();
        }

        public List<string> createTitle()
        {
            return titleList;
        }

        public string title, target, requirement;
    
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
        } */



       
    }
}
