<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Unio.cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>UNIO</title>
    <link rel="stylesheet" href="css/cadastroStyle.css"/>
    <link rel="stylesheet" href="css/headerSemLogar.css"/>
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
       <header>
        <main>
            <div class="divLogo">
                <a href="index.aspx">
                 <img class="logo_padrao" src="imagens/logos/logo_padrao.png" alt=""/>
                 <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="">
                </a>
            </div>
            <div class="divMenu" id="btnLogin">
                <ul>
                    <li>
                        <button name="btnLogin">Login</button><label for="btnLogin"><img src="imagens/icones/login_icon.png" alt=""/></label>
                    </li>
                </ul>
            </div>
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
        <asp:TextBox  runat="server" id="txtEmail" placeholder="Digite seu e-mail" class="inputLogin"></asp:TextBox>
        <asp:TextBox TextMode="Password" runat="server" id="txtSenha" placeholder="Digite sua senha" class="inputLogin"></asp:TextBox>
        <button id="btnEntrar">Entrar</button>
        <div>
            <p><a href="">Esqueceu a senha?</a></p>
        </div>
        <span class="msgErro escondido">Login e/ou senha inválido(s)</span>
    </article>

    <section class="blur escondido"></section>

    <section class="sessaoBg">

        <figure class="elemento01">
           <img src="imagens/elementos/Elemento17.svg" alt="">
        </figure>

        <main class="Cadastro">
            <h1>Como você deseja se <strong>cadastrar</strong>?</h1>
            <section class="gp_divs">
                <article class="cliente" id="cliente_art">
                    <div class="filtro">
                        <div class="divTextos">
                            <h2>Cliente</h2>
                            <h3>Estou procurando por um profissional que possa me ajudar.</h3>
                            <button><a href="formCliente.aspx">Selecionar</a></button>
                        </div>
                        <figure>
                            <img src="imagens/elementos/Elemento15.png" alt="">
                        </figure>
                    </div>
                </article>
                <article class="autonomo" id="autonomo_art">
                    <div class="filtro">
                        <div class="divTextos">
                            <h2>Autônomo</h2>
                            <h3>Estou procurando por clientes que necessitam do meu serviço.</h3>
                            <button><a href="formAutonomo.aspx">Selecionar</a></button>
                        </div>
                        <figure>
                            <img src="imagens/elementos/Elemento14.png" alt="">
                        </figure>
                    </div>
                </article>
            </section>
        </main>

        <figure class="elemento02">
            <img src="imagens/elementos/Elemento17.svg" alt="">
         </figure>
    </section>

    <script src="script/code.jquery.com_jquery-3.7.0.min.js"></script>
    <script type="text/javascript" src="script/login.js"></script>
    </form>
</body>
</html>
