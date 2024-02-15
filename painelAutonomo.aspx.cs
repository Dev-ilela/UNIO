using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class painelAutonomo : System.Web.UI.Page
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

                ddlProfissao.Items.Add(new ListItem(autonomo.Profissoes[0].Nome, autonomo.Profissoes[0].Codigo.ToString()));

                ddlProfissao.SelectedIndex = 0;

                Emblema emblema = autonomo.CarregarEmblemaAutonomo(emailAutonomo);

                decimal avaliacao = autonomo.CarregarAvaliacao(emailAutonomo);
                int servicosConcluidos = autonomo.CarregarServicosConcluidos(emailAutonomo);

                identificadorAutonomo.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{emailAutonomo}'>";
                string arquivoImagem = "";
                byte[] foto = autonomo.Foto;
                string base64String = Convert.ToBase64String(foto, 0, foto.Length);
                arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";

                litInfosAutonomo.Text = $@"<div class='informacoes'>
                                                <img id='imgAutonomo' src='{arquivoImagem}' alt=''>

                                                <div class='progressoAutonomo'>
                                                    <p class='progresso' id='progressoEstrelas' valor='{avaliacao}'>{avaliacao}</p>
                                                    <div class='avaliacaoProgresso'>
                                                        <div class='barra' id='barraProgressoEstrelas'>
                                                            <div></div>
                                                        </div>
                                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                    </div>
                                                </div>
                                                <div class='info'>
                                                    <h2>{autonomo.Nome}</h2>";

                litInfosAutonomo2.Text = $@"<div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {autonomo.Cidade.Nome}</div>
                                                </div>                    
                                          </div>";

                if (emblema.Codigo == 1)
                {
                    litProgressoEmblema.Text = $@"<a href='emblemas.aspx' class='emblemaAutonomo'>
                                              <p class='progresso' id='progressoEmblema' meta='10' valor='{servicosConcluidos}'>{servicosConcluidos}/10</p>
                                                <div class='barra' id='barraProgressoEmblema'>
                                                    <div id='teste'></div>
                                                </div>
                                                <img src='imagens/emblemas/bronze.png' alt=''>
                                            </a>";
                }
                if (emblema.Codigo == 2)
                {
                    litProgressoEmblema.Text = $@"<a href='emblemas.aspx' class='emblemaAutonomo'>
                                              <p class='progresso' id='progressoEmblema' meta='20' valor='{servicosConcluidos}'>{servicosConcluidos}/20</p>
                                                <div class='barra' id='barraProgressoEmblema'>
                                                    <div id='teste'></div>
                                                </div>
                                                <img src='imagens/emblemas/prata.png' alt=''>
                                            </a>";
                }
                if (emblema.Codigo == 3)
                {
                    litProgressoEmblema.Text = $@"<a href='emblemas.aspx' class='emblemaAutonomo'>
                                              <p class='progresso' id='progressoEmblema' meta='30' valor='{servicosConcluidos}'>{servicosConcluidos}/30</p>
                                                <div class='barra' id='barraProgressoEmblema'>
                                                    <div id='teste'></div>
                                                </div>
                                                <img src='imagens/emblemas/ouro.png' alt=''>
                                            </a>";
                }
                if(emblema.Codigo == 4)
                {
                    litProgressoEmblema.Text = $@"<a href='emblemas.aspx' class='emblemaAutonomo'>
                                              <p class='progresso' id='progressoEmblema' meta='30' valor='{servicosConcluidos}'>{servicosConcluidos}/30</p>
                                                <div class='barra' id='barraProgressoEmblema'>
                                                    <div id='teste'></div>
                                                </div>
                                                <img src='imagens/emblemas/ouro.png' alt=''>
                                            </a>";
                }
                
                          
                

                

                

                

                if ((!String.IsNullOrEmpty(Request["st"])) || (!String.IsNullOrEmpty(Request["dt"])) || (!String.IsNullOrEmpty(Request["pr"])))
                {
                    string statusSelecionado = "";
                    string dataSelecionada = "";
                    string prazoSelecionado = "";

                    if (!String.IsNullOrEmpty(Request["st"]))
                    {
                        statusSelecionado = Request["st"].Substring(0, Request["st"].Length - 1);
                    }
                    if (!String.IsNullOrEmpty(Request["dt"]))
                    {
                        dataSelecionada = Request["dt"].ToString();
                    }

                    if (!String.IsNullOrEmpty(Request["pr"]))
                    {
                        prazoSelecionado = Request["pr"].ToString();
                    }

                    string comando = $@"SELECT DISTINCT
	                                        C.NM_EMAIL_CLIENTE AS '0 - Email', C.NM_CLIENTE AS '1 - Nome', 
	                                        C.NM_CPF AS '2 - CPF', C.NM_TELEFONE AS '3 - Telefone',
	                                        CD.CD_CIDADE AS '4 - Cd Cidade', CD.NM_CIDADE AS '5 - Nome Cidade',
	                                        AN.CD_ANUNCIO AS '6 - Cd Anuncio', AN.DT_PUBLICACAO AS '7 - Dt Publicação', 
	                                        AN.HR_PUBLICACAO AS '8 - Hr Publicação', AN.NM_TITULO AS '9 - Titulo',
	                                        AN.DS_ANUNCIO AS '10 - Descrição', AN.IC_OCULTO AS '11 - Oculto',
	                                        AA.CD_AREA_ATUACAO AS '12 - Cd Area de Atuação', AA.NM_AREA_ATUACAO AS '13 - Nome Area de Atuação',
	                                        EA.CD_ESTADO_ANUNCIO AS '14 - Cd Status', EA.NM_ESTADO_ANUNCIO AS '15 - Nome Status',
	                                        PR.CD_PRAZO AS '16 - Cd Prazo', PR.NM_PRAZO AS '17 - Nome Prazo', PA.DT_PROPOSTA AS '18 - Dt Proposta',
	                                        PA.HR_PROPOSTA AS '19 - Hr Proposta', PA.IC_ESCOLHIDO AS '20 - Escolhido', C.IMG_PERFIL AS '21 - Foto do Cliente'

	                                        FROM PROPOSTA_ANUNCIO PA
	                                        JOIN ANUNCIO AN
		                                        ON(PA.CD_ANUNCIO = AN.CD_ANUNCIO)
	                                        JOIN CLIENTE C
		                                        ON (AN.NM_EMAIL_CLIENTE = C.NM_EMAIL_CLIENTE)
	                                        JOIN CIDADE CD
		                                        ON (C.CD_CIDADE = CD.CD_CIDADE)
	                                        JOIN AREA_ATUACAO AA
		                                        ON (AN.CD_AREA_ATUACAO = AA.CD_AREA_ATUACAO)
	                                        JOIN ESTADO_ANUNCIO EA
		                                        ON(AN.CD_ESTADO_ANUNCIO = EA.CD_ESTADO_ANUNCIO)
	                                        JOIN PRAZO PR
		                                        ON(AN.CD_PRAZO = PR.CD_PRAZO)
	                                        JOIN AUTONOMO A
			                                        ON(PA.NM_EMAIL_AUTONOMO = A.NM_EMAIL_AUTONOMO)
	                                        JOIN AUTONOMO_PROFISSAO AP
			                                        ON(PA.NM_EMAIL_AUTONOMO = AP.NM_EMAIL_AUTONOMO)
	                                        WHERE AP.NM_EMAIL_AUTONOMO = '{emailAutonomo}'
                                            AND AN.IC_OCULTO = 0
	                                        AND (
		                                        (EA.CD_ESTADO_ANUNCIO IN (2, 3, 4) AND PA.IC_ESCOLHIDO = 1)
		                                        OR (EA.CD_ESTADO_ANUNCIO NOT IN (2, 3, 4))
	                                        )";

                    if (!String.IsNullOrEmpty(statusSelecionado))
                    {
                        string[] listaStatusSelecionado = statusSelecionado.Split(',');

                        if (listaStatusSelecionado.Length > 0)
                        {
                            if (listaStatusSelecionado.Length == 1)
                            {
                                comando += $@" AND (EA.CD_ESTADO_ANUNCIO = {listaStatusSelecionado[0]})";
                            }
                            else
                            {
                                comando += $@" AND (EA.CD_ESTADO_ANUNCIO = {listaStatusSelecionado[0]}";

                                for (int indice = 1; indice < listaStatusSelecionado.Length; indice++)
                                {
                                    comando += $@" OR EA.CD_ESTADO_ANUNCIO = {listaStatusSelecionado[indice]} ";
                                }
                                comando += ")";
                            }
                        }
                    }

                    if (!String.IsNullOrEmpty(dataSelecionada))
                    {
                        comando += $@" AND AN.DT_PUBLICACAO = '{dataSelecionada}'";
                    }

                    if (!String.IsNullOrEmpty(prazoSelecionado))
                    {
                        int valor = int.Parse(prazoSelecionado);
                        if (valor > 0)
                            comando += $@" AND PR.CD_PRAZO = {prazoSelecionado}";
                    }

                    comando += $@" ORDER BY EA.CD_ESTADO_ANUNCIO";

                    Propostas propostas = new Propostas();
                    List<Proposta> listPropostas = propostas.CarregarPropostasComFiltro(comando);
                    int i = 0;
                    if (listPropostas.Count >= 1)
                    {
                        litServicos.Text = "<section class='listaServicos'>";
                        foreach (Proposta proposta in listPropostas)
                        {
                            arquivoImagem = "";
                            foto = null;
                            foto = proposta.Cliente.Foto;
                            base64String = Convert.ToBase64String(foto, 0, foto.Length);
                            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                            litDenunciar.Text += $@"      <article class='pnlDenuncia escondido' qual='{i}'>
                                                      <input type='hidden' id='infosAnuncio' codigo='{proposta.Codigo}'>
                                                            <div class='cabecalhoDenuncia'>
                                                                <figure class='backIcon'>
                                                                    <img src='imagens/icones/back_icon.png' alt=''>
                                                                </figure>
                                                                <h2>Denuncie</h2>
                                                                <figure class='alertIcon'>
                                                                    <img src='imagens/icones/alert_icon.png' alt=''>
                                                                </figure>
                                                            </div>
                                                            <div class='areaVermelha'>Revise os dados da sua denúncia</div>

                                                            <section class='infosCliente'>
                                                            <input type='hidden' id='identificadorCliente' value='{proposta.Cliente.Email}'>
                                                                <p class='clienteDenunciado'>Cliente denunciado:</p>
                                                                <div class='SobreOCliente'>
                                                                    <figure>
                                                                        <img src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{proposta.Cliente.Nome}</h2>
                                                                        <p>{proposta.Titulo}</p>
                                                                        <p class='data'>{proposta.DataPublicacao}</p>
                                                                    </div>
                                                                </div>
                                                                <div class='SobreADenuncia'>
                                                                    <label for=''>Selecione uma categoria:
                                                                        <select name='' id='selectCategoriaDenuncia'></select>
                                                                    </label>
                
                                                                    <label for='' class='divTextarea'>Descreva o ocorrido:
                                                                        <textarea name='' id='txtDescricaoDenuncia' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                                    </label>
                                                                    <p class='naoSePreocupe'>Não se preocupe, essa denúncia é anônima, o cliente não saberá que ela foi feita por você.</p>
                                                                    <div class='divButton'>
                                                                        <button id='btnDenunciar'>Denunciar</button>
                                                                    </div>
                                                                </div>
                                                            </section>
                                                        </article>";

                            litDesistir.Text += $@"<article class='pnlCancelar escondido' qual='{i}'>
                                               <input type='hidden' id='infosAnuncio' codigo='{proposta.Codigo}'>
                                                <div class='cabecalhoCancelar'>
                                                    <figure class='backIcon'>
                                                        <img src='imagens/icones/back_icon.png' alt=''>
                                                    </figure>
                                                    <h2>Desistir</h2>
                                                </div>
                                                    <section class='infosCliente'>
                                                    <input type='hidden' id='identificadorCliente' value='{proposta.Cliente.Email}'>
                                                        <div class='SobreOCliente'>
                                                            <figure>
                                                                <img src='{arquivoImagem}' alt=''>
                                                            </figure>
                                                            <div>
                                                                <h2>{proposta.Cliente.Nome}</h2>
                                                                <p>{proposta.Titulo}</p>
                                                            </div>
                                                        </div>

                                                        <section class='InicioPrazoCancelamento'>
                                                            <div>
                                                                <h3 class='inicio'>Início</h3>
                                                                <p>{proposta.DataProposta}</p>
                                                            </div>
                                                            <div class='divMeio'>
                                                                <h3 class='prazo'>Prazo</h3>
                                                                <p>{proposta.Prazo.Nome}</p>
                                                            </div>
                                                            <div>
                                                                <h3 class='cancelamento'>Desistência</h3>
                                                                <p>{DateTime.Now}</p>
                                                            </div>
                                                        </section>
                                                        <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                                                        <div class='divButton'>
                                                            <button id='btnCancelar2'>Desistir</button>
                                                        </div>
                                                    </section>
                                            </article>";

                            string styleEstado = "";
                            string opcoesAnuncio = "";

                            if (proposta.Estado.Codigo == 1)
                            {
                                styleEstado = "background-color: #FFCE85; color: #A86500;";
                                opcoesAnuncio = $@"<p id='Desistir'>Desistir</p>";
                            }
                            if (proposta.Estado.Codigo == 2)
                            {
                                styleEstado = "background-color: #9EA9E5; color: #001167;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>
                                        <hr>
                                        <p id='Desistir'>Desistir</p>";
                            }
                            if (proposta.Estado.Codigo == 3)
                            {
                                styleEstado = "background-color: #BEE38F; color: #2C4F00;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }
                            if (proposta.Estado.Codigo == 4)
                            {
                                styleEstado = "background-color: #E8A1B1; color: #5A0015;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }

                            litServicos.Text += $@"<article class='anuncio' id='anuncio_{i}'>
                                <div class='titulo_Btn'>
                                    <h2>{proposta.Titulo}</h2>
                                    <div class='status' style='{styleEstado}'>{proposta.Estado.Nome}</div>
                                </div>
    
                                <div class='data_Prazo'>
                                    <p class='data'>{proposta.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                    <p>Prazo: <strong>{proposta.Prazo.Nome}</strong></p>
                                </div>
    
                                <p class='descricao'>{proposta.Descricao}</p>
    
                                <div class='cliente_Opcoes'>
                                    <div>
                                        <figure>
                                            <img src='{arquivoImagem}' alt=''>
                                        </figure>
                                        <p>{proposta.Cliente.Nome}</p>
                                    </div>
                                    
                                    <figure class='pontinhos' qual='{i}'>
                                        <img src='imagens/icones/opcoes.png' alt=''>
                                    </figure>
                                </div>

                                <div class='OpcoesMenu escondido' qual='{i}'>
                                    {opcoesAnuncio}
                                </div>
                            </article>";
                            i++;
                        }
                        litServicos.Text += "</section>";
                    }
                    else
                    {
                        litSemServicos.Text = $@"<div class='SemAnuncios'>
                                               <figure>
                                                   <img id='interrogacao' src = 'imagens/elementos/Elemento19.svg' alt = ''>
                                               </figure>
   
                                              <h2> Hmm... Não achamos um anúncio com essas especificações:/</h2>
                                                <p> Tente filtrar de uma maneira diferente.</p>
                                            </div>";
                    }

                    #region Status
                    EstadosAnuncio Status = new EstadosAnuncio();
                    List<EstadoAnuncio> listaStatus = new List<EstadoAnuncio>();
                    listaStatus = Status.carregarStatus();

                    checkboxStatus.Items.Clear();
                    for (int indice = 0; indice < listaStatus.Count; indice++)
                    {
                        checkboxStatus.Items.Add(new ListItem(listaStatus[indice].Nome, listaStatus[indice].Codigo.ToString()));
                    }
                    #endregion

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
                }
                else
                {
                    Propostas propostas = new Propostas();
                    List<Proposta> listPropostas = propostas.CarregarPropostas(emailAutonomo);
                    int i = 0;
                    if (listPropostas.Count >= 1)
                    {
                        litServicos.Text = "<section class='listaServicos'>";
                        foreach (Proposta proposta in listPropostas)
                        {
                            arquivoImagem = "";
                            foto = null;
                            foto = proposta.Cliente.Foto;
                            base64String = Convert.ToBase64String(foto, 0, foto.Length);
                            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                            litDenunciar.Text += $@"<article class='pnlDenuncia escondido' qual='{i}'>
                                                      <input type='hidden' id='infosAnuncio' codigo='{proposta.Codigo}'>
                                                            <div class='cabecalhoDenuncia'>
                                                                <figure class='backIcon'>
                                                                    <img src='imagens/icones/back_icon.png' alt=''>
                                                                </figure>
                                                                <h2>Denuncie</h2>
                                                                <figure class='alertIcon'>
                                                                    <img src='imagens/icones/alert_icon.png' alt=''>
                                                                </figure>
                                                            </div>
                                                            <div class='areaVermelha'>Revise os dados da sua denúncia</div>

                                                            <section class='infosCliente'>
                                                            <input type='hidden' id='identificadorCliente' value='{proposta.Cliente.Email}'>
                                                                <p class='clienteDenunciado'>Cliente denunciado:</p>
                                                                <div class='SobreOCliente'>
                                                                    <figure>
                                                                        <img src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{proposta.Cliente.Nome}</h2>
                                                                        <p>{proposta.Titulo}</p>
                                                                        <p class='data'>{proposta.DataPublicacao}</p>
                                                                    </div>
                                                                </div>
                                                                <div class='SobreADenuncia'>
                                                                    <label for=''>Selecione uma categoria:
                                                                        <select name='' id='selectCategoriaDenuncia'></select>
                                                                    </label>
                
                                                                    <label for='' class='divTextarea'>Descreva o ocorrido:
                                                                        <textarea name='' id='txtDescricaoDenuncia' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                                    </label>
                                                                    <p class='naoSePreocupe'>Não se preocupe, essa denúncia é anônima, o cliente não saberá que ela foi feita por você.</p>
                                                                    <div class='divButton'>
                                                                        <button id='btnDenunciar'>Denunciar</button>
                                                                    </div>
                                                                </div>
                                                            </section>
                                                        </article>";

                            litDesistir.Text += $@"<article class='pnlCancelar escondido' qual='{i}'>
                                                       <input type='hidden' id='infosAnuncio' codigo='{proposta.Codigo}'>
                                                        <div class='cabecalhoCancelar'>
                                                            <figure class='backIcon'>
                                                                <img src='imagens/icones/back_icon.png' alt=''>
                                                            </figure>
                                                            <h2>Desistir</h2>
                                                        </div>
                                                            <section class='infosCliente'>
                                                            <input type='hidden' id='identificadorCliente' value='{proposta.Cliente.Email}'>
                                                                <div class='SobreOCliente'>
                                                                    <figure>
                                                                        <img src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{proposta.Cliente.Nome}</h2>
                                                                        <p>{proposta.Titulo}</p>
                                                                    </div>
                                                                </div>

                                                                <section class='InicioPrazoCancelamento'>
                                                                    <div>
                                                                        <h3 class='inicio'>Início</h3>
                                                                        <p>{proposta.DataProposta}</p>
                                                                    </div>
                                                                    <div class='divMeio'>
                                                                        <h3 class='prazo'>Prazo</h3>
                                                                        <p>{proposta.Prazo.Nome}</p>
                                                                    </div>
                                                                    <div>
                                                                        <h3 class='cancelamento'>Desistência</h3>
                                                                        <p>{DateTime.Now}</p>
                                                                    </div>
                                                                </section>
                                                                <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                                                                <div class='divButton'>
                                                                    <button id='btnCancelar2'>Desistir</button>
                                                                </div>
                                                            </section>
                                                    </article>";

                            string styleEstado = "";
                            string opcoesAnuncio = "";

                            if (proposta.Estado.Codigo == 1)
                            {
                                styleEstado = "background-color: #FFCE85; color: #A86500;";
                                opcoesAnuncio = $@"<p id='Desistir'>Desistir</p>";
                            }
                            if (proposta.Estado.Codigo == 2)
                            {
                                styleEstado = "background-color: #9EA9E5; color: #001167;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>
                                        <hr>
                                        <p id='Desistir'>Desistir</p>";
                            }
                            if (proposta.Estado.Codigo == 3)
                            {
                                styleEstado = "background-color: #BEE38F; color: #2C4F00;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }
                            if (proposta.Estado.Codigo == 4)
                            {
                                styleEstado = "background-color: #E8A1B1; color: #5A0015;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }

                            litServicos.Text += $@"<article class='anuncio' id='anuncio_{i}'>
                                                        <div class='titulo_Btn'>
                                                            <h2>{proposta.Titulo}</h2>
                                                            <div class='status' style='{styleEstado}'>{proposta.Estado.Nome}</div>
                                                        </div>
    
                                                        <div class='data_Prazo'>
                                                            <p class='data'>{proposta.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                            <p>Prazo: <strong>{proposta.Prazo.Nome}</strong></p>
                                                        </div>
    
                                                        <p class='descricao'>{proposta.Descricao}</p>
    
                                                        <div class='cliente_Opcoes'>
                                                            <div>
                                                                <figure>
                                                                    <img src='{arquivoImagem}' alt=''>
                                                                </figure>
                                                                <p>{proposta.Cliente.Nome}</p>
                                                            </div>
                                    
                                                            <figure class='pontinhos' qual='{i}'>
                                                                <img src='imagens/icones/opcoes.png' alt=''>
                                                            </figure>
                                                        </div>

                                                        <div class='OpcoesMenu escondido' qual='{i}'>
                                                            {opcoesAnuncio}
                                                        </div>
                                                    </article>";
                                                    i++;
                        }
                        litServicos.Text += "</section>";
                    }
                    else
                    {
                        litSemServicos.Text = $@"<section class='SemAnuncios'>
                                                    <figure>
                                                        <img src='imagens/elementos/Elemento20.svg' alt=''>
                                                    </figure>
                                                    <h2>Bem vindo(a) a Unio!</h2>
                                                    <p>Este é o seu painel de serviços, que tal começar se candidatando para uma vaga nova?</p>
                                                    <button id='btnProcurarServicos'>Procurar serviços</button>
                                                </section>";
                    }

                    #region Status
                    EstadosAnuncio Status = new EstadosAnuncio();
                    List<EstadoAnuncio> listaStatus = new List<EstadoAnuncio>();
                    listaStatus = Status.carregarStatus();

                    checkboxStatus.Items.Clear();
                    for (int indice = 0; indice < listaStatus.Count; indice++)
                    {
                        checkboxStatus.Items.Add(new ListItem(listaStatus[indice].Nome, listaStatus[indice].Codigo.ToString()));
                    }
                    #endregion

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
                    }
                
                
            }
        }

        protected void Aplicar_Click(object sender, EventArgs e)
        {
            
               string status = "";
                if (checkboxStatus.Items.Count > 0)
                {
                    for (int i = 0; i < checkboxStatus.Items.Count; i++)
                    {
                        if (checkboxStatus.Items[i].Selected)
                        {
                            status += checkboxStatus.Items[i].Value + ",";
                        }
                        Console.WriteLine(status);
                    }

                    string dtPublicacao = dataPublicacao.Text;
                    string prazoSelecionado = selectPrazo.SelectedValue;

                    Response.Redirect($@"painelAutonomo.aspx?st={status}&dt={dtPublicacao}&pr={prazoSelecionado}");
                }
            
            
        }

        protected void ddlProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {
            litDenunciar.Text = "";
            litDesistir.Text = "";
            litSemServicos.Text = "";
            litServicos.Text = "";
            litInfosAutonomo.Text = "";

            Autonomo a = new Autonomo();
            (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(Session["email"].ToString(), Session["senha"].ToString());
            string arquivoImagem = "";
            byte[] foto = autonomo.Foto;
            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;
            decimal avaliacao = autonomo.CarregarAvaliacao(Session["email"].ToString());

            litInfosAutonomo.Text = $@"<div class='informacoes'>
                                                <img id='imgAutonomo' src='{arquivoImagem}' alt=''>

                                                <div class='progressoAutonomo'>
                                                    <p class='progresso' valor='{avaliacao}'>{avaliacao}</p>
                                                    <div class='avaliacaoProgresso'>
                                                        <div class='barra'>
                                                            <div></div>
                                                        </div>
                                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                    </div>
                                                </div>
                                                <div class='info'>
                                                    <h2>{autonomo.Nome}</h2>";

            Propostas propostas = new Propostas();
            List<Proposta> listPropostas = propostas.CarregarPropostas(Session["email"].ToString());
            int i = 0;
            if (listPropostas.Count >= 1)
            {
                litServicos.Text = "<section class='listaServicos'>";
                foreach (Proposta proposta in listPropostas)
                {
                    arquivoImagem = "";
                    foto = null;
                    foto = proposta.Cliente.Foto;
                    base64String = Convert.ToBase64String(foto, 0, foto.Length);
                    arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                    litDenunciar.Text += $@"<article class='pnlDenuncia escondido' qual='{i}'>
                                                <input type='hidden' id='infosAnuncio' codigo='{proposta.Codigo}'>
                                                    <div class='cabecalhoDenuncia'>
                                                        <figure class='backIcon'>
                                                            <img src='imagens/icones/back_icon.png' alt=''>
                                                        </figure>
                                                        <h2>Denuncie</h2>
                                                        <figure class='alertIcon'>
                                                            <img src='imagens/icones/alert_icon.png' alt=''>
                                                        </figure>
                                                    </div>
                                                    <div class='areaVermelha'>Revise os dados da sua denúncia</div>

                                                    <section class='infosCliente'>
                                                    <input type='hidden' id='identificadorCliente' value='{proposta.Cliente.Email}'>
                                                        <p class='clienteDenunciado'>Cliente denunciado:</p>
                                                        <div class='SobreOCliente'>
                                                            <figure>
                                                                <img src='{arquivoImagem}' alt=''>
                                                            </figure>
                                                            <div>
                                                                <h2>{proposta.Cliente.Nome}</h2>
                                                                <p>{proposta.Titulo}</p>
                                                                <p class='data'>{proposta.DataPublicacao}</p>
                                                            </div>
                                                        </div>
                                                        <div class='SobreADenuncia'>
                                                            <label for=''>Selecione uma categoria:
                                                                <select name='' id='selectCategoriaDenuncia'></select>
                                                            </label>
                
                                                            <label for='' class='divTextarea'>Descreva o ocorrido:
                                                                <textarea name='' id='' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                            </label>
                                                            <p class='naoSePreocupe'>Não se preocupe, essa denúncia é anônima, o cliente não saberá que ela foi feita por você.</p>
                                                            <div class='divButton'>
                                                                <button id='btnDenunciar'>Denunciar</button>
                                                            </div>
                                                        </div>
                                                    </section>
                                                </article>";

                    litDesistir.Text += $@"<article class='pnlCancelar escondido' qual='{i}'>
                                               <input type='hidden' id='infosAnuncio' codigo='{proposta.Codigo}'>
                                                <div class='cabecalhoCancelar'>
                                                    <figure class='backIcon'>
                                                        <img src='imagens/icones/back_icon.png' alt=''>
                                                    </figure>
                                                    <h2>Desistir</h2>
                                                </div>
                                                    <section class='infosCliente'>
                                                    <input type='hidden' id='identificadorCliente' value='{proposta.Cliente.Email}'>
                                                        <div class='SobreOCliente'>
                                                            <figure>
                                                                <img src='{arquivoImagem}' alt=''>
                                                            </figure>
                                                            <div>
                                                                <h2>{proposta.Cliente.Nome}</h2>
                                                                <p>{proposta.Titulo}</p>
                                                            </div>
                                                        </div>

                                                        <section class='InicioPrazoCancelamento'>
                                                            <div>
                                                                <h3 class='inicio'>Início</h3>
                                                                <p>{proposta.DataProposta}</p>
                                                            </div>
                                                            <div class='divMeio'>
                                                                <h3 class='prazo'>Prazo</h3>
                                                                <p>{proposta.Prazo.Nome}</p>
                                                            </div>
                                                            <div>
                                                                <h3 class='cancelamento'>Desistência</h3>
                                                                <p>{DateTime.Now}</p>
                                                            </div>
                                                        </section>
                                                        <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                                                        <div class='divButton'>
                                                            <button id='btnCancelar2'>Desistir</button>
                                                        </div>
                                                    </section>
                                            </article>";

                    string styleEstado = "";
                    string opcoesAnuncio = "";

                    if (proposta.Estado.Codigo == 1)
                    {
                        styleEstado = "background-color: #4660d06b; color: #1736be;";
                        opcoesAnuncio = $@"<p id='Desistir'>Desistir</p>";
                    }
                    if (proposta.Estado.Codigo == 2)
                    {
                        styleEstado = "background-color: #4660cf; color: #f2f5ff;";
                        opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>
                                        <hr>
                                        <p id='Desistir'>Desistir</p>";
                    }
                    if (proposta.Estado.Codigo == 3)
                    {
                        styleEstado = "background-color: #6dc00088; color: #2C4F00;";
                        opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                    }
                    if (proposta.Estado.Codigo == 4)
                    {
                        styleEstado = "background-color: #de0028a6; color: #fefefe;";
                        opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                    }

                    litServicos.Text += $@"<article class='anuncio' id='anuncio_{i}'>
                                                <div class='titulo_Btn'>
                                                    <h2>{proposta.Titulo}</h2>
                                                    <div class='status' style='{styleEstado}'>{proposta.Estado.Nome}</div>
                                                </div>
    
                                                <div class='data_Prazo'>
                                                    <p class='data'>{proposta.DataPublicacao.Date.ToString().Substring(0, 10)}</p>
                                                    <p>Prazo: <strong>{proposta.Prazo.Nome}</strong></p>
                                                </div>
    
                                                <p class='descricao'>{proposta.Descricao}</p>
    
                                                <div class='cliente_Opcoes'>
                                                    <div>
                                                        <figure>
                                                            <img src='{arquivoImagem}' alt=''>
                                                        </figure>
                                                        <p>{proposta.Cliente.Nome}</p>
                                                    </div>
                                    
                                                    <figure class='pontinhos' qual='{i}'>
                                                        <img src='imagens/icones/opcoes.png' alt=''>
                                                    </figure>
                                                </div>

                                                <div class='OpcoesMenu escondido' qual='{i}'>
                                                    {opcoesAnuncio}
                                                </div>
                                            </article>";
                                    i++;
                }
                litServicos.Text += "</section>";
            }

            else
            {
                litSemServicos.Text = $@"<section class='SemAnuncios'>
                                                <figure>
                                                    <img src='imagens/elementos/Elemento20.svg' alt=''>
                                                </figure>
                                                <h2>Bem vindo(a) a Unio!</h2>
                                                <p>Este é o seu painel de serviços, que tal começar se candidatando para uma vaga nova?</p>
                                                <a href='buscaServicos.aspx'><button id='btnProcurarServicos'>Procurar serviços</button></a>
                                            </section>";
            }
        }
    }
}