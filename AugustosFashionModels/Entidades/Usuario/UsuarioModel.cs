﻿using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashionModels.Entidades.Cpfs;
using AugustosFashionModels.Entidades.Emails;
using AugustosFashionModels.Entidades.NomesCompletos;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Entidades
{
    public abstract class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public NomeCompleto NomeCompleto { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public Email Email { get; set; }
        public CPF CPF { get; set; }
        public EnderecoModel Endereco { get; set; }
        public List<TelefoneModel> Telefones { get; set; }
        public UsuarioModel(string nome, string sobreNome)
        {
            Endereco = new EnderecoModel();
            Telefones = new List<TelefoneModel>();
            NomeCompleto = new NomeCompleto(nome, sobreNome);

            //CPF = new CPF();
        }

        public UsuarioModel()
        {
            Endereco = new EnderecoModel();
            Telefones = new List<TelefoneModel>();
            NomeCompleto = new NomeCompleto();
        }      
    }
}

