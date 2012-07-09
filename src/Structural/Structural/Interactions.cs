namespace Structural
{
    using System;

    public interface IInteract<T>
    {
        object Run(T request);
    }

    public class Interactions
    {
        public static object Run<T>(IInteract<T> interaction, T request)
        {
            return interaction.Run(request);
        }
    }
}
