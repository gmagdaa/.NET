using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace Sylabus
{
    class Database
    {

            private static Database instance;

            //protected SqlCommand objSqlCommand;
            // protected SqlConnection conn;
            protected List<string> syllabus_list = new List<string>();
            

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

           /* public void openDatabase()
            {
				SqlConnection(ConfigurationSettings.AppSettings["RamyKwalConnectionString"]))
				conn.Open();
            }  */



          /*  public void closeDatabase()
            {
                conn.Close();
            } */

            public string getDataBaseData(string code, string polecenie)
        {

            string result = "";
            using (var conn = new SqlConnection(ConfigurationSettings.AppSettings["RamyKwalConnectionString"]))
            {
                conn.Open();
                using (var objSqlCommand = new SqlCommand())
                {
                    objSqlCommand.Connection = conn;
                    objSqlCommand.CommandType = CommandType.Text;
                    objSqlCommand.CommandText = polecenie;
                    objSqlCommand.Parameters.Add("@kod_przed", SqlDbType.NVarChar);
                    objSqlCommand.Parameters["@kod_przed"].Value = code;

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
            }

        }


            public List<string> list_syllabuses(String syllabuses)
            {
                String polecenie = "select KOD_PRZED from Przedmioty where KOD_PRZED like @kod_przed";
                using (var conn = new SqlConnection(ConfigurationSettings.AppSettings["RamyKwalConnectionString"]))
                {
                    conn.Open();
                    using (var objSqlCommand = new SqlCommand())
                    {
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

     
        



    }
}
