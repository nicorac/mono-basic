Module ExplicitConversionIntegerToDecimal1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Integer
        Dim value2 As Decimal
        Dim const2 As Decimal

        value1 = 50I
        value2 = CDec(value1)
        const2 = CDec(50I)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionIntegerToDecimal1")
            Return 1
        End If
    End Function
End Module

