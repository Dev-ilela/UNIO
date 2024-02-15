using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class meuPerfilAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginAutonomo = "";
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";
            
            if (Session["login"] != null)
            {
                loginAutonomo = Session["email"].ToString();
            }

            Autonomo a = new Autonomo();
            (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(loginAutonomo, Session["senha"].ToString());

            foto = autonomo.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            Emblema emblema = autonomo.CarregarEmblemaAutonomo(loginAutonomo);
            decimal avaliacao = autonomo.CarregarAvaliacao(loginAutonomo);

            ddlProfissao.Items.Add(new ListItem(autonomo.Profissoes[0].Nome, autonomo.Profissoes[0].Codigo.ToString()));

            ddlProfissao.SelectedIndex = 0;

            identificadorAutonomo.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}' sgEstado='{autonomo.Estado.Sigla}' cdCidade='{autonomo.Cidade.Codigo}' cdProfissao='{autonomo.Profissoes[0].Codigo}'>";
            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";

            litInfosAutonomo.Text = $@"<div class='informacoes'>
                                                <img id='imgAutonomo' src='{arquivoImagem}' alt=''>
                                                <label id='btnSelecionarImagemPerfil' for='btnAddImagem'>Alterar</label>
                                                <input type='file' name='file' id='btnAddImagem' style='display: none'>
                                                <label id='btnSalvarFotoPerfil' class='escondido'>Confirmar</label>
                                                <div class='progressoAutonomo'>
                                                    <p class='progresso' id='progressoEstrelas' valor='{avaliacao}'>{avaliacao}</p>
                                                    <div class='avaliacaoProgresso'>
                                                        <div class='barra' id='barraProgressoEstrelas'>
                                                            <div></div>
                                                        </div>
                                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                                    </div>
                                                </div>
                                                <div class='info'>
                                                    <h2>{autonomo.Nome}</h2>";

            litInfosAutonomo2.Text = $@"<div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''>  <p>{autonomo.Cidade.Nome}</p></div>
                                                </div>                    
                                          </div>";

            Portfolios portfolios = new Portfolios();
            List<Portfolio> listPortfolios = portfolios.CarregarPortfolios(autonomo.Email, autonomo.Profissoes[0].Codigo);

            if (listPortfolios.Count < 3) 
            {
                litAcoesPortfolio.Text = $@"<div class='divBntAddImagem'>
                                                <p>
                                                    <label class='btnAddImagem' id='btnSelecionarImagem' for='btnAddImagem'>Selecionar imagem</label>
                                                    <input type='file' name='file' id='btnAddImagem' style='display: none'>

                                                    <button id='btnSalvarPortfolio' class='btnAddImagem escondido' style='background-color: var(--Azul-marinho);'>Adicionar imagem</button>
                                                </p>
                                            </div>";

                                               //ATENÇÃO AQUI QUE TEM UM BUTTON COMENTADO DENTRO DAS ASPAS "" VIRANDO TEXTO
            }
            else
            {
                litAcoesPortfolio.Text = $@"<div class='divBntAddImagem escondido'>
                                                <p>
                                                    <label class='btnAddImagem' id='btnSelecionarImagem' for='btnAddImagem'>Selecionar imagem</label>
                                                    <input type='file' name='file' id='btnAddImagem' style='display: none'>

                                                    <button id='btnSalvarPortfolio' class='btnAddImagem escondido' style='background-color: var(--Azul-marinho);'>Adicionar imagem</button>
                                                </p>
                                            </div>";
            }

            if (listPortfolios.Count > 0)
            {
                int qual = 0;

                foreach (Portfolio portfolio in listPortfolios)
                {
                    foto = portfolio.Imagem;
                    base64String = Convert.ToBase64String(foto, 0, foto.Length);
                    arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

                    litPortfolio.Text += $@"<figure>
                                                <img src='{arquivoImagem}' alt='' style='border: 0.5px solid var(--Azul-pastel);'>
                                                <button>
                                                    <img src='imagens/icones/icone_lixo.png' alt='' ID='btnDeletarPortfolio' class='iconeLixo' value='{portfolio.Codigo}' qual='{qual}'/>
                                                </button>
                                            </figure>";
                    qual++;
                }
            }
            else
            {
                litSemPortfolio.Text = $@"<div class='semImagens' style='margin: auto; display: flex; flex-direction: column; padding-bottom: 3.3%; align-items: center;'>
                                            <img src='imagens/outras_imagens/SemPortfolio.svg' alt='' style='width: 35%;'>
                                            <h2>Você não tem fotos....</h2>
                                            <p style='font-family: var(--Regular); padding: 0; margin-top: 10px;'>Adicione fotos como portifólio, isso ajuda<br> os clientes a escolherem seu trabalho.</p>
                                        </div>";
            }

            int qtPortfolio = listPortfolios.Count;
            identificadorPortfolio.Text = $@"<input type='hidden' id='identificadorPortfolio' value='{qtPortfolio}'>";

            //if (IsPostBack) {
            //    if (listPortfolios.Count > 0)
            //    {
            //        foreach (Portfolio portfolio in listPortfolios)
            //        {
            //            arquivoImagem = "";
            //            foto = null;
            //            base64String = "";

            //            foto = portfolio.Imagem;
            //            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            //            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            //            litPortfolio.Text += $@"<figure>
            //                                        <img src='{arquivoImagem} alt=''>
            //                                        <img class='iconeLixo' src='imagens/icones/icone_lixo.png' alt=''>
            //                                    </figure>";
            //        }
            //    }
            //}

            litDadosBasicos.Text = $@"<div class='dadosEdicao'>

                                        <article class='pnlSalvar escondido'>
                                            <p> Foram realizadas alterações em seu perfil. Deseja salvá-las?</p>
                                            <div>
                                                <button id='btnVoltar'>Voltar</button>
                                                <button id='btnSalvar'>Salvar</button>
                                            </div>
                                        </article>
                    
                                        <section class='blur escondido'></section>

                                        <div class='dados'>
                                            <div class='coluna1'>
                                                <label for=''>Nome Completo:
                                                    <div class='divInput'>
                                                        <input type='text' placeholder='Digite aqui...' class='inputs' value='{autonomo.Nome}' id='txtNome'>
                                                    </div>
                                                </label>
                                
                                                <label for=''>Celular:
                                                    <div class='divInput'>
                                                        <input type='tel' placeholder='(__) _____-____' class='inputs' value='{autonomo.Telefone}' id='txtCelular'>
                                                    </div>
                                                </label>
        
                                                <label for=''>CPF:
                                                    <div class='divInput'>
                                                        <input type='text' placeholder='___.___.____-__' class='inputs' value='{autonomo.CPF}' id='txtCPF'>
                                                    </div>
                                                </label>
                                            </div>
    
                                            <div class='coluna2'>
                                                <label for=''>Em qual estado você reside?
                                                    <div class='divInput'>
                                                        <select name='' id='ddlEstado' class='inputs'>
                                                        </select>
                                                    </div>
                                                </label>
                                                <label for=''>Em qual cidade você reside?
                                                    <div class='divInput'>
                                                        <select name='' id='ddlCidade' class='inputs'>
                                                        </select>
                                                    </div>
                                                </label>
                               
                                                <p>*Por favor, revise seus dados antes de criar seu perfil!</p>
    
                                                <button id='btnSalvarDados' class='btnSalvar'>Salvar</button>
                                            </div>    
                                        </div> ";

            string dinheiro = "";
            string pix = "";
            string credito = "";
            string debito = "";

            foreach (FormaPagamento formaPagamento in autonomo.FormasPagamento)
            {
                if (formaPagamento.Codigo == 1)
                {
                    dinheiro = "checked='checked'";
                }

                if (formaPagamento.Codigo == 2)
                {
                    pix = "checked='checked'";
                }

                if (formaPagamento.Codigo == 3)
                {
                    credito = "checked='checked'";
                }

                if (formaPagamento.Codigo == 4)
                {
                    debito = "checked='checked'";
                }
            }

            string presencial = "";
            string home = "";
            string hibrido = "";

            foreach (FormaTrabalho formaTrabalho in autonomo.FormasTrabalho)
            {
                if (formaTrabalho.Codigo == 1)
                {
                    presencial = "checked='checked'";
                }

                if (formaTrabalho.Codigo == 2)
                {
                    home = "checked='checked'";
                }

                if (formaTrabalho.Codigo == 3)
                {
                    hibrido = "checked='checked'";
                }
            }

            litProfissao.Text = $@"<article class='pnlSalvar escondido' id='pnlConfirmaProfissao'>
                                            <p> Foram realizadas alterações em seu perfil. Deseja salvá-las?</p>
                                            <div>
                                                <button id='btnVoltar'>Voltar</button>
                                                <button id='btnSalvarMesmoProfissao'>Salvar</button>
                                            </div>
                                        </article>

                            
                            <div class='profissoes escondido'>
                            <div class='coluna1'>
                                <label for=''>Profissão:
                                    <div class='divInput'>
                                        <select name='' id='ddlDadosProfissao' class='inputs'>
                                        
                                        </select>
                                    </div>
                                </label>
    
                                <label for=''>Forma de trabalho:
                                    <div class='formasTrabalho'>
                                        <div><input type='checkbox' {presencial} id='chkPresencial'><p>Presencial</p></div>
                                        <div><input type='checkbox' {home} id='chkHome'><p>Home-Office</p></div>
                                        <div><input type='checkbox' {hibrido} id='chkHibrido'><p>Híbrido</p></div>
                                    </div>
                                </label>
    
                                <label for=''>Adicione uma descrição:
                                    <div class='divTextarea'>
                                        <textarea name='' id='txtDescricao' cols='' rows='' placeholder='Descreva sobre como é o seu modo de trabalhar, tempo de experiência etc'>{autonomo.Comentario}</textarea>
                                    </div>
                                </label>
                            </div>
                            <div class='coluna2'>
                                <label for=''>Formas de pagamento aceitas por você:
                                    <div class='formasPagamento'>
                                        <div><input type='checkbox' {dinheiro} id='chkDinheiro'><p>Dinheiro</p></div>
                                        <div><input type='checkbox' {pix} id='chkPix'><p>Pix</p></div>
                                        <div><input type='checkbox' {debito} id='chkDebito'><p>Débito</p></div>
                                        <div><input type='checkbox' {credito} id='chkCredito'><p>Crédito</p></div>
                                    </div>
                                </label>
                                <p>*Por favor, revise seus dados antes de criar seu perfil!</p>
                                    
    
                                <button id='btnSalvarProfissao' class='btnSalvar'>Salvar</button>
                            </div>
                        </div>";
        }

        protected void ddlProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}