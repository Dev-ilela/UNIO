using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class busca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!String.IsNullOrEmpty(Request["p"]))
                {
                    string emailCliente = "";

                    if (Session["email"] != null)
                    {
                        emailCliente = Session["email"].ToString();

                        Cliente c = new Cliente();
                        (Autonomo a, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

                        string arquivoImagem = "";
                        byte[] foto = cliente.Foto;
                        string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        litStylesHeader.Text = $@"<link rel='stylesheet' href='css/headerClienteLogado.css'>";
                        litLogo.Text = $@"<div class='divLogo'>
                                                <a href='painelCliente.aspx'>
                                                    <img class='logo_padrao' src='imagens/logos/logo_branca.png' alt=''>
                                                    <img class='logoBolinhas' src='imagens/elementos/Elemento03.png' alt=''>
                                                </a>
                                            </div>";

                        litMenu.Text = $@"<div class='divMenu'>
                                                <ul>
                                                    <li class='liDoPopup'><img class='aviso_notificacao escondido' src='imagens/icones/aviso_Notificações.png' alt=''><a href='chatCliente.aspx'><img src='imagens/icones/Mensagens_icon.png' alt='Ícone de mensagens'></a></li>
                                                    <li class='liDoPopup'>
                                                      <div class='popupNotificacao escondido'>
                                                          <div>
                                                              <figure><img src='imagens/icon_notificacoes/icon_selecionado.png' alt=''></figure>
                                                              <p>
                                                                  <strong>Você foi selecionado!</strong><br>
                                                                  Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                                                              </p>
                                                          </div>
                                                          <div>
                                                              <figure><img src='imagens/icon_notificacoes/icon_concluido.png' alt=''></figure>
                                                              <p>
                                                                  <strong>Serviço concluído</strong><br>
                                                                  Cliente concluiu o serviço. Confirme você também para finalizá-lo.
                                                              </p>
                                                          </div>
                                                          <div>
                                                              <figure><img src='imagens/icon_notificacoes/icon_selecionado.png' alt=''></figure>
                                                              <p>
                                                                  <strong>Você foi selecionado!</strong><br>
                                                                  Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                                                              </p>
                                                          </div>
                                                          <div>
                                                              <figure>
                                                                  <img src='imagens/icon_notificacoes/icon_mensagem.png' alt=''>
                                                              </figure>
                                                              <p>
                                                                  <strong>Você tem uma nova mensagem</strong><br>
                                                                  Você tem uma nova mensagem do cliente. Dê uma olhada quando puder.
                                                              </p>
                                                          </div>
                                                          <div>
                                                              <figure><img src='imagens/icon_notificacoes/icon_selecionado.png' alt=''></figure>
                                                              <p>
                                                                  <strong>Você foi selecionado!</strong><br>
                                                                  Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                                                              </p>
                                                          </div>
                                                          <div>
                                                              <figure>
                                                                  <img src='imagens/icon_notificacoes/icon_mensagem.png' alt=''>
                                                              </figure>
                                                              <p>
                                                                  <strong>Você tem uma nova mensagem</strong><br>
                                                                  Você tem uma nova mensagem do cliente. Dê uma olhada quando puder.
                                                              </p>
                                                          </div>
                                                      </div>
                                                      <img class='aviso_notificacao escondido' src='imagens/icones/aviso_Notificações.png' alt=''><img id='sininho' src='imagens/icones/Notificacoes_icon.png' alt='Ícone de notificações'>
                                                    </li>
                                                  <li id='perfilCliente'>
                                               
                                                      <img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>
                                                  </li>
                                                </ul>
              
                                                <article class='prflCliente escondido'>
                                                    <a href='painelCliente.aspx' class='opcao'>Painel de Serviços</a>
                                                    <a href='meuPerfilCliente.aspx' class='opcao'>Meu perfil</a>
                                                    <a href='criacaoAnuncio.aspx' class='opcao'>Criar anúncios</a>
                                                    <a href='AutonomosFavoritos.aspx' class='opcao'>Favoritos</a>
                                                    <a href='ComoFunciona.aspx' class='opcao'><img src='imagens/icones/comoFunciona_Icon.png' alt=''>Como funciona</a>
                                                    <button class='opcaoBtn'>Sair</button>
                                                </article>
                                            </div>";
                    }
                    else
                    {
                        litStylesHeader.Text = $@"<link rel='stylesheet' href='css/headerSemLogar.css'>";
                        litLogo.Text = $@"<div class='divLogo'>
                                                <a href='index.aspx'>
                                                    <img class='logo_padrao' src='imagens/logos/logo_padrao.png' alt=''>
                                                    <img class='logoBolinhas' src='imagens/elementos/Elemento03.png' alt=''>
                                                   </a>
                                            </div>";
                        litMenu.Text = $@"<div class='divMenu' id='btnLogin'>
                                                <ul>
                                                    <li id='btnCadastro'><div>Cadastre-se</div></li>
                                                    <li id='btnLogin'>
                                                        <button name='btnLogin'>Login</button>
                                                        <label for='btnLogin'><img src='imagens/icones/login_icon.png' alt=''/></label>
                                                    </li>
                                                </ul>
                                            </div>";
                    }

                    string busca = Request["p"].ToString();
                    iptBusca.Text = busca;

                    Profissoes profissoes = new Profissoes();
                    List<Profissao> listaProfissao = profissoes.carregarProfissoesNaBusca(busca);

                    if (listaProfissao.Count > 0)
                    {
                        litResultados.Text += $@"<p class='titulo'>Resultados por <strong>'{busca}'</strong></p>";
                        foreach (Profissao profissao in listaProfissao)
                        {
                            litResultados.Text += $@"<a href='buscaAutonomo.aspx?p={profissao.Nome}&cp={profissao.Codigo}' class='resultados'>
                                                        <div class='itemResultados'>
                                                            <p>{profissao.Nome}</p>
                                                            <img src='imagens/icones/front_icon_busca.png' alt=''>
                                                        </div>
                                                    </a>";
                        }
                    }
                    else
                    {
                        litResultados.Text = $@"<div class='SemAnuncios'>
                                                    <figure>
                                                        <img src = 'imagens/elementos/Elemento19.svg' alt = ''>
                                                    </figure>
   
                                                    <h2> Hmm... Não achamos um serviço com essas especificações:/</h2>
                                                    <p> Tente pesquisar de uma maneira diferente.</p>
                                                </div> ";
                    }
                }
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
                Response.Redirect($@"busca.aspx?p={busca}&");
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