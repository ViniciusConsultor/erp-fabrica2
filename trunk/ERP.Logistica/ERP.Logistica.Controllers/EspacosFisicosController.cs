using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Logistica.Models;
using System.Data;
using System.Data.SqlClient;

namespace ERP.Logistica.Controllers
{
    public class EspacosFisicosController
    {
        public static int criar(string nome, int andar, int numero, string especialidade)
        {
            EspacoFisico espaco = new EspacoFisico(nome, andar, numero, especialidade);
            if (espaco.verificaNome())
            {
                espaco.criar();
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static void apagar(int id)
        {
            EspacoFisico espaco = EspacoFisico.buscarPorId(id);
            espaco.apagar();
        }

        public static int atualizar(int id, string nome, int andar, int numero, string especialidade)
        {
            EspacoFisico espaco = EspacoFisico.buscarPorId(id);
            espaco.Nome = nome;
            espaco.Andar = andar;
            espaco.Numero = numero;
            espaco.Especialidade = especialidade;
            if (espaco.verificaNome())
            {
                espaco.atualizar();
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static EspacoFisico buscarPorId(int id)
        {
            return EspacoFisico.buscarPorId(id);
        }

        public static DataTable listar()
        {
            DataTable espaco = EspacoFisico.listar(); 
            DataTable especialidades = EspecialidadeController.listaEspecialidades();

            foreach (DataRow row1 in especialidades.Rows)
            {
                foreach (DataRow row2 in espaco.Rows)
                {
                    if (row2.ItemArray[4].Equals(row1.ItemArray[0]))
                        row2.SetField(espaco.Columns[4],row1.ItemArray[1]);
                }
            }

            return espaco;
        }

        public static DataTable listarEspacosFisicosDisponiveis()
        {
            return EspacoFisico.listarEspacosFisicosDisponiveis();
        }

        public static DataTable WebListar()
        {
            return EspacoFisico.WebListar();
        }
    }
}
