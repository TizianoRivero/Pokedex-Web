<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="Pokedex_Web.FormularioPokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Número:</label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo:</label>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList ID="ddlDebilidad" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="btn-container">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <a href="ListarPokemon.aspx">Cancelar</a>
                <asp:Button Text="Inactivar" ID="btnInactivar" onclick="btnInactivar_Click" runat="server" cssclass="btn btn-warning"/>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"/>
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgPokemon" Width="60%"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>  
     </div>

    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>
                    <% if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmarEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminacion" OnClick="btnConfirmaEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <% } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
