<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Prueba_de_appWEB_ASP.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    
    #ContenedorFooter {
        display: none;
    }

    #hrfooter {
        display: none;
    }

 
    .row {
        margin-bottom: 8px;
        align-content: center;
        justify-content: center;
    }

    </style>

   
    <div style="margin-top:200px" class="col-auto text-center align-items-center justify-content-center center-content">
        <div class="row">
            <div class="col-lg-12">
                <h3>Login</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-5 justify-content-center">
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control mx-auto" placeholder="Ingrese el usuario" Style="width: 250px;"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-5 justify-content-center">
                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" CssClass="form-control mx-auto" placeholder="Ingrese la contraseña" Style="width: 250px;"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnGuardar_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-lg-5">
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red">Usuario y/o contraseña incorrectos</asp:Label>
            </div>
        </div>
    </div>
  
</asp:Content>
