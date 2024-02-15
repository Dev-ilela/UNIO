using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unio
{
    public partial class edicaoAnuncio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request["c"] == null || Request["t"] == null || Request["d"] == null || Request["p"] == null || Request["a"] == null) {
                    Response.Redirect("painelCliente.aspx");
                }

                iptTitulo.Text = Request["t"];
                iptDescricao.Text = $@"<textarea name='' id='iptDescricao' cols='' rows='' placeholder=' Digite aqui...'>{Request["d"]}</textarea>";
            }
        }

        protected void btnBusca_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBusca.Text;
            if (string.IsNullOrEmpty(busca))
            {
                iptBusca.Focus();
            }
            else
            {
                Response.Redirect($@"busca.aspx?p={busca}");
            }
        }

        protected void btnBuscaMobile_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBuscaMobile.Text;
            if (string.IsNullOrEmpty(busca))
            {
                iptBuscaMobile.Focus();
            }
            else
            {
                Response.Redirect($@"busca.aspx?p={busca}");
            }
        }
    }
}