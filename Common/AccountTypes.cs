using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class AccountType
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private long? _classId;

        public long? ClassId
        {
            get { return _classId; }
            set
            {
                _classId = value;
                AccountClass = new AccountClass();
            }
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

        public AccountClass AccountClass { get; set; }

        public AccountType(long? classId, string name, string description)
        {
            ClassId = classId;
            Name = name;
            Description = description;
        }

        public AccountType() { }

    }
}
