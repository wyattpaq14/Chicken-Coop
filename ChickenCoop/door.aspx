<%@ Page Title="Door" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="door.aspx.cs" Inherits="ChickenCoop.door" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Chicken Coop Door Control</h1>
        <p class="lead">Welcome to a chicken coop door application. Here you can open the door.</p>
    </div>


    <div class="row">
        <div class="col-md-4">
            <h2>Coop Door</h2>
            <p>
                <asp:Label ID="lblDoorStatus" runat="server" Text=""></asp:Label>
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
