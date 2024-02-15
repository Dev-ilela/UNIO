<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formAutonomo.aspx.cs" Inherits="Unio.formAutonomo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>UNIO</title>
    <script src="script/code.jquery.com_jquery-3.7.0.min.js"></script>
    <link rel="stylesheet" href="css/formAutonomoStyle.css"/>
    <link rel="stylesheet" href="css/headerSemLogar.css"/>
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
        <main>
            <div class="divLogo">
                <a href="index.aspx">
                 <img class="logo_padrao" src="imagens/logos/logo_padrao.png" alt=""/>
                 <img class="logoBolinhas" src="imagens/elementos/Elemento03.png" alt=""/>
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

            <asp:Literal ID="litTeste" runat="server"></asp:Literal>

    <article class="pnlLogin escondido">
        <figure class="backIcon">
            <img src="imagens/icones/back_icon.png" alt="">
        </figure>
        <figure class="logoLogin">
            <img src="imagens/elementos/Elemento03.png" alt="">
        </figure>
        <h2>Login</h2>
        <asp:TextBox runat="server" id="txtEmail" placeholder="Digite seu e-mail" class="inputLogin"></asp:TextBox>
        <asp:TextBox runat="server" id="txtSenha" placeholder="Digite sua senha" class="inputLogin" TextMode="Password"></asp:TextBox>
        <button id="btnEntrar">Entrar</button>
        <div>
            <p><a href="">Esqueceu a senha?</a></p>
        </div>
        <span class="msgErro escondido">Login e/ou senha inválido(s)</span>
    </article>

    <section class="blur escondido"></section>
    
    <section class="sessaoBg">
        <main>
            <section class="section_geral">
                <div class="tituloCadastroAutonomo">
                     <figure>
                            <a href="cadastro.aspx"><img src="imagens/icones/back_forms_icon.png" alt=""></a>
                    </figure>
                    <h2>Voltar</h2>
                </div>

                <section class="divisoraEtapas">
                    <section class="slides">
                        <article class="dadosForm1">
                            <div class="coluna1">
                                <label for="">Nome Completo:
                                    <div class="divInput">
                                        <asp:TextBox runat="server" id="inputNome" placeholder="Digite aqui..." class="inputs"></asp:TextBox>
                                    </div>
                                </label>
                                <label for="">E-mail:
                                    <div class="divInput">
                                        <asp:TextBox runat="server" id="inputEmail" placeholder="Digite aqui..." class="inputs"></asp:TextBox>
                                    </div>
                                </label>
                                <label for="">Senha:
                                    <div class="divInput">
                                        <asp:TextBox runat="server" id="inputSenha" placeholder="Digite aqui..." class="inputs" TextMode="Password"></asp:TextBox>
                                        <div class="avisoInput">
                                            <img id="aviso-icon" src="imagens/icones/aviso_icon.png" alt="">
                                            <div class="popupAviso">A senha deve conter no mínimo 8 caracteres</div>
                                        </div>
                                    </div>
                                </label>
                                <label for="">Confirme sua senha:
                                    <div class="divInput">
                                        <asp:TextBox runat="server" id="inputSenhaConfirmacao" placeholder="Digite aqui..." class="inputs" TextMode="Password"></asp:TextBox>
                                    </div>
                                </label>
        
                            </div>
                            <div class="coluna2">
                                <label for="">Celular:
                                    <div class="divInput">
                                        <asp:TextBox runat="server" id="inputTelefone" placeholder="(__) _____-____" class="inputs" maxlength="11"></asp:TextBox>
                                    </div>
                                </label>
                           <%-- <div class="divInputs">--%>
                                <label for="">Estado:
                                    <div class="divInput">
                                        <asp:DropDownList ID="ddlEstado" runat="server" class="inputs" ></asp:DropDownList>
                                    </div>
                                </label>
                            <label for="">Cidade:
                                <div class="divInput">
                                    <asp:DropDownList ID="ddlCidade" runat="server" class="inputs" ></asp:DropDownList>
                                </div>
                            </label>
                            <%--</div>--%>
                                <label for="">CPF:
                                    <div class="divInput">
                                        <asp:TextBox runat="server" id="inputCPF" placeholder="___.___.____-__" class="inputs" maxlength="11"></asp:TextBox>
                                    </div>
                                </label>
                                <p>*Por favor, revise seus dados antes de criar seu perfil!</p>
                                <span class="labelErro escondido">Login e/ou senha inválido(s)</span>
                            </div>
                        </article>
    
                        <article class="dadosForm2">
                            <div class="coluna1">
                                <label for="">Qual é a sua profissão?
                                    <div class="divInput">
                                        <select id="ddlProfissao" class="inputs">

                                        </select>
                                    </div>
                                </label>
    
                                <label for="">Forma de trabalho:
                                    <%--<div class="formasTrabalho">
                                        <div><asp:CheckBox ID="chkPresencial" runat="server"/><p>Presencial</p></div>
                                        <div><asp:CheckBox ID="chkHomeOffice" runat="server"/><p>Home-Office</p></div>
                                        <div><asp:CheckBox ID="chkHibrido" runat="server"/><p>Híbrido</p></div>
                                    </div>--%>

                                    <div ID="pnlFormasTrabalho" class="formasTrabalho">

                                    </div>
                                </label>
    
                                <label for="">Adicione uma descrição:
                                    <div class="divTextarea">
                                        <textarea ID="txtDescricaoProfissao" name="" id="" cols="" rows="" placeholder="Descreva sobre como é o seu modo de trabalhar, tempo de experiência etc"></textarea>
                                    </div>
                                </label>
                            </div>
                            <div class="coluna2">
                                <label for="">Formas de pagamento aceitas por você:
                                    <%--<div class="formasPagamento">
                                        <%--<div><asp:CheckBox ID="chkDinheiro" runat="server"/><p>Dinheiro</p></div>
                                        <div><asp:CheckBox ID="chkPix" runat="server"/><p>Pix</p></div>
                                        <div><asp:CheckBox ID="chkDebito" runat="server"/><p>Débito</p></div>
                                        <div><asp:CheckBox ID="chkCredito" runat="server"/><p>Crédito</p></div>

                                        <%--<asp:CheckBoxList ID="chkFormaPagamento" Enabled="true" runat="server"></asp:CheckBoxList>
                                    </div>--%>

                                     <div ID="pnlformasPagamento" CssClass="formasPagamento">

                                     </div>
                                </label>
                                <p>*Por favor, revise seus dados antes de criar seu perfil!</p>
                            </div>
                        </article>

                    </section>
                </section>
                <article class="barraEbutton">
                    <div id="progresso">
                        <img class="seta_voltar escondido" src="imagens/icones/back_etapa.svg" alt=""/>
                        <div class="barra">
                            <div></div>
                        </div>
                    </div>
                    <div class="botao">
                        <button id="btnContinuar" class="btnContinuar">Continuar</button>
                        <button id="btnCriarPerfil" class="btnCriarPerfil escondido">Criar Perfil</button>
                    </div>
                </article>
            </section>
        </main>
    </section>

    <script type="text/javascript" src="script/login.js"></script>
    <script type="text/javascript" src="script/barraProgresso.js" ></script>
    <script type="text/javascript" src="script/assincrono.js" ></script>
        </div>
    </form>
</body>
</html>
