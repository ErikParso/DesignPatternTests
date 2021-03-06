﻿namespace CQRS
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
