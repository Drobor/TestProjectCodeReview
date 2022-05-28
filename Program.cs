using TestProject;

/// <summary> Date base </summary>
DBConnection DataBase = new DBConnection() ;

/// <summary> list of employees with subordinates </summary>
Dictionary<int, EmployeeStructure> EmployeeStructure = new();

/// <summary> list of all employees </summary>
Dictionary<int, EmployeeStructure> AllEmployees = new();

GetEmployeeStructure();
main();

/// <summary>
/// Start Method
/// </summary>
void main()
{
    Console.WriteLine("Для подсчёта зарплаты сотрудника, введите его Id, для подсчёта зарплаты всех сотрудников, введите - All ");
    var result = Console.ReadLine(); 
    if (int.TryParse(result, out int n))
    {
        CalculateEmployeeSalary(n);
    }
    if(result == "All")
    {
        CalculateAllEmployeeSalary();
    }
    main();
}
//------------------------------------------------------------------------------------------------------------------------------------

/// <summary>
/// a method in which the structure of employees is formed according to the logic of the head - subordinate
/// </summary>
void GetEmployeeStructure()
{
    var employee = DataBase.Employees.ToDictionary(x => x.Id);

    var leader = DataBase.Leaders.ToDictionary(x => x.Id);

    var leaderEmployee = DataBase.LeadersEmployees.ToDictionary(x => x.EmployeesId, x => x.LeadersId);

    foreach (var item in employee)
    {
        AllEmployees.Add(item.Key, new EmployeeStructure()
        {
            Id = item.Key,
            FullName = item.Value.FullName,
            Position = item.Value.Position,
            StartDate = item.Value.StartDate,
            WageRate = item.Value.WageRate,
            Salary = 0,
            Subordinate = new Dictionary<int, EmployeeStructure>()
        });
    }

    foreach (var item in leaderEmployee)
    {
        AllEmployees[item.Value].Subordinate.Add(item.Key, AllEmployees[item.Key]);
    }

    foreach (var item in leader)
    {
        if (!leaderEmployee.ContainsKey(item.Key))
        {
            EmployeeStructure.Add(item.Key, AllEmployees[item.Key]);
        }
    }
    foreach (var item in AllEmployees)
    {
        Console.WriteLine("Id = {0}, Сотрудник = {1}", item.Key, item.Value.FullName);
    }
}
//------------------------------------------------------------------------------------------------------------------------------------

/// <summary>
/// Calculate an employee's salary
/// </summary>
void CalculateEmployeeSalary(int id)
{
    IPosition position = new Position();
    position.ChchooseObject(AllEmployees[id]);

    Console.WriteLine("Зарплата сотрудника - " + AllEmployees[id].FullName + " : " + AllEmployees[id].Salary);
}
//------------------------------------------------------------------------------------------------------------------------------------

/// <summary>
/// Calculate the salary of all employees
/// </summary>
void CalculateAllEmployeeSalary()
{
    IPosition position = new Position();
    foreach (var item in EmployeeStructure)
    {
        position.ChchooseObject(item.Value);
    }
    foreach(var item in AllEmployees)
    {
        Console.WriteLine("Зарплата сотрудника - " + AllEmployees[item.Key].FullName + " : " + AllEmployees[item.Key].Salary);
    }
}



//------------------------------------------------------------------------------------------------------------------------------------
Console.ReadLine();