using Microsoft.EntityFrameworkCore;

namespace TestProject
{
    /// <summary>
    /// Class, with structure: employee - manager
    /// </summary>
    [Keyless]
    public class LeadersEmployees
    {
        /// <summary> Employee ID </summary>
        public int EmployeesId { get; set; }

        /// <summary> Leaders ID </summary>
        public int LeadersId { get; set; }
    }
}
