<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meuPerfilAutonomo.aspx.cs" Inherits="Unio.meuPerfilAutonomo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerAutonomoLogado.css">
    <link rel="stylesheet" href="css/meuPerfilAutonomo.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
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

                <%--<section class="perfilAutonomo">
                    <section class="bgPerfil">
                        <asp:Literal ID="litInfosAutonomo" runat="server"></asp:Literal>
                        <asp:DropDownList ID="ddlProfissao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfissao_SelectedIndexChanged" CssClass="profissao"></asp:DropDownList>
                        <asp:Literal ID="litInfosAutonomo2" runat="server"></asp:Literal>
                    </section>
                </section>--%>

                <section class="perfilAutonomo">
                    <section class="bgPerfil">
                        <asp:Literal ID="identificadorAutonomo" runat="server"></asp:Literal>
                        <asp:Literal ID="litInfosAutonomo" runat="server"></asp:Literal>
                        <asp:DropDownList ID="ddlProfissao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfissao_SelectedIndexChanged" CssClass="profissao"></asp:DropDownList>
                        <asp:Literal ID="litInfosAutonomo2" runat="server"></asp:Literal>
                    </section>
                </section>

                <%--<section class="perfilAutonomo">
                    <section class="bgPerfil" >
                        <asp:Literal ID="identificadorAutonomo" runat="server"></asp:Literal>
                        <div class="informacoes">
                            <asp:Literal ID="litImgPerfil1" runat="server"></asp:Literal>
                            <img id="imgAutonomo" src="imagens/autonomos/autonomo_3.png" alt="">
                            <div class="progressoAutonomo">
                                <p class="progresso" valor="4">4,0</p>
                                <div class="avaliacaoProgresso">
                                    <div class="barra">
                                        <div></div>
                                    </div>
                                    <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                </div>
                            </div>
                            <div class="info">
                                <h2>Joaquim Braga Oliveira</h2>
                                <div class="cidade"> <img src="imagens/icones/localizacao.png" alt=""> Santos - SP </div>
                            </div>                    
                        </div>
                    </section>
                </section>--%>

                <section class="edicaoPerfil">
                        <div class="filtroAreas">
                            <div class="filtroSelecionado" id="meusDados">
                                <p>Meus Dados</p>
                            </div>
                            <div id="btnProfissoes">
                               <p>Minha Profissão</p> 
                            </div>
                            <div id="btnPortfolio">
                                <p>Meu Portfólio</p>
                            </div>
                            <a href="emblemas.aspx">
                                <div id="emblemas">
                                    <p>Emblemas</p>
                                </div>
                            </a>
                            <a href="avaliacoesDoAutonomo.aspx">
                                <div id="avaliacoes">
                                    <p>Avaliações</p>
                                </div>
                            </a>
                            
                        </div>

                    <asp:Literal ID="litDadosBasicos" runat="server"></asp:Literal>
                    <asp:Literal ID="litProfissao" runat="server"></asp:Literal>
                        

                        <%--<button id="adicionarNovaProfissao">Adicionar</button>  --%>

                        <%--<div class="profissoesNovas escondido">
                            <div class="coluna1">
                                <label for="">Qual é a sua profissão?
                                    <div class="divInput">
                                        <select name="" id="" class="inputs">
                                        <option value="">Selecione</option>
                                        </select>
                                    </div>
                                </label>
    
                                <label for="">Forma de trabalho:
                                    <div class="formasTrabalho">
                                        <div><input type="checkbox"><p>Presencial</p></div>
                                        <div><input type="checkbox"><p>Home-Office</p></div>
                                        <div><input type="checkbox"><p>Híbrido</p></div>
                                    </div>
                                </label>
    
                                <label for="">Adicione uma descrição:
                                    <div class="divTextarea">
                                        <textarea name="" id="" cols="" rows="" placeholder="Descreva sobre como é o seu modo de trabalhar, tempo de experiência etc"></textarea>
                                    </div>
                                </label>
                            </div>
                            <div class="coluna2">
                                <label for="">Formas de pagamento aceitas por você:
                                    <div class="formasPagamento">
                                        <div><input type="checkbox"><p>Dinheiro</p></div>
                                        <div><input type="checkbox"><p>Pix</p></div>
                                        <div><input type="checkbox"><p>Débito</p></div>
                                        <div><input type="checkbox"><p>Crédito</p></div>
                                    </div>
                                </label>
                                <p>*Por favor, revise seus dados antes de criar seu perfil!</p>
                                    
    
                                <button id="btnAddProfissao" class="btnAdd">Adicionar</button> 
                            </div> 
                        </div>--%>

                        <div class="portfolio escondido">
                            <%--<div class="divBntAddImagem">
                                <p>
                                    <button class="btnAddImagem">Adicionar foto</button>
                                    <label class="btnAddImagem" for="btnAddImagem">Selecionar imagem</label>
                                    <input type="file" name="file" id="btnAddImagem" style="display: none" >

                                    <button id="btnSalvarPortfolio" class="btnAddImagem escondido">Adicionar imagem</button>
                                </p>
                            </div>--%>
                                    <asp:Literal ID="litAcoesPortfolio" runat="server"></asp:Literal>
                            <div class="imagens">
                                <asp:Literal ID="litPortfolio" runat="server"></asp:Literal>
                                <asp:Literal ID="litSemPortfolio" runat="server"></asp:Literal>
                                <asp:Literal ID="identificadorPortfolio" runat="server"></asp:Literal>
                                <%--<figure>
                                    <img src="imagens/autonomos/portfolio_1.png" alt="">
                                    <img class="iconeLixo" src="imagens/icones/icone_lixo.png" alt="">
                                </figure>
                                <figure>
                                    <img src="imagens/autonomos/portfolio_2.png" alt="">
                                    <img class="iconeLixo" src="imagens/icones/icone_lixo.png" alt="">
                                </figure>
                                <figure>
                                    <img src="imagens/autonomos/portfolio_3.png" alt="">
                                    <img class="iconeLixo" src="imagens/icones/icone_lixo.png" alt="">
                                </figure>--%>
                                <%--<figure><img src="imagens/autonomos/portfolio_3.png" alt=""><img class="iconeLixo" src="imagens/icones/icone_lixo.png" alt=""></figure>
                                <figure><img src="imagens/autonomos/portfolio_3.png" alt=""><img class="iconeLixo" src="imagens/icones/icone_lixo.png" alt=""></figure>--%>
                                <!-- <figure id="btnAddImagem"><a href=""><img class="adicionaFoto" src="imagens/icones/icon_portfolio.png" alt=""></a></figure> -->
                            </div>
                        </div>
                    </div>
                </section>
            </section>
        </main>
    </section>

    <script src="script/meuPerfilAutonomo.js"></script>
    <script src="script/menuHeaderAutonomo.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    <script type="text/javascript" src="script/portfolio.js"></script>
    </form>
</body>
</html>
