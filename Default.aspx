<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        input {
            width:500px;
        }
        .row button {
            background-color: Transparent;
            background-repeat: no-repeat;
            border: none;
            cursor:pointer;
            overflow: hidden;
            outline:none;
            height:25px; 
            width:500px;
            text-align: left;
            margin-top: 5px;
            margin-bottom: 5px;
        }
    </style>

    <div class="jumbotron">
        <h2>TODO List</h2>
        <p class="lead">Your Personal TODO List</p>
    </div>

    <div class="row">
        <asp:PlaceHolder ID="TableContainer" runat="server"/>
    </div>
    <input type="text" runat="server" value="Add your task here" id="RowText"/>
    <!-- style="width:500px" -->
    <button runat="server" onserverclick="SubmitBtn_Click" id="Submit"> Add task </button>
    <!-- style="height:25px; width:75px" -->
        <!-- onmouseover="this.style.backgroundColor='lightgreen'" onmouseout="this.style.backgroundColor='lightgrey'" --> 
    <button style="height:25px; width:75px" runat="server" onserverclick="ClearBtn_Click" id="Clear"> Clear All </button>
    <label id="ErrorLabel" runat="server"></label>

</asp:Content>
