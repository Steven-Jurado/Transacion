namespace Nttdata.Steven.Jurado.Domain.Helpers
{
    using System;

    [Serializable]
    public class TransactionExceptionHelper : Exception
    {
        public TransactionExceptionHelper() { }

        public TransactionExceptionHelper(string message)
            : base(message) { }

    }
}
