using Clientes_RealClinic.BLL;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes_RealClinic.UI
{
    public partial class AdicionarCliente : System.Web.UI.Page
    {
        ClienteBLL clienteBLL = new ClienteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime minDate = new DateTime(1753, 1, 1);
                DateTime maxDate = DateTime.Now;

                rvDataNascimento.MinimumValue = minDate.ToString("yyyy-MM-dd");
                rvDataNascimento.MaximumValue = maxDate.ToString("yyyy-MM-dd");
                rvDataNascimento.ErrorMessage = $"A data de nascimento deve estar entre {minDate.ToString("dd/MM/yyyy")} e {maxDate.ToString("dd/MM/yyyy")}.";
            }
        }

        protected void btnCadastrarCliente(object sender, EventArgs e)
        {

            string nome = txtNome.Text.Trim();
            DateTime dataNacimento = DateTime.Parse(txtDataNascimento.Text.Trim());
            bool statusCliente = ckBoxAtivo.Checked;

            clienteBLL.AdicionarCliente(nome, dataNacimento, statusCliente);
            
            Response.Redirect("~/UI/Default");
        }
    }
}