'Author: Ritvik Mayank <mritvik@novell.com>
'Copyright (C) 2005 Novell, Inc (http://www.novell.com)

Imports System
Module ConversionShiftOperator

    Function Main() As Integer
        Dim A As Integer = -10
        Dim B As Integer = 2
        Dim R As Integer
        R = A >> B
        If R <> -3 Then
            System.Console.WriteLine("#Error With >> Shift Operator") : Return 1
        End If
    End Function
End Module
