using CQRS.Queries;
using CQRS.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.QueryHandlers
{
    public class UserQueriesHandler :
        IQueryHandler<GetUserQuery, UserViewModel>,
        IQueryHandler<GetUsersQuery, IEnumerable<UserViewModel>>
    {
        private readonly Database _database;

        public UserQueriesHandler(Database database)
        {
            _database = database;
        }

        public UserViewModel Execute(GetUserQuery query)
        {
            var user = _database.Users.First(u => u.Id == query.UserId);
            return new UserViewModel()
            {
                Id = user.Id,
                UserName = user.Name,
                DateCreated = user.DateCreated
            };
        }

        public IEnumerable<UserViewModel> Execute(GetUsersQuery query)
        {
            return _database.Users.Select(u => new UserViewModel {
                Id = u.Id,
                UserName = u.Name,
                DateCreated = u.DateCreated
            });
        }
    }
}
