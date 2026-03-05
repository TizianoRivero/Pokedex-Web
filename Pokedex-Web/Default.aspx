<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hola!</h1>
    <p>Llegaste al pokedex web!</p>


    <div class="row row-cols-1 row-cols-md-3 g-4">


        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
            <div class="col">
                <div class="card">
                    <img src="<%# Eval("UrlImagen")%>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre")%></h5>
                        <p class="card-text"><%#Eval("Descripcion")%></p>
                        <a href="DetallePokemon.aspx?id=<%#Eval("Id")%>">Detalle</a>
                        <asp:Button Text="Ejemplo" 
                            cssclass="btn btn-primary" 
                            runat="server" ID="btnEjemplo" 
                            CommandArgument='<%#Eval("Id")%>' 
                            CommandName="PokemonId" 
                            OnClick="btnEjemplo_Click"/>
                    </div>
                </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
