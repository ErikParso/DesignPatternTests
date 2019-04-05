namespace CQRS
{
    public interface IQuery
    {

    }

    public interface IQueryHandler<TQuery,TResult>
        where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}
