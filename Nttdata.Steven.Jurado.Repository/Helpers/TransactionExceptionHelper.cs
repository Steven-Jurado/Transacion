namespace Nttdata.Steven.Jurado.Repository.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class TransactionExceptionHelper : Exception
    {
        public TransactionExceptionHelper() { }

        public TransactionExceptionHelper(string message)
            : base(message) { }

    }
}
