using System.Collections.Generic;

namespace Core.Business
{
    public class RequestUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public List<string> Roles { get; set; }
    }
}