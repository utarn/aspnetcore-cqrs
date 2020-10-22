using System;

namespace aspnetcore_cqrs.Data
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}