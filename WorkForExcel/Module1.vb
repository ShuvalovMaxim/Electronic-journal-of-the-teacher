Public Module Module1

    Sub Main()
    End Sub

    Public Function ReadExcelFile(filePath As String) As List(Of String)
        Dim MyConnect As OleDb.OleDbConnection
        Dim setData As DataSet
        Dim studentsList As List(Of String) = New List(Of String)
        Dim Commands As OleDb.OleDbDataAdapter
        Dim path As String = filePath
        MyConnect = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 8.0;")
        Commands = New OleDb.OleDbDataAdapter("select * from [Лист1$]", MyConnect)
        setData = New DataSet
        Commands.Fill(setData)

        For Each MyDataRow As DataRow In setData.Tables(0).Rows
            studentsList.Add(MyDataRow(0))
        Next
        MyConnect.Close()
        Return studentsList
    End Function

End Module
