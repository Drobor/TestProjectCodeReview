namespace TestProject
{
    internal interface IPosition
    {
        /// <summary>
        /// call the employee payroll method Obj
        /// </summary>
        /// <param name="obj">Employee</param>        
        public Task GetCalculate(ISalary obj);
    //-----------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Select an employee's position for calculation
        /// </summary>
        /// <param name="item">Employee</param>        
        public Task ChchooseObject(EmployeeStructure item);
    //-----------------------------------------------------------------------------------------------------------------------------
   
    }
}
