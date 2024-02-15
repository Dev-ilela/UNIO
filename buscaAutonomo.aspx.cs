using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class buscaAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string loginCliente = "";
                string emailCliente = "";


                if (Session["login"] != null)
                {
                    loginCliente = Session["login"].ToString();
                    emailCliente = Session["email"].ToString();
                    Literal litIdentificador = new Literal();
                    litIdentificador.Text = $"<input type='hidden' id='identificadorCliente' value='{emailCliente}'>";
                    Form.Controls.Add(litIdentificador);
                }


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


                if ((!String.IsNullOrEmpty(Request["est"])) || (!String.IsNullOrEmpty(Request["fp"])) || (!String.IsNullOrEmpty(Request["e"])))
                {


                    #region Estados

                    Estados estados = new Estados();
                    List<Estado> listEstados = new List<Estado>();
                    listEstados = estados.CarregarEstados();

                    ddlEstado.Items.Add(new ListItem("-- Selecione --", "-1"));

                    for (int indice = 0; indice < listEstados.Count; indice++)
                    {
                        string sigla = listEstados[indice].Sigla.ToString();
                        string nome = listEstados[indice].Nome;
                        ddlEstado.Items.Add(new ListItem(nome, sigla));
                    }

                    #endregion

                    #region Formas de pagamento
                    FormasPagamento formasPagamento = new FormasPagamento();
                    List<FormaPagamento> listaFormasPagamento = new List<FormaPagamento>();
                    listaFormasPagamento = formasPagamento.CarregarFormasPagamento();

                    checkboxFormaPagamento.Items.Clear();
                    for (int indice = 0; indice < listaFormasPagamento.Count; indice++)
                    {
                        checkboxFormaPagamento.Items.Add(new ListItem(listaFormasPagamento[indice].Nome, listaFormasPagamento[indice].Codigo.ToString()));
                    }
                    #endregion


                    #region Emblemas
                    Emblemas emblemas = new Emblemas();
                    List<Emblema> listEmblemas = new List<Emblema>();
                    listEmblemas = emblemas.carregarEmblemas();

                    checkboxEmblemas.Items.Clear();
                    for (int indice = 0; indice < listEmblemas.Count; indice++)
                    {
                        checkboxEmblemas.Items.Add(new ListItem(listEmblemas[indice].Nome, listEmblemas[indice].Codigo.ToString()));
                    }
                    #endregion

                    string filtro = Request["p"];

                    string formasPagamentoSelecionado = "";
                    string emblemasSelecionada = "";
                    string EstadoSelecionado = Request["est"];

                    if (!String.IsNullOrEmpty(Request["fp"]))
                    {
                        formasPagamentoSelecionado = Request["fp"].Substring(0, Request["fp"].Length - 1);
                    }
                    if (!String.IsNullOrEmpty(Request["e"]))
                    {
                        emblemasSelecionada = Request["e"].Substring(0, Request["e"].Length - 1);
                    }


                    string comando = $@"SELECT
                                            a.nm_email_autonomo AS '00 - Email',
                                            a.nm_autonomo AS '01 - Nome',
                                            a.nm_cpf AS '02 - CPF',
                                            a.nm_telefone AS '03 - Telefone',
                                            a.ds_comentario AS '04 - Descrição',
	                                        a.ic_congelado AS '05 - Congelado',
                                            a.img_perfil AS '06 - Imagem',
                                            c.cd_cidade AS '07 - Codigo Cidade',
                                            c.nm_cidade AS '08 - Nome Cidade',
                                            es.sg_estado AS '09 - Sigla Estado',
                                            es.nm_estado AS '10 - Nome Estado',
                                            p.cd_profissao AS '11 - Codigo profissao',
                                            p.nm_profissao AS '12 - Nome profissao',
                                            aa.cd_area_atuacao AS '13 - Codigo Área de Atuação',
                                            aa.nm_area_atuacao AS '14 - Nome Área de Atuação',
                                            Round(((SUM(AC.qt_avaliacao)) / COUNT(qt_avaliacao)), 2) AS '15 - Media Avaliação',
	                                        e.cd_emblema '16 - Codigo Emblema',
	                                        e.nm_emblema '17 - Nome Emblema'
                                        FROM
                                            AUTONOMO A
                                                join
                                            autonomo_profissao ap ON (a.nm_email_autonomo = ap.nm_email_autonomo)
                                                right join
                                            profissao p ON (ap.cd_profissao = p.cd_profissao)
                                                Join
                                            area_atuacao aa ON (p.cd_area_atuacao = aa.cd_area_atuacao)
                                                JOIN
                                            CIDADE C ON (a.cd_cidade = c.cd_cidade)
                                                join
                                            estado ES ON (c.sg_estado = es.sg_estado)
                                                left join
                                            avaliacao_categoria_avaliacao AC ON (A.nm_email_autonomo = AC.nm_email_autonomo AND
	                                        p.nm_profissao LIKE '{filtro}')
		                                        join emblema e
		                                        on(ap.cd_emblema = e.cd_emblema)
		                                        join autonomo_forma_pagamento afp
		                                        on (A.nm_email_autonomo = afp.nm_email_autonomo)
                                        WHERE p.nm_profissao like '{filtro}'";


                    if (!String.IsNullOrEmpty(formasPagamentoSelecionado))
                    {
                        string[] listaFormasSelecionadas = formasPagamentoSelecionado.Split(',');

                        if (listaFormasSelecionadas.Length > 0)
                        {
                            if (listaFormasSelecionadas.Length == 1)
                            {
                                comando += $@" AND (afp.cd_forma_pagamento = {listaFormasSelecionadas[0]})";
                            }
                            else
                            {
                                comando += $@" AND (afp.cd_forma_pagamento = {listaFormasSelecionadas[0]}";

                                for (int indice = 1; indice < listaFormasSelecionadas.Length; indice++)
                                {
                                    comando += $@" OR afp.cd_forma_pagamento = {listaFormasSelecionadas[indice]} ";
                                }
                                comando += ")";
                            }


                        }
                    }

                    if (!String.IsNullOrEmpty(emblemasSelecionada))
                    {
                        string[] listaEmblemasSelecionadas = emblemasSelecionada.Split(',');

                        if (listaEmblemasSelecionadas.Length > 0)
                        {
                            if (listaEmblemasSelecionadas.Length == 1)
                            {
                                comando += $@" AND (ap.cd_emblema = {listaEmblemasSelecionadas[0]})";
                            }
                            else
                            {
                                comando += $@" AND (ap.cd_emblema = {listaEmblemasSelecionadas[0]}";

                                for (int indice = 1; indice < listaEmblemasSelecionadas.Length; indice++)
                                {
                                    comando += $@" OR ap.cd_emblema  = {listaEmblemasSelecionadas[indice]} ";
                                }
                                comando += ")";
                            }
                        }
                    }

                    if (!String.IsNullOrEmpty(EstadoSelecionado))
                    {
                        if (EstadoSelecionado != "-1")
                            comando += $@" AND es.sg_estado = '{EstadoSelecionado}'";
                    }

                    comando += $@" GROUP BY a.nm_email_autonomo";



                    Autonomos autonomos = new Autonomos();
                    List<Autonomo> listaAutonomos = autonomos.CarregarAutonomosComFiltro(comando);

                    int i = 0;
                    if (listaAutonomos.Count > 0)
                    {
                        litResultados.Text = $@"<p class='titulo'>Resultados por <strong>“{filtro}”</strong></p>";
                        foreach (Autonomo autonomo in listaAutonomos)
                        {
                            if (autonomo.Congelado == false)
                            {
                                string arquivoImagem = "";
                                byte[] foto = autonomo.Foto;
                                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;
                                string avaliacao = "";
                              

                                if (autonomo.Avaliacao != 0)
                                {
                                    avaliacao = autonomo.Avaliacao.ToString().Replace(".", ",");
                                }
                                else
                                {
                                    avaliacao = "0,0";
                                }

                                litResultados.Text += $@"<div class='autonomosResultado'>
                                                                <a href = 'perfilAutonomo.aspx?a={autonomo.Email}&p={Request["p"]}&cp={Request["cp"]}' class='infoAutonomo'>
                                                                <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                                <div class='autonomo' qual='{i}'>
                                                                    <h3>{autonomo.Nome}</h3>
                                                                    <p class='descricao'>{autonomo.Comentario}...</p>
                                                                    <div class='avaliacao'>
                                                                        <div class='barra' valor='{avaliacao}'>
                                                                            <div></div>
                                                                        </div>
                                                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                                    </div>
                                                                </a>";


                                if (Session["login"] != null)
                                {
                                    Favoritos favoritos = new Favoritos();
                                    List<Autonomo> listaFavoritos = new List<Autonomo>();
                                    listaFavoritos = favoritos.CarregarFavoritos(emailCliente);

                                    if (favoritos.VerificaFavorito(emailCliente, autonomo.Email))
                                    {
                                        litResultados.Text += $@"<figure class='coracoesVazados escondido' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                    <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                    }
                                    else
                                    {
                                        litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                    <figure class='coracoesPreenchidos  escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                    }


                                    litResultados.Text += $@"<input type='hidden' id='identificadorAutonomo' value='{autonomo.Email}'>";

                                    i++;
                                }
                                else
                                {
                                    litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                              <figure class='coracoesPreenchidos  escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                }

                                litResultados.Text += $@"</div> 
                                                    </div>";
                            }
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
                else
                {
                    string filtro = Request["p"];

                    #region Estados

                    Estados estados = new Estados();
                    List<Estado> listEstados = new List<Estado>();
                    listEstados = estados.CarregarEstados();

                    ddlEstado.Items.Add(new ListItem("-- Selecione --", "-1"));

                    for (int indice = 0; indice < listEstados.Count; indice++)
                    {
                        string sigla = listEstados[indice].Sigla.ToString();
                        string nome = listEstados[indice].Nome;
                        ddlEstado.Items.Add(new ListItem(nome, sigla));
                    }

                    #endregion

                    #region Formas de pagamento
                    FormasPagamento formasPagamento = new FormasPagamento();
                    List<FormaPagamento> listaFormasPagamento = new List<FormaPagamento>();
                    listaFormasPagamento = formasPagamento.CarregarFormasPagamento();

                    checkboxFormaPagamento.Items.Clear();
                    for (int indice = 0; indice < listaFormasPagamento.Count; indice++)
                    {
                        checkboxFormaPagamento.Items.Add(new ListItem(listaFormasPagamento[indice].Nome, listaFormasPagamento[indice].Codigo.ToString()));

                    }
                    #endregion

                    #region Emblemas
                    Emblemas emblemas = new Emblemas();
                    List<Emblema> listEmblemas = new List<Emblema>();
                    listEmblemas = emblemas.carregarEmblemas();

                    checkboxEmblemas.Items.Clear();
                    for (int indice = 0; indice < listEmblemas.Count; indice++)
                    {
                        checkboxEmblemas.Items.Add(new ListItem(listEmblemas[indice].Nome, listEmblemas[indice].Codigo.ToString()));
                    }
                    #endregion

                    Autonomos autonomos = new Autonomos();
                    List<Autonomo> listaAutonomos = autonomos.CarregarAutonomos(filtro);

                    int i = 0;
                    if (listaAutonomos.Count > 0)
                    {
                        litResultados.Text = $@"<p class='titulo'>Resultados por <strong>“{filtro}”</strong></p>";
                        foreach (Autonomo autonomo in listaAutonomos)
                        {
                            if (autonomo.Congelado == false)
                            {
                                string arquivoImagem = "";
                                byte[] foto = autonomo.Foto;
                                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;
                                string avaliacao = "";

                                if (autonomo.Avaliacao != 0)
                                {
                                    avaliacao = autonomo.Avaliacao.ToString().Replace(".", ",");
                                }
                                else
                                {
                                    avaliacao = "0,0";
                                }

                                litResultados.Text += $@"<div class='autonomosResultado'>
                                                            <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                                <div class='autonomo' qual='{i}'>
                                                                    <a href = 'perfilAutonomo.aspx?a={autonomo.Email}&p={Request["p"]}&cp={Request["cp"]}' class='infoAutonomo'>
                                                                        <h3>{autonomo.Nome}</h3>
                                                                        <p class='descricao'>{autonomo.Comentario}</p>
                                                                        <div class='avaliacao'>
                                                                            <div class='barra' valor='{avaliacao}'>
                                                                                <div></div>
                                                                            </div>
                                                                            <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                                        </div>
                                                                    </a>";

                                if (Session["login"] != null)
                                {
                                    Favoritos favoritos = new Favoritos();
                                    List<Autonomo> listaFavoritos = new List<Autonomo>();
                                    listaFavoritos = favoritos.CarregarFavoritos(emailCliente);

                                    if (favoritos.VerificaFavorito(emailCliente, autonomo.Email))
                                    {
                                        litResultados.Text += $@"<figure class='coracoesVazados escondido' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                    <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                    }
                                    else
                                    {
                                        litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                    <figure class='coracoesPreenchidos  escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                    }

                                    litResultados.Text += $@"<input type='hidden' id='identificadorAutonomo' value='{autonomo.Email}'>";

                                    i++;
                                }
                                else
                                {
                                    litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                              <figure class='coracoesPreenchidos  escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>";
                                }

                                litResultados.Text += $@"</div>
                                                    </div>";
                            }
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
            else
            {

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

        protected void Aplicar_Click(object sender, EventArgs e)
        {
            string formasPagamento = "";
            string profissao = Request["p"];
            string emblemas = "";
            string estadoSelecionado = ddlEstado.SelectedValue;

            if (checkboxFormaPagamento.Items.Count > 0)
            {
                for (int i = 0; i < checkboxFormaPagamento.Items.Count; i++)
                {
                    if (checkboxFormaPagamento.Items[i].Selected)
                    {
                        formasPagamento += checkboxFormaPagamento.Items[i].Value + ",";
                    }
                }
            }
            if (checkboxEmblemas.Items.Count > 0)
            {
                for (int i = 0; i < checkboxEmblemas.Items.Count; i++)
                {
                    if (checkboxEmblemas.Items[i].Selected)
                    {
                        emblemas += checkboxEmblemas.Items[i].Value + ",";
                    }
                }
            }

            Response.Redirect($@"buscaAutonomo.aspx?p={profissao}&cp={Request["cp"]}&est={estadoSelecionado}&fp={formasPagamento}&e={emblemas}");
        }
    }
}