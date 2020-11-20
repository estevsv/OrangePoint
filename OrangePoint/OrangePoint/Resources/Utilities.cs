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
        public Image CarregaImagemUsuario(Usuario usuario, Image imagemPadrao)
        {
            if (usuario.FotoUsuario != null && usuario.FotoUsuario != "")
                return Image.FromFile(usuario.FotoUsuario);
            return imagemPadrao;
        } 
    }
}
