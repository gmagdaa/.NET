using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllabus.DataBase
{
    class Effects_dbo
    {
        protected string command;
        protected List<string> effect_list = new List<string>();
        protected string language;


        public List<string> getData(int id)
        {
            language = MainWindow.language;

            if (language == "Polski")
            {
                command = "select Opis from SylabusEfKsz where ID_SYLAB = @param";
            }
            else if (language == "Angielski")
            {
                command = "select Opis_en from SylabusEfKsz where ID_SYLAB = @param";
            }
            effect_list = Database.Instance.getDataList(id, command);

            if (effect_list.Count != 0)
                return effect_list;
            else
            {
                if (language == "Polski")
                {
                    effect_list.Add("Opis sylabusu nie został zdefiniowany.");
                    return effect_list;
                }
                else if (language == "Angielski")
                {
                    effect_list.Add("Effect syllabus has not been defined.");
                    return effect_list;
                }
                else
                {
                    effect_list.Add("Error");
                    return effect_list;
                }
            }

        }
    }
}
