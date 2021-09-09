using OrangePoint.BusinessRule;
using OrangePoint.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangePoint.Resources
{
    public class Utilities
    {
        PermissaoTelaRule permissaoTelaRule = new PermissaoTelaRule();

        public string RetornaData(int numero)
        {
            if (numero < 10)
            {
                return "0" + numero;
            }
            return numero.ToString();
        }

        public Image CarregaImagemUsuario(Usuario usuario, Image imagemPadrao)
        {
            try
            {
                if (usuario.FotoUsuario != null && usuario.FotoUsuario != "")
                    return Image.FromFile(usuario.FotoUsuario);
            }
            catch { return imagemPadrao; }
            return imagemPadrao;
        }

        public List<bool> GeraListaPermissoes(Usuario usuario)
        {
            //Referências das Posições[Cadastros, Consultoria Contábil, Apuração de Lucro Real,Controle de Usuarios,Folha de Ponto, Controle de Folha de Ponto]
            List<bool> listaPermissoes = new List<bool> {false, false, false, false, false, false };

            List<PermissaoTela> listaPermissaoTela = permissaoTelaRule.PesquisaPermissaoTela();

            foreach(PermissaoTela permissaoTela in listaPermissaoTela.Where(o => o.TipoPermissao.CodTipoPermissao == usuario.TipoPermissao.CodTipoPermissao))
            {
                switch (permissaoTela.DescTela)
                {
                    case "Cadastros":
                        listaPermissoes[0] = true;
                        break;
                    case "Consultoria Contábil":
                        listaPermissoes[1] = true;
                        break;
                    case "Apuração de Lucro Real":
                        listaPermissoes[2] = true;
                        break;
                    case "Controle de Usuários":
                        listaPermissoes[3] = true;
                        break;
                    case "Folha de Ponto":
                        listaPermissoes[4] = true;
                        break;
                    case "Controle de Folha de Ponto":
                        listaPermissoes[5] = true;
                        break;
                }
            }

            return listaPermissoes;
        }
    }
}
