using BudgettingApplication.Data;
using BudgettingApplication.DTO;
using BudgettingApplication.Enum;
using BudgettingApplication.Model;
using Microsoft.EntityFrameworkCore;


namespace BudgettingApplication.Service
{
    public class BudgettingService : Iservice
    {
        private readonly DatabaseContext databaseContext;

        public BudgettingService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Income>> GetAllIncomes()
        {
            return await databaseContext.Incomes.ToListAsync();
        }
        public async Task<IEnumerable<Income>> GetMonthlyIncome(int userId, Months month)
        {
            return await databaseContext.Incomes
            .Where(i => i.UserId == userId && i.TransactionMonth == month)
            .ToListAsync();
        }

        public async Task<List<Income>> GetIncomesByUserId(int userId)
        {
            return await databaseContext.Incomes
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }
        public async Task<Income> AddIncome(Income income)
        {
            databaseContext.Incomes.Add(income);
            await databaseContext.SaveChangesAsync();
            return income;
        }

        public async Task<IEnumerable<IncomeSummary>> GetMonthlyIncome(int userId)
        {
            var monthlyIncomes = await databaseContext.Incomes
            .Where(i => i.UserId == userId)
            .ToListAsync();

            var groupedIncomes = monthlyIncomes
                .GroupBy(i => i.TransactionMonth)
                .OrderBy(group => group.Key)
                .Select(group => new IncomeSummary
                {
                    Period = ((Months)group.Key).ToString(),
                    TotalIncome = group.Sum(i => i.Amount)
                })
                .ToList();
            return groupedIncomes;
        }

        public async Task<IEnumerable<IncomeSummary>> GetQuarterlyIncome(int userId)
        {
            var quarterlyIncomes = await databaseContext.Incomes
           .Where(i => i.UserId == userId)
           .ToListAsync();

            var groupedIncomes = quarterlyIncomes
                .GroupBy(i => ((int)i.TransactionMonth - 1) / 3 + 1)
                .Select(group => new IncomeSummary
                {
                    Period = $"Q{group.Key}",
                    TotalIncome = group.Sum(i => i.Amount)
                })
                .OrderBy(incomeSummary => incomeSummary.Period)
                .ToList();

            return groupedIncomes;
        }

        public async Task<IEnumerable<IncomeSummary>> GetHalfYearlyIncome(int userId)
        {
            var halfYearlyIncomes = await databaseContext.Incomes
           .Where(i => i.UserId == userId)
           .ToListAsync();  // Fetch all data into memory

            var groupedIncomes = halfYearlyIncomes
                .GroupBy(i => (((int)i.TransactionMonth - 1) / 6) + 1)
                .Select(group => new IncomeSummary
                {
                    Period = $"H{group.Key}",
                    TotalIncome = group.Sum(i => i.Amount)
                })
                .OrderBy(incomeSummary => incomeSummary.Period)
                .ToList();
            return groupedIncomes;

        }

        public async Task<IEnumerable<IncomeSummary>> GetAnnualIncome(int userId)
        {
            var annualIncomes = await databaseContext.Incomes
                .Where(i => i.UserId == userId)
                .GroupBy(i => 1)
                .Select(group => new IncomeSummary
                {
                    Period = "Annual",
                    TotalIncome = group.Sum(i => i.Amount)
                })
                .ToListAsync();
            return annualIncomes;
        }


        public async Task<List<Expense>> GetAllExpenses()
        {
            return await databaseContext.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetMonthlyExpense(int userId, Months month)
        {
            return await databaseContext.Expenses
            .Where(i => i.UserId == userId && i.TransactionMonth == month)
            .ToListAsync();
        }
        public async Task<List<Expense>> GetExpensesByUserId(int userId)
        {
            return await databaseContext.Expenses
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<Expense> AddExpense(Expense expense)
        {
            databaseContext.Expenses.Add(expense);
            await databaseContext.SaveChangesAsync();
            return expense;

        }
        public async Task<IEnumerable<ExpenseSummary>> GetMonthlyExpense(int userId)
        {
            var monthlyExpense = await databaseContext.Expenses
            .Where(i => i.UserId == userId)
            .ToListAsync();

            var groupedExpenses = monthlyExpense
                .GroupBy(i => i.TransactionMonth)
                .OrderBy(group => group.Key)
                .Select(group => new ExpenseSummary
                {
                    Period = ((Months)group.Key).ToString(),
                    TotalExpense = group.Sum(i => i.Amount)
                })
                .ToList();
            return groupedExpenses;
        }

        public async Task<IEnumerable<ExpenseSummary>> GetQuarterlyExpense(int userId)
        {
            var quarterlyExpenses = await databaseContext.Expenses
           .Where(i => i.UserId == userId)
           .ToListAsync();

            var groupedExpenses = quarterlyExpenses
                .GroupBy(i => ((int)i.TransactionMonth - 1) / 3 + 1)
                .Select(group => new ExpenseSummary
                {
                    Period = $"Q{group.Key}",
                    TotalExpense = group.Sum(i => i.Amount)
                })
                .OrderBy(incomeSummary => incomeSummary.Period)
                .ToList();
            return groupedExpenses;
        }

        public async Task<IEnumerable<ExpenseSummary>> GetHalfYearlyExpense(int userId)
        {
            var halfYearlyExpenses = await databaseContext.Expenses
           .Where(i => i.UserId == userId)
           .ToListAsync();

            var groupedExpenses = halfYearlyExpenses
                .GroupBy(i => (((int)i.TransactionMonth - 1) / 6) + 1)
                .Select(group => new ExpenseSummary
                {
                    Period = $"H{group.Key}",
                    TotalExpense = group.Sum(i => i.Amount)
                })
                .OrderBy(incomeSummary => incomeSummary.Period)
                .ToList();
            return groupedExpenses;

        }

        public async Task<IEnumerable<ExpenseSummary>> GetAnnualExpense(int userId)
        {
            var annualExpenses = await databaseContext.Expenses
                .Where(i => i.UserId == userId)
                .GroupBy(i => 1)
                .Select(group => new ExpenseSummary
                {
                    Period = "Annual",
                    TotalExpense = group.Sum(i => i.Amount)
                })
                .ToListAsync();

            return annualExpenses;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await databaseContext.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await databaseContext.Transactions.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTransaction(Transaction transaction)
        {
            var newTransaction = new Transaction
            {
                Name = transaction.Name,
                Amount = transaction.Amount,
                UserId = transaction.UserId,
                TransactionMonth = transaction.TransactionMonth,
                Type = transaction.Type
            };
            databaseContext.Transactions.Add(newTransaction);
            await databaseContext.SaveChangesAsync();

            if (transaction.Type == TransactionType.Income)
            {
                var existingIncome = await databaseContext.Incomes
        .       FirstOrDefaultAsync(i => i.UserId == transaction.UserId &&
                                      i.TransactionName == transaction.Name &&
                                      i.TransactionMonth == transaction.TransactionMonth);
                if (existingIncome != null)
                {
                    existingIncome.Amount += transaction.Amount;
                }
                else
                {
                    var income = new Income
                    {
                        TransactionName = transaction.Name,
                        Amount = transaction.Amount,
                        UserId = transaction.UserId,
                        TransactionMonth = transaction.TransactionMonth,
                    };
                    databaseContext.Incomes.Add(income);
                }
                await databaseContext.SaveChangesAsync();

            }
            else if (transaction.Type == TransactionType.Expense)
            {
                var existingExpense = await databaseContext.Expenses
                .FirstOrDefaultAsync(i => i.UserId == transaction.UserId &&
                                      i.TransactionName == transaction.Name &&
                                      i.TransactionMonth == transaction.TransactionMonth);
                if (existingExpense != null)
                {
                    existingExpense.Amount += transaction.Amount;
                }
                else
                {
                    var expense = new Expense
                    {
                        TransactionName = transaction.Name,
                        Amount = transaction.Amount,
                        UserId = transaction.UserId,
                        TransactionMonth = transaction.TransactionMonth
                    };

                    databaseContext.Expenses.Add(expense);
                }
               
                await databaseContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Invalid transaction type", nameof(transaction.Type));
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await databaseContext.Users.ToListAsync();
        }
        public async Task<User> AddUser(User user)
        {
            databaseContext.Users.Add(user);
            await databaseContext.SaveChangesAsync();
            return user;

        }

       


        




    }
}
