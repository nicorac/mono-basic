Module ImplicitConversionDoubleToSingle1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Double
        Dim value2 As Single
        Dim const2 As Single

        value1 = 110.011
        value2 = value1
        const2 = 110.011

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ImplicitConversionDoubleToSingle1")
            Return 1
        End If
    End Function
End Module

