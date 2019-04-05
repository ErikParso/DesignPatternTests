using CQRS.CommandHandlers;
using CQRS.Commands;
using CQRS.Queries;
using CQRS.QueryHandlers;
using CQRS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Database();
            var userQueriesHandler = new UserQueriesHandler(database);
            var userCommandsHandler = new UserCommandsHandler(database);

            IQueryHandler<GetUsersQuery, IEnumerable<UserViewModel>> getUsersQueryHandler = userQueriesHandler;
            IQueryHandler<GetUserQuery, UserViewModel> getUserQueryHandler = userQueriesHandler;
            ICommandHandler<NewUserCommand> newUserCommandHandler = userCommandsHandler;

            Console.WriteLine("insert 10 users using NewUserCommand...");
            foreach (var i in Enumerable.Range(0, 10))
            {
                newUserCommandHandler.Execute(new NewUserCommand()
                {
                    UserName = $"User {i}"
                });
            }

            Console.WriteLine("Getting all users using GetUsersQuery...");
            var users = getUsersQueryHandler.Execute(new GetUsersQuery());
            foreach (var u in users)
            {
                Console.WriteLine(u);
            }

            Console.WriteLine("Getting user using GetUserQuery...");
            var user = getUserQueryHandler.Execute(new GetUserQuery()
            {
                UserId = users.First().Id
            });
            Console.WriteLine(user);

            Console.ReadLine();
        }
    }
}
