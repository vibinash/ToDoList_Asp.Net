<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>TODO List</h2>
        <p class="lead">A Simple TODO List.</p>
        <!-- 
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
            -->
    </div>

    <div class="row">
        <asp:PlaceHolder ID="TableContainer" runat="server"/>
    </div>
    <input type="text" runat="server" value="Add your task here" id="RowText"/>
    <input type="submit" runat="server" onserverclick="SubmitBtn_Click" id="Submit" />
    <label id="ErrorLabel" runat="server"></label>
</asp:Content>
