using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using captaApi.Data;
using captaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace captaApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CaptaContext _context;

        public ClienteRepository(CaptaContext context)
        {
            _context = context;
        }

        public void AddCliente(TbCliente cliente)
        {
            _context.Add(cliente);
        }

        public async Task<TbCliente> Cliente(int id)
        {
            return await _context.TbClientes.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TbCliente>> Clientes()
        {
            return await _context.TbClientes.Include(b => b.TbDominios).ToListAsync();
                
        }

        public void DelCliente(int id)
        {
            TbCliente cliente = _context.TbClientes.Where(x => x.Id.Equals(id)).FirstOrDefault();
            TbDominio dominio = _context.TbDominios.Where(x => x.ClienteIdFk.Equals(cliente.Id)).FirstOrDefault();
            
            _context.TbDominios.Remove(dominio);
            _context.TbClientes.Remove(cliente);
        }

        public void PutCliente(TbCliente cliente)
        {
            _context.Update(cliente);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}