<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Pokedex_Web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class ="row">
        <div class="col-4">

            <h2>Creá tu perfil Trainee</h2>

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:textbox runat="server" cssclass="form-control" ID="txtPassword" Textmode="Password"/>
            </div>

            <asp:button text="Registrarse" cssclass="btn btn-primary" runat="server" ID="btnRegistrarse"/>
            <a href="/">Cancelar</a>

        </div>
    </div>
</asp:Content>
