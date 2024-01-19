using BudgettingApplication.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgettingApplication.Model
{ 
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public Months TransactionMonth { get; set; }

    }
}
