Module ImplicitConversionUIntegerToChar1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As UInteger
        Dim value2 As Char
        Dim const2 As Char

        value1 = 60UI
        value2 = value1
        const2 = 60UI

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ImplicitConversionUIntegerToChar1")
            Return 1
        End If
    End Function
End Module

