<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaltAndHashGenerator.aspx.cs" Inherits="ChickenCoop.SaltAndHashGenerator" %>
<asp:Content ID="SaltAndHashGen" ContentPlaceHolderID="MainContent" runat="server">


    <br /><br />
    <%--password validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:label id="lblPassword" runat="server" text="Password" cssclass="col-lg-2 control-label"></asp:label>
        <div class="col-lg-10">
            <asp:textbox id="txtPassword" runat="server" cssclass="form-control"></asp:textbox>
        </div>
        <br /><br /><br />
        <asp:label id="lblHash" runat="server" text="Hash" cssclass="col-lg-2 control-label"></asp:label>
        <div class="col-lg-10">
            <asp:textbox id="txtHash" runat="server" cssclass="form-control"></asp:textbox>
        </div>
        <br /><br /><br />
        <asp:label id="lblSalt" runat="server" text="Salt" cssclass="col-lg-2 control-label"></asp:label>
        <div class="col-lg-10">
            <asp:textbox id="txtSalt" runat="server" cssclass="form-control"></asp:textbox>
        </div>

    </div>
    <br />
    <br />
    <asp:button id="btnGenerate" runat="server" cssclass="col-lg-8 btn btn-default col-md-offset-2" text="Generate Hash" OnClick="btnGenerate_Click" />








    <br />
    <br />




</asp:Content>

