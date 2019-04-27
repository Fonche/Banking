using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace Common
{
    public class Transaction : INotifyPropertyChanged
    {
        private long _id;
        private long? _transactionTypeId;
        private long? _userId;
        private DateTime _entryDate;
        private DateTime _date;
        private string _currency;
        private long? _accountDebitId;
        private long? _accountCreditId;
        private decimal? _amount;
        private decimal? _fee;
        private string _description;
        private Common.TransactionStatus _status;
        private string _statusCode;

        public string StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Common.TransactionStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public long? TransactionTypeId
        {
            get { return _transactionTypeId; }
            set
            {
                _transactionTypeId = value;
                TransactionType = new TransactionType();
                OnPropertyChanged(new PropertyChangedEventArgs("TransactionTypeId"));
            }
        }

        public TransactionType TransactionType { get; set; }

        public long? UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                User = new User();
            }
        }
        public DateTime EntryDate
        {
            get { return _entryDate; }
            set { _entryDate = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Currency
        {
            get { return _currency; }
            set
            {
                _currency = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Currency"));
            }
        }
        public long? AccountDebitId
        {
            get { return _accountDebitId; }
            set
            {
                _accountDebitId = value;
                AccountDebit = new Account();
            }
        }
        public Account AccountDebit { get; set; }

        public long? AccountCreditId
        {
            get { return _accountCreditId; }
            set
            {
                _accountCreditId = value;
                AccountCredit = new Account();
            }
        }
        public Account AccountCredit { get; set; }

        public decimal? Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public decimal? Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public User User { get; set; }

        public Transaction(long? transactionTypeId, long? userId, DateTime entryDate, DateTime date, string currency, long? accountDebitId, long? accountCreditId, decimal amount, decimal fee, string description, Common.TransactionStatus status)
        {
            TransactionTypeId = transactionTypeId;
            UserId = userId;
            EntryDate = entryDate;
            Date = date;
            Currency = currency;
            AccountDebitId = accountDebitId;
            AccountCreditId = accountCreditId;
            Amount = amount;
            Fee = fee;
            Description = description;
            Status = status;
            
        }

        public Transaction() { }


       
        public bool InsertTransaction(out string msg)
        {
            msg = String.Empty;

           
            
            decimal? availableBalance = AccountDebit.CalculateAvailableBalance();

            if (!availableBalance.HasValue)
            {
                msg = "No available balance!";
                return false;
            }
            if (availableBalance < Amount)
            {
                msg = "No enough funds!";
                return false;
            }

            try
            {
                //Create SqlConnection
                using (SqlConnection con = new SqlConnection(Common.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.InsertTransaction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TransactionTypeId", TransactionTypeId);
                        cmd.Parameters.AddWithValue("@UserId", UserId);
                        cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@Currency", Currency);
                        cmd.Parameters.AddWithValue("@AccountIdDebit", AccountDebitId);
                        cmd.Parameters.AddWithValue("@AccountIdCredit", AccountCreditId);
                        cmd.Parameters.AddWithValue("@Fee", Fee);
                        cmd.Parameters.AddWithValue("@Amount", Amount);
                        cmd.Parameters.AddWithValue("@Description", Description);
                     
                        
                    

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                        
                         }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        public static bool CancelTransaction(long? Id, out string msg)
        {
            if (!Id.HasValue)
            {
                msg = "There is no transaction to cancel!";
                return false;
            }

            try
            {
                //Create SqlConnection
                using (SqlConnection con = new SqlConnection(Common.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.CancelTransaction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id.Value);

                        SqlParameter param = cmd.Parameters.Add("@res", SqlDbType.Bit);
                        param.Direction = ParameterDirection.ReturnValue;

                        con.Open();
                        cmd.ExecuteNonQuery();

                        object res = param.Value;

                        if ((int)res == 1)
                        {
                            msg = "Transaction was cancelled!";
                            return true;
                        }
                        else
                        {
                            msg = "Cancel error!";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

    }
}
