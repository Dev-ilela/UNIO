<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="erro.aspx.cs" Inherits="Unio.erro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>UNIO</title>
    <link rel="stylesheet" href="css/headerSemlogar.css">
    <link rel="stylesheet" href="css/erro.css">
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
        <main>
            <div class="divLogo">
                <a href="index.aspx"><img src="imagens/logos/logo_padrao.png" alt=""></a>
            </div>
        </main>  
    </header>

    <section class="sessaoBg">
            <section class="geral">
                <main>
                    <img id="elemento1" src="imagens/elementos/Elemento22.svg" alt="">
                    <article class="erro">
                        <figure>
                            <img src="imagens/icones/icon_erro.png" alt="">
                        </figure>
                        <div class="linha"></div>
                        <div class="msgErro">
                            <h2>Vish...</h2>
                            <p>Parece que a página procurada não foi encontrada, porque você não volta e tenta novamente?</p>
                            <button id="btnVoltar">Voltar</button>
                        </div>
                    </article>
                    <img id="elemento2" src="imagens/elementos/Elemento23.svg" alt="">
                </main>
            </section>
            <img id="numeroErro" src="imagens/icones/404.png" alt="">
    </section>
    </form>
</body>
</html>
