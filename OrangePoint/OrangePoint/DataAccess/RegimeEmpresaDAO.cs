﻿using MySql.Data.MySqlClient;
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
    public class RegimeEmpresaDAO
    {
        private ConexaoBD conexao = new ConexaoBD();

        public DataTable PesquisaRegimeEmpresasTabela()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM bdorangepoint.regime_empresa;", conexao.StringConexao);
                da.Fill(tabela);
            }
            catch
            {
                MessageBox.Show("Erro RegimeEmpresaDAO/PesquisaRegimeEmpresasTabela. Contate o Suporte.");
            }
            return tabela;
        }

        public List<RegimeEmpresa> PesquisaRegimeEmpresasLista()
        {
            List<RegimeEmpresa> listRegimeEmpresa = new List<RegimeEmpresa>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "SELECT * FROM bdorangepoint.regime_empresa;";
                conexao.Desconectar();
                conexao.Conectar();
                MySqlDataReader registro = cmd.ExecuteReader();
                while (registro.Read())
                {
                    RegimeEmpresa regimeEmpresa = new RegimeEmpresa();
                    regimeEmpresa.CodRegime = int.Parse(registro["COD_REGIME"].ToString());
                    regimeEmpresa.Descricao = registro["DESCRICAO"].ToString();

                    listRegimeEmpresa.Add(regimeEmpresa);
                }
                conexao.Desconectar();
            }
            catch (Exception ex) { MessageBox.Show("Erro RegimeEmpresaDAO/PesquisaRegimeEmpresasLista. Contate o Suporte"); }
            return listRegimeEmpresa;
        }
    }
}