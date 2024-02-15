using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unio.modelos;

namespace Unio
{
    public partial class meuPerfilCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string arquivoImagem = "";
            byte[] foto = null;
            string base64String = "";

            string emailCliente = "";

            if (Session["email"] != null)
            {
                emailCliente = Session["email"].ToString();
            }

            Cliente c = new Cliente();
            (Autonomo autonomo, Cliente cliente) = c.CarregarUsuario(emailCliente, Session["senha"].ToString());

            identificadorCliente.Text = $@"<input type='hidden' id='identificadorCliente' sgEstado='{cliente.Estado.Sigla}' cdCidade='{cliente.Cidade.Codigo}' value={cliente.Email}>";

            arquivoImagem = "";
            foto = cliente.Foto;
            base64String = Convert.ToBase64String(foto, 0, foto.Length);
            arquivoImagem = Convert.ToString("data:image/jpeg;base64,") + base64String;

            litImgPerfil.Text = $@"<img src='{arquivoImagem}' id='imgCliente' alt='ícone do perfil'>";

            litInfosCliente.Text = $@"<div class='informacoes'>
                                            <img id='imgCliente' src='{arquivoImagem}' alt=''>
                                            <label id='btnSelecionarImagemPerfil' for='btnAddImagem'>Alterar</label>
                                            <input type='file' name='file' id='btnAddImagem' style='display: none'>
                                            <label id='btnSalvarFotoPerfil' class='escondido'>Confirmar</label>                                            
                                            <div class='info'>
                                                <h2>{cliente.Nome}</h2>
                                                <div class='cidade'> <img src='imagens/icones/localizacao.png' alt=''> <p>{cliente.Cidade.Nome}</p> </div>
                                            </div>                    
                                          </div>";

            litDadosBasicos.Text = $@"<article class='pnlSalvar escondido'>
                                            <p> Foram realizadas alterações em seu perfil. Deseja salvá-las?</p>
                                            <div>
                                                <button id='btnVoltar'>Voltar</button>
                                                <button id='btnSalvarMesmo' class='btnSalvar'>Salvar</button>
                                            </div>
                                        </article>
                    
                                        <section class='blur escondido'></section>

                                        <div class='dados'>
                                            <div class='coluna1'>
                                                <label for=''>Nome Completo:
                                                    <div class='divInput'>
                                                        <input type='text' placeholder='Digite aqui...' class='inputs' value='{cliente.Nome}' id='txtNome'>
                                                    </div>
                                                </label>
                               
                                                <label for=''>Celular:
                                                    <div class='divInput'>
                                                        <input type='tel' placeholder='(__) _____-____' class='inputs' value='{cliente.Telefone}' id='txtCelular'>
                                                    </div>
                                                </label>
        
                                                <label for=''>CPF:
                                                    <div class='divInput'>
                                                        <input type='text' placeholder='___.___.____-__' class='inputs' value='{cliente.CPF}' id='txtCPF'>
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
    
                                                <button id='btnSalvar' class='btnSalvar'>Salvar Alterações</button>
                                            </div>
                                            </article>";
        }

        protected void btnBusca_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBusca.Text;
            if (string.IsNullOrEmpty(busca))
            {

            }
            else
            {
                Response.Redirect($@"busca.aspx?p={busca}");
            }
        }
        protected void btnBuscaMobile_Click(object sender, ImageClickEventArgs e)
        {
            string busca = iptBuscaMobile.Text;
            if (string.IsNullOrEmpty(busca))
            {
                iptBuscaMobile.Focus();
            }
            else
            {
                Response.Redirect($@"busca.aspx?p={busca}");
            }
        }
    }
}