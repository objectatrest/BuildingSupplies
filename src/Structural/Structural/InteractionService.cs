namespace Structural
{
    using System;

    public class Interactions
    {
        public static object Run<T>(IInteract<T> interaction, T request)
        {
            return interaction.Run(request);
        }
    }
}
