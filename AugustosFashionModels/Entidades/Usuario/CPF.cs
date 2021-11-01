using System;

namespace AugustosFashionModels.Entidades.Usuario
{
    public struct CPF
    {
        private string _valor;
        private string _mensagemErro;

        public string ValorFormatado
        { 
                get  => Convert.ToUInt64(_valor).ToString(@"000\.000\.000\-00");
        }

        public string RecuperarMensagemErro { get => _mensagemErro; }

        public CPF(string valor)
        {
            _valor = valor;
            _mensagemErro = string.Empty;
        }
        public void ValidarCPF()
        {
            if (_valor.Length != 11)
                _mensagemErro = "CPF inválido";
        } 
        public override string ToString()
        {
            return _valor;
        }

        public static implicit operator CPF(string valor) => new CPF(valor);
    }
}
