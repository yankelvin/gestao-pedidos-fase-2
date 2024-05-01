﻿namespace GestaoPedidos.Domain.Entities
{
    public class Usuario : Entidade
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public int Tipo { get; private set; }
        public bool Status { get; private set; }

        public Usuario(int id, string nome, string email, string senha, int tipo, bool status)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
            Status = status;
        }
    }
}
