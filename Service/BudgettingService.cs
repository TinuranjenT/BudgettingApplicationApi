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
            try
            {
                return await databaseContext.Incomes.ToListAsync();
            }
            catch (Exception ex)
            { 
                throw new Exception("An error occurred while fetching all incomes.", ex);
            }
        }
        public async Task<List<Income>> GetMonthlyIncome(int userId, Months month)
        {
            try
            {
                return await databaseContext.Incomes.Where(i => i.UserId == userId && i.TransactionMonth == month).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching monthly incomes.", ex);
            }
        }

        public async Task<List<Income>> GetIncomesByUserId(int userId)
        {
            try
            {
                return await databaseContext.Incomes.Where(i => i.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching incomes by user ID.", ex);
            }
        }
        public async Task<Income> AddIncome(Income income)
        {
            try
            {
                databaseContext.Incomes.Add(income);
                await databaseContext.SaveChangesAsync();
                return income;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding an income.", ex);
            }
        }

        public async Task<List<IncomeSummary>> GetMonthlyIncome(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching monthly income summaries.", ex);
            }
        }

        public async Task<List<IncomeSummary>> GetQuarterlyIncome(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching quarterly income summaries.", ex);
            }
        }

        public async Task<List<IncomeSummary>> GetHalfYearlyIncome(int userId)
        {
            try
            {
                var halfYearlyIncomes = await databaseContext.Incomes
               .Where(i => i.UserId == userId)
               .ToListAsync();  

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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching quarterly income summaries.", ex);
            }
        }

        public async Task<List<IncomeSummary>> GetAnnualIncome(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching annual income summaries.", ex);
            }
        }
        public async Task<List<Expense>> GetAllExpenses()
        {
            try
            {
                return await databaseContext.Expenses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching all expenses.", ex);
            }
        }

        public async Task<List<Expense>> GetMonthlyExpense(int userId, Months month)
        {
            try
            {
                return await databaseContext.Expenses
                   .Where(i => i.UserId == userId && i.TransactionMonth == month)
                   .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching monthly expenses.", ex);
            }
        }
        public async Task<List<Expense>> GetExpensesByUserId(int userId)
        {
            try
            {
                return await databaseContext.Expenses
                    .Where(i => i.UserId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching expenses by user ID.", ex);
            }
        }
        public async Task<Expense> AddExpense(Expense expense)
        {
            try
            {
                databaseContext.Expenses.Add(expense);
                await databaseContext.SaveChangesAsync();
                return expense;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding an expense.", ex);
            }
        }

        public async Task<List<ExpenseSummary>> GetMonthlyExpense(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching monthly expense summaries.", ex);
            }
        }
        public async Task<List<ExpenseSummary>> GetQuarterlyExpense(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching quarterly expense summaries.", ex);
            }
        }
        public async Task<List<ExpenseSummary>> GetHalfYearlyExpense(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching half-yearly expense summaries.", ex);
            }
        }
        public async Task<List<ExpenseSummary>> GetAnnualExpense(int userId)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching annual expense summaries.", ex);
            }
        }
        public async Task<List<Transaction>> GetAllTransactions()
        {
            try
            {
                return await databaseContext.Transactions.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching all transactions.", ex);
            }
        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            try
            {
                return await databaseContext.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching transaction with ID {id}.", ex);
            }
        }

        public async Task AddTransaction(Transaction transaction)
        {
            try
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
                   .FirstOrDefaultAsync(i => i.UserId == transaction.UserId &&
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
                   throw new Exception("Invalid transaction type");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding a transaction.", ex);
            }
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await databaseContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching all users.", ex);
            }
        }
        public async Task<User> AddUser(User user)
        {
            try
            {
                databaseContext.Users.Add(user);
                await databaseContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding a user.", ex);
            }
        }
    }
}
