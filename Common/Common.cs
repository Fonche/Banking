using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Common
    {
        public static long? currentUserId;

        public static string role;

        public static long accountId;
        public static string accNumber;
        public static long cliendId;
        public static string status;
        public static int blocked;
        public static decimal balance;
        public static decimal amountOnHold;
        public static decimal avBalance;

      
     //   public const string connectionString = "Data Source=10.200.86.25;Initial Catalog=LT-10;User ID=LT-10;Password=LT-10P@ssw0rd";
       public const string connectionString = @"Data Source=DESKTOP-OTL7OL2;Initial Catalog=Praksa;Integrated Security=True";
        
        public enum ClientType
        {
            Individual=0,
            Organization=1
        }

   
            
   

    public enum AccountClassType
    {
        CashAccount = 1,
        CurrentAccount = 2,
        DepositAccount = 3,
        CreditAccount = 4
    }

    public enum TransactionStatus
    {
        Active = 'A',
        Cancelled = 'C'
    }

    public enum AccountStatus
    {
        Active = 'A',
        Closed = 'C',
        Opened = 'O'
    }

    public enum PostingEntryType
    {
        Debit = -1,
        Credit = 1,
        Nonfinancial = 0
    }

    public enum Operation
    {
        Equal,
        GreatherThan,
        GreatherThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Between,
        In,
        Like,
        StartsWith,
        EndsWith,
        Contains,
        NotEqual
    }

    public enum CommandType
    {
        New,
        Modify,
        Preview,
        Cancel
    }


    }
}
