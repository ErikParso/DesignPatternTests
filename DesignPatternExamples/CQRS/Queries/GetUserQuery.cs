using CQRS.DataObjects;
using System;

namespace CQRS.Queries
{
    public class GetUserQuery : IQuery
    {
        public Guid UserId { get; set; }
    }
}
