using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class emblemas : System.Web.UI.Page
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

            ddlProfissao.Items.Add(new ListItem(autonomo.Profissoes[0].Nome, autonomo.Profissoes[0].Codigo.ToString()));

            ddlProfissao.SelectedIndex = 0;

            Emblema emblema = autonomo.CarregarEmblemaAutonomo(loginAutonomo);
            decimal avaliacao = autonomo.CarregarAvaliacao(loginAutonomo);
            int servicosConcluidos = autonomo.CarregarServicosConcluidos(loginAutonomo);

            foto = autonomo.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            identificadorAutonomo.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{loginAutonomo}'>";
            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgAutonomo' alt='ícone do perfil'>";

            litInfosAutonomo.Text = $@"<div class='informacoes'>
                                                <img id='imgAutonomo' src='{arquivoImagem}' alt=''>

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

            litInfosAutonomo2.Text = $@"<div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> {autonomo.Cidade.Nome}</div>
                                                </div>                    
                                          </div>";

            

            if (emblema.Codigo == 1)
            {
                litEmblemaAtual.Text = $@"<div class='div1'>
                                            <div class='divEmblemaAtual'>
                                                <figure><img src='imagens/emblemas/novato.png' alt=''></figure>
                                                <p>Você é um profissional {emblema.Nome}!</p>
                                            </div>
                                            <div class='descricaoEmblemaAtual'>
                                                <p>O emblema “<strong>{emblema.Nome}</strong>”, é conquistado assim que você entra na plataforma. Para conquistar os proximos emblemas, realize serviços de boa qualidade!</p>
                                            </div>
                                        </div>";

                int valorBronze = 10;
                int quantoFalta = valorBronze - servicosConcluidos;

                litEmblemasConquistados.Text = $@"<div class='div2'>
                                                        <div class='emblemasConquistados'>
                                                            <p>Emblemas a serem conquistados por você:</p>
                                                            <div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/ouro.png' alt=''></figure>
                                                                    <p>Ouro</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/prata.png' alt=''></figure>
                                                                    <p>Prata</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/bronze.png' alt=''></figure>
                                                                    <p>Bronze</p>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class='divGrafico'>
                                                            <figure><img src='imagens/graficos_emblemas/grafico_Novato.png' alt=''></figure>
                                                            <p>Faltam <strong>{quantoFalta}</strong> serviços para se tornar um profissional Bronze!</p>
                                                        </div>";
            }

            if (emblema.Codigo == 2)
            {
                litEmblemaAtual.Text = $@"<div class='div1'>
                                            <div class='divEmblemaAtual'>
                                                <figure><img src='imagens/emblemas/bronze.png' alt=''></figure>
                                                <p>Você é um profissional {emblema.Nome}!</p>
                                            </div>
                                            <div class='descricaoEmblemaAtual'>
                                                <p>O emblema “<strong>{emblema.Nome}</strong>”, é conquistado quando você alcança a marca de {emblema.Meta} trabalhos concluídos com excelência. Parabéns, continue assim!</p>
                                            </div>
                                        </div>";

                int valorPrata = 20;
                int quantoFalta = valorPrata - servicosConcluidos;

                litEmblemasConquistados.Text = $@"<div class='div2'>
                                                        <div class='emblemasConquistados'>
                                                            <p>Emblemas já conquistados por você:</p>
                                                            <div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/bronze.png' alt=''></figure>
                                                                    <p>Bronze</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/novato.png' alt=''></figure>
                                                                    <p>Novato</p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class='divGrafico'>
                                                            <figure><img src='imagens/graficos_emblemas/grafico_Bronze.png' alt=''></figure>
                                                            <p>Faltam <strong>{quantoFalta}</strong> serviços para se tornar um profissional Prata!</p>
                                                        </div>";
            }

            if (emblema.Codigo == 3)
            {
                litEmblemaAtual.Text = $@"<div class='div1'>
                                            <div class='divEmblemaAtual'>
                                                <figure><img src='imagens/emblemas/prata.png' alt=''></figure>
                                                <p>Você é um profissional {emblema.Nome}!</p>
                                            </div>
                                            <div class='descricaoEmblemaAtual'>
                                                <p>O emblema “<strong>{emblema.Nome}</strong>”, é conquistado quando você alcança a marca de {emblema.Meta} trabalhos concluídos com excelência. Parabéns, continue assim!</p>
                                            </div>
                                        </div>";

                int valorOuro = 30;
                int quantoFalta = valorOuro - servicosConcluidos;

                litEmblemasConquistados.Text = $@"<div class='div2'>
                                                        <div class='emblemasConquistados'>
                                                            <p>Emblemas já conquistados por você:</p>
                                                            <div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/prata.png' alt=''></figure>
                                                                    <p>Prata</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/bronze.png' alt=''></figure>
                                                                    <p>Bronze</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/novato.png' alt=''></figure>
                                                                    <p>Novato</p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class='divGrafico'>
                                                            <figure><img src='imagens/graficos_emblemas/grafico_Prata.png' alt=''></figure>
                                                            <p>Faltam <strong>{quantoFalta}</strong> serviços para se tornar um profissional Ouro!</p>
                                                        </div>";
            }

            if (emblema.Codigo == 4)
            {
                litEmblemaAtual.Text = $@"<div class='div1'>
                                            <div class='divEmblemaAtual'>
                                                <figure><img src='imagens/emblemas/ouro.png' alt=''></figure>
                                                <p>Você é um profissional {emblema.Nome}!</p>
                                            </div>
                                            <div class='descricaoEmblemaAtual'>
                                                <p>O emblema “<strong>{emblema.Nome}</strong>”, é conquistado quando você alcança a marca de {emblema.Meta} trabalhos concluídos com excelência. Parabéns, continue assim!</p>
                                            </div>
                                        </div>";


                litEmblemasConquistados.Text = $@"<div class='div2'>
                                                        <div class='emblemasConquistados'>
                                                            <p>Emblemas já conquistados por você:</p>
                                                            <div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/ouro.png' alt=''></figure>
                                                                    <p>Prata</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/prata.png' alt=''></figure>
                                                                    <p>Prata</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/bronze.png' alt=''></figure>
                                                                    <p>Bronze</p>
                                                                </div>
                                                                <div>
                                                                    <figure><img src='imagens/emblemas/novato.png' alt=''></figure>
                                                                    <p>Novato</p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class='divGrafico'>
                                                            <figure><img src='imagens/graficos_emblemas/grafico_Ouro.png' alt=''></figure>
                                                            <p>Este é o maior emblema da plataforma, sinta-se orgulhoso(a) por tê-lo alcançado!</p>
                                                        </div>";
             }


            litBarraBronze.Text = $@"<div class='quantoFaltaBronze' valorBronze='{servicosConcluidos}'>
                                <p>{servicosConcluidos}/10</p>";
            litBarraPrata.Text = $@"<div class='quantoFaltaPrata' valorPrata='{servicosConcluidos}'>
                                <p>{servicosConcluidos}/20</p>";
            litBarraOuro.Text = $@"<div class='quantoFaltaOuro' valorOuro='{servicosConcluidos}'>
                                <p>{servicosConcluidos}/30</p>";
        }

        protected void ddlProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}