<%@ Page Title="Home" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ExamenIIProgra.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .container {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        h1 {
            font-family: Poppins-Bold;
            font-size: 24px;
            text-align: center;
            display: block;
        }

        p {
            font-family: Poppins-Bold;
            text-align: center;
            font-size: 20px;
            text-align: center;
        }

        .centered-img {
            display: block;
            max-width: 50%;
            margin: 0 auto;
            opacity: 0.1;
            z-index: -1;
            position: absolute;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
            <h1>Veterinaria La Huellita</h1>
            <p>Consulte en el menú la acción que desee realizar.</p>
        </div>
        <img src="Fondo.png" alt="Imagen de fondo" class="centered-img">
    </div>
</asp:Content>
