<%@ Page Title="Mascotas" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Mascotas.aspx.cs" Inherits="ExamenIIProgra.Mascotas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MasterRelated.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="miDiv">
        <h1 class="miTitulo">Mascotas</h1>
    </div>

    <div class="miDiv">
        <asp:GridView ID="GridMascotas" runat="server" CssClass="miGrid">
        </asp:GridView>
    </div>

    <div class="miDiv">
        <div class="texto-con-input">
            <p class="miTexto">Código de mascota:</p>
            <asp:TextBox ID="TID_Mascota" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Nombre:</p>
            <asp:TextBox ID="TNombre_Mascota" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Tipo:</p>
            <asp:TextBox ID="TTipo_Mascota" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Comida:</p>
            <asp:TextBox ID="TComida_Favorita" runat="server"></asp:TextBox>
        </div>
    </div>


    <div class="miDivButton">
        <asp:Button ID="BAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="BAgregar_Click" />
        <asp:Button ID="BBorrar" runat="server" Text="Borrar" CssClass="button" OnClick="BBorrar_Click" />
        <asp:Button ID="BModificar" runat="server" Text="Modificar" CssClass="button" OnClick="BModificar_Click" />
    </div>
</asp:Content>
