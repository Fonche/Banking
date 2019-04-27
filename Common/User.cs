using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Common

{
    public class User
    {
        private long _id;
        public long Id { get { return _id; } set { _id = value; } }

        private string _name;
        public string Name { get; set; }

        private string _username;
        public string Username { get; set; }

        private string _password;
        public string Password { get; set; }

        private long? _cashAccountId;
        public long? CashAccountId { get; set; }

        private long? _cliendId;
        public long? ClientId { get { return _cliendId; } set { _cliendId = value; Client = new Client(); } }

        public Client Client { get; set; }

        public User() { }

        public User(string name, string username, string password, long? cashaccId, long? clientId)
        {
            Name = name;
            Username = username;
            Password = password;
            CashAccountId = cashaccId;
            ClientId = clientId;
        }

        public static bool checkLogin(String username, String password, out string msg )
        {
            msg = String.Empty;
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                msg = "Invalid username or password";
               
                return false;
            }
            try
            {
                 
                using (SqlConnection conn = new SqlConnection(Common.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.CheckLogin1", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.Add("@ADMIN", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;

                        SqlParameter param = new SqlParameter("@res", SqlDbType.Bit);
                        param.Direction = ParameterDirection.ReturnValue;
                 
                        cmd.Parameters.Add(param);
                        cmd.Parameters.Add("@userId", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        object res = param.Value;
                        Console.WriteLine((int)res);
                        if ((int)res == 1)
                        {
                            long userId = Convert.ToInt64(cmd.Parameters["@userId"].Value);
                            Common.currentUserId = userId;
                            Common.role = cmd.Parameters["@ADMIN"].Value.ToString();
                            Console.WriteLine("USER ID: " + userId);

                            MessageBox.Show ( "Login vo red");
                            return true;
                        }
                        else MessageBox.Show("Login Failed");
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public static void AddUser(String Name, String UserName, String Password, String CashAccountId, String ClientId,String role)
        {
            try {
                var c = new SqlConnection(Common.connectionString);
                using (SqlConnection conn = new SqlConnection(Common.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.InsertUser", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@CashAccountId", CashAccountId);
                        cmd.Parameters.AddWithValue("@ClientId", ClientId);
                        cmd.Parameters.AddWithValue("@Role", role);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            

            }


        public static string PassHasCod (String data)
        {
            SHA1 sha = SHA1.Create();
            byte[] hashdata = sha.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder returnValue = new StringBuilder();

            for (int i=0; i< hashdata.Length; i++)
            {
                returnValue.Append(hashdata[i].ToString());


            }
            return returnValue.ToString();
        }


    }
}
