using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllabus.DataBase
{
    class Contents_dbo
    {
        protected string command;
        protected List<string> content_list = new List<string>();
        protected string language;

        public List<string> getData(int id)
        {
            language = MainWindow.language;

            if (language == "Polski")
            {
                command = "select Tresc from SylabusTresci where ID_SYLAB = @param";
            }
            else if (language == "Angielski")
            {
                command = "select Tresc_eng from SylabusTresci where ID_SYLAB = @param";
            }
            content_list = Database.Instance.getDataList(id, command);

            if (content_list.Count != 0)
                return content_list;
            else
            {
                if (language == "Polski")
                {
                    content_list.Add("Treść sylabusu nie została zdefiniowana.");
                    return content_list;
                }
                else if (language == "Angielski")
                {
                    content_list.Add("Content syllabus has not been defined.");
                    return content_list;
                }
                else
                {
                    content_list.Add("Error");
                    return content_list;
                }
            }

        }
    }
    }
