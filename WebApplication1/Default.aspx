<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Welcome</h1>
            <p class="lead">Use textbox to modify price and <b>save</b> button to persist data.</p>
        </section>
        <section>
            <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="PN" HeaderText="PN" />
                    <asp:BoundField DataField="SalesOrg" HeaderText="SalesOrg" HeaderStyle-Width="100" />
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="100" />
        </section>
    </main>

</asp:Content>
