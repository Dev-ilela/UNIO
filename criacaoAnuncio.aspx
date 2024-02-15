<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="criacaoAnuncio.aspx.cs" Inherits="Unio.criacaoAnuncio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerClienteLogado.css">
    <link rel="stylesheet" href="css/criacao&EdicaoAnuncio.css">
    <link rel="stylesheet" href="css/FiltroGlobal.css"/>
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

            <div class="divBusca" id="divBusca">
                <asp:TextBox name="iptBusca" ID="iptBusca" placeholder="Ex. eletricista" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnBusca" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBusca_Click"/>
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
                      <%--<img src="imagens/clientes/cliente_1.png" id="imgCliente" alt="ícone do perfil">--%>
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
            <section class="buscaMobile" id="buscaMobile">
                <div class="divBusca">
                        <asp:TextBox ID="iptBuscaMobile" runat="server" placeholder="Ex. eletricista"></asp:TextBox>
                    <asp:ImageButton id="btnBuscaMobile" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBuscaMobile_Click"/>
                </div>
            </section>

            <section class="geral">

                <div class="atualizarDados">
                    <figure class="voltarIcon">
                        <a href="painelCliente.aspx"><img src="imagens/icones/back_forms_icon.png" alt=""></a>
                    </figure>
                    <h2>Voltar</h2>
                </div>

                <h2>Criação Anúncio</h2>

                <asp:Panel ID="dadosForm1" CssClass="dadosForm1" runat="server"> 
                    <div class="coluna1">
                        <label for="">Título:
                            <div class="divInput">
                                <%--<input type="text" placeholder="Digite aqui..." class="inputs">--%>
                                <%--<asp:TextBox ID="txtTitulo" runat="server" CssClass="inputs" placeholder="Digite aqui..."></asp:TextBox>--%>
                                <input type="text" ID="txtTitulo" placeholder="Digite aqui..." class="inputs" />
                            </div>
                        </label>
                        <label class="divTextarea">
                            Descrição:
                            <%--<textarea ID="txtDescricao" name="" id="" cols="" rows="" placeholder="Digite aqui..."></textarea>--%>
                            <%-- <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>--%>
                            <textarea ID="txtDescricao"  Rows="4" Columns="50" placeholder="Digite aqui..."></textarea>
                        </label>
                        <label class="inputs">
                            *Em quanto tempo você pretende solucionar?
                            <%--<select name="" id="selectPrazo">
                                <option value="">Urgente</option>
                                <option value="">Indefinido</option>
                                <option value="">3 dias</option>
                                <option value="">7 dias</option>
                                <option value="">15 dias</option>
                                <option value="">20 dias</option>
                                <option value="">30 dias</option>
                                <option value="">+30 dias</option>
                            </select>--%>

                            <%--<asp:DropDownList ID="selectPrazo" runat="server"></asp:DropDownList>--%>
                            <select id="selectPrazo" ></select>
                        </label>
                    </div>

                    <div class="coluna2">
                        <label for="">Em qual área se encaixa sua necessidade?
                            <div class="divInput">
                                <%--<select name="" id="" class="inputs">
                                <option value="">Selecione</option>
                                </select>--%>

                                <%--<asp:DropDownList ID="ddlAreaAtuacao" runat="server" CssClass="inputs"></asp:DropDownList>--%>
                                <select id="ddlAreaAtuacao" class="inputs"></select>
                            </div>
                        </label>
                        <%--<label for="" class="presencial">O Serviço será presencial?
                            <br />
                            <div><input type="radio">Sim</div>
                            <div><input type="radio">Não</div>
                            <asp:CheckBox ID="chkSim" runat="server" Text="Sim"/>
                            <asp:CheckBox ID="chkNao" runat="server" Text="Não"/>

                            <asp:RadioButtonList ID="rblPresencial" runat="server"></asp:RadioButtonList>
                        </label>--%>
                        

                        <div class="botoes">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            <p>*Por favor, revise seus dados antes de criar seu Anúncio!</p>
                            <%--<a href="painelCliente.html"><button id="btnPublicar">Publicar</button></a>--%>

                            <%--<button id="btnAutoFavorito">Enviar para autônomos favoritos</button>--%>
                            <%--<button id="btnAutoFavorito">Enviar para autônomos favoritos</button>--%>
                            <%--<asp:Button ID="btnAutoFavorito" runat="server" AutoPostBack="false" Text="Enviar para autônomos favoritos" OnClick="btnAutoFavorito_Click" />
                            <asp:Button ID="btnAnuncioPublico" runat="server" Text="Publicar" OnClick="btnPublicarAnuncio_Click"/>--%>
                            <button id="btnPublicar">Publicar</button>
                            <button id="btnAutoFavorito">Enviar para autônomos favoritos</button>
                        </div>
                       </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="dadosForm2" CssClass="dadosForm2 escondido" runat="server">
                    <section class="filtroPorCategoria">
                    
                            <div class="filtro">
                                <div class="filtroTitulo">
                                    <p>Filtre por:</p>
                                </div>
                                
                                <div class="categorias">
                                    <div class="alinhar">
                                        <label for="" class="cidade">
                                            <details>
                                                <summary>Estado</summary>
                                                <select name="" id="selectEstado">
                                                </select>
                                            </details>
                                        </label>
            
                                        <label for="" class="pagamento">
                                            <details>
                                                <summary>Forma de pagamento</summary>
                                                <%--<div><input type="checkbox" name="" id="checkbox"><p>Dinheiro</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Pix</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Débito</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Crédito</p></div>--%>
                                            </details>
                                        </label>
        
                                        <label for="" class="emblema">
                                            <details>
                                                <summary>Emblemas</summary>
                                                <%--<div><input type="checkbox" name="" id="checkbox"><p>Novato</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Bronze</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Prata</p></div>
                                                <div><input type="checkbox" name="" id="checkbox"><p>Ouro</p></div>--%>
                                            </details>
                                        </label>
                                    </div>
                                    <button id="Aplicar">Aplicar</button>
                                </div>
                            </div>
                        </section>

                        <section class="SemFavoritos escondido">
                            <figure>
                                <img src="imagens/elementos/Elemento24.svg" alt="">
                            </figure>
                            <h2>Você não tem favoritos...</h2>
                            <p>Que tal dar uma pesquisada e encontrar a pessoa certa para a sua necessidade?</p>
                        </section>
            
                        <section class="autonomosFavoritos">
                            <div class="divInput"><input type="text" placeholder="Busque por:" id="txtBusca"><button id="btnBuscar"><img src="imagens/icones/lupa_azul.png" alt="" srcset=""></button></div>
        
                            <div id="pnlResultados" class="resultados"></div>
                           <button id="btnEnviar">Enviar</button>
                        </section>
                </asp:Panel>

            </section>
        </main>
    </section>

    <script src="script/menuHeaderCliente.js"></script>
    <script src="script/criacaoAnuncio.js"></script>
    <script src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
