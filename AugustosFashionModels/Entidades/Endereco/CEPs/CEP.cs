using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashionModels.Entidades.Endereco.CEPs
{
    public class CEP
    {
        private string _valor;

        public string RetornaValor { get => _valor; }
        public string RetornaValorFormatado
        {
            get => Convert.ToUInt32(_valor).ToString(@"00000-000");
        }

        public CEP(string valor)
        {
            _valor = valor;
        }

        public string RemoverFormatacao(string valor)
        {
            string cepSemFormatacao = valor;

            cepSemFormatacao = new string((from c in cepSemFormatacao
                                           where char.IsDigit(c)
                                           select c
            ).ToArray());

            return cepSemFormatacao;
        }

        public override string ToString()
        {
            return _valor;
        }

        public static implicit operator CEP(string valor) => new CEP(valor);
    }
}
