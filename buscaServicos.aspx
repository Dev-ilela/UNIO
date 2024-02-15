<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscaServicos.aspx.cs" Inherits="Unio.buscaServicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerAutonomoLogado.css"/>
    <link rel="stylesheet" href="css/FiltroGlobal.css">
    <link rel="stylesheet" href="css/buscarServicos&PropostasStyle.css"/>
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png"/>
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <div class="divLogo">
                <a href="painelAutonomo.aspx">
                    <img class="logo_padrao" src="imagens/logos/logo_branca.png" alt="">
                    <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="">
                   </a>
            </div>

            <div class="divMenu">
                <ul>
                  <li><img class="aviso_notificacao escondido" src="imagens/icones/aviso_Notificações.png" alt=""><a href="chatAutonomo.aspx"><img src="imagens/icones/Mensagens_icon.png" alt="Ícone de mensagens"></a></li>
                  <li class="liDoPopup">
                    <div class="popupNotificacao escondido">
                        <div>
                            <figure><img src="imagens/icon_notificacoes/icon_selecionado.png" alt=""></figure>
                            <p>
                                <strong>Você foi selecionado!</strong><br>
                                Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                            </p>
                        </div>
                        <div>
                            <figure><img src="imagens/icon_notificacoes/icon_concluido.png" alt=""></figure>
                            <p>
                                <strong>Serviço concluído</strong><br>
                                Cliente concluiu o serviço. Confirme você também para finalizá-lo.
                            </p>
                        </div>
                        <div>
                            <figure><img src="imagens/icon_notificacoes/icon_selecionado.png" alt=""></figure>
                            <p>
                                <strong>Você foi selecionado!</strong><br>
                                Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                            </p>
                        </div>
                        <div>
                            <figure>
                                <img src="imagens/icon_notificacoes/icon_mensagem.png" alt="">
                            </figure>
                            <p>
                                <strong>Você tem uma nova mensagem</strong><br>
                                Você tem uma nova mensagem do cliente. Dê uma olhada quando puder.
                            </p>
                        </div>
                        <div>
                            <figure><img src="imagens/icon_notificacoes/icon_selecionado.png" alt=""></figure>
                            <p>
                                <strong>Você foi selecionado!</strong><br>
                                Parabéns! Você foi aceito para o serviço solicitado, acerte os detalhes através do chat.
                            </p>
                        </div>
                        <div>
                            <figure>
                                <img src="imagens/icon_notificacoes/icon_mensagem.png" alt="">
                            </figure>
                            <p>
                                <strong>Você tem uma nova mensagem</strong><br>
                                Você tem uma nova mensagem do cliente. Dê uma olhada quando puder.
                            </p>
                        </div>
                    </div>
                    <img class="aviso_notificacao escondido" src="imagens/icones/aviso_Notificações.png" alt=""><img id="sininho" src="imagens/icones/Notificacoes_icon.png" alt="Ícone de notificações">
                  </li>
                  <li id="perfilAutonomo">
                      <asp:Literal ID="litImgPerfil" runat="server"></asp:Literal>
                      <%--<img src="imagens/autonomos/autonomo_3.png" id="imgAutonomo" alt="ícone do perfil">--%>
                  </li>
                </ul>
              
                <article class="prflAutonomo escondido">
                    <a href="painelAutonomo.aspx" class="opcao">Painel de Serviços</a>
                    <a href="meuPerfilAutonomo.aspx" class="opcao">Meu perfil</a>
                    <a href="buscarServicos.aspx" class="opcao">Serviços</a>
                    <a href="propostasRecebidas.aspx" class="opcao">Propostas</a>
                    <a href="ComoFunciona.aspx" class="opcao"><img src="imagens/icones/comoFunciona_Icon.png" alt=""/>Como funciona</a>
                    <button class="opcaoBtn">Sair</button>
                  </article>
            </div>
        </main>  
    </header>
    <section class="areaMenu escondido"></section>

        <div class="fundo-mensagem escondido">
            <span class="mensagem-erro-ou-sucesso escondido">
            </span>
        </div>

        <asp:Literal ID="litPopUpDetalhes" runat="server"></asp:Literal> runat="server" />

<%--    <article class="popupDetalhes escondido">
        <div class="areaVermelha">Você realmente deseja se candidatar para esta vaga?</div>

        <section class="infosClienteDetalhes">
            <figure>
                <img src="imagens/clientes/cliente_2.png" alt="">
            </figure>
            <div class="SobreOanuncio">
                <h2>Conserto de geladeira</h2>
                <p class="nome">Marcela Borella</p>
                <div>
                    <p class="data">19/06/2023</p>
                    <p>Prazo: <strong>A definir</strong></p>
                </div>
            </div>
        </section>
        <p class="descricao2">O Congelador da minha geladeira está gelando cada vez menos, de uma semana pra cá passou a fazer bastante barulho e soltar água por baixo, não sei o que fazer...</p>
        <div class="buttons">
            <button id="btnCancelar">Cancelar</button>
            <button id="btnCandidatarMesmo">Candidatar</button>
        </div> 
    </article>--%>

    <section class="blur escondido"></section>

    <section class="sessaoBg">
        <main>
            <section class="geral">

                <section class="filtroPorCategoria">
                    <asp:DropDownList ID="ddlProfissao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfissao_SelectedIndexChanged" CssClass="profissao"></asp:DropDownList>
                   
                    <div class="filtro">
                        <div class="filtroTitulo">
                            <p>Filtre por:</p>
                        </div>
                        
                        <div class="categorias">
                            <div class="alinhar">
                                <label for="" class="classificar">
                                    <details>
                                        <summary>Classificar</summary>
                                        <p>Data de postagem</p>
                                        <div><asp:RadioButton GroupName="radio"  ID="maisRecente" runat="server" />Mais recente</div>
                                        <div><asp:RadioButton GroupName="radio" ID="maisAntigo" runat="server" />Mais antigo</div>
                                        

                                        <p>Prazo</p>
                                       <div class="inputs">
                                            <asp:DropDownList ID="selectPrazo" runat="server"></asp:DropDownList>
                                        </div>
                                      </details>
                                </label>
    
                                <label for="" class="cidade">
                                    <details>
                                        <summary>Estado</summary>
                                        <asp:DropDownList ID="ddlEstado" AutoPostBack="false" runat="server"></asp:DropDownList>
                                    </details>
                                </label>
                            </div>
                            <asp:Button ID="Aplicar" runat="server" Text="Aplicar" OnClick="Aplicar_Click"/>
                        </div>
                        
                    </div>
                </section>
    
                <section class="resultadosBusca">
                    <div class="divBuscar">
                         <asp:TextBox ID="iptBusca" placeholder="Busque por..." runat="server"></asp:TextBox>
                        
                         <asp:ImageButton ID="btnBuscar" src="imagens/icones/lupa_azul.png" runat="server" OnClick="btnBuscar_Click"/>
                        
                    </div>

                    <%--<div class="SemAnuncios escondido">
                        <figure>
                            <img src="imagens/elementos/Elemento19.svg" alt="">
                        </figure>
                        <h2>Hmm... Não achamos um serviço com essas especificações :/
                        </h2>
                        <p>Tente pesquisar de uma maneira diferente.</p>
                       </div>--%>

                    <asp:Literal ID="SemAnuncios" runat="server"></asp:Literal>
                    <div class="resultados">

                        <asp:Literal ID="litResultados" runat="server"></asp:Literal>

                        <%--<article class="anuncio">
                            <div class="titulo_Btn">
                                <h2>Conserto de geladeira</h2>
                                <button class="btnCandidatar">Se Candidatar</button>
                            </div>

                            <div class="data_Prazo">
                                <p class="data">19/06/2023</p>
                                <p>Prazo: <strong>A definir</strong></p></p>
                            </div>

                            <p class="descricao">O Congelador da minha geladeira está gelando cada vez menos, de uma semana pra cá passou a fazer bastante barulho e soltar água por baixo, não sei o que fazer...</p>

                            <div class="cliente_Opcoes">
                                <div>
                                    <figure>
                                        <img src="imagens/clientes/cliente_2.png" alt="">
                                    </figure>
                                    <p>Marcela Borella</p>
                                </div>
                            </div>
                        </article>

                        <article class="anuncio">
                            <div class="titulo_Btn">
                                <h2>Conserto de geladeira</h2>
                                <button class="btnCandidatar">Se Candidatar</button>
                            </div>

                            <div class="data_Prazo">
                                <p class="data">19/06/2023</p>
                                <p>Prazo: <strong>A definir</strong></p></p>
                            </div>

                            <p class="descricao">O Congelador da minha geladeira está gelando cada vez menos, de uma semana pra cá passou a fazer bastante barulho e soltar água por baixo, não sei o que fazer...</p>

                            <div class="cliente_Opcoes">
                                <div>
                                    <figure>
                                        <img src="imagens/clientes/cliente_2.png" alt="">
                                    </figure>
                                    <p>Marcela Borella</p>
                                </div>
                            </div>
                        </article>

                        <article class="anuncio">
                            <div class="titulo_Btn">
                                <h2>Conserto de geladeira</h2>
                                <button class="btnCandidatar">Se Candidatar</button>
                            </div>

                            <div class="data_Prazo">
                                <p class="data">19/06/2023</p>
                                <p>Prazo: <strong>A definir</strong></p></p>
                            </div>

                            <p class="descricao">O Congelador da minha geladeira está gelando cada vez menos, de uma semana pra cá passou a fazer bastante barulho e soltar água por baixo, não sei o que fazer...</p>

                            <div class="cliente_Opcoes">
                                <div>
                                    <figure>
                                        <img src="imagens/clientes/cliente_2.png" alt="">
                                    </figure>
                                    <p>Marcela Borella</p>
                                </div>
                            </div>
                        </article>

                        <article class="anuncio">
                            <div class="titulo_Btn">
                                <h2>Conserto de geladeira</h2>
                                <button class="btnCandidatar">Se Candidatar</button>
                            </div>

                            <div class="data_Prazo">
                                <p class="data">19/06/2023</p>
                                <p>Prazo: <strong>A definir</strong></p></p>
                            </div>

                            <p class="descricao">O Congelador da minha geladeira está gelando cada vez menos, de uma semana pra cá passou a fazer bastante barulho e soltar água por baixo, não sei o que fazer...</p>

                            <div class="cliente_Opcoes">
                                <div>
                                    <figure>
                                        <img src="imagens/clientes/cliente_2.png" alt="">
                                    </figure>
                                    <p>Marcela Borella</p>
                                </div>
                            </div>
                        </article>--%>

                        <!-- <div class="mudarPagina">
                            <p class="pDestacado">1</p>
                            <p>2</p>
                            <p>3</p>
                            <p>4</p>
                            <p>...</p>
                            <p>6</p>
                        </div>-->
                    </div> 

                </section>
            </section>
        </main>
    </section>

    <script type="text/javascript" src="script/detalhesAnuncio.js"></script>
    <script type="text/javascript" src="script/menuHeaderAutonomo.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    <script type="text/javascript" src="script/candidatura.js"></script>
    </form>
</body>
</html>
