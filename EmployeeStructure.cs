namespace TestProject
{
    /// <summary>
    /// Class describing the structure of the employee model 
    /// </summary>
    public class EmployeeStructure
    {
        /// <summary> Employee ID </summary>
        public int Id { get; set; }

        /// <summary> Full name of the employee (Last name, First name, Patronymic) </summary>
        public string FullName { get; set; }

        /// <summary> Date of entry the company  </summary>
        public DateTime StartDate { get; set; }

        /// <summary> Employee status ( Employee - 1, Manager - 2, Sales - 3) </summary>
        public int Position { get; set; }

        /// <summary>  Basic wage rate for employee  </summary>        
        public Decimal WageRate { get; set; }

        /// <summary> employee's subordinates</summary>
        public Dictionary<int, EmployeeStructure> Subordinate { get; set; }

        /// <summary> employee's total salary </summary>
        public Decimal Salary   { get; set; }


    }
}
