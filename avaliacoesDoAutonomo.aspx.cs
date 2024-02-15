using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class avaliacoesDoAutonomo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailAutonomo = "";

            if (Session["email"] != null)
            {
                emailAutonomo = Session["email"].ToString();
            }

            Autonomo a = new Autonomo();
            (Autonomo autonomo, Cliente cliente) = a.CarregarUsuario(emailAutonomo, Session["senha"].ToString());

            ddlProfissao.Items.Add(new ListItem(autonomo.Profissoes[0].Nome, autonomo.Profissoes[0].Codigo.ToString()));

            ddlProfissao.SelectedIndex = 0;

            Emblema emblema = autonomo.CarregarEmblemaAutonomo(emailAutonomo);
            decimal avaliacao = autonomo.CarregarAvaliacao(emailAutonomo);
            int servicosConcluidos = autonomo.CarregarServicosConcluidos(emailAutonomo);

            identificadorAutonomo.Text = $@"<input type='hidden' id='identificadorAutonomo' value='{emailAutonomo}'>";
            string arquivoImagem = "";
            byte[] foto = autonomo.Foto;
            string base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

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


            Avaliacoes avs = new Avaliacoes();
            List<Avaliacao> avaliacoes = avs.CarregarAvaliacoes(autonomo.Email);

            if (avaliacoes.Count > 0)
            {
                litAvaliacoes.Text = $@"<section class='avaliacaoAutonomo'>";
                foreach (Avaliacao av in avaliacoes)
                {
                    string arquivoImagemAv = "";
                    byte[] fotoAv = av.Cliente.Foto;
                    string base64StringAv = Convert.ToBase64String(fotoAv, 0, fotoAv.Length);
                    arquivoImagemAv = Convert.ToString("data:image/jpeg;base64,") + base64StringAv;

                    litAvaliacoes.Text += $@"<div class='avaliacao'>
                        <img src='{arquivoImagemAv}' alt=''>
                        <div class='infoGeral'>
                            <div class='infoCima'>
                                <div class='nomeEavalicao'>
                                    <h2>{av.Cliente.Nome}</h2>
                                    <div class='avaliacaoEstrelas'>
                                        <div id='progressoEstrelas' class='barra' valor='{av.Media.ToString().Replace(",", ".")}'>
                                            <div id='barraProgressoEstrelas'></div>
                                        </div>
                                        <figure><img src='imagens/icones/estrelas_vazadas.png' alt=''></figure>
                                    </div>
                                </div>
                                
                            </div>
                            <p>{av.Descricao}!</p>
                        </div>
                    </div>";

                    //<p>{av.DataPostagem}</p>
                }
                litAvaliacoes.Text += $@"</section>";
            }
            else
            {
                litAvaliacoes.Text = $@"<section class=""SemAvaliacao"">
                    <figure>
                        <img src=""imagens/elementos/Elemento21.svg"" alt="""">
                    </figure>
                    <h2>Hmm... Ainda não te avaliaram</h2>
                    <p>Dica: antes de concluir um serviço peça para que o cliente te avalie, isso ajuda outras pessoas a virem até você!</p>
                </section>";
            }

        }

        protected void ddlProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}