Imports System.Data.SqlClient
Imports WebApplication1.dsTestTableAdapters

Public Class daTest

    ' 3.1 Public property 'ds' as dsTest class
    Public Property ds As dsTest

    ' 3.2 Private property 'taIM' as ItemMaster table adapter
    Private taIM As New ItemMasterTableAdapter()

    ' 3.3 Private property 'taID' as ItemMaster table adapter
    Private taID As New ItemDetailTableAdapter()

    ' 3.4 Constructor to create 'ds'
    Public Sub New()
        ds = New dsTest()
    End Sub

    ' 3.5 Public function 'ReadTest' to fill ItemMaster and ItemDetail and return #records read
    Public Function ReadTest() As Integer
        Dim recordsRead As Integer = 0

        recordsRead += ds.ItemMaster.Rows.Count
        recordsRead += ds.ItemDetail.Rows.Count

        Return recordsRead
    End Function

    ' 3.6 Initialize taIM and taID and fill dataset
    Public Sub InitializeAndFill()
        taIM.Fill(ds.ItemMaster)
        taID.Fill(ds.ItemDetail)
    End Sub

    Public Sub UpdatePrice(ItemId As Integer, Price As Decimal)
        ds.ItemDetail.FirstOrDefault(Function(row) row.Field(Of Integer)("ID") = ItemId).Price = Price
        taID.Update(ds.ItemDetail)
    End Sub
End Class