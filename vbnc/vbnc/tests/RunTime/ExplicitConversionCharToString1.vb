Module ExplicitConversionCharToString1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Char
        Dim value2 As String
        Dim const2 As String

        value1 = "C"c
        value2 = CStr(value1)
        const2 = CStr("C"c)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionCharToString1")
            Return 1
        End If
    End Function
End Module

