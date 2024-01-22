My task is to create a basic budgetting web application and I have developed the API endpoints for adding and retrieving transactions.
If the Transaction type is income, the income has is added for the particular month and if it is an expense, then the expense is added for the particular month. 
Additionally I have implemented Api's to retrieve the total income, total expenses and grouped income and expenses for Monthly, Quarterly, Half-yearly and Yearly basis. 
Furthermore I have integrated it with the database in SQL Server Management Studio.

List of API's:

1.api/Expense/GetAllExpenses
2.api/Expense/GetSpecificMonthExpenseById?userId={}&month={}
3.api/Expense/GetExpensesByUserId/{userId}
4.api/Expense/AddExpense
5.api/Expense/GetMonthlyExpense/{userId}
6.api/Expense/GetQuarterlyExpense/{userId}
7.api/Expense/GetHalfYearlyExpense/{userId}
8.api/Expense/GetAnnualExpense/{userId}

9.api/Income/GetAllIncome
10.api/Income/GetSpecificMonthIncomeeById?userId={}&month={}
11.api/Income/GetIncomesByUserId/{userId}
12.api/Income/AddNewIncome
13.api/Income/GetMonthlyIncome/{userId}
14.api/Income/GetQuarterlyIncome/{userId}
15.api/Income/GetHalfYearlyIncome/{userId}
16.api/Income/GetAnnualIncome/{userId}

17.api/Transaction/GetAllTransaction
18.api/Transaction/GetAllTransactionById{id}
19.api/Transaction/AddNewTransaction

20.api/User/GetAllUsers
21.api/User/AddNewUser





