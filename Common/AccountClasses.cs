using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Common;
using System.Windows.Forms;

namespace Common
{
    public class AccountClass
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private Common.AccountClassType _type;

        public Common.AccountClassType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public AccountClass(string name, string description, Common.AccountClassType type)
        {
            Name = name;
            Description = description;
            Type = type;
        }

        public AccountClass() { }

     
            public static void ADD(string Name, string Discription, string Type)
            {
                try
                {
                    var c = new SqlConnection(Common.connectionString);
                    using (SqlConnection conn = new SqlConnection(Common.connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.InsertAccountClasses", conn))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Name", Name);
                            cmd.Parameters.AddWithValue("@Description", Discription);
                            cmd.Parameters.AddWithValue("@Type", Type);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                    }

                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);

                }

            }
        }
    }

    
    
    

