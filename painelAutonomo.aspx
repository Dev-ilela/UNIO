<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="painelAutonomo.aspx.cs" Inherits="Unio.painelAutonomo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerAutonomoLogado.css"/>
    <link rel="stylesheet" href="css/painelAutonomoStyle.css"/>
    <link rel="stylesheet" href="css/FiltroGlobal.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png"/>
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

    <div class="fundo-mensagem escondido">
        <span class="mensagem-erro-ou-sucesso escondido">
        </span>
    </div>

        <asp:Literal ID="litDenunciar" runat="server"></asp:Literal>

        <asp:Literal ID="litDesistir" runat="server"></asp:Literal>

    <section class="blur escondido"></section>

    <section class="sessaoBg">
        <main>
            <section class="geral">

                <section class="perfilAutonomo">
                    <section class="bgPerfil">
                        <asp:Literal ID="identificadorAutonomo" runat="server"></asp:Literal>
                        <asp:Literal ID="litInfosAutonomo" runat="server"></asp:Literal>
                        <asp:DropDownList ID="ddlProfissao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfissao_SelectedIndexChanged" CssClass="profissao"></asp:DropDownList>
                        <asp:Literal ID="litInfosAutonomo2" runat="server"></asp:Literal>
                    </section>
                </section>

                <section class="menuAutonomo">
                    <asp:Literal ID="litProgressoEmblema" runat="server"></asp:Literal>

                    <div class="procurarServicos">
                        <div class="organizar">
                            <p><a href="buscaServicos.aspx">Procurar Serviços</a></p>
                            <img src="imagens/icones/procurarServico_icon.png" alt="">                            
                        </div>
                    </div>

                    <div class="propostasRecebidas">
                        <a href="propostasRecebidas.aspx"><p>Propostas Recebidas</p></a>
                        <div style="position:relative">
                            <img class="aviso_notificacao escondido" src="imagens/icones/aviso_Notificações.png" alt="">
                            <img src="imagens/icones/propostasRecebidas_icon.png" alt="">
                        </div>
                        
                    </div>
                </section>

                <section class="painelServicos">

                    <h2 class="titulo">Painel de Serviços:</h2>

                    <section class="sectionGeral">

                        <section class="filtroPorCategoria">
                        
                            <div class="filtro">
                                <div class="filtroTitulo">
                                    <p>Filtre por:</p>
                                </div>
                                
                                <div class="categorias">
                                    <div class="alinhar">
                                        <label for="" class="status">
                                            <details>
                                                <summary>Status</summary>
                                                <%--<div><input type="checkbox" name="" id="checkbox"><p>Concluido</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Em andamento</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Aguardando resposta</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Cancelado</p></div>--%>
                                                <asp:CheckBoxList ID="checkboxStatus" runat="server"></asp:CheckBoxList>
    
                                            </details>      
                                        </label>
                                        
                                        <label for="" class="dataPublicacao">
                                            <details>
                                                <summary>Data de Publicação</summary>

                                               <asp:TextBox TextMode="Date" ID="dataPublicacao" runat="server"></asp:TextBox>
                                            </details>
                                        </label>
    
                                        <label for="" class="prazo">
                                            <details>
                                                <summary>Prazo</summary>

                                                <div class="inputs">
                                                    <asp:DropDownList ID="selectPrazo" runat="server"></asp:DropDownList>
                                                </div>
                                            </details>    
                                        </label>
    
                                    </div>
                                     <asp:Button id="Aplicar" runat="server" Text="Aplicar" OnClick="Aplicar_Click"/>
                                </div>
                            </div>
                        </section>

                        <%--<section class="SemAnuncios escondido">
                            <figure>
                                <img src="imagens/elementos/Elemento20.svg" alt="">
                            </figure>
                            <h2>Bem vindo(a) a Unio!</h2>
                            <p>Este é o seu painel de serviços, que tal começar se candidatando para uma vaga nova?</p>
                            <a href="buscaServicos.aspx"><button id="btnProcurarServicos">Procurar serviços</button></a>
                        </section>--%>

                        <asp:Literal ID="litSemServicos" runat="server"></asp:Literal>
    
                        <%--<section class="listaServicos">--%>

                            <asp:Literal ID="litServicos" runat="server"></asp:Literal>

                            <%--<article class="anuncio">
                                <div class="titulo_Btn">
                                    <h2>Conserto de geladeira</h2>
                                    <div class="status" style="background-color: #223dc35b; color: #001167;">Em andamento</div>
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
                                    
                                    <figure class="pontinhos" qual="0">
                                        <img src="imagens/icones/opcoes.png" alt="">
                                    </figure>
                                </div>

                                <div class="OpcoesMenu escondido">
                                    <p id="Denunciar">Denunciar</p>
                                    <hr>
                                    <p id="Concluir">Concluir</p>
                                    <hr>
                                    <p id="Cancelar">Cancelar Projeto</p>
                                </div>
                            </article>

                            <article class="anuncio">
                                <div class="titulo_Btn">
                                    <h2>Conserto de geladeira</h2>
                                    <div class="status" style="background-color: #6dc00088; color: #2C4F00;">Concluido</div>
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
                                    
                                    <figure class="pontinhos" qual="1">
                                        <img src="imagens/icones/opcoes.png" alt="">
                                    </figure>
                                </div>

                                <div class="OpcoesMenu escondido">
                                    <p id="Denunciar">Denunciar</p>
                                    <hr>
                                    <p id="Concluir">Concluir</p>
                                    <hr>
                                    <p id="Cancelar">Cancelar Projeto</p>
                                </div>
                            </article>

                            <article class="anuncio">
                                <div class="titulo_Btn">
                                    <h2>Conserto de geladeira</h2>
                                    <div class="status" style="background-color: #cb294f5b; color: #5A0015;">Cancelado</div>
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
                                    
                                    <figure class="pontinhos" qual="2">
                                        <img src="imagens/icones/opcoes.png" alt="">
                                    </figure>
                                </div>

                                <div class="OpcoesMenu escondido">
                                    <p id="Denunciar">Denunciar</p>
                                    <hr>
                                    <p id="Concluir">Concluir</p>
                                    <hr>
                                    <p id="Cancelar">Cancelar Projeto</p>
                                </div>
                            </article>

                            <article class="anuncio">
                                <div class="titulo_Btn">
                                    <h2>Conserto de geladeira</h2>
                                    <div class="status" style="background-color: #cb294f5b; color: #5A0015;">Cancelado</div>
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
                                    
                                    <figure class="pontinhos" qual="3">
                                        <img src="imagens/icones/opcoes.png" alt="">
                                    </figure>
                                </div>

                                <div class="OpcoesMenu escondido">
                                    <p id="Denunciar">Denunciar</p>
                                    <hr>
                                    <p id="Concluir">Concluir</p>
                                    <hr>
                                    <p id="Cancelar">Cancelar Projeto</p>
                                </div>
                            </article>
                            <article class="anuncio">
                                <div class="titulo_Btn">
                                    <h2>Conserto de geladeira</h2>
                                    <div class="status" style="background-color: #cb294f5b; color: #5A0015;">Cancelado</div>
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
                                    
                                    <figure class="pontinhos" qual="4">
                                        <img src="imagens/icones/opcoes.png" alt="">
                                    </figure>
                                </div>

                                <div class="OpcoesMenu escondido">
                                    <p id="Denunciar">Denunciar</p>
                                    <hr>
                                    <p id="Concluir">Concluir</p>
                                    <hr>
                                    <p id="Cancelar">Cancelar Projeto</p>
                                </div>
                            </article>
                            <article class="anuncio">
                                <div class="titulo_Btn">
                                    <h2>Conserto de geladeira</h2>
                                    <div class="status" style="background-color: #cb294f5b; color: #5A0015;">Cancelado</div>
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
                                    
                                    <figure class="pontinhos" qual="5">
                                        <img src="imagens/icones/opcoes.png" alt="">
                                    </figure>
                                </div>

                                <div class="OpcoesMenu escondido">
                                    <p id="Denunciar">Denunciar</p>
                                    <hr>
                                    <p id="Concluir">Concluir</p>
                                    <hr>
                                    <p id="Cancelar">Cancelar Projeto</p>
                                </div>
                            </article>
                            
                        </section>--%>

                    </section>

                </section>

            </section>
        </main>
    </section>
    
    <script src="script/menuHeaderAutonomo.js"></script>
    <script type="text/javascript" src="script/painelAutonomo.js"></script>
    <script type="text/javascript" src="script/detalhesAnuncio.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
