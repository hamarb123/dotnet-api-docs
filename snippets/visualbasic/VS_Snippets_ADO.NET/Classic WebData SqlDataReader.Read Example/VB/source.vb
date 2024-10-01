﻿Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Module1

    ' <Snippet1>
    Private Sub ReadOrderData(ByVal connectionString As String)
        Dim queryString As String = _
            "SELECT OrderID, CustomerID FROM dbo.Orders;"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()

            ' Call Read before accessing data.
            While reader.Read()
                ReadSingleRow(CType(reader, IDataRecord))
            End While

            ' Call Close when done reading.
            reader.Close()
        End Using
    End Sub

    Private Sub ReadSingleRow(ByVal record As IDataRecord)
       Console.WriteLine(String.Format("{0}, {1}", record(0), record(1)))
    End Sub
    ' </Snippet1>

End Module
