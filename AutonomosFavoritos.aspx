<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutonomosFavoritos.aspx.cs" Inherits="Unio.AutonomosFavoritos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerClienteLogado.css">
    <link rel="stylesheet" href="css/AutonomosFavoritosStyle.css">
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

            <div class="divBusca" id="divBusca">
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

    <section class="sessaoBg">
        <main>

            <section class="geral">
                
                <section class="buscaMobile" id="buscaMobile">
                    <div class="divBusca">
                         <asp:TextBox ID="iptBuscaMobile" runat="server" placeholder="Ex. eletricista"></asp:TextBox>
                         <asp:ImageButton id="btnBuscaMobile" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBuscaMobile_Click"/>
                    </div>
                </section>
                
                <section class="filtroPorCategoria">
                    
                   <div class="filtro">
                        <div class="filtroTitulo">
                            <p>Filtre por:</p>
                        </div>
    
                        <div class="categorias">
                            <div class="alinhar">
                                <label for="" class="localizacao">
                                    <details>
                                        <summary>Localização</summary>
                                        <label>Estado</label>
                                        <asp:DropDownList ID="ddlEstado" AutoPostBack="false" runat="server"></asp:DropDownList>

                                    </details>
                                </label>
    
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
                                        <%--<div><input type="checkbox" name="" id="checkbox"><p>Novato</p></div>
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
    
                <section class="autonomosFavoritos">
                    <div class="divInput">
                        <asp:TextBox ID="inputBuscaFavoritos" runat="server" placeholder="Busque por:"></asp:TextBox>
                        <asp:ImageButton ID="btnBuscaFavoritos" runat="server" src="imagens/icones/lupa_azul.png" OnClick="btnBuscaFavoritos_Click"/>
                       <%-- <input type="text" placeholder="Busque por:" id="inputBuscaAutonomos">
                        <button id="btnBuscaAutonomos"><img src="imagens/icones/lupa_azul.png" alt="" srcset=""></button>--%>
                    </div>

                    <%--<section class="SemFavoritos ">
                        <figure>
                            <img src="imagens/elementos/Elemento24.svg" alt="">
                        </figure>
                        <h2>Sem corações por aqui...</h2>
                        <p>Parece que você ainda não favoritou ninguém, que tal dar uma pesquisada e encontrar a pessoa certa para a sua necessidade?</p>
                    </section>--%>
                    <asp:Literal ID="litSemFavoritos" runat="server"></asp:Literal>

                    <asp:Literal ID="litResultados" runat="server"></asp:Literal>

                    <%--<div class="resultados escondido">
                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_1.png)"></div>
                            <!-- <img src="imagens/autonomos/autonomo_1.png" alt=""> -->
                            <div class="autonomo">
                                <div class="infoAutonomo">
                                    <h3>Joilson da Silva</h3>
                                    <p class="descricao">Sou pedreiro a 10 anos, especialista na parte de estrutura Sou pedreiro a 10 anos, especialista na parte de estrutura Sou pedreiro a 10 anos, especialista na parte de estrutura Sou pedreiro a 10 anos, especialista na parte de estrutura</p>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <figure class="coracoesVazados" qual="0"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="0"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_2.png)"></div>
                            <!-- <img src="imagens/autonomos/autonomo_2.png" alt=""> -->
                            <div class="autonomo">
                                <div class="infoAutonomo">
                                    <h3>Manoel Barreto dos Santos</h3>
                                    <p class="descricao">Sou pedreiro a 25 anos, trabalho com respeito e seriedade...</p>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <figure class="coracoesVazados" qual="1"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="1"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <a href="perfilAutonomo.aspx" class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_3.png)"></div>
                            <!-- <img src="imagens/autonomos/autonomo_3.png" alt=""> -->
                            <div class="autonomo">
                                <div class="infoAutonomo">
                                    <h3>Joaquim Braga Oliveira</h3>
                                    <p class="descricao">Estou disponível para trabalhos de longa duração que exijam...</p>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="4">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <figure class="coracoesVazados" qual="2"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="2"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </a>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_4.png)"></div>
                            <!-- <img src="imagens/autonomos/autonomo_4.png" alt=""> -->
                            <div class="autonomo">
                                <div class="infoAutonomo">
                                    <h3>Antônio Carlos da Cruz Tavares</h3>
                                    <p class="descricao">Faço todo tipo de serviço que envolva reparo doméstico...</p>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="2">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <figure class="coracoesVazados" qual="3"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="3"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_5.png)"></div>
                            <!-- <img src="imagens/autonomos/autonomo_5.png" alt=""> -->
                            <div class="autonomo">
                                <div class="infoAutonomo">
                                    <h3>Guilhermino de Jesus</h3>
                                    <p class="descricao">Trabalho com qualidade e excelência para as donas de casa... </p>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="1">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <figure class="coracoesVazados" qual="4"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="4"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_5.png)"></div>
                            <!-- <img src="imagens/autonomos/autonomo_5.png" alt=""> -->
                            <div class="autonomo">
                                <div class="infoAutonomo">
                                    <h3>Guilhermino de Jesus</h3>
                                    <p class="descricao">Trabalho com qualidade e excelência para as donas de casa... </p>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <figure class="coracoesVazados" qual="5"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="5"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_5.png)"></div>
                            <!-- <img src="imagens/autonomos/autonomo_5.png" alt=""> -->
                            <div class="autonomo">
                                <div class="infoAutonomo">
                                    <h3>Guilhermino de Jesus</h3>
                                    <p class="descricao">Trabalho com qualidade e excelência para as donas de casa... </p>
                                    <div class="avaliacaoEstrelas">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                <figure class="coracoesVazados" qual="6"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="6"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>--%>

                        <!-- <div class="mudarPagina">
                            <p class="pDestacado">1</p>
                            <p>2</p>
                            <p>3</p>
                            <p>4</p>
                            <p>...</p>
                            <p>6</p>
                        </div> -->
                    <%--</div>--%>

                </section>
            </section>
        </main>
    </section>

    <script type="text/javascript" src="script/menuHeaderCliente.js"></script>
    <script type="text/javascript" src="script/AutonomosFavoritos.js"></script>
    <script type="text/javascript" src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
