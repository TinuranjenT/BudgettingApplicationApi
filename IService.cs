using BudgettingApplication.DTO;
using BudgettingApplication.Enum;
using BudgettingApplication.Model;

namespace BudgettingApplication
{
    public interface Iservice
    {
        Task<List<Income>> GetAllIncomes();
        Task<IEnumerable<Income>> GetMonthlyIncome(int userId, Months month);
        Task<List<Income>> GetIncomesByUserId(int userId);
        Task<Income> AddIncome(Income income);
        Task<Expense> AddExpense(Expense expense);
        Task<List<Expense>> GetExpensesByUserId(int userId);
        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(int id);
        Task AddTransaction(Transaction transaction);
        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User user);

       
        Task<IEnumerable<IncomeSummary>> GetMonthlyIncome(int userId);

        Task<IEnumerable<IncomeSummary>> GetQuarterlyIncome(int userId);
        Task<IEnumerable<IncomeSummary>> GetHalfYearlyIncome(int userId);
        Task<IEnumerable<IncomeSummary>> GetAnnualIncome(int userId);

        Task<List<Expense>> GetAllExpenses();
        Task<IEnumerable<Expense>> GetMonthlyExpense(int userId,  Months month);

        Task<IEnumerable<ExpenseSummary>> GetMonthlyExpense(int userId);
        Task<IEnumerable<ExpenseSummary>> GetQuarterlyExpense(int userId);
        Task<IEnumerable<ExpenseSummary>> GetHalfYearlyExpense(int userId);
        Task<IEnumerable<ExpenseSummary>> GetAnnualExpense(int userId);


    }
}
