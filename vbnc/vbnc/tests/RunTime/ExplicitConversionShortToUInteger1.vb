Module ExplicitConversionShortToUInteger1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Short
        Dim value2 As UInteger
        Dim const2 As UInteger

        value1 = 30S
        value2 = CUInt(value1)
        const2 = CUInt(30S)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionShortToUInteger1")
            Return 1
        End If
    End Function
End Module

