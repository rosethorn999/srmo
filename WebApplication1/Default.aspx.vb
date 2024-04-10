Public Class _Default
    Inherits Page
    ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("masterConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Using db As New DataClasses1DataContext(ConnectionString)
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
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Iterate through each row in the GridView
        For Each row As GridViewRow In gvitems.Rows
            ' Find the controls for price editing
            Dim txtPrice As TextBox = CType(row.FindControl("txtPrice"), TextBox)

            If txtPrice IsNot Nothing Then
                ' Get the updated price from the TextBox
                Dim newPrice As Decimal
                If Decimal.TryParse(txtPrice.Text, newPrice) Then
                    Dim itemId As Integer = Convert.ToInt32(row.Cells(0).Text) ' Assuming the ID is in the first cell

                    ' Update the database with the new price
                    UpdatePriceInDatabase(itemId, newPrice)
                End If
            End If
        Next
    End Sub

    Private Sub UpdatePriceInDatabase(itemId As Integer, newPrice As Decimal)
        ' Update the database with the new price
        Using db As New DataClasses1DataContext(ConnectionString)
            Dim item = db.ItemDetails.FirstOrDefault(Function(i) i.ID = itemId)
            If item IsNot Nothing Then
                item.Price = newPrice
                db.SubmitChanges()
            End If
        End Using
    End Sub
End Class