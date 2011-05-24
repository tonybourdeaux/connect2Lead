<%@ Page Title="" Language="C#" MasterPageFile="~/Connect2Lead.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Connect2Leads._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<script language='javascript'>
    function showDiv() {
        document.getElementById('myHiddenDiv').style.display = "";
        setTimeout('document.images["myAnimatedImage"].src="/images/progressbar_green.gif"', 200);
    } 
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br /><br /><br />
 <asp:Label ID="Label2" runat="server" Text="Browse to Select File To Upload"></asp:Label><br /><br /><br />
    <asp:FileUpload ID="FileUpload1" runat="server" /><br /><br /><br />
        <asp:Button ID="ButtonUploadFile" runat="server" Text="Upload File" 
        Height="26px" onclick="ButtonUploadFile_Click"  OnClientClick="showDiv();"/>
    <br /><br /><br />
    <span id='myHiddenDiv' style='display: none'>
        <img src="" id='myAnimatedImage' align="middle">
    </span>
    
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    test 2<asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
&nbsp;
</asp:Content>
