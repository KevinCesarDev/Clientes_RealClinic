<%@ Page Title="Adicionar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdicionarCliente.aspx.cs" Inherits="Clientes_RealClinic.UI.AdicionarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 ">
        <div class="row d-flex justify-content-center align-items-center w-100">
            <div class="col-md-8 col-lg-6">
                <h2 class="text-center mb-4">Cadastro de Cliente</h2>

                <div class="d-grid mb-3  align-items-center w-100">
                    <label for="nome" class="form-label col-2">Nome</label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control col-12" placeholder="Nome Completo"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txtNome" ErrorMessage="O nome é obrigatório." CssClass="text-danger" Display="Dynamic" />
                </div>

                
                <div class="mb-3 d-grid align-items-center">
                    <label for="dataNascimento" class="align-self-start form-label col-12">Data de Nascimento</label>
                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control col-12 w-100" TextMode="Date" />
                    <asp:RequiredFieldValidator ID="rfvDataNascimento" runat="server" ControlToValidate="txtDataNascimento" ErrorMessage="A data de nascimento é obrigatória." CssClass="text-danger" Display="Dynamic" />
                    <asp:RangeValidator ID="rvDataNascimento" runat="server" ControlToValidate="txtDataNascimento" ErrorMessage="Erro" CssClass="text-danger" Display="Dynamic" Type="Date" MaximumValue="" MinimumValue="" />
                </div>

           
                <div class="form-check ps-2 mb-3 d-flex justify-content-start align-items-center w-100 ">
                    <asp:CheckBox ID="ckBoxAtivo" runat="server" Checked="True" Text="Cliente Ativo" TextAlign="Left" CssClass="checkbox_large"/>
                </div>

                
                <div class="d-flex justify-content-evenly">
                    <asp:Button ID="BtnVoltar" runat="server" CssClass="btn btn-secondary btn-block" Text="Voltar" OnClientClick="history.back()" />
                    <asp:Button ID="btnCadastrar" runat="server" CssClass="btn btn-primary btn-block" Text="Cadastrar" OnClick="btnCadastrarCliente" />
                </div>
            </div>
        </div>

    </div>

</asp:Content>
