using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace captaApi.Model
{
    public partial class TbDominio
    {
        private int id;
        private string? tipo;
        private bool situacao;
        private int clienteIdFk;
        private TbCliente clienteIdFkNavigation;

        public TbDominio(TbCliente clienteIdFkNavigation, int clienteIdFk, bool situacao, string? tipo, int id)
        {
            this.clienteIdFkNavigation = clienteIdFkNavigation;
            this.clienteIdFk = clienteIdFk;
            this.situacao = situacao;
            this.tipo = tipo;
            this.id = id;
        }

        public TbDominio()
        {
            ClienteIdFkNavigation = new TbCliente();
        }

        public int Id { get => id; set => id = value; }
        public string? Tipo { get => tipo; set => tipo = value; }
        public bool Situacao { get => situacao; set => situacao = value; }

        [JsonIgnore]
        public int ClienteIdFk { get => clienteIdFk; set => clienteIdFk = value; }

        [JsonIgnore]
        public virtual TbCliente ClienteIdFkNavigation { get => clienteIdFkNavigation; set => clienteIdFkNavigation = value; }
    }
}
