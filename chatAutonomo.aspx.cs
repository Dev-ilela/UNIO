using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class chatAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string emailAutonomo = "";

                if (Session["email"] != null)
                {
                    emailAutonomo = Session["email"].ToString();
                }

                Autonomo a = new Autonomo();
                (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(emailAutonomo, Session["senha"].ToString());

                string arquivoImagem = "";
                byte[] foto = autonomo.Foto;
                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";
            }
        }
    }
}