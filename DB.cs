using System;
using System.Text;

namespace Sylabus
{
    public abstract class DB
    {
        protected string command;
        protected string result;

        public virtual string getData(string code)
        {
            command = "";
            string result = Database.Instance.getDataBaseData(code, command);

            if (result != "")
                return result;
            else
                return result = "";
        }


    }
}
