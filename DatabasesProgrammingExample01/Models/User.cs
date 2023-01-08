using Microsoft.EntityFrameworkCore;

namespace DatabasesProgrammingExample01.Models
{
    [Owned]
    public class User
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }

}
