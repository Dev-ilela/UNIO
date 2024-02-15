using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unio
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBusca_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBusca.Text;
            if (string.IsNullOrEmpty(busca))
            {

            }
            else
            {
                Response.Redirect($@"busca.aspx?p={busca}");
            }
        }

        protected void btnSaibaMais_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComoFunciona.aspx");
        }
    }
}