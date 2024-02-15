<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="avaliacoesDoAutonomo.aspx.cs" Inherits="Unio.avaliacoesDoAutonomo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
<meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/headerAutonomoLogado.css">
    <link rel="stylesheet" href="css/avaliacoesDoAutonomo.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
    <title>UNIO</title>
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

                  </li>
                </ul>
              
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
                        <asp:Literal ID="identificadorAutonomo" runat="server"></asp:Literal>
                        <asp:Literal ID="litInfosAutonomo" runat="server"></asp:Literal>
                        <asp:DropDownList ID="ddlProfissao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfissao_SelectedIndexChanged" CssClass="profissao"></asp:DropDownList>
                        <asp:Literal ID="litInfosAutonomo2" runat="server"></asp:Literal>
                    </section>
                </section>
                </section>

                

                <section class="filtros">
                    <div>
                        <div><p>Avaliação</p></div>
                        <select id="selectAvaliacao">
                            <option value="Maior">Maior</option>
                            <option value="Menor">Menor</option>
                        </select>
                    </div>
                </section>

                <asp:Literal ID="litAvaliacoes" runat="server"></asp:Literal>

                <%--<section class="SemAvaliacao">
                    <figure>
                        <img src="imagens/elementos/Elemento21.svg" alt="">
                    </figure>
                    <h2>Hmm... Ainda não te avaliaram</h2>
                    <p>Dica: antes de concluir um serviço peça para que o cliente te avalie, isso ajuda outras pessoas a virem até você!</p>
                </section>

                <section class="avaliacaoAutonomo escondido">
                    <div class="avaliacao">
                        <img src="imagens/clientes/cliente_1.png" alt="">

                        <div class="infoGeral">

                            <div class="infoCima">
                                <div class="nomeEavalicao">
                                    <h2>Carolina de Almeida dos Santos</h2>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <p>24/03/2022</p>
                            </div>

                            <p>O seu Joaquim foi um ótimo profissional, entregou tudo no prazo, sem gambiarras e ainda deixou tudo limpinho antes de ir embora. Super educado, e sincero, recomendo!</p>
                        </div>

                    </div>

                    <div class="avaliacao">
                        <img src="imagens/clientes/cliente_2.png" alt="">
                        <div class="infoGeral">
                            <div class="infoCima">
                                <div class="nomeEavalicao">
                                    <h2>Silvana Evangelista Costa</h2>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <p>12/03/2022</p>

                            </div>
                            <p>Contratei o seu Joaquim pra trocar o azulejo daqui de casa e ele fez um bom serviço, tivemos um probleminha com o horário mas ele foi bem paciente e prestativo para resolver. Recomendo.</p>
                        </div>
                    </div>

                    <div class="avaliacao">
                        <img src="imagens/clientes/cliente_3.png" alt="">
                        <div class="infoGeral">
                            <div class="infoCima">
                                <div class="nomeEavalicao">
                                    <h2>Carlos Augusto de Alencar</h2>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="4.5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <p>15/02/2022</p>

                            </div>
                            <p>Muito bom o trabalho dele, recomendo.</p>
                        </div>
                    </div>

                    <div class="avaliacao">
                        <img src="imagens/clientes/cliente_4.png" alt="">
                        <div class="infoGeral">
                            <div class="infoCima">
                                <div class="nomeEavalicao">
                                    <h2>Josislene Alves da Silva</h2>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="4">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <p>07/02/2022</p>

                            </div>
                            <p>Ele fez o trabalho muito bem, só é bem fechado. Ofereci um cafézinho e ele não quis, por isso vou dar 4 estrelas.</p>
                        </div>
                    </div>

                    <div class="avaliacao">
                        <img src="imagens/clientes/cliente_5.png" alt="">
                        <div class="infoGeral">
                            <div class="infoCima">
                                <div class="nomeEavalicao">
                                    <h2>Vitor dos Andes</h2>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="2">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <p>30/01/2022</p>

                            </div>
                            <p>Muito careiro.</p>
                        </div>
                    </div>
                </section>

            </section>--%>
        </main>
    </section>
    <script type="text/javascript" src="script/menuHeaderAutonomo.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    <script type="text/javascript" src="script/AvaliacoesAutonomo.js"></script>
    </form>
</body>
</html>
