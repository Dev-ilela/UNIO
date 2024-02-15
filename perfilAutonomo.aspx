<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfilAutonomo.aspx.cs" Inherits="Unio.perfilAutonomo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <asp:Literal ID="litStylesHeader" runat="server"></asp:Literal>
    <script src="script/code.jquery.com_jquery-3.7.0.min.js"></script>
    <link rel="stylesheet" href="css/perfilAutonomoStyle.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <asp:Literal ID="litLogo" runat="server"></asp:Literal>
            <div class="divBusca" id="divBusca">
                <asp:TextBox name="iptBusca" ID="iptBusca" placeholder="Ex. eletricista" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnBusca" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBusca_Click"/>
            </div>
           <asp:Literal ID="litMenu" runat="server"></asp:Literal>
        </main>  
    </header>

    <article class="pnlLogin escondido">
        <figure class="backIcon">
            <img src="imagens/icones/back_icon.png" alt=""/>
        </figure>
        <figure class="logoLogin">
            <img src="imagens/elementos/Elemento03.png" alt=""/>
        </figure>
        <h2>Login</h2>
        <asp:TextBox runat="server" id="txtEmail" placeholder="Digite seu e-mail" CssClass="inputLogin"></asp:TextBox>
        <asp:TextBox runat="server" id="txtSenha" placeholder="Digite sua senha" CssClass="inputLogin" type="password"></asp:TextBox>
        <span class="msgErro escondido"></span>

        <button id="btnEntrar">Entrar</button>
        <div>
            <p><a href="">Esqueceu a senha?</a></p>
        </div>
        <div id="cadastre">
            <p><a href="cadastro.aspx"><b>Não possui login? </b>Cadastre-se</a></p>
        </div>
    </article>

    <section class="blur escondido"></section>

    <section class="sessaoBg">
        <main>
            <asp:Literal ID="litGeral" runat="server"></asp:Literal>
        </main>
    </section>
    
    <script src="script/login.js"></script>
    <script src="script/perfilAutonomo.js"></script>
    <script type="text/javascript" src="script/menuHeaderCliente.js"></script>
    </form>
</body>
</html>
