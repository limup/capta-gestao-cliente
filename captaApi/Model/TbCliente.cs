using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace captaApi.Model
{
    public partial class TbCliente
    {
        private int id;
        private string nome;

        private long cpf;
        private string sexo;
        private ICollection<TbDominio> tbDominios;

        public TbCliente()
        {
            TbDominios = new HashSet<TbDominio>();
        }

        
        public TbCliente(string nome, long cpf, string sexo)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.sexo = sexo;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public Int64 Cpf { get => cpf; set => cpf = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public virtual ICollection<TbDominio> TbDominios { get => tbDominios; set => tbDominios = value; }
    }
}
