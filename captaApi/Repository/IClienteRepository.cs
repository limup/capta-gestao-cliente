using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using captaApi.Model;

namespace captaApi.Repository
{
    public interface IClienteRepository
    {
        //Listagens
        Task<IEnumerable<TbCliente>> Clientes();

        //Busca
        Task<TbCliente> Cliente (int id);

        //Cadastro
        void AddCliente(TbCliente cliente);

        //Atualização
        void PutCliente(TbCliente cliente);

        //Deleta
        void DelCliente (int id);

        Task<bool> SaveChangesAsync();
    }
}