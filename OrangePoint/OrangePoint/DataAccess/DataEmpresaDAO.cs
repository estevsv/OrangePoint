using MySql.Data.MySqlClient;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrangePoint.DataAccess
{
    public class DataEmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();
        TipoDataDAO tipoDataDAO = new TipoDataDAO();
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public DataTable PesquisaDataEmpresaTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.datas_empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro DataEmpresaDAO/PesquisaDataEmpresaTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<DataEmpresa> PesquisaDataEmpresaLista()
        {
            List<DataEmpresa> listDataEmpresa = new List<DataEmpresa>();
            List<TipoData> listTipoData = tipoDataDAO.PesquisaTipoDataLista();
            List<Empresa> listEmpresa = empresaDAO.PesquisaEmpresasLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.datas_empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    DataEmpresa dataEmpresa = new DataEmpresa();
                    dataEmpresa.CodData = int.Parse(registro["COD_DATA"].ToString());
                    dataEmpresa.Data = Convert.ToDateTime(registro["DATA"]);
                    dataEmpresa.TipoData = listTipoData.Find(o => o.CodTipoData == int.Parse(registro["COD_TIPO_DATA"].ToString()));
                    dataEmpresa.Empresa = listEmpresa.Find(o => o.CodEmpresa == int.Parse(registro["COD_EMPRESA"].ToString()));

                    listDataEmpresa.Add(dataEmpresa);
                }
                conexao.Desconectar();
            }
            catch { MessageBox.Show("Erro DataEmpresaDAO/PesquisaDataEmpresaLista. Contate o Suporte"); }
            return listDataEmpresa;
        }

        public void ExcluiDataEmpresa(int codDataEmpresa)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from bdorangepoint.datas_empresa where COD_DATA = " + codDataEmpresa;
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro DataEmpresaDAO/ExcluiDataEmpresa. Contate o Suporte");
            }
        }

        public void IncluirDataEmpresa(int codTipoData, int codEmpresa, DateTime data)
        {
            try
            {
                string dataFiltrada = data.Year + "-" + data.Month + "-" + data.Day;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`datas_empresa` (`COD_TIPO_DATA`, `COD_EMPRESA`, `DATA`) VALUES (" + codTipoData + "," + codEmpresa + "," + dataFiltrada + ");";
                conexao.Desconectar();
                conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch
            {
                MessageBox.Show("Erro DataEmpresaDAO/IncluirDataEmpresa. Contate o Suporte");
            }
        }
    }
}
