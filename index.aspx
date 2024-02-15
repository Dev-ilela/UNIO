<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Unio.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>UNIO</title>
    <script src="script/code.jquery.com_jquery-3.7.0.min.js"></script>
    <link rel="stylesheet" href="css/indexStyle.css"/>
    <link rel="stylesheet" href="css/headerSemLogar.css"/>
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png"/>
</head>
<body>
    <form id="form1" runat="server">

    <header>
        <main>
                <div class="divLogo">
                    <img class="logo_padrao" src="imagens/logos/logo_padrao.png" alt="">
                    <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt="" srcset="">
                </div>
                <div class="divBusca">
                    <asp:TextBox name="iptBusca" ID="iptBusca" placeholder="Ex. eletricista" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="btnBusca" runat="server" src="imagens/icones/search_icon.png" alt="" OnClick="btnBusca_Click"/>
                </div>

            <div class="divMenu">
                <ul>
                    <li id="btnCadastro"><div>Cadastre-se</div></li>
                    <li id="btnLogin">
                        <button name="btnLogin">Login</button>
                        <label for="btnLogin"><img src="imagens/icones/login_icon.png" alt=""/></label>
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

    <section class="sessao1">

        <figure class="elemento10_2">
            <img src="imagens/elementos/Elemento10.svg" alt="">
        </figure>

        <main>
             <div>
                <figure>
                    <img src="imagens/elementos/Elemento07.png" alt=""/>
                </figure>
                <h1>
                    Seu <b>profissional</b><br/>
                    ideal, está a alguns<br/>
                    cliques de distância.
                </h1>
                 <asp:Button ID="btnSaibaMais" runat="server" Text="Saiba como" OnClick="btnSaibaMais_Click" />
            </div>
        </main>

        <figure class="elemento09">
            <img src="imagens/elementos/Elemento09.svg" alt="">
        </figure>
        <figure class="elemento12">
            <img src="imagens/elementos/Elemento12.svg" alt="">
        </figure>
    </section>

    <section class="sessao2">

        <figure class="elemento18">
            <img src="imagens/elementos/Elemento18.svg" alt="">
        </figure>

        <main>
            <div id="s2_geral">
                <p id="s2_elemento"><img src="imagens/elementos/Elemento06.svg" alt=""/></p>

                <h2>Escolha o profissional que melhor <br id="break"/>
                se encaixa na sua necessidade</h2>
                    
                <div class="s2_gp_articles">
                    <article class="s2_article" id="s2_art1">
                        <div class="filtro">
                            <div class="s2_gp_art">
                                <h3>Busque</h3>
                                <p>Filtre e favorite profissionais de sua preferência</p>
                                <button id="buscarJa">Buscar já</button>
                            </div>
                        </div>
                    </article>
                    <article class="s2_article" id="s2_art2">
                        <div class="filtro">
                            <div class="s2_gp_art">
                                <h3>Escolha</h3>
                                <p>Decida com qual profissional <br/> você fechará o serviço</p>
                                 <button id="escolherJa">Escolher já</button>
                            </div>
                        </div>
                    </article>
                    <article class="s2_article" id="s2_art3">
                        <div class="filtro">
                            <div class="s2_gp_art">
                                <h3>Negocie</h3>
                                <p>Acerte os detalhes do serviço<br/>pelo chat</p>
                                <button id="negociarJa">Negociar já</button>
                            </div>
                        </div>
                    </article>
                </div>  
            </div>
        </main>

        <figure class="elemento02">
            <img src="imagens/elementos/Elemento02.svg" alt="">
        </figure>
    </section>

    <section class="sessao3">
        <div class="s3_filtro">
            <main>
                <div class="s3_esquerda">
                    <h2>Encontre diversos<br/>
                        tipos de serviços
                    </h2>
                    <div id="s3_elemento">
                        <img src="imagens/elementos/Elemento13.png" alt=""/>
                    </div>
                </div>
                <div class="s3_direita">
                    <div class="borda">
                        <div class="s3_video">
                            <div class="s3_filtro_video">
                                <video autoplay muted loop>
                                    <source src="video/video.mp4" type="video/mp4">
                                    <source src="video/video.ogg" type="video/ogg">
                                    Your browser does not support the video tag.
                                  </video>

                            </div>
                        </div>
                    </div>
                </div>
            </main>
        </div>
    </section>

    <section class="sessao4">
        <main>
            <div class="s4_esquerda">
                <img src="imagens/elementos/Elemento11.svg" alt=""/>
            </div>

            <div class="s4_direita">
                <div class="s4_margem">
                    <div>
                        <h2>Você possui um<br/>
                            um serviço a prestar?
                        </h2>
                        <p>Anuncie seu trabalho e aumente seu<br/>
                           faturamento no mês. Cadastre-se já.
                        </p>
                        <button id="AnuncieServico">Anuncie seu serviço</button>
                    </div>
                </div>
            </div>
        </main>
    </section>

    <footer>
        <div class="f_laterais f_esquerda">
            <div>

            </div>
        </div>
        <div class="f_meio">
            <div>
                <img src="imagens/logos/logo_vermelho.png" alt="">
            </div>

            <p>
                © 2023 UnioTeam | Powered by <b id="f_medium">ours</b> <br/>
                Ainda tem dúvidas?<b id="f_semiB"> <a href="ComoFunciona.aspx">Veja como funciona</a></b>
            </p>
        </div>
        <div class="f_laterais f_direita">
            <div>

            </div>
        </div>
    </footer>

    <script type="text/javascript" src="script/login.js"></script>
   </form>

</body>
</html>