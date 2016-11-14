<%@ Control Language="C#" ClassName="WebControl1" %>
<script runat="server">

    private void CheckBoxList1_OnTextChanged(object sender, EventArgs e)
    {
        Label1.Text = CheckBoxList1.Text;
    }

</script>


<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnTextChanged="CheckBoxList1_OnTextChanged">
    <asp:ListItem>a</asp:ListItem>
    <asp:ListItem>b</asp:ListItem>
    <asp:ListItem>c</asp:ListItem>
    <asp:ListItem>d</asp:ListItem>
</asp:CheckBoxList>



