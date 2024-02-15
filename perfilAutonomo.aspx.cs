using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class perfilAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["a"]) || String.IsNullOrEmpty(Request["p"]) || String.IsNullOrEmpty(Request["cp"]))
            {
                Response.Redirect("index.aspx");
            }

            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
                Literal litIdentificador = new Literal();
                litIdentificador.Text = $"<input type='hidden' id='identificadorCliente' value='{emailCliente}'>";
                Form.Controls.Add(litIdentificador);

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

            Autonomo autonomo = new Autonomo();
            autonomo.Email = Request["a"];
            autonomo.PreencherDados();

            string arquivoImagemAutonomo = "";
            byte[] fotoAutonomo = autonomo.Foto;
            string base64StringAutonomo = Convert.ToBase64String(fotoAutonomo, 0, fotoAutonomo.Length);
            arquivoImagemAutonomo = Convert.ToString("data:image/jpeg;base64,") + base64StringAutonomo;

            #region Portfolio
            Portfolios portfolios = new Portfolios();
            autonomo.Portfolio = portfolios.CarregarPortfolios(autonomo.Email, int.Parse(Request["cp"]));
            Emblema emblema = autonomo.CarregarEmblemaAutonomo(autonomo.Email);
            decimal avaliacaoEstrelas = autonomo.CarregarAvaliacao(autonomo.Email);

            string txtPorfolio = "";
            string imagensPortfolio = "";
            foreach (Portfolio portfolio in autonomo.Portfolio)
            {
                string arquivoImagem = "";
                byte[] foto = portfolio.Imagem;
                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                imagensPortfolio += $@"<img src='{arquivoImagem}' alt=''>";
            }
            if (imagensPortfolio != "")
            {
                txtPorfolio = $@"<section class='portfolioAutonomo'>
                                        <h2>Algumas imagens do meu trabalho:</h2>
                                        <div>
                                            {imagensPortfolio}
                                        </div>
                                    </section>";
            }
            else
            {
                txtPorfolio = "";
            }

            #endregion

            #region FormaDePagamento
            string FormasDePagamento = "<div>";
            string NomeFormaDePagamento = "<p>";
            foreach (FormaPagamento formaPagamento in autonomo.FormasPagamento)
            {
                FormasDePagamento += $@"<img src='imagens/icones/forma_pag_{formaPagamento.Codigo}.png' alt=''>";
                NomeFormaDePagamento += $@"{formaPagamento.Nome}, ";
            }

            NomeFormaDePagamento = NomeFormaDePagamento.Substring(0, (NomeFormaDePagamento.Length - 2));
            FormasDePagamento += "</div>";
            NomeFormaDePagamento += "</p>";
            #endregion

            #region Avaliações
            Avaliacoes avs = new Avaliacoes();
            List<Avaliacao> avaliacoes = avs.CarregarAvaliacoes(autonomo.Email);
            string txtAvaliacoes = "";
            foreach (Avaliacao avaliacao in avaliacoes)
            {
                string arquivoImagemAv = "";
                byte[] fotoAv = avaliacao.Cliente.Foto;
                string base64StringAv = Convert.ToBase64String(fotoAv, 0, fotoAv.Length);
                arquivoImagemAv = Convert.ToString("data:image/jpeg;base64,") + base64StringAv;

                txtAvaliacoes += $@"<div class='avaliacao'>
                                        <img src='{arquivoImagemAv}' alt=''>
                                        <div class='infoGeral'>
                                            <div class='infoCima'>
                                                <div class='nomeEavalicao'>
                                                    <h2>{avaliacao.Cliente.Nome}</h2>
                                                    <div class='avaliacaoEstrelas'>
                                                        <div id='progressoEstrelas' class='barra' valor='{avaliacao.Media.ToString().Replace(",", ".")}'>
                                                            <div id='barraProgressoEstrelas'></div>
                                                        </div>
                                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                    </div>
                                                </div>
                                
                                            </div>
                                            <p>{avaliacao.Descricao}!</p>
                                        </div>
                                    </div>";
            }
            #endregion

            litGeral.Text = $@"<section class='geral'>
                                <section class='perfilAutonomo'>
                                    <section class='bgPerfil' >
                                      <input type='hidden' id='identificadorAutonomo' value='{autonomo.Email}'>
                                        <div class='informacoes'>
                                            <img id='imgAutonomo' src='{arquivoImagemAutonomo}' alt=''>
                                            <div class='progressoAutonomo'>
                                                <p class='progresso' valor='{avaliacaoEstrelas}'>{avaliacaoEstrelas}</p>
                                                <div class='avaliacaoProgresso'>
                                                    <div class='barra' id='progresso'>
                                                        <div id='barraProgresso'></div>
                                                    </div>
                                                    <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                </div>
                                            </div>
                                            <div class='info'>
                                                <h2>{autonomo.Nome}</h2>
                                                <p>{Request["p"]}</p>
                                                <div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {autonomo.Cidade.Nome} - {autonomo.Estado.Nome} </div>
                                            </div>                    
                                        </div>";

            if (Session["login"] != null)
            {
                Favoritos favoritos = new Favoritos();

                if (favoritos.VerificaFavorito(Session["email"].ToString(), autonomo.Email))
                {
                    litGeral.Text += $@"<figure class='coracoesVazados escondido'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                        <figure class='coracoesPreenchidos'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                        </section>
                                        </section>

                                        <section class='emblemaAutonomo'>
                                            <p>Esse profissional é um usuário <strong>{emblema.Nome.ToLower()}!</strong></p> 
                                            <img src='imagens/emblemas/{emblema.Nome.ToLower()}.png' alt=''>
                                        </section>

                                        <section class='sobreAutonomo'>
                                            <h2>Um pouco sobre mim:</h2>
                                            <p>{autonomo.Comentario}</p>
                                        </section>

                                        {txtPorfolio}

                                        <section class='pagamentoAutonomo'>
                                            <h2>Forma de pagamento:</h2>
                                            {FormasDePagamento}
                                            {NomeFormaDePagamento}
                                        </section>

                                        <div class='filtroEtitulo'>
                                                <h2>Avaliações:</h2>
                                                <section class='filtros'>
                                                    <div>
                                                        <div><p>Avaliação</p></div>
                                                        <select id='selectAvaliacao'>
                                                            <option value='Maior'>Maior</option>
                                                            <option value='Menor'>Menor</option>
                                                        </select>
                                                    </div>
                                                </section>
                                            </div>

                                        <section class='avaliacaoAutonomo'>
                                            
                                            

                                            {txtAvaliacoes}
                    
                                        </section>

                                    </section>";
                }
                else
                {
                    litGeral.Text += $@"<figure class='coracoesVazados'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                        <figure class='coracoesPreenchidos  escondido'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                         </section>
                                            </section>

                                            <section class='emblemaAutonomo'>
                                                <p>Esse profissional é um usuário <strong>{emblema.Nome.ToLower()}!</strong></p> 
                                                <img src='imagens/emblemas/{emblema.Nome.ToLower()}.png' alt=''>
                                            </section>

                                            <section class='sobreAutonomo'>
                                                <h2>Um pouco sobre mim:</h2>
                                                <p>{autonomo.Comentario}</p>
                                            </section>

                                            {txtPorfolio}

                                            <section class='pagamentoAutonomo'>
                                                <h2>Forma de pagamento:</h2>
                                                {FormasDePagamento}
                                                {NomeFormaDePagamento}
                                            </section>

                                             <div class='filtroEtitulo'>
                                                    <h2>Avaliações:</h2>
                                                    <section class='filtros'>
                                                        <div>
                                                            <div><p>Avaliação</p></div>
                                                            <select id='selectAvaliacao'>
                                                                <option value='Maior'>Maior</option>
                                                                <option value='Menor'>Menor</option>
                                                            </select>
                                                        </div>
                                                    </section>
                                                </div>

                                            <section class='avaliacaoAutonomo'>
                                               

                                                {txtAvaliacoes}
                    
                                            </section>

                                        </section>";
                }
            }
            else
            {
                litGeral.Text += $@"<figure class='coracoesVazados'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                        <figure class='coracoesPreenchidos  escondido'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                         </section>
                                            </section>

                                            <section class='emblemaAutonomo'>
                                                <p>Esse profissional é um usuário <strong>{emblema.Nome.ToLower()}!</strong></p> 
                                                <img src='imagens/emblemas/{emblema.Nome.ToLower()}.png' alt=''>
                                            </section>

                                            <section class='sobreAutonomo'>
                                                <h2>Um pouco sobre mim:</h2>
                                                <p>{autonomo.Comentario}</p>
                                            </section>

                                            {txtPorfolio}

                                            <section class='pagamentoAutonomo'>
                                                <h2>Forma de pagamento:</h2>
                                                {FormasDePagamento}
                                                {NomeFormaDePagamento}
                                            </section>

                                            <div class='filtroEtitulo'>
                                                    <h2>Avaliações:</h2>
                                                    <section class='filtros'>
                                                        <div>
                                                            <div><p>Avaliação</p></div>
                                                            <select id='selectAvaliacao'>
                                                                <option value='Maior'>Maior</option>
                                                                <option value='Menor'>Menor</option>
                                                            </select>
                                                        </div>
                                                    </section>
                                                </div>

                                            <section class='avaliacaoAutonomo'>
                                                

                                                {txtAvaliacoes}
                    
                                            </section>

                                        </section>";
            }
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
    }
}