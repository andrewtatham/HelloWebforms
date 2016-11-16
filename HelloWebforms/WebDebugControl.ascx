<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebDebugControl.ascx.cs" Inherits="HelloWebforms.WebDebugControl" %>



<h1>ASP.NET code-behind </h1>
<p>Label:
    <asp:Label ID="codeBehindLabel" runat="server"></asp:Label></p>
<p>Literal:
    <asp:Label ID="codeBehindLiteral" runat="server"></asp:Label></p>

<h1>ASP.NET Databinding (Hmm)</h1>
<p>Property:
    <asp:Label ID="sessionIdLabel" runat="server" Text="<%# Session.SessionID %>"></asp:Label></p>
<p>Method:
    <asp:Label ID="GetDebugInfoLabel" runat="server" Text="<%# Controller.GetDebugInfo() %>"></asp:Label></p>


<h1>Response.Write (Bad)</h1>
<p>Response.Write: <% Response.Write(Session.SessionID); %></p>

<h1>Knockout</h1>
<p>Session ID: <strong data-bind="text: sessionId">todo</strong></p>

<script>

    // This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
    function DebugViewModel() {
        this.sessionId = "<% Response.Write(Session.SessionID); %>";
    }

    // Activates knockout.js
    ko.applyBindings(new DebugViewModel());
</script>
