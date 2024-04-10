<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Welcome</h1>
            <p class="lead">Use textbox to modify price and <b>save</b> button to persist data.</p>
        </section>
        <section>
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
