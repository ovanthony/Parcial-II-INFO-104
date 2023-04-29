<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ExamenIIProgra.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MasterRelated.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="miDiv">
        <h1 class="miTitulo">Usuarios</h1>
    </div>

    <div class="miDiv">
        <asp:GridView ID="GridUsuarios" runat="server" CssClass="miGrid">
        </asp:GridView>
    </div>

    <div class="miDiv">
        <div class="texto-con-input">
            <p class="miTexto">Código de usuario:</p>
            <asp:TextBox ID="TLogin_Usuario" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Clave de usuario:</p>
            <asp:TextBox ID="TClave_Usuario" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Nombre de usuario:</p>
            <asp:TextBox ID="TNombre_Usuario" runat="server"></asp:TextBox>
        </div>
    </div>


    <div class="miDivButton">
        <asp:Button ID="BAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="BAgregar_Click" />
        <asp:Button ID="BBorrar" runat="server" Text="Borrar" CssClass="button" OnClick="BBorrar_Click" />
        <asp:Button ID="BModificar" runat="server" Text="Modificar" CssClass="button" OnClick="BModificar_Click" />
    </div>
</asp:Content>
