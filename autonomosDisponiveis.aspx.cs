    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class autonomosDisponiveis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";

            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
            }

            Favoritos favoritos = new Favoritos();
            List<Autonomo> listaFavoritos = new List<Autonomo>();
            listaFavoritos = favoritos.CarregarFavoritos(emailCliente);

            Cliente c = new Cliente();
            (Autonomo autonomo, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

            arquivoImagem = "";
            foto = cliente.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";

            Literal litIdentificador = new Literal();
            litIdentificador.Text = $@"<input type='hidden' id='identificadorAnuncio' value='{Request["ca"]}'>";

            litIdentificadorCliente.Text = $@"<input type='hidden' id='identificadorCliente' value='{emailCliente}'>";
       

            if (Session != null)
            {
                if (!IsPostBack)
                {
                    if ((!String.IsNullOrEmpty(Request["ca"])) && (!String.IsNullOrEmpty(Request["b"])))
                    {
                        if ((!String.IsNullOrEmpty(Request["fp"])) || (!String.IsNullOrEmpty(Request["e"])))
                        {
                            string busca = Request["b"].ToString();
                            string codigoAnuncio = Request["ca"];
                            inputBuscaAutonomos.Text = busca.Substring(0, busca.Length - 1);
                            litResultados.Text = "";

                            string formasPagamentoSelecionado = "";
                            string emblemasSelecionada = "";

                            if (!String.IsNullOrEmpty(Request["fp"]))
                            {
                                formasPagamentoSelecionado = Request["fp"].Substring(0, Request["fp"].Length - 1);
                            }
                            if (!String.IsNullOrEmpty(Request["e"]))
                            {
                                emblemasSelecionada = Request["e"].Substring(0, Request["e"].Length - 1);
                            }

                            string comando = $@"select DISTINCT
                                                    AU.NM_EMAIL_AUTONOMO
                                                from
                                                    proposta_anuncio pa
                                                        join
                                                    anuncio a ON (pa.cd_anuncio = a.cd_anuncio)
                                                        join
                                                    cliente c ON (pa.nm_email_cliente = c.nm_email_cliente)
                                                        join
                                                    autonomo au ON (pa.nm_email_autonomo = au.nm_email_autonomo)
                                                        join
                                                    autonomo_profissao ap ON (pa.nm_email_autonomo= ap.nm_email_autonomo)
                                                        join
                                                    autonomo_forma_pagamento af ON (pa.nm_email_autonomo = af.nm_email_autonomo)
                                                where
                                                    pa.nm_email_cliente = '{emailCliente}'
                                                        and pa.cd_anuncio = {codigoAnuncio}
                                                        and au.nm_autonomo like '{busca}'";


                            if (!String.IsNullOrEmpty(emblemasSelecionada))
                            {
                                string[] listaEmblemasSelecionadas = emblemasSelecionada.Split(',');

                                if (listaEmblemasSelecionadas.Length > 0)
                                {
                                    if (listaEmblemasSelecionadas.Length == 1)
                                    {
                                        comando += $@" AND (AP.CD_EMBLEMA = {listaEmblemasSelecionadas[0]})";

                                    }
                                    else
                                    {
                                        comando += $@" AND (AP.CD_EMBLEMA = {listaEmblemasSelecionadas[0]}";

                                        for (int indice = 1; indice < listaEmblemasSelecionadas.Length; indice++)
                                        {
                                            comando += $@" OR AP.CD_EMBLEMA  = {listaEmblemasSelecionadas[indice]} ";

                                        }
                                        comando += ")";
                                    }


                                }
                            }

                            if (!String.IsNullOrEmpty(formasPagamentoSelecionado))
                            {
                                string[] listaFormasSelecionadas = formasPagamentoSelecionado.Split(',');

                                if (listaFormasSelecionadas.Length > 0)
                                {
                                    if (listaFormasSelecionadas.Length == 1)
                                    {
                                        comando += $@" AND (AF.CD_FORMA_PAGAMENTO = {listaFormasSelecionadas[0]})";

                                    }
                                    else
                                    {
                                        comando += $@" AND (AF.CD_FORMA_PAGAMENTO = {listaFormasSelecionadas[0]}";

                                        for (int indice = 1; indice < listaFormasSelecionadas.Length; indice++)
                                        {
                                            comando += $@" OR AF.CD_FORMA_PAGAMENTO = {listaFormasSelecionadas[indice]} ";

                                        }
                                        comando += ")";
                                    }


                                }
                            }

                            litResultados.Text = "";
                            Propostas propostas = new Propostas();
                            List<Autonomo> candidatos = propostas.CarregarCandidatosComFiltro(comando);

                            int i = 0;
                            if (candidatos.Count > 0)
                            {
                                litResultados.Text = $@"<div class='resultados'>";
                                foreach (Autonomo candidato in candidatos)
                                {
                                    arquivoImagem = "";
                                    foto = candidato.Foto;
                                    base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                    arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                    decimal avaliacao = candidato.CarregarAvaliacao(candidato.Email);

                                    litResultados.Text += $@"<div class='autonomosResultado'>
                                    <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                    <input type='hidden' id='identificadorAnuncio' value='{Request["ca"]}'>
                                    <div class='autonomo'>
                                        <input type='hidden' id='identificadorAutonomo' value='{candidato.Email}'>
                                        <a href = 'perfilAutonomo.aspx?a={candidato.Email}&p={candidato.Profissoes[0].Nome}&cp={candidato.Profissoes[0].Codigo}' class='infoAutonomo'>
                                            <h3>{candidato.Nome}</h3>
                                            <p class='descricao'>{candidato.Comentario}...</p>
                                            <div class='avaliacaoEstrelas'>
                                                <div class='barra' valor='{avaliacao.ToString().Replace(",",".")}'>
                                                    <div></div>
                                                </div>
                                                <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                            </div>
                                        </a>

                                           <div class='coracoesEButton'>
                                                <button id='btnContratar' value='{candidato.Email}'>Contratar</button>
                                                <input type ='hidden' value='{candidato.Email}'>";

                                    if (favoritos.VerificaFavorito(emailCliente, candidato.Email))
                                    {
                                        litResultados.Text += $@"
                                                                            <figure class='coracoesVazados escondido' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                            <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>

                                                           </div>
                                                        </div>
                                                 </div>";
                                    }
                                    else
                                    {
                                        litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                             <figure class='coracoesPreenchidos escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                         </div> 
                                                        </div>
                                                 </div>";
                                    }

                                    i++;
                                }
                                litResultados.Text += $@"</div>";
                            }
                            else
                            {
                                litSemAutonomos.Text = $@"<section class=SemAutonomos'>
                                                    <figure><img src='çççimagens/elementos/Elemento26.png' alt=''></figure>
                                                    <h2>Parece que não há ninguém por aqui...</h2>
                                                    <p>Os autônomos que você selecionou ainda não retornaram sua solicitação, tente novamente mais tarde</p>
                                                  </section>";
                            }

                        }
                        else
                        {
                            string busca = Request["b"].ToString();
                            inputBuscaAutonomos.Text = busca.Substring(0, busca.Length - 1);
                            litResultados.Text = "";
                            Propostas propostas = new Propostas();
                            List<Autonomo> candidatos = propostas.CarregarCandidatosComBusca(Request["ca"], Session["email"].ToString(), busca);

                            int i = 0;
                            if (candidatos.Count > 0)
                            {
                                litResultados.Text = $@"<div class='resultados'>";
                                foreach (Autonomo candidato in candidatos)
                                {
                                    arquivoImagem = "";
                                    foto = candidato.Foto;
                                    base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                    arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                    decimal avaliacao = candidato.CarregarAvaliacao(candidato.Email);

                                    litResultados.Text += $@"<div class='autonomosResultado'>
                                    <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                    <input type='hidden' id='identificadorAnuncio' value='{Request["ca"]}'>
                                    <div class='autonomo'>
                                        <input type='hidden' id='identificadorAutonomo' value='{candidato.Email}'>
                                        <a href = 'perfilAutonomo.aspx?a={candidato.Email}&p={candidato.Profissoes[0].Nome}&cp={candidato.Profissoes[0].Codigo}' class='infoAutonomo'>
                                            <h3>{candidato.Nome}</h3>
                                            <p class='descricao'>{candidato.Comentario}...</p>
                                            <div class='avaliacaoEstrelas'>
                                                <div class='barra' valor='{avaliacao.ToString().Replace(",",".")}'>
                                                    <div></div>
                                                </div>
                                                <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                            </div>
                                        </a>

                                           <div class='coracoesEButton'>
                                                <button id='btnContratar' value='{candidato.Email}'>Contratar</button>
                                                <input type ='hidden' value='{candidato.Email}'>";

                                    if (favoritos.VerificaFavorito(emailCliente, candidato.Email))
                                    {
                                        litResultados.Text += $@"
                                                                            <figure class='coracoesVazados escondido' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                            <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>

                                                           </div>
                                                        </div>
                                                 </div>";
                                    }
                                    else
                                    {
                                        litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                             <figure class='coracoesPreenchidos escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                         </div> 
                                                        </div>
                                                 </div>";
                                    }

                                    i++;
                                }
                                litResultados.Text += $@"</div>";
                            }
                            else
                            {
                                litSemAutonomos.Text = $@"<section class='SemAutonomos'>
                                                    <figure><img src='imagens/elementos/Elemento26.png' alt=''></figure>
                                                    <h2>Parece que não há ninguém por aqui...</h2>
                                                    <p>A pesquisa não corresponde ao nome dos autônomos candidatados</p>
                                                  </section>";
                            }
                        }

                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(Request["ca"]))
                        {
                            if ((!String.IsNullOrEmpty(Request["fp"])) || (!String.IsNullOrEmpty(Request["e"])))
                            {
                                string codigoAnuncio = Request["ca"];
                                litResultados.Text = "";

                                string formasPagamentoSelecionado = "";
                                string emblemasSelecionada = "";

                                if (!String.IsNullOrEmpty(Request["fp"]))
                                {
                                    formasPagamentoSelecionado = Request["fp"].Substring(0, Request["fp"].Length - 1);
                                }
                                if (!String.IsNullOrEmpty(Request["e"]))
                                {
                                    emblemasSelecionada = Request["e"].Substring(0, Request["e"].Length - 1);
                                }

                                string comando = $@"select DISTINCT
                                                    AU.NM_EMAIL_AUTONOMO
                                                from
                                                    proposta_anuncio pa
                                                        join
                                                    anuncio a ON (pa.cd_anuncio = a.cd_anuncio)
                                                        join
                                                    cliente c ON (pa.nm_email_cliente = c.nm_email_cliente)
                                                        join
                                                    autonomo au ON (pa.nm_email_autonomo = au.nm_email_autonomo)
                                                        join
                                                    autonomo_profissao ap ON (pa.nm_email_autonomo = ap.nm_email_autonomo)
                                                        join
                                                    autonomo_forma_pagamento af ON (pa.nm_email_autonomo = af.nm_email_autonomo)
                                                where
                                                    pa.nm_email_cliente = '{emailCliente}'
                                                        and pa.cd_anuncio = {codigoAnuncio}";


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

                                if (!String.IsNullOrEmpty(formasPagamentoSelecionado))
                                {
                                    string[] listaFormasSelecionadas = formasPagamentoSelecionado.Split(',');

                                    if (listaFormasSelecionadas.Length > 0)
                                    {
                                        if (listaFormasSelecionadas.Length == 1)
                                        {
                                            comando += $@" AND (af.cd_forma_pagamento = {listaFormasSelecionadas[0]})";

                                        }
                                        else
                                        {
                                            comando += $@" AND (af.cd_forma_pagamento = {listaFormasSelecionadas[0]}";

                                            for (int indice = 1; indice < listaFormasSelecionadas.Length; indice++)
                                            {
                                                comando += $@" OR af.cd_forma_pagamento = {listaFormasSelecionadas[indice]} ";

                                            }
                                            comando += ")";
                                        }


                                    }
                                }

                                litResultados.Text = "";
                                Propostas propostas = new Propostas();
                                List<Autonomo> candidatos = propostas.CarregarCandidatosComFiltro(comando);
                                

                                int i = 0;
                                if (candidatos.Count > 0)
                                {
                                    litResultados.Text = $@"<div class='resultados'>";
                                    foreach (Autonomo candidato in candidatos)
                                    {
                                        arquivoImagem = "";
                                        foto = candidato.Foto;
                                        base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                        decimal avaliacao = candidato.CarregarAvaliacao(candidato.Email);

                                        litResultados.Text += $@"<div class='autonomosResultado'>
                                        <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                        <input type='hidden' id='identificadorAnuncio' value='{Request["ca"]}'>
                                        <div class='autonomo'>
                                            <input type='hidden' id='identificadorAutonomo' value='{candidato.Email}'>
                                            <a href = 'perfilAutonomo.aspx?a={candidato.Email}&p={candidato.Profissoes[0].Nome}&cp={candidato.Profissoes[0].Codigo}' class='infoAutonomo'>
                                                <h3>{candidato.Nome}</h3>
                                                <p class='descricao'>{candidato.Comentario}...</p>
                                                <div class='avaliacaoEstrelas'>
                                                    <div class='barra' valor='{avaliacao.ToString().Replace(",",".")}'>
                                                        <div></div>
                                                    </div>
                                                    <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                </div>
                                            </a>

                                               <div class='coracoesEButton'>
                                                    <button id='btnContratar' value'{candidato.Email}'>Contratar</button>
                                                    <input type ='hidden' value='{candidato.Email}'>";

                                        if (favoritos.VerificaFavorito(emailCliente, candidato.Email))
                                        {
                                            litResultados.Text += $@"
                                                                            <figure class='coracoesVazados escondido' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                            <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>

                                                           </div>
                                                        </div>
                                                 </div>";
                                        }
                                        else
                                        {
                                            litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                             <figure class='coracoesPreenchidos escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                         </div> 
                                                        </div>
                                                 </div>";
                                        }

                                        i++;
                                    }
                                    litResultados.Text += $@"</div>";
                                }
                                else
                                {
                                    litSemAutonomos.Text = $@"<section class='SemAutonomos'>
                                                    <figure><img src='imagens/elementos/Elemento26.png' alt=''></figure>
                                                    <h2>Parece que não há ninguém por aqui...</h2>
                                                    <p>Os autônomos que você selecionou ainda não retornaram sua solicitação, tente novamente mais tarde</p>
                                                  </section>";
                                }

                            }
                            else
                            {
                                litResultados.Text = "";
                                Propostas propostas = new Propostas();
                                List<Autonomo> candidatos = propostas.CarregarCandidatos(Request["ca"], Session["email"].ToString());

                                int i = 0;
                                if (candidatos.Count > 0)
                                {
                                    litResultados.Text = $@"<div class='resultados'>";
                                    foreach (Autonomo candidato in candidatos)
                                    {
                                        arquivoImagem = "";
                                        foto = candidato.Foto;
                                        base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                        arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                        decimal avaliacao = candidato.CarregarAvaliacao(candidato.Email);

                                        litResultados.Text += $@"<div class='autonomosResultado'>
                                                                <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                                <input type='hidden' id='identificadorAnuncio' value='{Request["ca"]}'>
                                                                <div class='autonomo'>
                                                                     <input type='hidden' id='identificadorAutonomo' value='{candidato.Email}'>
                                                                    <a href = 'perfilAutonomo.aspx?a={candidato.Email}&p={candidato.Profissoes[0].Nome}&cp={candidato.Profissoes[0].Codigo}' class='infoAutonomo'>
                                                                        <h3>{candidato.Nome}</h3>
                                                                        <p class='descricao'>{candidato.Comentario}...</p>
                                                                        <div class='avaliacaoEstrelas'>
                                                                            <div class='barra' valor='{avaliacao.ToString().Replace(",",".")}'>
                                                                                <div></div>
                                                                            </div>
                                                                            <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                                        </div>
                                                                    </a>

                                                                       <div class='coracoesEButton'>
                                                                            <button id='btnContratar' value'{candidato.Email}'>Contratar</button>
                                                                            <input type ='hidden' value='{candidato.Email}'>";

                                        if (favoritos.VerificaFavorito(emailCliente, candidato.Email))
                                                {
                                                   litResultados.Text += $@"
                                                                            <figure class='coracoesVazados escondido' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                            <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>

                                                           </div>
                                                        </div>
                                                 </div>";
                                                }
                                                else
                                                {
                                                    litResultados.Text += $@"<figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                                             <figure class='coracoesPreenchidos escondido' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                         </div> 
                                                        </div>
                                                 </div>";
                                                }

                                        i++;
                                    }
                                    litResultados.Text += $@"</div>";
                                }
                                else
                                {
                                    litSemAutonomos.Text = $@"<section class='SemAutonomos'>
                                                    <figure><img src='imagens/elementos/Elemento26.png' alt=''></figure>
                                                    <h2>Parece que não há ninguém por aqui...</h2>
                                                    <p>Os autônomos que você selecionou ainda não retornaram sua solicitação, tente novamente mais tarde</p>
                                                  </section>";
                                }
                            }


                        }
                    }


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
                }




            }
            else
            {
                Response.Redirect("erro.aspx");
            }
        }

        protected void btnBuscaAutonomos_Click(object sender, ImageClickEventArgs e)
        {
            string busca = inputBuscaAutonomos.Text + "%";
            if (!String.IsNullOrEmpty(busca))
            {
                Response.Redirect($@"autonomosDisponiveis.aspx?ca={Request["ca"]}&b={busca}");
            }
        }

        protected void Aplicar_Click(object sender, EventArgs e)
        {
            string formasPagamento = "";
            string emblemas = "";

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

            if (!String.IsNullOrEmpty(inputBuscaAutonomos.Text))
            {
                string busca = inputBuscaAutonomos.Text + "%";
                Response.Redirect($@"autonomosDisponiveis.aspx?ca={Request["ca"]}&b={busca}&fp={formasPagamento}&e={emblemas}");
            }
            else
            {
                Response.Redirect($@"autonomosDisponiveis.aspx?ca={Request["ca"]}&fp={formasPagamento}&e={emblemas}");
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