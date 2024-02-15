using MySqlX.XDevAPI;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class painelCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
            }
            Cliente c = new Cliente();
            (Autonomo a, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

            string arquivoImagem = "";
            byte[] foto = cliente.Foto;
            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            identificadorCliente.Text = $@"<input type='hidden' id='identificadorCliente' value='{emailCliente}'>";

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";

            litInfosCliente.Text = $@"<div class='informacoes'>
                                            <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                            <div class='info'>
                                                <h2>{cliente.Nome}</h2>
                                                <div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {cliente.Cidade.Nome} </div>
                                            </div>                    
                                          </div>";
            litServicos.Text = "";

            if (!IsPostBack)
            {
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

                    string comando = $@"SELECT

                                    C.NM_EMAIL_CLIENTE AS '0 - Email', C.NM_CLIENTE AS '1 - Nome', 
			                        C.NM_CPF AS '2 - CPF', C.NM_TELEFONE AS '3 - Telefone',
			                        CD.CD_CIDADE AS '4 - Cd Cidade', CD.NM_CIDADE AS '5 - Nome Cidade',
			                        AN.CD_ANUNCIO AS '6 - Cd Anuncio', AN.DT_PUBLICACAO AS '7 - Dt Publicação', 
			                        AN.HR_PUBLICACAO AS '8 - Hr Publicação', AN.NM_TITULO AS '9 - Titulo',
			                        AN.DS_ANUNCIO AS '10 - Descrição', AN.IC_OCULTO AS '11 - Oculto',
			                        AA.CD_AREA_ATUACAO AS '12 - Cd Area de Atuação', AA.NM_AREA_ATUACAO AS '13 - Nome Area de Atuação',
			                        EA.CD_ESTADO_ANUNCIO AS '14 - Cd Status', EA.NM_ESTADO_ANUNCIO AS '15 - Nome Status',
			                        PR.CD_PRAZO AS '16 - Cd Prazo', PR.NM_PRAZO AS '17 - Nome Prazo', C.IMG_PERFIL AS '18 - Foto do Cliente'

                                                FROM ANUNCIO AN
                                                JOIN CLIENTE C

                                                    ON(AN.NM_EMAIL_CLIENTE = C.NM_EMAIL_CLIENTE)

                                                JOIN CIDADE CD

                                                    ON(C.CD_CIDADE = CD.CD_CIDADE)

                                                JOIN AREA_ATUACAO AA

                                                    ON(AN.CD_AREA_ATUACAO = AA.CD_AREA_ATUACAO)

                                                JOIN ESTADO_ANUNCIO EA

                                                    ON(AN.CD_ESTADO_ANUNCIO = EA.CD_ESTADO_ANUNCIO)

                                                JOIN PRAZO PR

                                                    ON(AN.CD_PRAZO = PR.CD_PRAZO)

                                                WHERE C.NM_EMAIL_CLIENTE = '{emailCliente}'";

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

                    Anuncios anuncios = new Anuncios();
                    List<Anuncio> listAnuncios = anuncios.CarregarAnunciosClienteComFiltro(comando);
                    int i = 0;

                    string arquivoImagemAutonomo = "";

                    if (listAnuncios.Count >= 1)
                    {
                        litServicos.Text = $@"<section class='listaAnuncios'>";
                        foreach (Anuncio anuncio in listAnuncios)
                        {
                            Autonomo autonomo = new Autonomo();
                            string styleEstado = "";
                            string opcoesAnuncio = "";

                            if (anuncio.Estado.Codigo == 1)
                            {
                                styleEstado = "background-color: #faab005e; color: #af6b11;";
                                opcoesAnuncio = $@"<p id='Editar'>Editar</p>
                                        <hr>
                                        <p id='Cancelar'>Cancelar Projeto</p>";
                            }
                            if (anuncio.Estado.Codigo == 2)
                            {
                                styleEstado = "background-color: #223dc35b; color: #001167;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>
                                        <hr>
                                        <p id='Concluir'>Concluir</p>
                                        <hr>
                                        <p id='Cancelar'>Cancelar Projeto</p>";
                            }
                            if (anuncio.Estado.Codigo == 3)
                            {
                                styleEstado = "background-color: #6dc00088; color: #2C4F00;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }
                            if (anuncio.Estado.Codigo == 4)
                            {
                                styleEstado = "background-color: #cb294f5b;color: #5A0015;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }

                            if (anuncio.Estado.Codigo == 1)
                            {
                                Propostas propostas = new Propostas();
                                List<Autonomo> candidatos = propostas.CarregarCandidatos(anuncio.Codigo.ToString(), emailCliente);
                                litServicos.Text += $@"<article class='anuncio'>
                                                            <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}' titulo='{anuncio.Titulo}' descricao='{anuncio.Descricao}' cdPrazo='{anuncio.Prazo.Codigo}' cdArea='{anuncio.AreaAtuacao.Codigo}'>

                                                            <div class='titulo_Btn'>
                                                                <h2>{anuncio.Titulo}</h2>
                                                                <div class='status' style='{styleEstado}'>{anuncio.Estado.Nome}</div>
                                                            </div>
        
                                                            <div class='data_Prazo'>
                                                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                            </div>
        
                                                            <p class='descricao'>{anuncio.Descricao}</p>
        
                                                            <div class='cliente_Opcoes'>
                                                                <div>
                                                                    <a href='AutonomosDisponiveis.aspx?ca={anuncio.Codigo}'><p class='autonomosDisponiveis'>{candidatos.Count}</p></a>
                                                                    <p>Autônomo(s) disponível(eis)</p>
                                                                </div>
                                        
                                                                <figure class='pontinhos' qual='{i}'>
                                                                    <img src='imagens/icones/opcoes.png' alt=''>
                                                                </figure>
                                                            </div>

                                                            <div class='OpcoesMenu escondido' qual='{i}'>
                                                                {opcoesAnuncio}
                                                            </div>
                                                        </article>";
                            }
                            else
                            {
                                autonomo.CarregarAutonomoContratado(anuncio.Codigo);

                                if (autonomo.Nome != null)
                                {
                                    byte[] fotoAutonomo = autonomo.Foto;
                                    string base64StringAutonomo = Convert.ToBase64String(fotoAutonomo, 0, fotoAutonomo.Length);
                                    arquivoImagemAutonomo = Convert.ToString("data:image/jpeg;base64,") + base64StringAutonomo;

                                    litServicos.Text += $@"<article class='anuncio'>
                                                                <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}' titulo='{anuncio.Titulo}' descricao='{anuncio.Descricao}' cdPrazo='{anuncio.Prazo.Codigo}' cdArea='{anuncio.AreaAtuacao.Codigo}'>

                                                                <div class='titulo_Btn'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <div class='status' style='{styleEstado}'>{anuncio.Estado.Nome}</div>
                                                                </div>
        
                                                                <div class='data_Prazo'>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                                </div>
        
                                                                <p class='descricao'>{anuncio.Descricao}</p>
        
                                                                <div class='cliente_Opcoes'>
                                                                    <div>
                                                                        <a href='chatCliente.aspx'>
                                                                            <img class='autonomoSelecionado' src='{arquivoImagemAutonomo}'>

                                                                        </a>
                                                                        <p>{autonomo.Nome}</p>
                                                                    </div>
                                        
                                                                    <figure class='pontinhos' qual='{i}'>
                                                                        <img src='imagens/icones/opcoes.png' alt=''>
                                                                    </figure>
                                                                </div>

                                                                <div class='OpcoesMenu escondido' qual='{i}'>
                                                                    {opcoesAnuncio}
                                                                </div>
                                                            </article>";
                                }
                                else
                                {
                                    litServicos.Text += $@"<article class='anuncio'>
                                                                <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}' titulo='{anuncio.Titulo}' descricao='{anuncio.Descricao}' cdPrazo='{anuncio.Prazo.Codigo}' cdArea='{anuncio.AreaAtuacao.Codigo}'>

                                                                <div class='titulo_Btn'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <div class='status' style='{styleEstado}'>{anuncio.Estado.Nome}</div>
                                                                </div>
        
                                                                <div class='data_Prazo'>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                                </div>
        
                                                                <p class='descricao'>{anuncio.Descricao}</p>
        
                                                                <div class='cliente_Opcoes'>
                                                            </article>";
                                }
                            }

                            litDenunciar.Text += $@"<article class='pnlDenuncia escondido' qual='{i}'>
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
                                                            <input type='hidden' id='identificadorAutonomo' value='{autonomo.Email}'>
                                                            <p class='clienteDenunciado'>Autônomo denunciado:</p>
                                                            <div class='SobreOAutonomo'>
                                                                <figure>
                                                                    <img id='imgCliente' src='{arquivoImagemAutonomo}' alt=''>
                                                                </figure>
                                                                <div>
                                                                    <h2>{autonomo.Nome}</h2>
                                                                    <p>{anuncio.Titulo}</p>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                </div>
                                                            </div>
                                                            <div class='SobreADenuncia'>
                                                                <label for=''>Selecione uma categoria:
                                                                    <select name='' id='selectCategoriaDenuncia'></select>
                                                                </label>
                
                                                                <label for='' class='divTextarea'>Descreva o ocorrido:
                                                                    <textarea name='' id='txtDescricaoDenuncia' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                                </label>
                                                                <p class='naoSePreocupe'>Não se preocupe, essa denúncia é anônima, o autônomo não saberá que ela foi feita por você.</p>
                                                                <div class='divButton'>
                                                                    <button id='btnDenunciar'>Denunciar</button>
                                                                </div>
                                                            </div>
                                                        </section>
                                                    </article>";

                            litConcluir.Text += $@"<article class='pnlConcluir escondido' qual='{i}'>
                                                        <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>

                                                        <div class='cabecalhoConcluir'>
                                                            <figure class='backIcon'>
                                                                <img src='imagens/icones/back_icon.png' alt=''>
                                                            </figure>
                                                            <h2>Concluir</h2>
                                                        </div>
                                                            <section class='infosCliente'>
                                                                <div class='SobreOAutonomo'>
                                                                    <figure>
                                                                        <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{anuncio.Titulo}</h2>
                                                                        <p>{cliente.Nome}</p>
                                                                    </div>
                                                                </div>

                                                                <section class='InicioPrazoConclusao'>
                                                                    <div>
                                                                        <h3 class='inicio'>Início</h3>
                                                                        <p>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                    <div class='divMeio'>
                                                                        <h3 class='prazo'>Prazo</h3>
                                                                        <p>{anuncio.Prazo.Nome}</p>
                                                                    </div>
                                                                    <div>
                                                                        <h3 class='conclusao'>Conclusão</h3>
                                                                        <p>{DateTime.Now.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                </section>
                                                                <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao concluir tenha certeza de que o serviço já foi completamente finalizado.</p>
                                                                <div class='divButton'>
                                                                    <button id='btnConcluir'>Concluir</button>
                                                                </div>
                                                            </section>
                                                    </article>";

                            if (autonomo.Email != "")
                                litAvaliar.Text += $@"<article class='pnlAvaliar escondido' qual='{i}'>
                                                          <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>
                                                          <input type='hidden' id='infosAutonomo' email='{autonomo.Email}'>
                                                            <div class='cabecalhoAvaliar'>
                                                                <h2>Avaliar</h2>
                                                            </div>

                                                            <div class='SobreOAutonomo'>
                                                                <figure>
                                                                    <img src='{arquivoImagemAutonomo}' alt=''>
                                                                </figure>
                                                                <div>
                                                                    <h2>{autonomo.Nome}</h2>
                                                                    <p>{anuncio.Titulo}</p>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                </div>
                                                            </div>

                                                            <div class='categoriasAvaliacao'>
                                                                <div class='cumprimentos'>
                                                                    <h2>Cumprimento de prazos:</h2>
                                                                    <div class='barra'>
                                                                        <div class='estrelasCumprimento'>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id='execucao'>
                                                                    <h2>Execução do serviço:</h2>
                                                                    <div class='barra'>
                                                                        <div class='estrelasExecucao'>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id='comunicacao'>
                                                                    <h2>Comunicação:</h2>
                                                                    <div class='barra'>
                                                                        <div class='estrelasComunicacao'>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class='SobreAAvaliacao'>
                                                                <label for='' class='divTextarea'> <strong class='strongAvaliacao'>Escreva um comentário:</strong>
                                                                    <textarea style='color: #414441;' name='' id='descricaoAvaliacao_{i}' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                                </label>
                                                                <div class='divButton'>
                                                                    <button id='btnAvaliar'>Enviar Avaliação</button>
                                                                </div>
                                                            </div>
                                                        </article>";

                            litCancelar.Text += $@"<article class='pnlCancelar escondido' qual='{i}'>
                                                       <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>

                                                        <div class='cabecalhoCancelar'>
                                                            <figure class='backIcon'>
                                                                <img src='imagens/icones/back_icon.png' alt=''>
                                                            </figure>
                                                            <h2>Cancelar</h2>
                                                        </div>

                                                            <section class='infosCliente'>
                                                                <div class='SobreOAutonomo'>
                                                                    <figure>
                                                                        <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{anuncio.Cliente.Nome}</h2>
                                                                        <p>{anuncio.Titulo}</p>
                                                                    </div>
                                                                </div>
                                                                <section class='InicioPrazoCancelamento'>
                                                                    <div>
                                                                        <h3 class='inicio'>Início</h3>
                                                                        <p>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                    <div class='divMeio'>
                                                                        <h3 class='prazo'>Prazo</h3>
                                                                        <p>{anuncio.Prazo.Nome}</p>
                                                                    </div>
                                                                    <div>
                                                                        <h3 class='cancelamento'>Cancelamento</h3>
                                                                        <p>{DateTime.Now.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                </section>
                                                                <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                                                                <div class='divButton'>
                                                                    <button id='btnCancelar2'>Cancelar</button>
                                                                </div>
                                                            </section>
                                                    </article>";

                            i++;
                        }
                        litServicos.Text += $@"</section>";
                    }
                    else
                    {
                        litServicos.Text = $@"<div class='SemAnuncios'>
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
                    Anuncios anuncios = new Anuncios();
                    List<Anuncio> listAnuncios = anuncios.CarregarAnunciosCliente(emailCliente);
                    int i = 0;

                    string arquivoImagemAutonomo = "";

                    if (listAnuncios.Count >= 1)
                    {
                        litServicos.Text = $@"<section class='listaAnuncios'>";
                        foreach (Anuncio anuncio in listAnuncios)
                        {
                            Autonomo autonomo = new Autonomo();
                            string styleEstado = "";
                            string opcoesAnuncio = "";

                            if (anuncio.Estado.Codigo == 1)
                            {
                                styleEstado = "background-color: #faab005e; color: #af6b11;";
                                opcoesAnuncio = $@"<p id='Editar'>Editar</p>
                                        <hr>
                                        <p id='Cancelar'>Cancelar Projeto</p>";
                            }
                            if (anuncio.Estado.Codigo == 2)
                            {
                                styleEstado = "background-color: #223dc35b; color: #001167;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>
                                        <hr>
                                        <p id='Concluir'>Concluir</p>
                                        <hr>
                                        <p id='Cancelar'>Cancelar Projeto</p>";
                            }
                            if (anuncio.Estado.Codigo == 3)
                            {
                                styleEstado = "background-color: #6dc00088; color: #2C4F00;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }
                            if (anuncio.Estado.Codigo == 4)
                            {
                                styleEstado = "background-color: #cb294f5b;color: #5A0015;";
                                opcoesAnuncio = $@"<p id='Denunciar'>Denunciar</p>";
                            }

                            if (anuncio.Estado.Codigo == 1)
                            {
                                Propostas propostas = new Propostas();
                                List<Autonomo> candidatos = propostas.CarregarCandidatos(anuncio.Codigo.ToString(), emailCliente);
                                litServicos.Text += $@"<article class='anuncio'>
                                                            <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}' titulo='{anuncio.Titulo}' descricao='{anuncio.Descricao}' cdPrazo='{anuncio.Prazo.Codigo}' cdArea='{anuncio.AreaAtuacao.Codigo}'>

                                                            <div class='titulo_Btn'>
                                                                <h2>{anuncio.Titulo}</h2>
                                                                <div class='status' style='{styleEstado}'>{anuncio.Estado.Nome}</div>
                                                            </div>
        
                                                            <div class='data_Prazo'>
                                                                <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                            </div>
        
                                                            <p class='descricao'>{anuncio.Descricao}</p>
        
                                                            <div class='cliente_Opcoes'>
                                                                <div>
                                                                    <a href='AutonomosDisponiveis.aspx?ca={anuncio.Codigo}'><p class='autonomosDisponiveis'>{candidatos.Count}</p></a>
                                                                    <p>Autônomo(s) disponível(eis)</p>
                                                                </div>
                                        
                                                                <figure class='pontinhos' qual='{i}'>
                                                                    <img src='imagens/icones/opcoes.png' alt=''>
                                                                </figure>
                                                            </div>

                                                            <div class='OpcoesMenu escondido' qual='{i}'>
                                                                {opcoesAnuncio}
                                                            </div>
                                                        </article>";
                            }
                            else
                            {
                                autonomo.CarregarAutonomoContratado(anuncio.Codigo);

                                if (autonomo.Nome != null)
                                {
                                    byte[] fotoAutonomo = autonomo.Foto;
                                    string base64StringAutonomo = Convert.ToBase64String(fotoAutonomo, 0, fotoAutonomo.Length);
                                    arquivoImagemAutonomo = Convert.ToString("data:image/jpeg;base64,") + base64StringAutonomo;

                                    litServicos.Text += $@"<article class='anuncio'>
                                                                <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}' titulo='{anuncio.Titulo}' descricao='{anuncio.Descricao}' cdPrazo='{anuncio.Prazo.Codigo}' cdArea='{anuncio.AreaAtuacao.Codigo}'>

                                                                <div class='titulo_Btn'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <div class='status' style='{styleEstado}'>{anuncio.Estado.Nome}</div>
                                                                </div>
        
                                                                <div class='data_Prazo'>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                                </div>
        
                                                                <p class='descricao'>{anuncio.Descricao}</p>
        
                                                                <div class='cliente_Opcoes'>
                                                                    <div>
                                                                        <a href='chatCliente.aspx'>
                                                                            <img class='autonomoSelecionado' src='{arquivoImagemAutonomo}'>

                                                                        </a>
                                                                        <p>{autonomo.Nome}</p>
                                                                    </div>
                                        
                                                                    <figure class='pontinhos' qual='{i}'>
                                                                        <img src='imagens/icones/opcoes.png' alt=''>
                                                                    </figure>
                                                                </div>

                                                                <div class='OpcoesMenu escondido' qual='{i}'>
                                                                    {opcoesAnuncio}
                                                                </div>
                                                            </article>";
                                }
                                else
                                {

                                    litServicos.Text += $@"<article class='anuncio'>
                                                                <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}' titulo='{anuncio.Titulo}' descricao='{anuncio.Descricao}' cdPrazo='{anuncio.Prazo.Codigo}' cdArea='{anuncio.AreaAtuacao.Codigo}'>

                                                                <div class='titulo_Btn'>
                                                                    <h2>{anuncio.Titulo}</h2>
                                                                    <div class='status' style='{styleEstado}'>{anuncio.Estado.Nome}</div>
                                                                </div>
        
                                                                <div class='data_Prazo'>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    <p>Prazo: <strong>{anuncio.Prazo.Nome}</strong></p>
                                                                </div>
        
                                                                <p class='descricao'>{anuncio.Descricao}</p>
        
                                                                <div class='cliente_Opcoes'>
                                                            </article>";
                                }
                            }

                            litDenunciar.Text += $@"<article class='pnlDenuncia escondido' qual='{i}'>
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
                                                        <input type='hidden' id='identificadorAutonomo' value='{autonomo.Email}'>
                                                            <p class='clienteDenunciado'>Autônomo denunciado:</p>
                                                            <div class='SobreOAutonomo'>
                                                                <figure>
                                                                    <img id='imgCliente' src='{arquivoImagemAutonomo}' alt=''>
                                                                </figure>
                                                                <div>
                                                                    <h2>{autonomo.Nome}</h2>
                                                                    <p>{anuncio.Titulo}</p>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                </div>
                                                            </div>
                                                            <div class='SobreADenuncia'>
                                                                <label for=''>Selecione uma categoria:
                                                                    <select name='' id='selectCategoriaDenuncia'></select>
                                                                </label>
                
                                                                <label for='' class='divTextarea'>Descreva o ocorrido:
                                                                    <textarea name='' id='txtDescricaoDenuncia' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                                </label>
                                                                <p class='naoSePreocupe'>Não se preocupe, essa denúncia é anônima, o autônomo não saberá que ela foi feita por você.</p>
                                                                <div class='divButton'>
                                                                    <button id='btnDenunciar'>Denunciar</button>
                                                                </div>
                                                            </div>
                                                        </section>
                                                    </article>";

                            litConcluir.Text += $@"<article class='pnlConcluir escondido' qual='{i}'>
                                                        <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>

                                                        <div class='cabecalhoConcluir'>
                                                            <figure class='backIcon'>
                                                                <img src='imagens/icones/back_icon.png' alt=''>
                                                            </figure>
                                                            <h2>Concluir</h2>
                                                        </div>
                                                            <section class='infosCliente'>
                                                                <div class='SobreOAutonomo'>
                                                                    <figure>
                                                                        <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{anuncio.Titulo}</h2>
                                                                        <p>{cliente.Nome}</p>
                                                                    </div>
                                                                </div>

                                                                <section class='InicioPrazoConclusao'>
                                                                    <div>
                                                                        <h3 class='inicio'>Início</h3>
                                                                        <p>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                    <div class='divMeio'>
                                                                        <h3 class='prazo'>Prazo</h3>
                                                                        <p>{anuncio.Prazo.Nome}</p>
                                                                    </div>
                                                                    <div>
                                                                        <h3 class='conclusao'>Conclusão</h3>
                                                                        <p>{DateTime.Now.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                </section>
                                                                <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao concluir tenha certeza de que o serviço já foi completamente finalizado.</p>
                                                                <div class='divButton'>
                                                                    <button id='btnConcluir'>Concluir</button>
                                                                </div>
                                                            </section>
                                                    </article>";

                            bool isVerificado = anuncio.VerificaAvaliacao(anuncio.Codigo);
                            if (autonomo.Email != "")
                                if (!isVerificado)
                                litAvaliar.Text += $@"<article class='pnlAvaliar escondido' qual='{i}'>
                                                          <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>
                                                          <input type='hidden' id='infosAutonomo' email='{autonomo.Email}'>
                                                            <div class='cabecalhoAvaliar'>
                                                                <h2>Avaliar</h2>
                                                            </div>

                                                            <div class='SobreOAutonomo'>
                                                                <figure>
                                                                    <img src='{arquivoImagemAutonomo}' alt=''>
                                                                </figure>
                                                                <div>
                                                                    <h2>{autonomo.Nome}</h2>
                                                                    <p>{anuncio.Titulo}</p>
                                                                    <p class='data'>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                </div>
                                                            </div>

                                                            <div class='categoriasAvaliacao'>
                                                                <div class='cumprimentos'>
                                                                    <h2>Cumprimento de prazos:</h2>
                                                                    <div class='barra'>
                                                                        <div class='estrelasCumprimento'>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id='execucao'>
                                                                    <h2>Execução do serviço:</h2>
                                                                    <div class='barra'>
                                                                        <div class='estrelasExecucao'>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id='comunicacao'>
                                                                    <h2>Comunicação:</h2>
                                                                    <div class='barra'>
                                                                        <div class='estrelasComunicacao'>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                            <figure>
                                                                                <img src='imagens/icones/estrela_vazada_sozinha.png' alt=''>
                                                                            </figure>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class='SobreAAvaliacao'>
                                                                <label for='' class='divTextarea'> <strong class='strongAvaliacao'>Escreva um comentário:</strong>
                                                                    <textarea style='color: #414441;' name='' id='descricaoAvaliacao_{i}' cols='' rows='' placeholder='Digite aqui...'></textarea>
                                                                </label>
                                                                <div class='divButton'>
                                                                    <button id='btnAvaliar'>Enviar Avaliação</button>
                                                                </div>
                                                            </div>
                                                        </article>";

                            litCancelar.Text += $@"<article class='pnlCancelar escondido' qual='{i}'>
                                                       <input type='hidden' id='infosAnuncio' codigo='{anuncio.Codigo}'>

                                                        <div class='cabecalhoCancelar'>
                                                            <figure class='backIcon'>
                                                                <img src='imagens/icones/back_icon.png' alt=''>
                                                            </figure>
                                                            <h2>Cancelar</h2>
                                                        </div>

                                                            <section class='infosCliente'>
                                                                <div class='SobreOAutonomo'>
                                                                    <figure>
                                                                        <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                                                    </figure>
                                                                    <div>
                                                                        <h2>{anuncio.Cliente.Nome}</h2>
                                                                        <p>{anuncio.Titulo}</p>
                                                                    </div>
                                                                </div>
                                                                <section class='InicioPrazoCancelamento'>
                                                                    <div>
                                                                        <h3 class='inicio'>Início</h3>
                                                                        <p>{anuncio.DataPublicacao.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                    <div class='divMeio'>
                                                                        <h3 class='prazo'>Prazo</h3>
                                                                        <p>{anuncio.Prazo.Nome}</p>
                                                                    </div>
                                                                    <div>
                                                                        <h3 class='cancelamento'>Cancelamento</h3>
                                                                        <p>{DateTime.Now.ToString().Substring(0, 10)}</p>
                                                                    </div>
                                                                </section>
                                                                <p class='atencao'><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                                                                <div class='divButton'>
                                                                    <button id='btnCancelar2'>Cancelar</button>
                                                                </div>
                                                            </section>
                                                    </article>";

                            i++;
                        }
                        litServicos.Text += $@"</section>";
                    }
                    else
                    {
                        litServicos.Text = "";
                        litSemAnuncios.Text = $@"<section class='SemAnuncios'>
                                                    <figure>
                                                        <img src='imagens/elementos/Elemento20.svg' alt=''>
                                                    </figure>
                                                    <h2>Bem vindo(a) a Unio!</h2>
                                                    <p>Este é o seu painel de anúncios, que tal começar criando um novo?</p>
                                                    <a href='criacaoAnuncio.aspx'><button id='btnCriarAnuncio'>Criar anúncio</button></a>
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

                Response.Redirect($@"painelCliente.aspx?st={status}&dt={dtPublicacao}&pr={prazoSelecionado}");
            }

        }
    }
}