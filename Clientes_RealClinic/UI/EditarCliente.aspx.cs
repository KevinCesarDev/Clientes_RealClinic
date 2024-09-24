using Clientes_RealClinic.BLL;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Diagnostics;

namespace Clientes_RealClinic.UI
{
    public partial class EditarCliente : System.Web.UI.Page
    {

        ClienteBLL ClienteBLL = new ClienteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataRow cliente = CarregarDadosCliente();

                txtNome.Text = cliente["CLI_NOME"].ToString();
                txtDataNascimento.Text = DateTime.ParseExact(cliente["CLI_DATANASCIMENTO"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                ckBoxAtivo.Checked = bool.Parse(cliente["CLI_ATIVO"].ToString());


                DateTime minDate = new DateTime(1753, 1, 1);
                DateTime maxDate = DateTime.Now;

                

                rvDataNascimento.MinimumValue = minDate.ToString("yyyy-MM-dd");
                rvDataNascimento.MaximumValue = maxDate.ToString("yyyy-MM-dd");
                rvDataNascimento.ErrorMessage = $"A data de nascimento deve estar entre {minDate.ToString("dd/MM/yyyy")} e {maxDate.ToString("dd/MM/yyyy")}.";

                Popup.Attributes["style"] = "display: none";

            }
        }

        protected DataRow CarregarDadosCliente()
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/UI/Default");
            }
            
            int id = (int)Session["ID"];

            DataRow cliente = ClienteBLL.ObterClientePorId(id);
            nomeClienteExc.Text = cliente["CLI_NOME"].ToString();

            return cliente;

        }

        protected void AbrirPopup(object sender,EventArgs e)
        {
            Popup.Attributes["style"] = "display: block";
        }

        protected void ConfirmarEdicao(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/UI/Default");
            }

            int id = (int)Session["ID"];
            string nome = txtNome.Text;
            DateTime dtNasc = DateTime.Parse(txtDataNascimento.Text.Trim());
            bool status = ckBoxAtivo.Checked;

            ClienteBLL.AtualizarCliente(id, nome, dtNasc, status);
            Response.Redirect("~/UI/Default");
        }

        protected void VoltarPag(object sender,EventArgs e)
        {
            Response.Redirect("~/UI/Default");
        }

        protected void FecharPopup(object sender, EventArgs e)
        {
            Popup.Attributes["style"] = "display: none";
        }

    }
}