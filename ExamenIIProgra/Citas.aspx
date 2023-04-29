<%@ Page Title="Citas" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Citas.aspx.cs" Inherits="ExamenIIProgra.Citas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/MasterRelated.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="miDiv">
        <h1 class="miTitulo">Citas</h1>
    </div>

    <div class="miDiv">
        <asp:GridView ID="GridCitas" runat="server" CssClass="miGrid">
        </asp:GridView>
    </div>

    <div class="miDiv">
        <div class="texto-con-input">
            <p class="miTexto">Código de mascota:</p>
            <asp:TextBox ID="TID_Mascota" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Fecha:</p>
            <asp:TextBox ID="TProxima_Fecha" runat="server"></asp:TextBox>
        </div>
        <div class="texto-con-input">
            <p class="miTexto">Médico:</p>
            <asp:TextBox ID="TMedico_Asignado" runat="server"></asp:TextBox>
        </div>
    </div>


    <div class="miDivButton">
        <asp:Button ID="BAgregar" runat="server" Text="Agregar" CssClass="button" OnClick="BAgregar_Click" />
        <asp:Button ID="BBorrar" runat="server" Text="Borrar" CssClass="button" OnClick="BBorrar_Click" />
        <asp:Button ID="BModificar" runat="server" Text="Modificar" CssClass="button" OnClick="BModificar_Click" />
    </div>
</asp:Content>
