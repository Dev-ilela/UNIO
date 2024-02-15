<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emblemas.aspx.cs" Inherits="Unio.emblemas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerAutonomoLogado.css">
    <link rel="stylesheet" href="css/emblemasStyle.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <div class="divLogo">
                <a href="painelAutonomo.aspx">
                    <img class="logo_padrao" src="imagens/logos/logo_branca.png" alt=""/>
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
                     <asp:Literal ID="identificadorAutonomo" runat="server"></asp:Literal>
                    <asp:Literal ID="litImgPerfil" runat="server"></asp:Literal>
                    <%--<img src="imagens/autonomos/autonomo_3.png" id="imgAutonomo" alt="ícone do perfil">--%>
                </li>
              
                <article class="prflAutonomo escondido">
                    <a href="painelAutonomo.aspx" class="opcao">Painel de Serviços</a>
                    <a href="meuPerfilAutonomo.aspx" class="opcao">Meu perfil</a>
                    <a href="buscaServicos.aspx" class="opcao">Serviços</a>
                    <a href="propostasRecebidas.aspx" class="opcao">Propostas</a>
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
             <div class="divVoltar">
                 <a href="meuPerfilAutonomo.aspx"><img src="imagens/icones/back_icon.png" alt=""></a>
                <p>Voltar</p>
             </div>

            <section class="perfilAutonomo">
                <section class="bgPerfil">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <asp:Literal ID="litInfosAutonomo" runat="server"></asp:Literal>
                    <asp:DropDownList ID="ddlProfissao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfissao_SelectedIndexChanged" CssClass="profissao"></asp:DropDownList>
                    <asp:Literal ID="litInfosAutonomo2" runat="server"></asp:Literal>
                </section>
            </section>
            </section>

             <section class="MenuSobreEmblemas">

                    <div class="filtroAreas">
                        <div class="filtroSelecionado" id="btnMeuProgresso">
                            <p>Meu Progresso</p>
                        </div>
                        <div id="btnNovato">
                           <p>Novato</p> 
                        </div>
                        <div id="btnBronze">
                            <p>Bronze</p>
                        </div>
                        <div id="btnPrata">
                            <p>Prata</p>
                        </div>
                        <div id="btnOuro">
                            <p>Ouro</p>
                        </div>
                    </div>

                    <article class="infoEmblemas">
                        <asp:Literal ID="litEmblemaAtual" runat="server"></asp:Literal>
                        <%--<div class="div1">
                            <div class="divEmblemaAtual">
                                <figure><img src="imagens/emblemas/prata.png" alt=""></figure>
                                <p>Você é um profissional prata!</p>
                            </div>
                            <div class="descricaoEmblemaAtual">
                                <p>O emblema “<strong>Prata</strong>”, é conquistado quando você alcança a marca de 200 trabalhos concluídos com excelência. Parabéns, continue assim!</p>
                            </div>
                        </div>--%>

                         <asp:Literal ID="litEmblemasConquistados" runat="server"></asp:Literal>
                       <%-- <div class="div2">
                            <div class="emblemasConquistados">
                                <p>Emblemas conquistados por você:</p>
                                <div>
                                    <div>
                                        <figure><img src="imagens/emblemas/prata.png" alt=""></figure>
                                        <p>Prata</p>
                                    </div>
                                    <div>
                                        <figure><img src="imagens/emblemas/bronze.png" alt=""></figure>
                                        <p>Bronze</p>
                                    </div>
                                    <div>
                                        <figure><img src="imagens/emblemas/novato.png" alt=""></figure>
                                        <p>Novato</p>
                                    </div>
                                </div>
                            </div>
                            <div class="divGrafico">
                                <figure><img src="imagens/graficos_emblemas/grafico_prata.png" alt=""></figure>
                                <p>Faltam <strong>2</strong> emblemas para se tornar um profissional ouro!</p>
                            </div>--%>
                        </div>
                    </article>

                    <article class="sobreNovato escondido">
                        <div class="dsNovato">
                            <figure>
                                <img src="imagens/emblemas/novato.png" alt="">
                            </figure>
                            <p>O emblema <strong>“Novato”</strong>, é utilizado para sinalizar que o autônomo é novo na plataforma.

                                Você perde esta marca após concluir seus
                                5 primeiros serviços.
                            </p>
                        </div>
                        <div class="barraEicon">
                            <p>Seu progresso neste emblema:</p>
                            <div>
                                <div class="barraNovato">
                                    <div></div>
                                </div>
                                <figure>
                                    <img src="imagens/icones/certificado_icon.png" alt="">
                                </figure>
                            </div>
                        </div>
                    </article>

                    <article class="sobreBronze escondido">
                        <div class="dsBronze">
                            <figure>
                                <img src="imagens/emblemas/bronze.png" alt="">
                            </figure>
                            <p>O emblema <strong>“Bronze”</strong>, é concedido à aqueles profissionais que conquistaram a meta de 10 serviços realizados com sucesso, ou seja, onde receberam máxima avaliação.</p>
                        </div>
                        <div class="barraEicon">
                            <p>Seu progresso neste emblema:</p>
                            <div>
                                <div class="barraBronze">
                                    <div></div>
                                </div>
                                <figure>
                                    <img src="imagens/icones/certificado_icon.png" alt="">
                                </figure>
                            </div>
                           <%-- <div class="quantoFaltaBronze" valorBronze="80">
                                <p>50/100</p>
                            </div>--%>
                            <asp:Literal ID="litBarraBronze" runat="server"></asp:Literal>
                        </div>
                    </article>

                    <article class="sobrePrata escondido">
                        <div class="dsPrata">
                            <figure>
                                <img src="imagens/emblemas/prata.png" alt="">
                            </figure>
                            <p>O emblema <strong>“Prata”</strong>, é concedido à aqueles profissionais que conquistaram a meta de 20 serviços realizados com sucesso, ou seja, onde receberam máxima avaliação.</p>
                        </div>
                        <div class="barraEicon">
                            <p>Seu progresso neste emblema:</p>
                            <div>
                                <div class="barraPrata">
                                    <div></div>
                                </div>
                                <figure>
                                    <img src="imagens/icones/certificado_icon.png" alt="">
                                </figure>
                            </div>
                            <%--<div class="quantoFaltaPrata" valorPrata="80">
                                <p>50/100</p>
                            </div>--%>
                            <asp:Literal ID="litBarraPrata" runat="server"></asp:Literal>
                        </div>
                    </article>

                    <article class="sobreOuro escondido">
                        <div class="dsOuro">
                            <figure>
                                <img src="imagens/emblemas/ouro.png" alt="">
                            </figure>
                            <p>O emblema <strong>“Ouro”</strong>, é concedido à aqueles profissionais que conquistaram a meta de 30 serviços realizados com sucesso, ou seja, onde receberam máxima avaliação.</p>
                        </div>
                        <div class="barraEicon">
                            <p>Seu progresso neste emblema:</p>
                            <div>
                                <div class="barraOuro">
                                    <div></div>
                                </div>
                                <figure>
                                    <img src="imagens/icones/certificado_icon.png" alt="">
                                </figure>
                            </div>
                            <%--<div class="quantoFaltaOuro" valorOuro="80">
                                <p>50/100</p>
                            </div>--%>
                            <asp:Literal ID="litBarraOuro" runat="server"></asp:Literal>
                        </div>
                    </article>
                </section>

            </section>
 
        </main>

    </section>
    <script src="script/emblemas.js"></script>
    <script src="script/menuHeaderAutonomo.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
