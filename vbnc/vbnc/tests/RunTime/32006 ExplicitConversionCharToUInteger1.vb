Module ExplicitConversionCharToUInteger1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Char
        Dim value2 As UInteger
        Dim const2 As UInteger

        value1 = "C"c
        value2 = CUInt(value1)
        const2 = CUInt("C"c)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionCharToUInteger1")
            Return 1
        End If
    End Function
End Module

