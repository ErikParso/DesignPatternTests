using System;

namespace CQRS.Commands
{
    public class NewUserCommand : ICommand
    {
        public NewUserCommand()
        {
            UserId = Guid.NewGuid();
        }

        public Guid UserId { get; private set; }
        public string UserName { get; set; }
    }

}
