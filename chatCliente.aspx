<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chatCliente.aspx.cs" Inherits="Unio.chatCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
<meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerClienteLogado.css">
    <link rel="stylesheet" href="css/chatGlobal.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <div class="divLogo">
                <a href="painelCliente.aspx">
                    <img class="logo_padrao" src="imagens/logos/logo_branca.png" alt=""/>
                    <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="">
                </a>
            </div>

            <div class="divBusca">
                <input type="text" name="iptBusca" id="iptBusca" placeholder="Ex. eletricista">
                <a href="busca.aspx" id="btnBusca"><button id="btnBusca"><img src="imagens/icones/search_icon.png" alt=""></button></a>
            </div>

            <div class="divMenu">
                <ul>
                  <li><img class="aviso_notificacao escondido" src="imagens/icones/aviso_Notificações.png" alt=""><a href="chatCliente.aspx"><img src="imagens/icones/Mensagens_icon.png" alt="Ícone de mensagens"></a></li>
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
                  <li id="perfilCliente">
                      <asp:Literal ID="litImgPerfil" runat="server"></asp:Literal>
                  </li>
                </ul>
              
                <article class="prflCliente escondido">
                    <a href="painelCliente.aspx" class="opcao">Painel de Serviços</a>
                    <a href="meuPerfilCliente.aspx" class="opcao">Meu perfil</a>
                    <a href="criacaoAnuncio.aspx" class="opcao">Criar anúncios</a>
                    <a href="AutonomosFavoritos.aspx" class="opcao">Favoritos</a>
                    <a href="ComoFunciona.aspx" class="opcao"><img src="imagens/icones/comoFunciona_Icon.png" alt="">Como funciona</a>
                    <button class="opcaoBtn">Sair</button>
                </article>
            </div>
        </main>  
    </header>
    <section class="areaMenu escondido"></section>

    <section class="sessaoBg">
        <main>
            <section class="geral">
                <h2>Conversas:</h2>
                <article class="areaChat">
                    <section class="janelas">
                        <div class="busca">
                            <input class="busquePor" type="text" placeholder="Busque por...">
                            <button id="btnBuscar"><img src="imagens/icones/lupa_chat.png" alt=""></button>
                        </div>

                        <section class="SemAnuncios">
                            <figure>
                                <img src="imagens/elementos/Elemento25.svg" alt="">
                            </figure>
                            <h2>Cri cri... Cri cri...</h2>
                            <p>Que silêncio por aqui, dê uma olhada nos autônomos candidatados em algum anúncio feito por você e faça negócios!</p>
                            <button id="btnProcurar">Procurar Agora</button>
                        </section>
                        <div class="pessoas escondido" id="regiaoChats">
                            <%--<div style="position:relative"class="principal">
                                <img class="aviso_notificacao" src="imagens/icones/aviso_Notificações.png" alt="">
                                <figure><img src="imagens/clientes/cliente3.png" alt=""></figure>
                                <div>
                                    <h3>Guilhermino de Jesus</h3>
                                    <p>Pedreiro</p>
                                </div>
                            </div>--%>
                           <%-- <div class="principal">
                                <figure><img src="imagens/clientes/cliente3.png" alt=""></figure>
                                <div>
                                    <h3>Antônio Carlos da Cruz Tavares</h3>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                            </div>
                            <div class="principal">
                                <figure><img src="imagens/clientes/cliente3.png" alt=""></figure>
                                <div>
                                    <h3>Manoel Barreto dos Santos</h3>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                            </div>
                            <div class="principal">
                                <figure><img src="imagens/clientes/cliente3.png" alt=""></figure>
                                <div>
                                    <h3>Joaquim Braga Oliveira</h3>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                            </div>
                            <div class="principal">
                                <figure><img src="imagens/clientes/cliente3.png" alt=""></figure>
                                <div>
                                    <h3>Joilson da Silva</h3>
                                    <p>Lorem ipsum dolor sit amet</p>
                                </div>
                            </div>
                        </div>--%>
                    </section>
                    <section class="conversas" id="conversas">
                        <%--<div class="infoPessoa">--%>
                            <%--<h1>Joaquim Braga Oliveira</h1>
                            <div>
                                <p><strong>Prazo:</strong> A definir</p>
                                <figure><img src="imagens/icones/alert_icon.png" alt=""></figure>
                            </div>
                        </div>--%>

                        <%-- IMPORTANTE --%>
                        <%--<div class="chat" id="chat">
                            
                            <div class="msgServiçoIniciado">
                                <p>Serviço iniciado em 26/07/2023</p>
                            </div>

                            <div class="msgRecebida">
                                <p>Você vai cobrar quanto pra fazer isso?</p>
                            </div>
                            <div class="msgEnviada">
                                <p>Ah pelo tempo que vai levar vai ter que ser uns 500 reais dona</p>
                            </div>
                            <div class="msgEnviada">
                                <p>Vou deixar de fazer muito trabalho pra focar no seu e ficar bom</p>
                            </div>
                            <div class="msgRecebida">
                                <p>Poxa, a situação tá complicada pra mim, se eu pagar a vista você não faz por 400?</p>
                            </div>
                            <div class="msgEnviada">
                                <p>Tá complicado pra todo mundo né, mas vou fechar nesse valor pra você vai</p>
                            </div>
                            <div class="msgRecebida">
                                <p>Muito obrigada moço, vou fechar o trabalho com você então</p>
                            </div>
                        </div>
                        <div class="enviarMsg">
                            <input class="enviar" type="text" placeholder="Escreva aqui...">
                            <button id="btnEnviar">Enviar</button>
                        </div>--%>
                    </section>
                </article>
            </section>
        </main>
    </section>
    
    <script type="text/javascript" src="script/menuHeaderCliente.js"></script>
    <script type="text/javascript" src="script/chatGlobal.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
