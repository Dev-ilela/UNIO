using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class propostasRecebidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginAutonomo = "";
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";

            if (Session["login"] != null)
            {
                loginAutonomo = Session["email"].ToString();
            }

            Autonomo a = new Autonomo();
            (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(loginAutonomo, Session["senha"].ToString());

            foto = autonomo.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            ddlProfissao.Items.Add(new ListItem(autonomo.Profissoes[0].Nome, autonomo.Profissoes[0].Codigo.ToString()));

            ddlProfissao.SelectedIndex = 0;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";

            #region Prazos
            Prazos prazos = new Prazos();
            List<Prazo> listPrazos = new List<Prazo>();
            listPrazos = prazos.CarregarPrazos();

            selectPrazo.Items.Add(new ListItem("-- Selecione --", "-1"));

            for (int indice = 0; indice < listPrazos.Count; indice++)
            {
                string codigo = listPrazos[indice].Codigo.ToString();
                string nome = listPrazos[indice].Nome;
                selectPrazo.Items.Add(new ListItem(nome, codigo));
            }
            #endregion

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

            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request["s"]))
                {
                    if ((!String.IsNullOrEmpty(Request["RouA"])) || (!String.IsNullOrEmpty(Request["p"])) || (!String.IsNullOrEmpty(Request["est"])))
                    {
                        string recenteOuAntigo = Request["RouA"];
                        string prazoSelecionado = Request["p"];
                        string EstadoSelecionado = Request["est"];

                        string comando = $@"SELECT DISTINCT
			                                    C.NM_EMAIL_CLIENTE AS '0 - Email', C.NM_CLIENTE AS '1 - Nome', 
			                                    C.NM_CPF AS '2 - CPF', C.NM_TELEFONE AS '3 - Telefone',
			                                    CD.CD_CIDADE AS '4 - Cd Cidade', CD.NM_CIDADE AS '5 - Nome Cidade',
			                                    AN.CD_ANUNCIO AS '6 - Cd Anuncio', AN.DT_PUBLICACAO AS '7 - Dt Publicação', 
			                                    AN.HR_PUBLICACAO AS '8 - Hr Publicação', AN.NM_TITULO AS '9 - Titulo',
			                                    AN.DS_ANUNCIO AS '10 - Descrição', AN.IC_OCULTO AS '11 - Oculto',
			                                    AA.CD_AREA_ATUACAO AS '12 - Cd Area de Atuação', AA.NM_AREA_ATUACAO AS '13 - Nome Area de Atuação', 
			                                    EA.CD_ESTADO_ANUNCIO AS '14 - Cd Status', EA.NM_ESTADO_ANUNCIO AS '15 - Nome Status',
			                                    PR.CD_PRAZO AS '16 - Cd Prazo', PR.NM_PRAZO AS '17 - Nome Prazo', C.IMG_PERFIL AS '18 - Imagem de Perfil'
			                                    FROM DESTINATARIO_ANUNCIO DA 
			                                    JOIN ANUNCIO AN
				                                    ON(AN.CD_ANUNCIO = DA.CD_ANUNCIO)
			                                    JOIN CLIENTE C
				                                    ON (AN.NM_EMAIL_CLIENTE = C.NM_EMAIL_CLIENTE)
			                                    JOIN CIDADE CD
				                                    ON (C.CD_CIDADE = CD.CD_CIDADE)
                                                JOIN ESTADO ES
													ON (CD.SG_ESTADO = ES.SG_ESTADO)
			                                    JOIN AREA_ATUACAO AA
				                                    ON (AN.CD_AREA_ATUACAO = AA.CD_AREA_ATUACAO)
			                                    JOIN PRAZO PR
				                                    ON(AN.CD_PRAZO = PR.CD_PRAZO)
			                                    JOIN PROFISSAO P
				                                    ON (AA.CD_AREA_ATUACAO = P.CD_AREA_ATUACAO)
			                                    JOIN AUTONOMO_PROFISSAO AP
				                                    ON (P.CD_PROFISSAO = AP.CD_PROFISSAO)
			                                    JOIN ESTADO_ANUNCIO EA
				                                    ON(AN.CD_ESTADO_ANUNCIO = EA.CD_ESTADO_ANUNCIO)
			                                    JOIN AUTONOMO A
				                                    ON (AP.NM_EMAIL_AUTONOMO = A.NM_EMAIL_AUTONOMO)
			                                    WHERE DA.NM_EMAIL_AUTONOMO = '{loginAutonomo}' AND AN.CD_ESTADO_ANUNCIO = 1";

                        if (!String.IsNullOrEmpty(prazoSelecionado))
                        {
                            int valor = int.Parse(prazoSelecionado);
                            if (valor > 0)
                                comando += $@" AND AN.CD_PRAZO = {prazoSelecionado}";
                        }

                        if (!String.IsNullOrEmpty(EstadoSelecionado))
                        {
                            if (EstadoSelecionado != "-1")
                                comando += $@" AND es.sg_estado = '{EstadoSelecionado}'";
                        }

                        if (!String.IsNullOrEmpty(recenteOuAntigo))
                        {
                            if (recenteOuAntigo == "Mais recente")
                            {
                                comando += $@" ORDER BY AN.DT_PUBLICACAO DESC";
                            }
                            else
                            {
                                comando += $@" ORDER BY AN.DT_PUBLICACAO";
                            }
                        }

                        Literal litIdentificador = new Literal();
                        litIdentificador.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}'>";
                        Form.Controls.Add(litIdentificador);

                        Anuncios anuncios = new Anuncios();
                        List<Anuncio> listAnuncios = anuncios.CarregarAnunciosPrivadosComFiltro(comando);

                        if (listAnuncios.Count < 1)
                        {
                            SemAnuncios.Text = $@"<div class='SemAnuncios'>
                                                    <figure>
                                                        <img src='imagens/elementos/Elemento19.svg' alt=''>
                                                    </figure>
                                                    <h2>Hmm... Não achamos um serviço com essas especificações :/
                                                    </h2>
                                                    <p>Tente pesquisar de uma maneira diferente.</p>
                                                </div>";
                        }
                        else
                        {
                            int i = 0;
                            foreach (Anuncio anuncio in listAnuncios)
                            {
                                foto = anuncio.Cliente.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                litResultados.Text += $@"<article class='anuncio' id='anuncio_{anuncio.Codigo}'>
                                                         <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                         <div class='titulo_Btn'>
                                                         <h2>{anuncio.Titulo}</h2>";

                                Proposta prop = new Proposta();
                                prop.Codigo = anuncio.Codigo;
                                bool estadoCandidatura = prop.VerificarCandidatura(Session["email"].ToString());

                                if (prop.VerificarCandidatura(Session["email"].ToString()))
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar escondido' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar' qual='{i}' STYLE='background-color: #CB294E;'>Desistir</button>";
                                }
                                else
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar escondido' qual='{i}' STYLE='background-color: #CB294E;'>Desistir</button>";
                                }

                                litResultados.Text += $@"</div>
                                                            <div class='data_Prazo'>
                                                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                            </div>

                                                            <p class='descricao'>{anuncio.Descricao}</p>

                                                            <div class='cliente_Opcoes'>
                                                                <div>
                                                                    <figure>
                                                                        <img src = '{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <p>{anuncio.Cliente.Nome}</p>
                                                                </div>
                                                            </div>
                                                        </article>";

                                litPopUpDetalhes.Text += $@"<article class='popupDetalhes escondido'  id='popUp_{anuncio.Codigo}'>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaVermelha'>Você realmente deseja se retirar desta vaga?</div>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaAzul'>Você realmente deseja se candidatar para esta vaga?</div>";
                                }

                                litPopUpDetalhes.Text += $@"<section class='infosClienteDetalhes'>
                                                            <input type='hidden' id='identificadorCliente' value='{anuncio.Cliente.Email}'>
                                                            <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                                <figure>
                                                                    <img src='{arquivoImagem}' alt=''>
                                                                </figure>
                                                                <div class='SobreOanuncio'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <p class='nome'>{anuncio.Cliente.Nome}</p>
                                                                    <div>
                                                                        <p class='data'>{anuncio.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                                        <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong> </p>
                                                                    </div>
                                                                </div>
                                                            </section>
                                                            <p class='descricao2'>{anuncio.Descricao}</p>
                                                            <div class='buttons' qual='{i}'>
                                                                <button id = 'btnCancelar'> Cancelar </button>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo' Style='display:none'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo'>Desistir</button>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo' Style='display:none'>Desistir</button>";
                                }
                                litPopUpDetalhes.Text += $@"</div>
                                                        </article>";
                                i++;
                            }
                        }
                    }
                    else
                    {
                        Literal litIdentificador = new Literal();
                        litIdentificador.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}'>";
                        Form.Controls.Add(litIdentificador);

                        Anuncios anuncios = new Anuncios();
                        List<Anuncio> listAnuncios = anuncios.CarregarAnunciosPrivados(loginAutonomo);
                        if (listAnuncios.Count < 1)
                        {
                            SemAnuncios.Text = $@"
                                                <div class='SemAnuncios'>
                                                    <figure>
                                                        <img src='imagens/elementos/Elemento19.svg' alt=''>
                                                    </figure>
                                                    <h2>Hmm... Não achamos um serviço com essas especificações :/
                                                    </h2>
                                                    <p>Tente pesquisar de uma maneira diferente.</p>
                                                </div>";
                        }
                        else
                        {
                            int i = 0;
                            foreach (Anuncio anuncio in listAnuncios)
                            {
                                foto = anuncio.Cliente.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                litResultados.Text += $@"<article class='anuncio' id='anuncio_{anuncio.Codigo}'>
                                                        <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                        <div class='titulo_Btn'>
                                                        <h2>{anuncio.Titulo}</h2>";

                                Proposta prop = new Proposta();
                                prop.Codigo = anuncio.Codigo;
                                bool estadoCandidatura = prop.VerificarCandidatura(Session["email"].ToString());

                                if (prop.VerificarCandidatura(Session["email"].ToString()))
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar escondido' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar' qual='{i}' STYLE='background-color: #CB294E;'>Desistir</button>";
                                }
                                else
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar escondido' qual='{i}' STYLE='background-color: #CB294E;'>Desistir</button>";
                                }

                                litResultados.Text += $@"</div>
                                                            <div class='data_Prazo'>
                                                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                            </div>

                                                            <p class='descricao'>{anuncio.Descricao}</p>

                                                            <div class='cliente_Opcoes'>
                                                                <div>
                                                                    <figure>
                                                                        <img src = '{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <p>{anuncio.Cliente.Nome}</p>
                                                                </div>
                                                            </div>
                                                        </article>";

                                litPopUpDetalhes.Text += $@"<article class='popupDetalhes escondido'  id='popUp_{anuncio.Codigo}'>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaVermelha'>Você realmente deseja se retirar desta vaga?</div>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaAzul'>Você realmente deseja se candidatar para esta vaga?</div>";
                                }

                                litPopUpDetalhes.Text += $@"<section class='infosClienteDetalhes'>
                                                            <input type='hidden' id='identificadorCliente' value='{anuncio.Cliente.Email}'>
                                                            <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                                <figure>
                                                                    <img src='{arquivoImagem}' alt=''>
                                                                </figure>
                                                                <div class='SobreOanuncio'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <p class='nome'>{anuncio.Cliente.Nome}</p>
                                                                    <div>
                                                                        <p class='data'>{anuncio.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                                        <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong> </p>
                                                                    </div>
                                                                </div>
                                                            </section>
                                                            <p class='descricao2'>{anuncio.Descricao}</p>
                                                            <div class='buttons' qual='{i}'>
                                                                <button id = 'btnCancelar'> Cancelar </button>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo' Style='display:none'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo'>Desistir</button>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo' Style='display:none'>Desistir</button>";
                                }
                                litPopUpDetalhes.Text += $@"</div>
                                                        </article>";
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    if ((!String.IsNullOrEmpty(Request["RouA"])) || (!String.IsNullOrEmpty(Request["p"])) || (!String.IsNullOrEmpty(Request["est"])))
                    {
                        string busca = Request["s"].ToString();
                        iptBusca.Text = Request["s"].ToString();
                        busca = busca + "%";

                        string recenteOuAntigo = Request["RouA"];
                        string prazoSelecionado = Request["p"];
                        string EstadoSelecionado = Request["est"];


                        string comando = $@"SELECT DISTINCT
			                                    C.NM_EMAIL_CLIENTE AS '0 - Email', C.NM_CLIENTE AS '1 - Nome', 
			                                    C.NM_CPF AS '2 - CPF', C.NM_TELEFONE AS '3 - Telefone',
			                                    CD.CD_CIDADE AS '4 - Cd Cidade', CD.NM_CIDADE AS '5 - Nome Cidade',
			                                    AN.CD_ANUNCIO AS '6 - Cd Anuncio', AN.DT_PUBLICACAO AS '7 - Dt Publicação', 
			                                    AN.HR_PUBLICACAO AS '8 - Hr Publicação', AN.NM_TITULO AS '9 - Titulo',
			                                    AN.DS_ANUNCIO AS '10 - Descrição', AN.IC_OCULTO AS '11 - Oculto',
			                                    AA.CD_AREA_ATUACAO AS '12 - Cd Area de Atuação', AA.NM_AREA_ATUACAO AS '13 - Nome Area de Atuação', 
			                                    EA.CD_ESTADO_ANUNCIO AS '14 - Cd Status', EA.NM_ESTADO_ANUNCIO AS '15 - Nome Status',
			                                    PR.CD_PRAZO AS '16 - Cd Prazo', PR.NM_PRAZO AS '17 - Nome Prazo', C.IMG_PERFIL AS '18 - Imagem de Perfil'
			                                    FROM DESTINATARIO_ANUNCIO DA 
			                                    JOIN ANUNCIO AN
				                                    ON(AN.CD_ANUNCIO = DA.CD_ANUNCIO)
			                                    JOIN CLIENTE C
				                                    ON (AN.NM_EMAIL_CLIENTE = C.NM_EMAIL_CLIENTE)
			                                    JOIN CIDADE CD
				                                    ON (C.CD_CIDADE = CD.CD_CIDADE)
                                                JOIN ESTADO ES
													ON (CD.SG_ESTADO = ES.SG_ESTADO)
			                                    JOIN AREA_ATUACAO AA
				                                    ON (AN.CD_AREA_ATUACAO = AA.CD_AREA_ATUACAO)
			                                    JOIN PRAZO PR
				                                    ON(AN.CD_PRAZO = PR.CD_PRAZO)
			                                    JOIN PROFISSAO P
				                                    ON (AA.CD_AREA_ATUACAO = P.CD_AREA_ATUACAO)
			                                    JOIN AUTONOMO_PROFISSAO AP
				                                    ON (P.CD_PROFISSAO = AP.CD_PROFISSAO)
			                                    JOIN ESTADO_ANUNCIO EA
				                                    ON(AN.CD_ESTADO_ANUNCIO = EA.CD_ESTADO_ANUNCIO)
			                                    JOIN AUTONOMO A
				                                    ON (AP.NM_EMAIL_AUTONOMO = A.NM_EMAIL_AUTONOMO)
			                                    WHERE DA.NM_EMAIL_AUTONOMO = '{loginAutonomo}' AND AN.CD_ESTADO_ANUNCIO = 1 AND AN.NM_TITULO LIKE '{busca}'";

                        if (!String.IsNullOrEmpty(prazoSelecionado))
                        {
                            int valor = int.Parse(prazoSelecionado);
                            if (valor > 0)
                                comando += $@" AND AN.CD_PRAZO = {prazoSelecionado}";
                        }

                        if (!String.IsNullOrEmpty(EstadoSelecionado))
                        {
                            if (EstadoSelecionado != "-1")
                                comando += $@" AND es.sg_estado = '{EstadoSelecionado}'";
                        }

                        if (!String.IsNullOrEmpty(recenteOuAntigo))
                        {
                            if (recenteOuAntigo == "Mais recente")
                            {
                                comando += $@" ORDER BY AN.DT_PUBLICACAO DESC";
                            }
                            else
                            {
                                comando += $@" ORDER BY AN.DT_PUBLICACAO";
                            }
                        }

                        Literal litIdentificador = new Literal();
                        litIdentificador.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}'>";
                        Form.Controls.Add(litIdentificador);

                        Anuncios anuncios = new Anuncios();
                        List<Anuncio> listAnuncios = anuncios.CarregarAnunciosPrivadosComFiltro(comando);

                        if (listAnuncios.Count < 1)
                        {
                            SemAnuncios.Text = $@"<div class='SemAnuncios'>
                                                    <figure>
                                                        <img src='imagens/elementos/Elemento19.svg' alt=''>
                                                    </figure>
                                                    <h2>Hmm... Não achamos um serviço com essas especificações :/
                                                    </h2>
                                                    <p>Tente pesquisar de uma maneira diferente.</p>
                                                </div>";
                        }
                        else
                        {
                            int i = 0;
                            foreach (Anuncio anuncio in listAnuncios)
                            {
                                foto = anuncio.Cliente.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                litResultados.Text += $@"<article class='anuncio' id='anuncio_{anuncio.Codigo}'>
                                                        <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                        <div class='titulo_Btn'>
                                                        <h2>{anuncio.Titulo}</h2>";

                                Proposta prop = new Proposta();
                                prop.Codigo = anuncio.Codigo;
                                bool estadoCandidatura = prop.VerificarCandidatura(Session["email"].ToString());


                                if (prop.VerificarCandidatura(Session["email"].ToString()))
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar escondido' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar' qual='{i}' STYLE='background-color: #CB294E;'>Desistir</button>";
                                }
                                else
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar escondido' qual='{i}' STYLE='background-color: #CB294E;'>Desistir</button>";
                                }


                                litResultados.Text += $@"</div>
                                                            <div class='data_Prazo'>
                                                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                            </div>

                                                            <p class='descricao'>{anuncio.Descricao}</p>

                                                            <div class='cliente_Opcoes'>
                                                                <div>
                                                                    <figure>
                                                                        <img src = '{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <p>{anuncio.Cliente.Nome}</p>
                                                                </div>
                                                            </div>
                                                        </article>";

                                litPopUpDetalhes.Text += $@"<article class='popupDetalhes escondido'  id='popUp_{anuncio.Codigo}'>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaVermelha'>Você realmente deseja se retirar desta vaga?</div>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaAzul'>Você realmente deseja se candidatar para esta vaga?</div>";
                                }

                                litPopUpDetalhes.Text += $@"<section class='infosClienteDetalhes'>
                                                            <input type='hidden' id='identificadorCliente' value='{anuncio.Cliente.Email}'>
                                                            <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                                <figure>
                                                                    <img src='{arquivoImagem}' alt=''>
                                                                </figure>
                                                                <div class='SobreOanuncio'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <p class='nome'>{anuncio.Cliente.Nome}</p>
                                                                    <div>
                                                                        <p class='data'>{anuncio.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                                        <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong> </p>
                                                                    </div>
                                                                </div>
                                                            </section>
                                                            <p class='descricao2'>{anuncio.Descricao}</p>
                                                            <div class='buttons' qual='{i}'>
                                                                <button id = 'btnCancelar'> Cancelar </button>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo' Style='display:none'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo'>Desistir</button>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo' Style='display:none'>Desistir</button>";
                                }
                                litPopUpDetalhes.Text += $@"</div>
                                                        </article>";
                                i++;
                            }
                        }
                    }
                    else
                    {
                        string busca = Request["s"].ToString();
                        iptBusca.Text = Request["s"].ToString();
                        busca = busca + "%";

                        Literal litIdentificador = new Literal();
                        litIdentificador.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}'>";
                        Form.Controls.Add(litIdentificador);

                        Anuncios anuncios = new Anuncios();
                        List<Anuncio> listAnuncios = anuncios.CarregarAnunciosPrivadosComBusca(loginAutonomo, busca);

                        if (listAnuncios.Count < 1)
                        {
                            SemAnuncios.Text = $@"<div class='SemAnuncios'>
                                                    <figure>
                                                        <img src='imagens/elementos/Elemento19.svg' alt=''>
                                                    </figure>
                                                    <h2>Hmm... Não achamos um serviço com essas especificações :/
                                                    </h2>
                                                    <p>Tente pesquisar de uma maneira diferente.</p>
                                                </div>";
                        }
                        else
                        {
                            int i = 0;
                            foreach (Anuncio anuncio in listAnuncios)
                            {
                                foto = anuncio.Cliente.Foto;
                                base64String = Convert.ToBase64String(foto, 0, foto.Length);
                                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                                litResultados.Text += $@"<article class='anuncio' id='anuncio_{anuncio.Codigo}'>
                                                        <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                        <div class='titulo_Btn'>
                                                        <h2>{anuncio.Titulo}</h2>";

                                Proposta prop = new Proposta();
                                prop.Codigo = anuncio.Codigo;
                                bool estadoCandidatura = prop.VerificarCandidatura(Session["email"].ToString());

                                if (prop.VerificarCandidatura(Session["email"].ToString()))
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar escondido' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar' qual='{i}' STYLE='background-color: #CB294E;'>Retirar-me</button>";
                                }
                                else
                                {
                                    litResultados.Text += $@"<button id='btnCandidatar' class='btnCandidatar' qual='{i}'>Se Candidatar</button>
                                                                <button id='btnRemoverCandidatura' class='btnCandidatar escondido' qual='{i}' STYLE='background-color: #CB294E;'>Retirar-me</button>";
                                }

                                litResultados.Text += $@"</div>
                                                            <div class='data_Prazo'>
                                                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                            </div>

                                                            <p class='descricao'>{anuncio.Descricao}</p>

                                                            <div class='cliente_Opcoes'>
                                                                <div>
                                                                    <figure>
                                                                        <img src = '{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <p>{anuncio.Cliente.Nome}</p>
                                                                </div>
                                                            </div>
                                                        </article>";

                                litPopUpDetalhes.Text += $@"<article class='popupDetalhes escondido'  id='popUp_{anuncio.Codigo}'>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaVermelha'>Você realmente deseja se retirar desta vaga?</div>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<div class='areaAzul'>Você realmente deseja se candidatar para esta vaga?</div>";
                                }

                                litPopUpDetalhes.Text += $@"<section class='infosClienteDetalhes'>
                                                            '<input type='hidden' id='identificadorCliente' value='{anuncio.Cliente.Email}'>
                                                            <input type='hidden' id='identificadorAnuncio' value='{anuncio.Codigo}'>
                                                                <figure>
                                                                    <img src='{arquivoImagem}' alt=''>
                                                                </figure>
                                                                <div class='SobreOanuncio'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <p class='nome'>{anuncio.Cliente.Nome}</p>
                                                                    <div>
                                                                        <p class='data'>{anuncio.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                                        <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong> </p>
                                                                    </div>
                                                                </div>
                                                            </section>
                                                            <p class='descricao2'>{anuncio.Descricao}</p>
                                                            <div class='buttons' qual='{i}'>
                                                                <button id = 'btnCancelar'> Cancelar </button>";

                                if (estadoCandidatura)
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo' Style='display:none'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo'>Retirar-me</button>";
                                }
                                else
                                {
                                    litPopUpDetalhes.Text += $@"<button id='btnCandidatarMesmo'>Candidatar</button>
                                                                    <button id='btnCancelarCandidaturaMesmo' Style='display:none'>Retirar-me</button>";
                                }
                                litPopUpDetalhes.Text += $@"</div>
                                                        </article>";
                                i++;
                            }
                        }
                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBusca.Text;

            Response.Redirect($@"propostasRecebidas.aspx?s={busca}");
        }

        protected void Aplicar_Click(object sender, EventArgs e)
        {
            string busca = iptBusca.Text;
            string recenteOuAntigo = "";
            string prazoSelecionado = selectPrazo.SelectedValue;
            string EstadoSelecionado = ddlEstado.SelectedValue;

            if (maisRecente.Checked)
            {
                recenteOuAntigo = "Mais recente";
            }
            else
            {
                if (maisAntigo.Checked)
                {
                    recenteOuAntigo = "Mais antigo";
                }
            }

            if (!String.IsNullOrEmpty(iptBusca.Text))
            {
                busca = iptBusca.Text;
                Response.Redirect($@"propostasRecebidas.aspx?s={busca}&RouA={recenteOuAntigo}&p={prazoSelecionado}&est={EstadoSelecionado}");
            }
            else
            {
                Response.Redirect($@"propostasRecebidas.aspx?s={busca}&RouA={recenteOuAntigo}&p={prazoSelecionado}&est={EstadoSelecionado}");
            }
        }

        protected void ddlProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}