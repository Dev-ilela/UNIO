<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="autonomosDisponiveis.aspx.cs" Inherits="Unio.autonomosDisponiveis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerClienteLogado.css">
    <link rel="stylesheet" href="css/AutonomosDisponiveisStyle.css">
    <link rel="stylesheet" href="css/FiltroGlobal.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
             <div class="divLogo">
                 <a href="painelCliente.aspx">
                     <img class="logo_padrao" src="imagens/logos/logo_branca.png" alt="">
                     <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="">
                 </a>
             </div>

            <div class="divBusca">
                 <asp:TextBox ID="iptBusca" runat="server" placeholder="Ex. eletricista"></asp:TextBox>
                <asp:ImageButton id="btnBusca" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBusca_Click"/>
            </div>

            <div class="divMenu">
                <ul>
                    <li class="liDoPopup"><img class="aviso_notificacao escondido" src="imagens/icones/aviso_Notificações.png" alt=""><a href="chatCliente.aspx"><img src="imagens/icones/Mensagens_icon.png" alt="Ícone de mensagens"></a></li>
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
                        <asp:Literal ID="litIdentificadorCliente" runat="server"></asp:Literal>
                        <%--<img src="imagens/clientes/cliente_1.png" id="imgCliente" alt="ícone do perfil">--%>
                    </li>
                  </ul>
              
                <article class="prflCliente escondido">
                    <a href="painelCliente.aspx" class="opcao">Painel de Serviços</a>
                    <a href="edicaoPerfilCliente.aspx" class="opcao">Meu perfil</a>
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

                <section class="buscaMobile" id="buscaMobile">
                     <div class="divBusca">
                          <asp:TextBox ID="iptBuscaMobile" runat="server" placeholder="Ex. eletricista"></asp:TextBox>
                          <asp:ImageButton id="btnBuscaMobile" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBuscaMobile_Click"/>
                     </div>
                </section>

                <div class="atualizarDados">
                    <figure class="voltarIcon">
                        <a href="painelCliente.aspx"><img src="imagens/icones/back_forms_icon.png" alt=""></a>
                    </figure>
                    <h2>Voltar</h2>
                </div>

                <article class="dadosForm2">
                    <section class="filtroPorCategoria">
                    
                            <div class="filtro">
                                <div class="filtroTitulo">
                                    <p>Filtre por:</p>
                                </div>
                                
                                <div class="categorias">
                                    <div class="alinhar">
                                       <%--<label for="" class="cidade">
                                            <details>
                                                <summary>Cidade</summary>
                                                <select name="" id="selectCidade">
                                                    <option value="">São Paulo</option>
                                                </select>
                                            </details>
                                        </label>--%>
            
                                        <label for="" class="pagamento">
                                            <details>
                                                <summary>Forma de pagamento</summary>
                                                <asp:CheckBoxList ID="checkboxFormaPagamento" runat="server"></asp:CheckBoxList>
                                                <%-- <div><input type="checkbox" name="" id="checkbox"><p>Dinheiro</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Pix</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Débito</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Crédito</p></div>--%>
                                            </details>
                                        </label>
        
                                        <label for="" class="emblema">
                                            <details>
                                                <summary>Emblemas</summary>
                                                <asp:CheckBoxList ID="checkboxEmblemas" runat="server"></asp:CheckBoxList>
                                               <%-- <div><input type="checkbox" name="" id="checkbox"><p>Novato</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Bronze</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Prata</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Ouro</p></div>--%>
                                            </details>
                                        </label>
                                    </div>
                                    <asp:Button ID="Aplicar" runat="server" Text="Aplicar" OnClick="Aplicar_Click"/>
                                </div>
                            </div>
                        </section>

                        <section class="autonomosDisponiveis">
                            <div class="divInput">
                                <asp:TextBox ID="inputBuscaAutonomos" runat="server" placeholder="Busque por:"></asp:TextBox>
                                <asp:ImageButton ID="btnBuscaAutonomos" runat="server" src="imagens/icones/lupa_azul.png" OnClick="btnBuscaAutonomos_Click"/>
                               <%-- <input type="text" placeholder="Busque por:" id="inputBuscaAutonomos">
                                <button id="btnBuscaAutonomos"><img src="imagens/icones/lupa_azul.png" alt="" srcset=""></button>--%>
                            </div>
                            
                            <asp:Literal ID="litSemAutonomos" runat="server"></asp:Literal>
                            <%--<section class="SemAutonomos escondido">
                                <figure><img src="imagens/elementos/Elemento26.png" alt=""></figure>
                                <h2>Parece que não há ninguém por aqui...</h2>
                                <p>Os autônomos que você selecionou ainda não retornaram sua solicitação, tente novamente mais tarde</p>
                            </section>--%>
                            
                            
                            <asp:Literal ID="litResultados" runat="server"></asp:Literal>
        
                        </section>
                </article>
            </section>
        </main>
    </section>

    <script type="text/javascript" src="script/contratarAutonomo.js"></script>
    <script type="text/javascript" src="script/AutonomosFavoritos.js"></script>
    <script type="text/javascript" src="script/menuHeaderCliente.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
