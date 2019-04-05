using CQRS.Commands;
using CQRS.DataObjects;
using System;

namespace CQRS.CommandHandlers
{
    public class UserCommandsHandler : ICommandHandler<NewUserCommand>
    {
        private readonly Database _database;

        public UserCommandsHandler(Database database)
        {
            _database = database;
        }

        public void Execute(NewUserCommand command)
        {
            _database.Users.Add(new User() {
                Id = command.UserId,
                Name = command.UserName,
                DateCreated = DateTime.Now
            });
        }
    }
}
