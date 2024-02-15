using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class ComoFunciona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["email"] != null)
                {
                    string emailUsuario = "";
                    string arquivoImagem = "";

                    emailUsuario = Session["email"].ToString();

                    Cliente c = new Cliente();
                    (Autonomo a, Cliente cliente) = c.CarregarUsuario(emailUsuario, Session["senha"].ToString());

                    if (cliente != null)
                    {
                        byte[] foto = cliente.Foto;
                        string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                        litStylesHeaders.Text = $@"<link rel='stylesheet' href='css/headerClienteLogado.css'>";
                        litLogo.Text = $@"<div class='divLogo'>
                                            <a href='painelCliente.aspx'>
                                                <img class='logo_padrao' src='imagens/logos/logo_branca.png' alt=''/>
                                                <img class='logoBolinhas' src='imagens/elementos/Elemento03.png' alt=''>
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

                        litScript.Text = "<script type='text/javascript' src='script/menuHeaderCliente.js'></script>";
                    }
                    else
                    {
                        if (a != null)
                        {
                            byte[] foto = a.Foto;
                            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                            litStylesHeaders.Text = $@"<link rel='stylesheet' href='css/headerAutonomoLogado.css'>";
                            litLogo.Text = $@"<div class='divLogo'>
                                            <a href='painelAutonomo.aspx'>
                                                <img class='logo_padrao' src='imagens/logos/logo_branca.png' alt=''>
                                                <img class='logoBolinhas' src='imagens/elementos/Elemento03.png' alt=''>
                                            </a>
                                        </div>";

                            litMenu.Text = $@"<div class='divMenu'>
                                            <ul>
                                                <li class='liDoPopup'><img class='aviso_notificacao escondido' src='imagens/icones/aviso_Notificações.png' alt=''><a href='chatAutonomo.aspx'><img src='imagens/icones/Mensagens_icon.png' alt='Ícone de mensagens'></a></li>
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
                                            
                                                    <img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>
                                                </li>
                                            </ul>
            
                                            <article class='prflAutonomo escondido'>
                                                <a href='painelAutonomo.aspx' class='opcao'>Painel de Serviços</a>
                                                <a href='meuPerfilAutonomo.aspx' class='opcao'>Meu perfil</a>
                                                <a href='buscaServicos.aspx' class='opcao'>Serviços</a>
                                                <a href='propostasRecebidas.aspx' class='opcao'>Propostas</a>
                                                <a href='ComoFunciona.aspx' class='opcao'><img src='imagens/icones/comoFunciona_Icon.png' alt=''>Como funciona</a>
                                                <button class='opcaoBtn'>Sair</button>
                                            </article>
                                        </div>";

                            litScript.Text = "<script type='text/javascript' src='script/menuHeaderAutonomo.js'></script>";
                        }
                    }
                }
                else
                {
                    litStylesHeaders.Text = $@"<link rel='stylesheet' href='css/headerSemLogar.css'>";
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
                    
                    litScript.Text = "<script type='text/javascript' src='script/login.js'></script>";
                    litScript.Text += "<script src=\"script/code.jquery.com_jquery-3.7.0.min.js\"></script>";
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