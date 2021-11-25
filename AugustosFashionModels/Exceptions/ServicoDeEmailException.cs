using System;

namespace AugustosFashionModels.Exceptions
{
    public class ServicoDeEmailException : Exception
    {
        public ServicoDeEmailException() { }

        public ServicoDeEmailException(string mensagem)
            : base(mensagem) { }

        //public ServicoDeEmailException(string mensagem, Exception inner)
        //    : base(mensagem, inner) { }
    }
}
