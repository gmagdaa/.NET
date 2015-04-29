using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllabus.DataBase
{

    class Literature_dbo
    {
        protected string command;
        protected string result;
        protected string language;


        public string getData(int id)
        {
            language = MainWindow.language;

            if (language == "Polski")
            {
                command = "select Literatura from Sylabusy where id_sylab = @param";
            }
            else if (language == "Angielski")
            {
                command = "select Literatura_en from Sylabusy where id_sylab = @param";
            }
            result = Database.Instance.getDataString(id, command);

            if (result != "")
                return result;
            else
            {
                if (language == "Polski")
                {
                    return result = "Literatura sylabusu nie została zdefiniowana.";
                }
                else if (language == "Angielski")
                {
                    return result = "Litearture syllabus has not been defined.";
                }
                else
                {
                    return result = "Error";
                }
            }
        }
    }
}
