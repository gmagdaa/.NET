using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllabus.DataBase
{
    class Target_dbo
    {
        protected string command;
        protected string result;
        protected string language;


        public string getData(string code, string symbol)
        {
            language = MainWindow.language;

            if (language == "Polski")
            {
                command = "select Cel from Sylabusy where kod_przed = @param and KOD_SYLAB = @param2";
            }
            else if (language == "Angielski")
            {
                command = "select Cel_en from Sylabusy where kod_przed = @param and KOD_SYLAB = @param2";
            }
            result = Database.Instance.getData(code, symbol, command);

            if (result != "")
                return result;
            else
            {
                if (language == "Polski")
                {
                    return result = "Cel sylabusu nie został zdefiniowany.";
                }
                else if (language == "Angielski")
                {
                    return result = "Target syllabus has not been defined.";
                }
                else
                {
                    return result = "Error";
                }
            }
        }

    }
}
