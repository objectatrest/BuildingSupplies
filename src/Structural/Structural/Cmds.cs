namespace Structural
{
    using System;

    public interface ICommand<T>
    {
        object Execute(T request);
    }

    public class Cmds
    {
        public static object ExecuteCommand<T>(ICommand<T> cmd, T request)
        {
            return cmd.Execute(request);
        }
    }
}
