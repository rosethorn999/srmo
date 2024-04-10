<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <p>Your app description page.</p>
        <p>Use this area to provide additional information.</p>
        <p>grid here</p>
        <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ObjectDataSource1" Width="328px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="PN" HeaderText="PN" SortExpression="PN" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WebApplication1.dsTestTableAdapters.ItemMasterTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="PN" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PN" Type="String" />
                <asp:Parameter Name="Original_ID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <hr />
        <asp:GridView ID="gvitems" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="PN" HeaderText="PN" />
                <asp:BoundField DataField="SalesOrg" HeaderText="SalesOrg" />
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
    </main>
</asp:Content>
