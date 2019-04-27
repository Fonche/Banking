using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public class TransactionType
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
        private long? _accountClassDebitId;

        public long? AccountClassDebitId
        {
            get { return _accountClassDebitId; }
            set
            {
                _accountClassDebitId = value;
                AccountClassDebit = new AccountClass();
            }
        }

        public AccountClass AccountClassDebit { get; set; }

        private long? _accountClassCreditId;

        public long? AccountClassCreditId
        {
            get { return _accountClassCreditId; }
            set
            {
                _accountClassCreditId = value;
                AccountClassCredit = new AccountClass();
            }
        }

        public AccountClass AccountClassCredit { get; set; }

        private bool _reflectsAmountOnHold;

        public bool ReflectsAmountOnHold
        {
            get { return _reflectsAmountOnHold; }
            set { _reflectsAmountOnHold = value; }
        }
        private bool _hasFee;

        public bool HasFee
        {
            get { return _hasFee; }
            set { _hasFee = value; }
        }

        public TransactionType(string name, string description, long? accountClassDebitId, long? accountClassCreditId, bool reflectsAmountOnHold, bool hasFee)
        {
            Name = name;
            Description = description;
            AccountClassDebitId = accountClassDebitId;
            AccountClassCreditId = accountClassCreditId;
            ReflectsAmountOnHold = reflectsAmountOnHold;
            HasFee = hasFee;
        }

        public TransactionType() { }




    }
}
