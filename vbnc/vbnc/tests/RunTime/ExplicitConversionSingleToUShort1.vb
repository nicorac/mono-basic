Module ExplicitConversionSingleToUShort1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Single
        Dim value2 As UShort
        Dim const2 As UShort

        value1 = 100.001!
        value2 = CUShort(value1)
        const2 = CUShort(100.001!)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionSingleToUShort1")
            Return 1
        End If
    End Function
End Module

