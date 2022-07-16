using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capta_Tecnologia.Models
{
    public class Dominio
    {
        private int id;
        private string tipo;
        private bool situacao;


        public Dominio(int id, string tipo, bool situacao)
        {
            this.id = id;
            this.tipo = tipo;
            this.situacao = situacao;
        }

        public int Id { get => id; set => id = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public bool Situacao { get => situacao; set => situacao = value; }

    }
}
