using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class AutonomosFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
                Literal litIdentificador = new Literal();
                litIdentificador.Text = $"<input type='hidden' id='identificadorCliente' value='{emailCliente}'>";
                Form.Controls.Add(litIdentificador);
            }


            if (!IsPostBack)
            {
                Cliente c = new Cliente();
                (Autonomo autonomo, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

                string arquivoImagem = "";
                byte[] foto = cliente.Foto;
                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";



                if (!String.IsNullOrEmpty(Request["b"]))
                {
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

                        string busca = Request["b"];
                        inputBuscaFavoritos.Text = busca.Substring(0, busca.Length - 1);

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


                        string comando = $@"Select distinct f.nm_email_autonomo from favorito f
			                                    join autonomo a
				                                    on (f.nm_email_autonomo = a.nm_email_autonomo)
			                                    join autonomo_profissao ap
				                                    on (a.nm_email_autonomo = ap.nm_email_autonomo)
			                                    join autonomo_forma_pagamento afp
				                                    on (a.nm_email_autonomo = afp.nm_email_autonomo)
			                                    join emblema e
				                                    on (ap.cd_emblema = e.cd_emblema)
			                                    join cidade c
				                                    on (a.cd_cidade = c.cd_cidade)
			                                    join estado es
				                                    on (c.sg_estado = es.sg_estado)
			                                    where nm_email_cliente = '{emailCliente}' and a.nm_autonomo like '{busca}'";


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

                        Favoritos favoritos = new Favoritos();
                        List<Autonomo> listaFavoritos = favoritos.CarregarFavoritosComFiltroEBusca(comando);

                        if (listaFavoritos.Count > 0)
                        {
                            litResultados.Text = $@"<div class='resultados'>";
                            int i = 0;
                            foreach (Autonomo autonomoo in listaFavoritos)
                            {
                                arquivoImagem = "";
                                foto = autonomoo.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                decimal avaliacao = autonomoo.CarregarAvaliacao(autonomoo.Email);

                                litResultados.Text += $@"<div class='autonomosResultado'>
                                                <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                <div class='autonomo'>
                                                    <a href = 'perfilAutonomo.aspx?a={autonomoo.Email}&p={autonomoo.Profissoes[0].Nome}&cp={autonomoo.Profissoes[0].Codigo}' class='infoAutonomo'>
                                                    <div class='infoAutonomo'>
                                                        <h3>{autonomoo.Nome}</h3>
                                                        <p class='descricao'>{autonomoo.Comentario}</p>
                                                        <div class='avaliacaoEstrelas'>
                                                            <div class='barra' valor='{avaliacao.ToString().Replace("," , ".")}'>
                                                                <div></div>
                                                            </div>
                                                            <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                        </div>
                                                    </div>
                                                    </a>
                                                    <figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                    <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                    <input type='hidden' id='identificadorAutonomo' value='{autonomoo.Email}'>
                                                </div>
                                            </div>";
                                i++;
                            }
                            litResultados.Text += $@"</div>";
                        }
                        else
                        {
                            litSemFavoritos.Text = $@"<section class='SemFavoritos'>
                                                <figure>
                                                    <img src='imagens/elementos/Elemento24.svg' alt=''>
                                                </figure>
                                                <h2>Sem corações por aqui...</h2>
                                                <p>Parece que você ainda não favoritou ninguém com estas especificações, que tal procurar por outra pessoa?</p>
                                            </section>";
                        }
                    }
                    else
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

                        string busca = Request["b"].ToString();
                        inputBuscaFavoritos.Text = busca.Substring(0, busca.Length - 1);
                        Favoritos favoritos = new Favoritos();
                        List<Autonomo> listaFavoritos = favoritos.CarregarFavoritosComBusca(emailCliente, busca);

                        if (listaFavoritos.Count > 0)
                        {
                            litResultados.Text = $@"<div class='resultados'>";
                            int i = 0;
                            foreach (Autonomo autonomoo in listaFavoritos)
                            {
                                arquivoImagem = "";
                                foto = autonomoo.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                decimal avaliacao = autonomoo.CarregarAvaliacao(autonomoo.Email);

                                litResultados.Text += $@"<div class='autonomosResultado'>
                                                <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                <div class='autonomo'>
                                                    <a href = 'perfilAutonomo.aspx?a={autonomoo.Email}&p={autonomoo.Profissoes[0].Nome}&cp={autonomoo.Profissoes[0].Codigo}' class='infoAutonomo'>
                                                    <div class='infoAutonomo'>
                                                        <h3>{autonomoo.Nome}</h3>
                                                        <p class='descricao'>{autonomoo.Comentario}</p>
                                                        <div class='avaliacaoEstrelas'>
                                                            <div class='barra' valor='{avaliacao.ToString().Replace(",",".")}'>
                                                                <div></div>
                                                            </div>
                                                            <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                        </div>
                                                    </div>
                                                    </a>
                                                    <figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                    <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                    <input type='hidden' id='identificadorAutonomo' value='{autonomoo.Email}'>
                                                </div>
                                            </div>";

                                i++;
                            }
                            litResultados.Text += $@"</div>";
                        }
                        else
                        {
                            litSemFavoritos.Text = $@"<section class='SemFavoritos'>
                                                <figure>
                                                    <img src='imagens/elementos/Elemento24.svg' alt=''>
                                                </figure>
                                                <h2>Sem corações por aqui...</h2>
                                                <p>Parece que você ainda não favoritou ninguém com este nome, que tal procurar por outra pessoa?</p>
                                            </section>";
                        }
                    }
                }
                else
                {
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

                        string busca = Request["b"];

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


                        string comando = $@"Select distinct f.nm_email_autonomo from favorito f
			                                    join autonomo a
				                                    on (f.nm_email_autonomo = a.nm_email_autonomo)
			                                    join autonomo_profissao ap
				                                    on (a.nm_email_autonomo = ap.nm_email_autonomo)
			                                    join autonomo_forma_pagamento afp
				                                    on (a.nm_email_autonomo = afp.nm_email_autonomo)
			                                    join emblema e
				                                    on (ap.cd_emblema = e.cd_emblema)
			                                    join cidade c
				                                    on (a.cd_cidade = c.cd_cidade)
			                                    join estado es
				                                    on (c.sg_estado = es.sg_estado)
			                                    where nm_email_cliente = '{emailCliente}'";


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

                        Favoritos favoritos = new Favoritos();
                        List<Autonomo> listaFavoritos = favoritos.CarregarFavoritosComFiltro(comando);

                        if (listaFavoritos.Count > 0)
                        {
                            litResultados.Text = $@"<div class='resultados'>";
                            int i = 0;
                            foreach (Autonomo autonomoo in listaFavoritos)
                            {
                                arquivoImagem = "";
                                foto = autonomoo.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                decimal avaliacao = autonomoo.CarregarAvaliacao(autonomoo.Email);

                                litResultados.Text += $@"<div class='autonomosResultado'>
                                                <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                <div class='autonomo'>
                                                    <a href = 'perfilAutonomo.aspx?a={autonomoo.Email}&p={autonomoo.Profissoes[0].Nome}&cp={autonomoo.Profissoes[0].Codigo}' class='infoAutonomo'>
                                                    <div class='infoAutonomo'>
                                                        <h3>{autonomoo.Nome}</h3>
                                                        <p class='descricao'>{autonomoo.Comentario}</p>
                                                        <div class='avaliacaoEstrelas'>
                                                            <div class='barra' valor='{avaliacao.ToString().Replace(",",".")}'>
                                                                <div></div>
                                                            </div>
                                                            <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                        </div>
                                                    </div>
                                                    </a>    
                                                    <figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                    <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                    <input type='hidden' id='identificadorAutonomo' value='{autonomoo.Email}'>
                                                </div>
                                            </div>";

                                i++;
                            }
                            litResultados.Text += $@"</div>";
                        }
                        else
                        {
                            litSemFavoritos.Text = $@"<section class='SemFavoritos'>
                                                <figure>
                                                    <img src='imagens/elementos/Elemento24.svg' alt=''>
                                                </figure>
                                                <h2>Sem corações por aqui...</h2>
                                                <p>Parece que você ainda não favoritou ninguém com estas especificações, que tal procurar por outra pessoa?</p>
                                            </section>";
                        }
                    }
                    else
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
                        Favoritos favoritos = new Favoritos();
                        List<Autonomo> listaFavoritos = favoritos.CarregarFavoritos(emailCliente);


                        if (listaFavoritos.Count > 0)
                        {
                            litResultados.Text = $@"<div class='resultados'>";
                            int i = 0;
                            foreach (Autonomo autonomoo in listaFavoritos)
                            {
                                arquivoImagem = "";
                                foto = autonomoo.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                decimal avaliacao = autonomoo.CarregarAvaliacao(autonomoo.Email);

                                litResultados.Text += $@"<div class='autonomosResultado'>
                                                <div class='imgAutonomo' STYLE='background-image: url({arquivoImagem})'></div>
                                                <div class='autonomo'>
                                                    <a href = 'perfilAutonomo.aspx?a={autonomoo.Email}&p={autonomoo.Profissoes[0].Nome}&cp={autonomoo.Profissoes[0].Codigo}' class='infoAutonomo'>
                                                    <div class='infoAutonomo'>
                                                        <h3>{autonomoo.Nome}</h3>
                                                        <p class='descricao'>{autonomoo.Comentario}</p>
                                                        <div class='avaliacaoEstrelas'>
                                                            <div class='barra' valor='{avaliacao.ToString().Replace(",", ".")}'>
                                                                <div></div>
                                                            </div>
                                                            <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                        </div>
                                                    </div>
                                                    </a>
                                                    <figure class='coracoesVazados' qual='{i}'><img src='imagens/icones/mdi_heart-outline.png' alt=''></figure>
                                                    <figure class='coracoesPreenchidos' qual='{i}'><img src='imagens/icones/coracao_preenchido.png' alt=''></figure>
                                                    <input type='hidden' id='identificadorAutonomo' value='{autonomoo.Email}'>
                                                </div>
                                            </div>";

                                i++;
                            }
                            litResultados.Text += $@"</div>";
                        }
                        else
                        {
                            litSemFavoritos.Text = $@"<section class='SemFavoritos'>
                                                <figure>
                                                    <img src='imagens/elementos/Elemento24.svg' alt=''>
                                                </figure>
                                                <h2>Sem corações por aqui...</h2>
                                                <p>Parece que você ainda não favoritou ninguém, que tal dar uma pesquisada e encontrar a pessoa certa para a sua necessidade?</p>
                                            </section>";
                        }
                    }
                }
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

            if (!String.IsNullOrEmpty(inputBuscaFavoritos.Text))
            {
                string busca = inputBuscaFavoritos.Text + "%";
                Response.Redirect($@"AutonomosFavoritos.aspx?b={busca}&est={estadoSelecionado}&fp={formasPagamento}&e={emblemas}");
            }
            else
            {
                Response.Redirect($@"AutonomosFavoritos.aspx?est={estadoSelecionado}&fp={formasPagamento}&e={emblemas}");
            }

        }

        protected void btnBuscaFavoritos_Click(object sender, ImageClickEventArgs e)
        {
            string busca = inputBuscaFavoritos.Text;
            if (!String.IsNullOrEmpty(busca))
            {
                busca = inputBuscaFavoritos.Text + "%";
                Response.Redirect($@"autonomosFavoritos.aspx?b={busca}");
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