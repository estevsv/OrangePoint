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
    public class GrupoDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public DataTable PesquisaGrupoEmpresasTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.grupo_empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro GrupoDAO/PesquisaGrupoEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<Grupo> PesquisaGrupoEmpresasLista()
        {
            List<Grupo> listGrupoEmpresa = new List<Grupo>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.grupo_empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    Grupo grupo = new Grupo();
                    grupo.CodGrupo = int.Parse(registro["COD_GRUPO"].ToString());
                    grupo.Descricao = registro["DESCRICAO"].ToString();

                    listGrupoEmpresa.Add(grupo);
                }
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro GrupoDAO/PesquisaGrupoEmpresasLista. Contate o Suporte"); }
            return listGrupoEmpresa;
        }
    }
}
