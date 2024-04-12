Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim myDaTest As New daTest()
            myDaTest.InitializeAndFill()
            Dim recordsRead As Integer = myDaTest.ReadTest()

            ' Query the data using LINQ
            Dim query = From masterRow In myDaTest.ds.ItemMaster.AsEnumerable()
                        Group Join detailRow In myDaTest.ds.ItemDetail.AsEnumerable()
            On masterRow.Field(Of Integer)("ID") Equals detailRow.Field(Of Integer)("ID") Into detailGroup = Group
                        From detailItem In detailGroup.DefaultIfEmpty()
                        Select ID = masterRow.Field(Of Integer)("ID"),
                               PN = masterRow.Field(Of String)("PN"),
                               SalesOrg = detailItem.Field(Of String)("SalesOrg"),
                               Price = detailItem.Field(Of Decimal)("Price").ToString("#0.00")
            ' Bind the query result to the GridView
            gvTest.DataSource = query.ToList()
            gvTest.DataBind()
        End If
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Iterate through each row in the GridView
        For Each row As GridViewRow In gvTest.Rows
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
        Dim myDaTest As New daTest()
        myDaTest.InitializeAndFill()
        myDaTest.UpdatePrice(itemId, newPrice)
    End Sub
End Class