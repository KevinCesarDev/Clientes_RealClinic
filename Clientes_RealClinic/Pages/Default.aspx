<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clientes_RealClinic.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="searchBox d-flex mb-3">
            <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch" CssClass="col-md-6 d-flex">
                <asp:TextBox ID="txtSearch" runat="server" placeholder="Buscar Cliente" CssClass="form-control me-2 search  "></asp:TextBox>
                <asp:LinkButton ID="btnSearch" runat="server" OnClick="BuscarClientes" CssClass="btn btn-primary">
                    <i class="fa fa-search"></i>
                </asp:LinkButton>
            </asp:Panel>
            
            <div class="d-flex w-50 align-items-end justify-content-evenly">
                <asp:Label ID="LbFiltroColuna" runat="server" Text="Filtar por:">
                    <asp:DropDownList ID="ddlColuna" runat="server" AutoPostBack="true" OnSelectedIndexChanged="BuscarClientes" CssClass="form-select me-3">
                        <asp:ListItem Text="ID" Selected="True" Value="CLI_ID"></asp:ListItem>
                        <asp:ListItem Text="Nome" Value="CLI_NOME"></asp:ListItem>
                        <asp:ListItem Text="Data de Nascimento" Value="CLI_DATANASCIMENTO"></asp:ListItem>
                    </asp:DropDownList>
                </asp:Label>
                <asp:Label ID="LbFiltroOrdem" runat="server" Text="Ordenar por:">
                    <asp:DropDownList ID="ddlOrd" runat="server" AutoPostBack="true" OnSelectedIndexChanged="BuscarClientes" CssClass="form-select">
                        <asp:ListItem Text="Crescente" Selected="True" Value="ASC"></asp:ListItem>
                        <asp:ListItem Text="Descrescente" Selected="False" Value="DESC"></asp:ListItem>
                    </asp:DropDownList>                
                </asp:Label>
                <asp:Label ID="LbFiltroStatus" runat="server" Text="Classificar por:">
                    <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="BuscarClientes" CssClass="form-select" AutoPostBack="true">
                        <asp:ListItem Text="Todos" Selected="True" Value="Todos"></asp:ListItem>
                        <asp:ListItem Text="Ativos" Selected="False" Value="True"></asp:ListItem>
                        <asp:ListItem Text="Inativos" Selected="False" Value="False"></asp:ListItem>
                    </asp:DropDownList>
                </asp:Label>
                <asp:LinkButton runat="server" Text="Limpar Filtros" CssClass="btn btn-dark" OnClick="LimparFiltros"></asp:LinkButton>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" AllowPaging="true" PageSize="5" PageIndex="0" OnPageIndexChanging="RealizarPaginacao" 
                    OnRowCommand="ComandosListaCliente" >
                    <FooterStyle CssClass="bg-light fixed-bottom text-center" />
                    
                    
                    <PagerSettings Mode="NumericFirstLast" 
                            PageButtonCount="3"
                            FirstPageText='<i class="fas fa-angle-double-left me-5"></i>' 
                            LastPageText='<i class="fas fa-angle-double-right ms-5"></i>' 
                            />
                    <PagerStyle HorizontalAlign="Center" Font-Size="Larger"/>

                    
                        <Columns>
                            <asp:BoundField DataField="CLI_ID" HeaderText="ID" HeaderStyle-Width="100px" ItemStyle-Width="100px"/>
                            <asp:BoundField DataField="CLI_NOME" HeaderText="NOME" HeaderStyle-Width="200px" ItemStyle-Width="250px"/>
                            <asp:BoundField DataField="CLI_DATANASCIMENTO" HeaderText="DATA DE NASCIMENTO" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderStyle-Width="200px" ItemStyle-Width="150px"/>
                            <asp:CheckBoxField DataField="CLI_ATIVO" HeaderText="STATUS" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" HeaderStyle-Width="100px" ItemStyle-Width="100px"/>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkBtnEdit" runat="server" Text="Editar" CssClass="btn btn-primary" CommandName="CliqueEditarCliente" CommandArgument='<%# Eval("CLI_ID") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="LinkBtnExcl" runat="server" Text="Excluir" CssClass="btn btn-danger"  CommandName="CliqueExcluirCliente" CommandArgument='<%# Eval("CLI_ID") %>' data-cli-nome='<%# Eval("CLI_NOME") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                        <asp:Panel ID="Popup" runat="server" CssClass="modal" >
                            <div class="modal-content">
                                <asp:LinkButton runat="server" class="btn btn-close" OnClick="FecharPopup"></asp:LinkButton>
                                <div class="modal-body">
                                    <p class="mb-5">Você tem certeza que deseja <strong>EXCLUIR</strong> <asp:Literal ID="nomeClienteExc" runat="server"></asp:Literal>?</p>
                                    <div class="d-flex justify-content-between">
                                        <asp:LinkButton ID="BtnNegExcluir" runat="server" OnClick="FecharPopup" CssClass="btn btn-secondary" Text="Voltar"></asp:LinkButton>
                                        <asp:LinkButton ID="BtnConfExcluir" runat="server" OnClick="ExcluirCliente" CssClass="btn btn-success" Text="Confirmar"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        
                            </asp:Panel>

            </div>
        </div>
    </div>
</asp:Content>

