Public Class About
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Using db As New DataClasses1DataContext(ConfigurationManager.ConnectionStrings("masterConnectionString").ConnectionString)
                ' Query the data using LINQ
                Dim query = From master In db.ItemMasters
                            Group Join detail In db.ItemDetails
                            On master.ID Equals detail.ID Into detailGroup = Group
                            From detailItem In detailGroup.DefaultIfEmpty()
                            Select master.ID, master.PN, detailItem.SalesOrg, detailItem.Price

                ' Bind the query result to the GridView
                gvitems.DataSource = query.ToList()
                gvitems.DataBind()
            End Using
        End If
    End Sub

End Class