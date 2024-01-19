using BudgettingApplication.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgettingApplication.Model
{
    public class Income
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TransactionName { get; set; }
        public double Amount { get; set; }
        public  Months TransactionMonth { get; set; }

    }
}
