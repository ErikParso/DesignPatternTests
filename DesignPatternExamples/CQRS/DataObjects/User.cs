using System;

namespace CQRS.DataObjects
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
