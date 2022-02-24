<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCiudadano.aspx.cs" Inherits="Reniec.frmCiudano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!-- Formulario del CRUD para la tabla DocIdentidad -->
    <h3>CRUD de la tabla DocIdentidad</h3>
    <p> DNI: <asp:TextBox runat="server" Id="txtDNI"/></p>

    <p> Nombres: <asp:TextBox runat="server" Id="txtNombres"/></p>
    <p> Apellido Paterno: <asp:TextBox runat="server" Id="txtApPaterno"/></p>
    <p> Apellido Materno: <asp:TextBox runat="server" Id="txtApMaterno"/></p>
    <p> Fecha Nacimiento: <asp:TextBox runat="server" Id="txtFecNacimiento"/></p>
    <p> Sexo: <asp:TextBox runat="server" Id="txtSexo"/></p>
    <p> Estado Civil: <asp:TextBox runat="server" Id="txtEstCivil"/></p>
    <p> Direccion : <asp:TextBox runat="server" Id="txtDireccion"/></p>

    <p> 
        <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click"/>
        <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click"/>
        <asp:Button Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click"/>
        <asp:Button Text="Buscar" runat="server" Id="btnBuscar" OnClick="btnBuscar_Click"/>
    </p>

    <p>
        <asp:GridView runat="server" ID ="gvCiudadano"></asp:GridView>
    </p>

     
</asp:Content>
