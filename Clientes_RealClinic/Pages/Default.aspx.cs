using Clientes_RealClinic.BLL;
using Clientes_RealClinic.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes_RealClinic
{
    public partial class Default : System.Web.UI.Page
    {
        ClienteBLL clienteBLL = new ClienteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ord = ddlOrd.Text.Trim();
                string coluna = ddlColuna.Text.Trim();
                string status = ddlStatus.Text.Trim();

                CarregarClientes("",ord,coluna,status);

                Popup.Attributes["style"] = "display: none";

            }
        }

        protected void CarregarClientes(string busca, string ord, string coluna, string status)
        {
            DataTable dt;
            if (int.TryParse(busca, out int id))
            {

                dt = clienteBLL.BuscarClientesPorId(id);
                if (dt.Rows.Count > 0)
                {
                    gvClientes.DataSource = dt;
                }
                else
                {
                    gvClientes.DataSource = null;
                }
            }
            else
            { 
                dt = clienteBLL.BuscarClientesPorNome(busca,ord,coluna,status);

                if (dt.Rows.Count > 0)
                {
                    gvClientes.DataSource = dt;
                }
                else
                {
                    gvClientes.DataSource = null;
                }

            }

            gvClientes.DataBind();
        }

        protected void BuscarClientes(object sender, EventArgs e)
        {

            string busca = txtSearch.Text.Trim();
            string ord = ddlOrd.Text.Trim();
            string coluna = ddlColuna.Text.Trim();
            string status = ddlStatus.Text.Trim();

            CarregarClientes(busca,ord,coluna,status);
            
        }

        protected void RealizarPaginacao(object sender, GridViewPageEventArgs e)
        { 
            string busca = txtSearch.Text.Trim();
            string ord = ddlOrd.Text.Trim();
            string coluna = ddlColuna.Text.Trim();
            string status = ddlStatus.Text.Trim();

            gvClientes.PageIndex = e.NewPageIndex;
            CarregarClientes(busca, ord, coluna, status);
            
        }

        protected void ComandosListaCliente(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "CliqueEditarCliente")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = id;
                Response.Redirect("~/Pages/EditarCliente");
                
            }
            else if(e.CommandName == "CliqueExcluirCliente")
            {
                
                Popup.Attributes["style"] = "display: block";
                int id = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = id;
                nomeClienteExc.Text = clienteBLL.ObterClientePorId(id)["CLI_NOME"].ToString();


            }
        }

        protected void LimparFiltros(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ddlOrd.Text = "ASC";
            ddlColuna.Text = "CLI_ID";
            ddlStatus.Text = "Todos";

            CarregarClientes(txtSearch.Text, ddlOrd.Text, ddlColuna.Text, ddlStatus.Text);

        
        }

        protected void ExcluirCliente(object sender, EventArgs e)
        {
            
            Popup.Attributes["style"] = "display: none";

            clienteBLL.DeletarCliente((int)Session["ID"]);

            Response.Redirect("~/Pages/Default");
        }

        protected void FecharPopup(object sender, EventArgs e)
        {
            Popup.Attributes["style"] = "display: none";
        }


    }
}