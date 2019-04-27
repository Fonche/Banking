using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common;
using System.Data;

namespace Common
{
    public class Client
    {
        private String _name;
        public String Name { get; set; }

        private long _id;
        public long Id { get; set; }

        private Common.ClientType _type;
        public Common.ClientType Type;

        private String _identificationNumber;
        public String IdentificationNumber { get; set; }

        private String _address;
        public String Address { get; set; }

        private String _tel;
        public String Tel { get; set; }

        private String _mob;
        public String Mob { get; set; }

        private String _web;
        public String Web { get; set; }

        public Client()
        {

        }

        public Client(String name, Common.ClientType type, String idenNumber, String address, String tel, String mob, String web)
        {
            Name = name;
            Type = type;
            IdentificationNumber = idenNumber;
            Address = address;
            Tel = tel;
            Mob = mob;
            Web = web;
        }


      


    }
}
