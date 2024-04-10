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

        ' Fill ItemMaster
        taIM.Fill(ds.ItemMaster)
        recordsRead += ds.ItemMaster.Rows.Count

        ' Fill ItemDetail
        taID.Fill(ds.ItemDetail)
        recordsRead += ds.ItemDetail.Rows.Count

        Return recordsRead
    End Function

    ' 3.6 Initialize taIM and taID and fill dataset
    Public Sub InitializeAndFill()
        ' Initialize taIM and taID (already initialized in properties)

        ' Fill dataset
        taIM.Fill(ds.ItemMaster)
        taID.Fill(ds.ItemDetail)
    End Sub

End Class