namespace TestProject
{
    /// <summary>
    /// Employee payroll class of Employee status
    /// </summary>
    public class Employee : ISalary
    {
        /// <summary> Employee object </summary>
        private EmployeeStructure _Employee { get; set; }

        public Employee(EmployeeStructure employee)
        {
            _Employee = employee;
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Calculate the salary of an employee of the Employee position
        /// </summary>
        public async Task CalculateSalary()        
        {
            var percent =  YearsOld(_Employee.StartDate) * 3 <= 30 ? 100 + YearsOld(_Employee.StartDate) * 3 : 130;            
            _Employee.Salary =  _Employee.WageRate * (decimal)(percent / 100.0);            
        }
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Completed years of work in the company
        /// </summary>        
        public int YearsOld(DateTime startDate) => DateTime.Now.DayOfYear < startDate.DayOfYear 
            ? (DateTime.Now.Year - startDate.Year) - 1 
            : DateTime.Now.Year - startDate.Year;
    //-----------------------------------------------------------------------------------------------------------------------------

    }
}
