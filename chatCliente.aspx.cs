using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class chatCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
            }
            Cliente c = new Cliente();
            (Autonomo a, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

            string arquivoImagem = "";
            byte[] foto = cliente.Foto;
            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";
        }
    }
}