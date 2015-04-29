using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllabus.DataBase
{
    class Requirements_dbo
    {

        protected string result;
        protected string command;
        protected string language;

        public string getData(string code, string symbol)
        {
            language = MainWindow.language;

            if (language == "Polski")
            {
                command = "select Wymagania_wstepne from Sylabusy where KOD_PRZED = @param and KOD_SYLAB = @param2";
            }
            else if (language == "Angielski")
            {
                command = "select Wymagania_wstepne_en from Sylabusy where KOD_PRZED = @param and KOD_SYLAB = @param2";
            }
            result = Database.Instance.getData(code, symbol, command);

            if (result != "")
                return result;
            else
            {
                if (language == "Polski")
                {
                    return result = "Wymagania sylabusu nie zostały zdefiniowane.";
                }
                else if (language == "Angielski")
                {
                    return result = "Requirement syllabus has not been defined.";
                }
                else
                {
                    return result = "Error";
                }
            }
        }


    }
}
