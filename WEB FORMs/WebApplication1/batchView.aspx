<%@ Page Title="Batch mode results" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="batchView.aspx.cs" Inherits="WebApplication1.batchView" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <h3 style="width: 100%; text-align:center; height: 5%">Batch mode results&nbsp;&nbsp;</h3>
  
  
<asp:Table  ID="Query_table" runat="server" HorizontalAlign="Center" CssClass="table " Width="40%"  BackColor="White">
    <asp:TableHeaderRow EnableTheming="true" HorizontalAlign="Center">
        <asp:TableHeaderCell HorizontalAlign="Center" >#</asp:TableHeaderCell>
        <asp:TableHeaderCell HorizontalAlign="Center">File&nbsp;Name</asp:TableHeaderCell>
        <asp:TableHeaderCell Visible="false" HorizontalAlign="Center">Detailed</asp:TableHeaderCell>
    </asp:TableHeaderRow>
</asp:Table>
   
</asp:Content>
