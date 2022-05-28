namespace TestProject
{
    public class Position : IPosition
    {
        /// <summary>
        /// Calling the Object Count Method
        /// </summary>
        /// <param name="obj"> Object type </param>
        public async Task GetCalculate(ISalary obj)
        {
           await obj.CalculateSalary();
        }

        /// <summary>
        /// Select an object based on the employee's position
        /// </summary>        
        /// <param name="item">Selected Employee </param>
        public async Task ChchooseObject(EmployeeStructure item)
        {
            switch (item.Position)
            {
                case 1:
                    {
                        await GetCalculate(new Employee(item));
                        break;
                    }
                case 2:
                    {
                        await GetCalculate(new Manager(item));
                        break;
                    }
                case 3:
                    {
                        await GetCalculate(new Sales(item));
                        break;
                    }
            }
        }
    }
}
