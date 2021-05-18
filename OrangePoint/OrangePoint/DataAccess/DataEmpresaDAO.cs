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

        public List<DataEmpresa> PesquisaDataEmpresaLista(int codEmpresa = -1, string data = "")
        {
            List<DataEmpresa> listDataEmpresa = new List<DataEmpresa>();
            List<Empresa> listEmpresa = empresaDAO.PesquisaEmpresasLista();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                if (codEmpresa == -1)
                    cmd.CommandText = "SELECT * FROM bdorangepoint.datas_empresa;";
                else
                {
                    string formataPesquisa = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);
                    cmd.CommandText = "SELECT * FROM bdorangepoint.datas_empresa where COD_EMPRESA = '" + codEmpresa + "' and " +
                        "DATA = '" + formataPesquisa + "';";
                }
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    DataEmpresa dataEmpresa = new DataEmpresa();
                    dataEmpresa.CodData = int.Parse(registro["COD_DATA"].ToString());
                    dataEmpresa.Data = Convert.ToDateTime(registro["DATA"]);
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

        public void IncluirDataEmpresa(int codEmpresa, DateTime data)
        {
            try
            {
                string dataFiltrada = data.Year + "-" + data.Month + "-" + data.Day;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "INSERT INTO `bdorangepoint`.`datas_empresa` (`COD_EMPRESA`, `DATA`) VALUES (" + codEmpresa + ", @dataFiltrada);";
                cmd.Parameters.AddWithValue("@dataFiltrada", dataFiltrada);
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
