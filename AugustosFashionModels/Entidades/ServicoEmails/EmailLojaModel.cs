using AugustosFashionModels.Servicos.Criptografias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashionModels.Entidades.ServicoEmails
{
    public class EmailLojaModel
    {
        public int IdEmail { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Chave { get; set; }

        public string RetornarSenhaDescriptografada()
            => Criptografia.Decrypt(Senha, true, Chave);
    }
}
