using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public class Account
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private long? _typeId;

        public long? TypeId
        {
            get { return _typeId; }
            set
            {
                _typeId = value;
                AccountType = new AccountType();
            }
        }

        public AccountType AccountType { get; set; }

        private string _accountNumber;

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        private string _currency;

        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        private long? _clientId;

        public long? ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId = value;
                Client = new Client();
            }
        }

        public Client Client { get; set; }

        private Common.AccountStatus? _status;

        public Common.AccountStatus? Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private bool _blocked;

        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }
        private decimal? _balance;

        public decimal? Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        private decimal? _overdraftLimit;

        public decimal? OverdraftLimit
        {
            get { return _overdraftLimit; }
            set { _overdraftLimit = value; }
        }
        private decimal? _amountOnHold;

        public decimal? AmountOnHold
        {
            get { return _amountOnHold; }
            set { _amountOnHold = value; }
        }

        public Account(long? typeId, string accountNumber, string currency, long? clientId, Common.AccountStatus? status, bool blocked, decimal? balance, decimal? overdraftLimit, decimal? amountOnHold)
        {
            TypeId = typeId;
            AccountNumber = accountNumber;
            Currency = currency;
            ClientId = clientId;
            Status = status;
            Blocked = blocked;
            Balance = balance;
            OverdraftLimit = overdraftLimit;
            AmountOnHold = amountOnHold;
        }

        public Account() { }

        public decimal? CalculateAvailableBalance()
        {
            decimal? availableBalance = null;

            if (Balance.HasValue && OverdraftLimit.HasValue && AmountOnHold.HasValue)
                availableBalance = Balance.Value + OverdraftLimit.Value - AmountOnHold.Value;

            return availableBalance;
        }

        
    }
}
