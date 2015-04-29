using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syllabus
{
    class Database
    {
        private static Database instance;

        protected SqlCommand objSqlCommand;
        protected SqlConnection conn;
        protected List<string> syllabus_list = new List<string>();
        protected List<string> combobox = new List<string>();

        private Database() { }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        public void openDatabase()
        {
            conn = new SqlConnection(ConfigurationSettings.AppSettings["RamyKwalConnectionString"]);
            conn.Open();
        }


        public void closeDatabase()
        {
            conn.Close();
        }

        public string getData(string code, string symbol, string command)
        {
            string result = "";

            objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = conn;
            objSqlCommand.CommandType = CommandType.Text;
            objSqlCommand.CommandText = command;
            objSqlCommand.Parameters.Add("@param", SqlDbType.NVarChar);
            objSqlCommand.Parameters["@param"].Value = code;
            objSqlCommand.Parameters.Add("@param2", SqlDbType.NVarChar);
            objSqlCommand.Parameters["@param2"].Value = symbol;

            SqlDataReader reader = objSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    result = reader.GetString(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            reader.Close();

            return result;

        }

        public string getDataString(int id, string command)
        {
            string result = "";

            objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = conn;
            objSqlCommand.CommandType = CommandType.Text;
            objSqlCommand.CommandText = command;
            objSqlCommand.Parameters.Add("@param", SqlDbType.Int);
            objSqlCommand.Parameters["@param"].Value = id;

            SqlDataReader reader = objSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    result = reader.GetString(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            reader.Close();

            return result;

        }

        protected List<string> string_list = new List<string>();

        public List<string> getDataList(int id, string command)
        {
            string_list.Clear();
            objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = conn;
            objSqlCommand.CommandType = CommandType.Text;
            objSqlCommand.CommandText = command;
            objSqlCommand.Parameters.Add("@param", SqlDbType.NVarChar);
            objSqlCommand.Parameters["@param"].Value = id;

            SqlDataReader reader = objSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    string_list.Add(reader.GetString(0));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            reader.Close();

            return string_list;

        }

        protected int id;
        public int get_id(string code, string symbol)
        {
            string command = "select ID_SYLAB from [dbo].[Sylabusy] where KOD_PRZED = @param and KOD_SYLAB = @param2";
            objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = conn;
            objSqlCommand.CommandType = CommandType.Text;
            objSqlCommand.CommandText = command;
            objSqlCommand.Parameters.Add("@param", SqlDbType.NVarChar);
            objSqlCommand.Parameters["@param"].Value = code;
            objSqlCommand.Parameters.Add("@param2", SqlDbType.NVarChar);
            objSqlCommand.Parameters["@param2"].Value = symbol;
            SqlDataReader reader = objSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    id = Convert.ToInt32(reader.GetValue(0));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            reader.Close();

            if (id != null)
                return id;
            else
                return id = 0;

        }

        public List<string> get_code()
        {

            string command = "select kod_przed from Przedmioty";
            objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = conn;
            objSqlCommand.CommandType = CommandType.Text;
            objSqlCommand.CommandText = command;
            SqlDataReader reader = objSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(0);

                combobox.Add(name);
                

            }
            reader.Close();
            return combobox;
        }


        public List<string> list_syllabuses(String syllabuses)
        {
            String polecenie = "select KOD_PRZED from Przedmioty where KOD_PRZED like @kod_przed";
            objSqlCommand = new SqlCommand();
            objSqlCommand.Connection = conn;
            objSqlCommand.CommandType = CommandType.Text;
            objSqlCommand.CommandText = polecenie;
            objSqlCommand.Parameters.Add("@kod_przed", SqlDbType.NVarChar);
            objSqlCommand.Parameters["@kod_przed"].Value = syllabuses;
            SqlDataReader reader = objSqlCommand.ExecuteReader();

            while (reader.Read())
            {
                syllabus_list.Add(reader.GetString(0));

            }
            reader.Close();
            return syllabus_list;
        }
    }
}
