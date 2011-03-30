using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class FornecedorController
    {
        public static void criar(string nome, string telefone, string email, string localizacao, int ranking)
        {
            Fornecedor fornecedor = new Fornecedor(nome, telefone, email, localizacao, ranking);
            fornecedor.criar();
        }

        public static void apagar(int id)
        {
            Fornecedor fornecedor = Fornecedor.buscarPorId(id);
            fornecedor.apagar();
        }

        public static void atualizar(int id, string nome, string telefone, string email, string localizacao, int ranking)
        {
            Fornecedor fornecedor = Fornecedor.buscarPorId(id);
            fornecedor.Nome = nome;
            fornecedor.Telefone = telefone;
            fornecedor.Email = email;
            fornecedor.Localizacao = localizacao;
            fornecedor.Ranking = ranking;

            fornecedor.atualizar();
        }

        public static Fornecedor buscarPorId(int id)
        {
            return Fornecedor.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return Fornecedor.listar();
        }
    }
}
