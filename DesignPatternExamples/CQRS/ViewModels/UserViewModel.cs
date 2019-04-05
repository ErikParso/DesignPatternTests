using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public DateTime DateCreated { get; set; }

        public override string ToString()
            => $"{Id} : {UserName} ({DateCreated})";
    }
}
