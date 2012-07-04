namespace Structural
{
    using System;

    public interface IInteract<T>
    {
        object Run(T request);
    }
}
