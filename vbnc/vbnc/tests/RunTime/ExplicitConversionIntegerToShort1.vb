Module ExplicitConversionIntegerToShort1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Integer
        Dim value2 As Short
        Dim const2 As Short

        value1 = 50I
        value2 = CShort(value1)
        const2 = CShort(50I)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionIntegerToShort1")
            Return 1
        End If
    End Function
End Module

