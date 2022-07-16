using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capta_Tecnologia.Global
{
    public class Global
    {
        public enum Sexo
        {
            Masculino,
            Feminino,
            Outros
        }

        public enum Tipo
        {
            Tipo1,
            Tipo2,
            Tipo3,
            Tipo4,
            Tipo5,
            Tipo6,
            Tipo7,
            Tipo8,
            Tipo9,
            Tipo10
        }

        public enum Situacao
        {
            Inativo,
            Ativo
        }

        public enum Metodo
        {
            Cadastrar,
            Listar,
            Buscar,
            Atualizar,
            Deletar
        }
    }
}
