<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Default.aspx.cs" Inherits="_Default"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" StylesheetTheme="Default"
    MasterPageFile="~/MasterPage.master" Trace="true" %>
<%@ OutputCache Duration="180" VaryByParam="*" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1Resource1" Text="deutsch"></asp:Label>&nbsp;<br />
    <%
            Response.Write(string.Format("Request.Url &quot;{0}&quot;] = &quot;{1}&quot;; </br>", Request.Url.AbsoluteUri, Request.RawUrl));
            Response.Write(string.Format("Request.Url &quot;{0}&quot;] = &quot;{1}&quot;; </br>", Request.Url, Request.PhysicalPath));
    %>    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <hr />
    <b>Request.QueryString</b>
    <br />
    <%
        foreach (string param in Request.QueryString)
            Response.Write(string.Format("Request.QueryString[&quot;{0}&quot;] = &quot;{1}&quot;; </br>", param, Request.QueryString[param].ToString()));
    %>
    <br />
    <b>Context.Items</b>
    <br />
    <%
        foreach (string key in Context.Items.Keys)
        {
//            if (key.StartsWith("QueryString"))     // Config: <urlrewrite contextItemsPrefix="QueryString" />
                Response.Write(string.Format("Context.Items[&quot;{0}&quot;] = &quot;{1}&quot;; </br>", key, Context.Items[key]));
        }
    %>
    <br />
    <b>Page.ClientQueryString</b>
    <br />
    Page.ClientQueryString = &quot;<%=ClientQueryString %>&quot;; <br />
    <br />
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/de/Detail15.aspx" runat="server">Deutsch</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/en/Detail30.aspx" runat="server">English</asp:HyperLink>
    <asp:HyperLink ID="HyperLink3" NavigateUrl="~/fr/Detail45.aspx" runat="server">Francaise</asp:HyperLink>
    <asp:HyperLink ID="HyperLink4" NavigateUrl="~/en/Default.aspx" runat="server">Default (AppRedirect)</asp:HyperLink>
    <asp:HyperLink ID="HyperLink5" NavigateUrl="~/kickto/www.urlrewriting.net.aspx" runat="server">To UrlRewritingNet (Domain Redirect)</asp:HyperLink>
    <br />
    <b>Default.aspx Ende</b>
    <hr />
    <% Response.Write(Request.Url.AbsoluteUri); %>
</asp:Content>