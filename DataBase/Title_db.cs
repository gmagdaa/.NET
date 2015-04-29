using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllabus.DataBase
{
    class Title_dbo
    {
        protected string command;
        protected string result;
        protected string language;


        public string getData(string code, string symbol)
        {
            language = MainWindow.language;

            if (language == "Polski")
            {
                command = "select Nazwa from Przedmioty where kod_przed = @param";
            }
            else if (language == "Angielski")
            {
                command = "select Nazwa_eng from Przedmioty where kod_przed = @param";
            }
            result = Database.Instance.getData(code, symbol, command);

            if (result != "")
                return result;
            else
            {
                if (language == "Polski")
                {
                    return result = "Tytuł sylabusu nie został zdefiniowany.";
                }
                else if (language == "Angielski")
                {
                    return result = "Title syllabus has not been defined.";
                }
                else
                {
                    return result = "Error";
                }
            }
        }
    }
}

