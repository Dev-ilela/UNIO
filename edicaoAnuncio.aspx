<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edicaoAnuncio.aspx.cs" Inherits="Unio.edicaoAnuncio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerClienteLogado.css">
    <link rel="stylesheet" href="css/criacao&EdicaoAnuncio.css">
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
                  <li><img src="imagens/icones/Mensagens_icon.png" alt="Ícone de mensagens"></li>
                  <li><img src="imagens/icones/Notificacoes_icon.png" alt="Ícone de notificações"></li>
                  <li id="perfilCliente"><img src="imagens/clientes/cliente_1.png" id="imgCliente" alt="ícone do perfil"></li>
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

                <article class="dadosForm1">             
                    <div class="coluna1">
                        <label for="">Título:
                            <div class="divInput">
                                <asp:TextBox type="text" ID="iptTitulo" class="inputs" runat="server" placeholder="Digite aqui..."></asp:TextBox>
                            </div>
                        </label>
                        <label class="divTextarea">
                            Descrição:
                            <asp:Literal ID="iptDescricao" runat="server"></asp:Literal>
                                
                        </label>
                        <label class="inputs">
                            *Em quanto tempo você pretende solucionar?
<%--                            <select name="" id="selectPrazo">
                                <option value="">Urgente</option>
                                <option value="">Indefinido</option>
                                <option value="">3 dias</option>
                                <option value="">7 dias</option>
                                <option value="">15 dias</option>
                                <option value="">20 dias</option>
                                <option value="">30 dias</option>
                                <option value="">+30 dias</option>
                            </select>--%>
                            <asp:DropDownList runat="server" id="selectPrazo"></asp:DropDownList>
                        </label>
                    </div>

                    <div class="coluna2">
                        <label for="">Em qual área se encaixa sua necessidade?
                            <div class="divInput">
                                <asp:DropDownList class="inputs" runat="server" id="ddlAreaAtuacao"></asp:DropDownList>
                            </div>
                        </label>
                        
                        
                        <div class="botoes">
                            <p>*Por favor, revise seus dados antes de criar seu Anúncio!</p>
                            <button id="btnSalvarEdicao">Salvar Alterações</button>
                        </div>
                       </div>
                    
                </article>
                
            </section>
        </main>
    </section>

    <script src="script/menuHeaderCliente.js"></script>
    <script src="script/criacaoAnuncio.js"></script>
    <script src="script/Notificacoes.js"></script>
    </form>
</body>
</html>
