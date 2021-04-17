using System;

namespace CustomerApi.Domain
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Age { get; set; }
    }
}
