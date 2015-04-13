using System;
using System.Text;


namespace Sylabus
{
    class DBRequirement : DB
    {
        public override string getData(string code)
        {

            String command = "select Wymagania_wstepne from Sylabusy where kod_przed = @kod_przed";
            string result = Database.Instance.getDataBaseData(code, command);

            if (result != "")
                return result;
            else
                return result = "Wymagania wstępne sylabusu nie został zdefiniowane.";
        }
    }
}
