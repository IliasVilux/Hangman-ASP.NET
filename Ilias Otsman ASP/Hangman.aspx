<%@ Page Title="Ahorcado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Hangman.aspx.cs" Inherits="Ilias_Otsman_ASP.Hangman" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <asp:Image ID="PhaseImage" runat="server" />
        <asp:Panel ID="WordSpaces" runat="server"></asp:Panel>
        <asp:Panel ID="alphabetChars" runat="server" class="w-50 m-auto"></asp:Panel>
        <asp:Label ID="VidasRestantes" runat="server" Text=""></asp:Label>
        <h1 id="ResultTxt" runat="server"></h1>
    </div>
</asp:Content>
