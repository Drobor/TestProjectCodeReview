namespace TestProject
{
    /// <summary>
    ///Payroll class of an employee of the Sales position
    /// </summary>
    public class Sales : ISalary
    {
        /// <summary> Employee object  </summary>
        private EmployeeStructure _Employee { get; set; }

        public Sales(EmployeeStructure employee)
        {
            _Employee = employee;
        }

        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary> 
        /// Calculate the salary of an employee of the position Sales
        /// </summary>
        public async Task CalculateSalary()
        {
            var childList = GetChildElements(_Employee);
            CalculateSalarySubordinates(childList);
            var bonus = PercentFromSubordinates(childList);
            var percent = YearsOld(_Employee.StartDate) * 1 <= 35 ? 100 + YearsOld(_Employee.StartDate) * 1 : 135;
            _Employee.Salary = _Employee.WageRate * (decimal)(percent / 100.0) +bonus; 
        }
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Calculate the salary of subordinates of all positions
        /// </summary>
        /// <param name="childList"> list of subordinates </param>
        private void CalculateSalarySubordinates(List<EmployeeStructure> childList)
        {
            IPosition position = new Position();
            foreach (var item in childList)
            {
                if (item.Salary != 0) continue;
                position.ChchooseObject(item);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sum up the salary of subordinates of all positions and calculate the percentage of their salary
        /// </summary>
        /// <param name="childList">list of subordinates</param>       
        private decimal PercentFromSubordinates(List<EmployeeStructure> childList) 
            => childList.Sum(x => x.Salary) / 100 * Convert.ToDecimal(0.3);
        //-----------------------------------------------------------------------------------------------------------------------------   

        /// <summary>
        /// Get a list of subordinates of all positions 
        /// </summary>
        /// <param name="employee"> original employee </param>        
        private List<EmployeeStructure> GetChildElements(EmployeeStructure employee)
        {
            List<EmployeeStructure> list = new();
            if (employee.Subordinate.Any())
            {
                foreach (var x in employee.Subordinate)
                {
                    var result = GetChildElements(x.Value);
                    result.ForEach(x => list.Add(x));
                }
            }
            if (employee.Id != _Employee.Id)
            {
                list.Add(employee);
            }

            return list;                      
        }
        //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Completed years of work in the company
        /// </summary>       
        private int YearsOld(DateTime startDate) => DateTime.Now.DayOfYear < startDate.DayOfYear
            ? (DateTime.Now.Year - startDate.Year) - 1
            : DateTime.Now.Year - startDate.Year;
    //-----------------------------------------------------------------------------------------------------------------------------

    }
}
