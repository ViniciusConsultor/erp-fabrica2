using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;

namespace ERP.Logistica.Controllers
{
    public class EspacosFisicosController
    {
        public static void criar(string nome, int andar, int numero)
        {
            EspacoFisico espaco = new EspacoFisico(nome, andar, numero);
            espaco.criar();
        }

        public static void apagar(int id)
        {
            EspacoFisico espaco = EspacoFisico.buscarPorId(id);
            espaco.apagar();
        }

        public static void atualizar(int id, string nome, int andar, int numero)
        {
            EspacoFisico espaco = EspacoFisico.buscarPorId(id);
            espaco.Nome = nome;
            espaco.Andar = andar;
            espaco.Numero = numero;
            espaco.atualizar();
        }

        public static EspacoFisico buscarPorId(int id)
        {
            return EspacoFisico.buscarPorId(id);
        }

        public static DataTable listar()
        {
            return EspacoFisico.listar();
        }

        public static DataTable listarEspacosFisicosDisponiveis()
        {
            return EspacoFisico.listarEspacosFisicosDisponiveis();
        }
    }
}
