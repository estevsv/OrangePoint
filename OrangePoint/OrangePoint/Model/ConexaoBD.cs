using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Model
{
    public class ConexaoBD
    {
        private String _stringConexao;
        private MySqlConnection _conexao;

        public ConexaoBD()
        {
            this._conexao = new MySqlConnection();
            #if DEBUG
                this.StringConexao = "SERVER=localhost;DATABASE=bdorangepoint;UID=root;PWD=123456;SslMode=Required";
                this._conexao.ConnectionString = "SERVER=localhost;DATABASE=bdorangepoint;UID=root;PWD=123456;SslMode=Required";
#else
                this.StringConexao = "SERVER=10.10.11.252;DATABASE=bdorangepoint;UID=root;PWD=123456;SslMode=Required";
                this._conexao.ConnectionString = "SERVER=10.10.11.252;DATABASE=bdorangepoint;UID=root;PWD=123456;SslMode=Required"; 
#endif
        }

        public String StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }

        public MySqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }

        }
        public void Conectar()
        {
            this._conexao.Open();
        }

        public void Desconectar()
        {
            this._conexao.Close();
        }
    }
}
