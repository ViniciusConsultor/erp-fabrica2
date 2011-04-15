using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.Manutencao.Models
{
    public class TarefaManutencao
    {
        private int _id;
        private string _descricao;
        private string _local;
        private string _equipamento;
        private string _estado;
        private DateTime _inicioManutencao;
        private DateTime _fimManutencao;

        #region Constructors
       
          public TarefaManutencao(string descricao, string local, string equipamento, string estado, DateTime inicioManutencao, DateTime fimManutencao) 
        {
            this._descricao = descricao;
            this._local = local;
            this._equipamento = equipamento;
            this._estado = estado;
            this._inicioManutencao = inicioManutencao;
            this._fimManutencao = fimManutencao;
        }
     
        public TarefaManutencao(int id, string descricao, string local, string equipamento, string estado, DateTime inicioManutencao, DateTime fimManutencao)
            :this(descricao, local, equipamento, estado, inicioManutencao,fimManutencao)
        {
            this._id = id;
        }

 
        #endregion

        #region Properties
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public string Local
        {
            get { return _local; }
            set { _local = value; }
        }

        public string Equipamento
        {
            get { return _equipamento; }
            set { _equipamento = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int Id
        {
            get { return _id; }
        }

        public DateTime InicioManutencao
        {
            get { return _inicioManutencao; }
            set { _inicioManutencao = value; }
        }

        public DateTime FimManutencao
        {
            get { return _fimManutencao; }
            set { _fimManutencao = value; }
        }
        #endregion



        public void criar()
        {
            TarefaManutencaoDAO.criar(Descricao, Local, Equipamento, Estado, InicioManutencao, FimManutencao);
        }

        public void apagar()
        {
            TarefaManutencaoDAO.apagar(Id);
        }

        public void atualizar()
        {
            TarefaManutencaoDAO.atualizar(Id, Descricao, Local, Equipamento, Estado, InicioManutencao, FimManutencao);
        }

        
        #region static methods

        public static TarefaManutencao buscarPorId(int id)
        {
            DataSet ds = TarefaManutencaoDAO.buscarPorId(id);
            DataRow row = (DataRow)ds.Tables[0].Rows[0];
            TarefaManutencao tarefa = new TarefaManutencao(id, (string)row["Descricao"], (string)row["Local"], (string)row["Equipamento"], (string)row["Estado"], (DateTime)row["Inicio_Manutencao"], (DateTime)row["Fim_Manutencao"]);

            return tarefa;
        }


        public static DataTable listar()
        {
            return TarefaManutencaoDAO.listar();
        }

        public static DataTable WebListar()
        {
            return TarefaManutencaoDAO.WebListar();
        }
        #endregion
    }
}
