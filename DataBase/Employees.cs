namespace TestProject
{
    /// <summary>
    /// Class employees (all employees of the company)
    /// </summary>
    public class Employees
    {
        /// <summary> Employee ID </summary>
        public int Id { get; set; }

        /// <summary> Full name of the employee (Last name, First name, Patronymic) </summary>
        public string FullName { get; set; }

        /// <summary> Date of entry the company  </summary>
        public DateTime StartDate { get; set; }

        /// <summary> Employee status ( Employee - 1, Manager - 2, Sales - 3)  </summary>
        public int Position { get; set; }

        /// <summary>  basic wage rate for employee  </summary>        
        public Decimal WageRate { get; set; }
    }
}
