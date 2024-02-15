<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="painelCliente.aspx.cs" Inherits="Unio.painelCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerClienteLogado.css">
    <link rel="stylesheet" href="css/painelClienteStyle.css">
    <link rel="stylesheet" href="css/global.css">
    <link rel="stylesheet" href="css/FiltroGlobal.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png"/>
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
                <%--<asp:TextBox ID="iptBusca" runat="server" placeholder="Ex. eletricista"></asp:TextBox>--%>
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

        <asp:Literal ID="litDenunciar" runat="server"></asp:Literal>

        <asp:Literal ID="litConcluir" runat="server"></asp:Literal>

        <asp:Literal ID="litAvaliar" runat="server"></asp:Literal>

        <asp:Literal ID="litCancelar" runat="server"></asp:Literal>

    <%--    <article class="pnlDenuncia escondido">
            <div class="cabecalhoDenuncia">
                <figure class="backIcon">
                    <img src="imagens/icones/back_icon.png" alt="">
                </figure>
                <h2>Denuncie</h2>
                <figure class="alertIcon">
                    <img src="imagens/icones/alert_icon.png" alt="">
                </figure>
            </div>
            <div class="areaVermelha">Revise os dados da sua denúncia</div>

            <section class="infosCliente">
                <p class="clienteDenunciado">Autônomo denunciado:</p>
                <div class="SobreOAutonomo">
                    <figure>
                        <img src="imagens/clientes/cliente_2.png" alt="">
                    </figure>
                    <div>
                        <h2>Carolina de Almeida dos Santos</h2>
                        <p>Personalização da minha geladeira</p>
                        <p class="data">19/06/2023</p>
                    </div>
                </div>
                <div class="SobreADenuncia">
                    <label for="">Selecione uma categoria:
                        <select name="" id="selectCategoriaDenuncia"></select>
                    </label>
                
                    <label for="" class="divTextarea">Descreva o ocorrido:
                        <textarea name="" id="" cols="" rows="" placeholder="Digite aqui..."></textarea>
                    </label>
                    <p class="naoSePreocupe">Não se preocupe, essa denúncia é anônima, o autônomo não saberá que ela foi feita por você.</p>
                    <div class="divButton">
                        <button id="btnDenunciar">Denunciar</button>
                    </div>
                </div>
            </section>
        </article>--%>

    <%--    <article class="pnlConcluir escondido">
            <div class="cabecalhoConcluir">
                <figure class="backIcon">
                    <img src="imagens/icones/back_icon.png" alt="">
                </figure>
                <h2>Concluir</h2>
            </div>

                <section class="infosCliente">
                    <div class="SobreOAutonomo">
                        <figure>
                            <img src="imagens/clientes/cliente_2.png" alt="">
                        </figure>
                        <div>
                            <h2>Carolina de Almeida dos Santos</h2>
                            <p>Personalização da minha geladeira</p>
                        </div>
                    </div>

                    <section class="InicioPrazoConclusao">
                        <div>
                            <h3 class="inicio">Início</h3>
                            <p>19/06/2023</p>
                        </div>
                        <div class="divMeio">
                            <h3 class="prazo">Prazo</h3>
                            <p>13/06/2023</p>
                        </div>
                        <div>
                            <h3 class="conclusao">Conclusão</h3>
                            <p>22/06/2023</p>
                        </div>
                    </section>
                    <p class="atencao"><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao concluir tenha certeza de que o serviço já foi completamente finalizado.</p>
                    <div class="divButton">
                        <button id="btnConcluir">Concluir</button>
                    </div>
                </section>

        </article>--%>

    <%--<article class="pnlAvaliar escondido">
        <div class="cabecalhoAvaliar">
            <figure class="backIcon">
                <img src="imagens/icones/back_icon.png" alt="">
            </figure>
            <h2>Avaliar</h2>
        </div>

        <div class="SobreOAutonomo">
            <figure>
                <img src="imagens/clientes/cliente_2.png" alt="">
            </figure>
            <div>
                <h2>Carolina de Almeida dos Santos</h2>
                <p>Personalização da minha geladeira</p>
                <p class="data">19/06/2023</p>
            </div>
        </div>

        <div class="categoriasAvaliacao">
            <div class="cumprimentos">
                <h2>Cumprimento de prazos:</h2>
                <div class="barra">
                    <div class="estrelasCumprimento">
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                    </div>
                </div>
            </div>
            <div id="execucao">
                <h2>Execução do serviço:</h2>
                <div class="barra">
                    <div class="estrelasExecucao">
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                    </div>
                </div>
            </div>
            <div id="comunicacao">
                <h2>Comunicação:</h2>
                <div class="barra">
                    <div class="estrelasComunicacao">
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                        <figure>
                            <img src="imagens/icones/estrela_vazada_sozinha.png" alt="">
                        </figure>
                    </div>
                </div>
            </div>
        </div>

        <div class="SobreAAvaliacao">
            <label for="" class="divTextarea"> <strong class="strongAvaliacao">Escreva um comentário:</strong>
                <textarea name="" id="" cols="" rows="" placeholder="Digite aqui..."></textarea>
            </label>
            <div class="divButton">
                <button id="btnAvaliar">Enviar Avaliação</button>
            </div>
        </div>

    </article>--%>

    <%--<article class="pnlCancelar escondido">
        <div class="cabecalhoCancelar">
            <figure class="backIcon">
                <img src="imagens/icones/back_icon.png" alt="">
            </figure>
            <h2>Cancelar</h2>
        </div>

            <section class="infosCliente">
                <div class="SobreOAutonomo">
                    <figure>
                        <img src="imagens/clientes/cliente_2.png" alt="">
                    </figure>
                    <div>
                        <h2>Carolina de Almeida dos Santos</h2>
                        <p>Personalização da minha geladeira</p>
                    </div>
                </div>

                <section class="InicioPrazoCancelamento">
                    <div>
                        <h3 class="inicio">Início</h3>
                        <p>19/06/2023</p>
                    </div>
                    <div class="divMeio">
                        <h3 class="prazo">Prazo</h3>
                        <p>13/06/2023</p>
                    </div>
                    <div>
                        <h3 class="cancelamento">Cancelamento</h3>
                        <p>22/06/2023</p>
                    </div>
                </section>
                <p class="atencao"><strong>Atenção: </strong>essa ação não poderá ser desfeita, ao cancelar você não poderá mais realizar este serviço.</p>
                <div class="divButton">
                    <button id="btnCancelar2">Cancelar</button>
                </div>
            </section>

    </article>--%>

    <section class="blur escondido"></section>


    <div class="fundo-mensagem escondido">
        <span class="mensagem-erro-ou-sucesso escondido">
            
        </span>
    </div>
    

    <section class="sessaoBg">
        <main>
            <section class="geral">

                <section class="buscaMobile" id="buscaMobile">
                    <div class="divBusca">
                         <asp:TextBox ID="iptBuscaMobile" runat="server" placeholder="Ex. eletricista"></asp:TextBox>
                        <asp:ImageButton id="btnBuscaMobile" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBuscaMobile_Click"/>
                    </div>
                </section>

                <section class="perfilCliente">
                    <section class="bgPerfil" >
                        <asp:Literal ID="identificadorCliente" runat="server"></asp:Literal>
                        <asp:Literal ID="litInfosCliente" runat="server"></asp:Literal>
                    </section>
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
                                               <%-- <div><input type="checkbox" name="" id="checkbox"><p>Concluido</p></div>
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

                            <asp:Literal ID="litServicos" runat="server"></asp:Literal>

                        <asp:Literal ID="litSemAnuncios" runat="server"></asp:Literal>
   

                    </section>

                </section>

            </section>
        </main>
    </section>
    
    <script src="script/Notificacoes.js"></script>
    <script src="script/menuHeaderCliente.js"></script>
    <script src="script/detalhesAnuncioCliente.js"></script>
    </form>
</body>
</html>
