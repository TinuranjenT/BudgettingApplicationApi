using BudgettingApplication.DTO;
using BudgettingApplication.Enum;
using BudgettingApplication.Model;

namespace BudgettingApplication
{
    public interface Iservice
    {
        Task<List<Income>> GetAllIncomes();
        Task<List<Income>> GetMonthlyIncome(int userId, Months month);
        Task<List<Income>> GetIncomesByUserId(int userId);
        Task<Income> AddIncome(Income income);
        Task<List<IncomeSummary>> GetMonthlyIncome(int userId);
        Task<List<IncomeSummary>> GetQuarterlyIncome(int userId);
        Task<List<IncomeSummary>> GetHalfYearlyIncome(int userId);
        Task<List<IncomeSummary>> GetAnnualIncome(int userId);


        Task<List<Expense>> GetAllExpenses();
        Task<List<Expense>> GetMonthlyExpense(int userId, Months month);
        Task<List<Expense>> GetExpensesByUserId(int userId);
        Task<Expense> AddExpense(Expense expense);
        Task<List<ExpenseSummary>> GetMonthlyExpense(int userId);
        Task<List<ExpenseSummary>> GetQuarterlyExpense(int userId);
        Task<List<ExpenseSummary>> GetHalfYearlyExpense(int userId);
        Task<List<ExpenseSummary>> GetAnnualExpense(int userId);


        Task<List<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(int id);
        Task AddTransaction(Transaction transaction);


        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User user);

      

       
       


    }
}
