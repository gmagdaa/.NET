using System;
using System.Text;


namespace Sylabus
{
    class DBTarget : DB
    {
        public override string getData(string code)
        {

            String command = "select Cel from Sylabusy where kod_przed = @kod_przed";
            string result = Database.Instance.getDataBaseData(code, command);

            if (result != "")
                return result;
            else
                return result = "Cel sylabusu nie został zdefiniowany.";
        }
    }
}
