using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capta_Tecnologia.Models
{
    public class Cliente
    {
        private int id;
        private string nome;
        private long cpf;
        private string sexo;
        private ICollection<Dominio> tbdominios;

        public Cliente(int id, string nome, long cpf, string sexo, ICollection<Dominio> dominios)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            tbDominios = dominios;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public Int64 Cpf { get => cpf; set => cpf = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public ICollection<Dominio> tbDominios { get => tbdominios; set => tbdominios = value; }

        public Cliente()
        {
            List<Dominio> tbDominios = new List<Dominio>();
        }

    }
}
