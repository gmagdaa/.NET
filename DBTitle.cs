using System;
using System.Collections.Generic;
using System.Text;


namespace Sylabus
{
    class DBTitle : DB
    {
       // public List<string> titleList = new List<string>();
        public override string getData(string code)
        {
            command = "select Nazwa from Przedmioty where kod_przed = @kod_przed";
            result = Database.Instance.getDataBaseData(code, command);

            if (result != "")
            {
                return result;
            }
            else
                return result = "Tytuł sylabusu nie został zdefiniowany.";
        }


    }
}
