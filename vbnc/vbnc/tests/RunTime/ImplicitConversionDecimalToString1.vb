Module ImplicitConversionDecimalToString1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Decimal
        Dim value2 As String
        Dim const2 As String

        value1 = 90.09D
        value2 = value1
        const2 = 90.09D

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ImplicitConversionDecimalToString1")
            Return 1
        End If
    End Function
End Module

