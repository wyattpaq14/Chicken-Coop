<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="door.aspx.cs" Inherits="ChickenCoop.door" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Chicken Coop Door Control</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
    </div>

     <div class="row">
        <div class="col-md-4">
            <h2>Login</h2>
            <p>
                Please Login
            </p>
            <p>
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-default" OnClick="btnLogin_Click" Text="Open Coop" />
            </p>

            
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Coop Door Actuator</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <asp:Button ID="btnOpen" runat="server" CssClass="btn btn-default" OnClick="btnOpen_Click" Text="Open Coop" />
            </p>
            <p>
                <asp:Button ID="btnClose" runat="server" CssClass="btn btn-default" OnClick="btnClose_Click" Text="Close Coop" />
            </p>

            
        </div>
    </div>



</asp:Content>
