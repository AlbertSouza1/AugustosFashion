using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashionModels.Entidades.Cliente;
using AugustosFashionModels.Entidades.ContasClientes;
using AugustosFashionModels.Entidades.Dinheiros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AugustosFashion.Entidades.Cliente
{
    public class ClienteModel : UsuarioModel
    {
        public ClienteModel(string nome, string sobreNome, char sexo, DateTime dataNascimento, string email, string cpf, decimal limiteCompraAPrazo, string observacao, EnderecoModel endereco, List<TelefoneModel> telefones)
        : base(nome, sobreNome)
        {
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Email = email;
            CPF/*.NumeroCpf*/ = cpf;
            LimiteCompraAPrazo = limiteCompraAPrazo;
            Observacao = observacao;
            Endereco = endereco;
            Telefones = telefones;

            Contas = new List<ContaClienteModel>();
        }
        public int IdCliente { get; set; }
        public Dinheiro LimiteCompraAPrazo { get; set; }
        public string  Observacao { get; set; }
        public List<ContaClienteModel> Contas { get; set; }       
        public Dinheiro Divida { get => Contas.Sum(x => x.Valor.RetornaValor);}       
        public ClienteModel(){
            Contas = new List<ContaClienteModel>();
        }
        public string VerificarSeEhAniversarioDoCliente()
        {
            var mensagem = string.Empty;

            if(DataNascimento.Month == DateTime.Now.Month  && DataNascimento.Day == DateTime.Now.Day)
            {
                mensagem =  $"{NomeCompleto.Nome} está fazendo aniversário hoje.";
            }

            return mensagem;
        }           

        public decimal RetornarLimiteParaNovaCompra() =>        
           LimiteCompraAPrazo.RetornaValor - Divida.RetornaValor;

        public decimal RetornarLimiteParaAlteracaoDeCompra(decimal valorPreviamenteComprado)
            => LimiteCompraAPrazo.RetornaValor - (Divida.RetornaValor - valorPreviamenteComprado);
        

        public string ValidarCliente()
        {
            var retorno = new ClienteValidator().Validate(this);

            if (!retorno.IsValid)
                return retorno.ToString();

            return string.Empty;
        }
    }
}
