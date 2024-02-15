<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="buscaAutonomo.aspx.cs" Inherits="Unio.buscaAutonomo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">

    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>UNIO</title>
    <link rel="stylesheet" href="css/buscaAutonomoStyle.css"/>
    <asp:Literal ID="litStylesHeader" runat="server"></asp:Literal>
    <link rel="stylesheet" href="css/FiltroGlobal.css"/>
    <link rel="shortcut icon" href="imagens/elementos/Elemento03.png"/>
</head>
<body>
    <form id="form1" runat="server">
     <header>
        <main>
            <asp:Literal ID="litLogo" runat="server"></asp:Literal>

            <div class="divBusca" id="divBusca">
                <asp:TextBox ID="iptBusca" name="iptBusca" runat="server" placeholder="Ex. eletricista"></asp:TextBox>
                <asp:ImageButton ID="btnBusca" src="imagens/icones/search_icon.png" alt="" runat="server" OnClick="btnBusca_Click" />
            </div>
            <asp:Literal ID="litMenu" runat="server"></asp:Literal>
        </main>  
    </header>
    <section class="areaMenu escondido"></section>

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

            
            
            <section class="geral">
                
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
    
                <section class="resultadosBusca">
                   <%-- <p class="titulo">Resultados por <strong>“Técnico em Manutenção de Eletrodomésticos”</strong></p>--%>

                <asp:Literal ID="litResultados" runat="server"></asp:Literal>

                    <div class="resultados">
                        <%--<div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_1.png)"></div>
                            <div class="autonomo" qual="0">
                                <a href="perfilAutonomo.aspx" class="infoAutonomo">
                                    <h3>Joilson da Silva</h3>
                                    <p>Sou pedreiro a 10 anos, especialista na parte de estrutura...</p>
                                    <div class="avaliacao" >
                                        <div class="barra" valor="2.5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </a>

                                <figure class="coracoesVazados" qual="0"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="0"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_2.png)"></div>
                            <div class="autonomo" qual="1">
                                <a href="perfilAutonomo.aspx" class="infoAutonomo">
                                    <h3>Manoel Barreto dos Santos</h3>
                                    <p>Sou pedreiro a 25 anos, trabalho com respeito e seriedade...</p>
                                    <div class="avaliacao">
                                        <div class="barra"  valor="4">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </a>

                               <figure class="coracoesVazados" qual="1"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                               <figure class="coracoesPreenchidos escondido" qual="1"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_3.png)"></div>
                            <div class="autonomo" qual="2">
                                <a href="perfilAutonomo.aspx" class="infoAutonomo">
                                    <h3>Joaquim Braga Oliveira</h3>
                                    <p>Estou disponível para trabalhos de longa duração que exijam...</p>
                                    <div class="avaliacao">
                                        <div class="barra"  valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </a>

                                <figure class="coracoesVazados" qual="2"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="2"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_4.png)"></div>
                            <div class="autonomo" qual="3">
                                <a href="perfilAutonomo.aspx" class="infoAutonomo">
                                    <h3>Antônio Carlos da Cruz Tavares</h3>
                                    <p>Faço todo tipo de serviço que envolva reparo doméstico...</p>
                                    <div class="avaliacao">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </a>

                                <figure class="coracoesVazados" qual="3"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="3"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_5.png)"></div>
                            <div class="autonomo" qual="4">
                                <a href="perfilAutonomo.aspx" class="infoAutonomo">
                                    <h3>Guilhermino de Jesus</h3>
                                    <p>Trabalho com qualidade e excelência para as donas de casa... </p>
                                    <div class="avaliacao">
                                        <div class="barra" valor="5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </a>
                                
                                <figure class="coracoesVazados" qual="4"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="4"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_5.png)"></div>
                            <div class="autonomo" qual="5">
                                <a class="infoAutonomo">
                                    <h3>Guilhermino de Jesus</h3>
                                    <p>Trabalho com qualidade e excelência para as donas de casa... </p>
                                    <div class="avaliacao">
                                        <div class="barra" valor="4.5">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </a>

                                <figure class="coracoesVazados" qual="5"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="5"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>

                        <div class="autonomosResultado">
                            <div class="imgAutonomo" STYLE="background-image: url(imagens/autonomos/autonomo_5.png)"></div>
                            <div class="autonomo" qual="6">
                                <div class="infoAutonomo">
                                    <h3>Guilhermino de Jesus</h3>
                                    <p>Trabalho com qualidade e excelência para as donas de casa... </p>
                                    <div class="avaliacao">
                                        <div class="barra" valor="3.6">
                                            <div></div>
                                        </div>
                                        <figure><img src="imagens/icones/estrelas_vazadas.png" alt=""></figure>
                                    </div>
                                </div>
                                
                                <figure class="coracoesVazados" qual="6"><img src="imagens/icones/mdi_heart-outline.png" alt=""></figure>
                                <figure class="coracoesPreenchidos escondido" qual="6"><img src="imagens/icones/coracao_preenchido.png" alt=""></figure>
                            </div>
                        </div>--%>
                    </div>

                </section>

            </section>
        </main>
    </section>

    <script type="text/javascript" src="script/code.jquery.com_jquery-3.7.0.min.js"></script>
    <script type="text/javascript" src="script/login.js"></script>
    <script type="text/javascript" src="script/menuHeaderCliente.js"></script>
    <script type="text/javascript" src="script/buscaAutonomo.js"></script>
    </form>
</body>
</html>
