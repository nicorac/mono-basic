Module ExplicitConversionUIntegerToSByte1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As UInteger
        Dim value2 As SByte
        Dim const2 As SByte

        value1 = 60UI
        value2 = CSByte(value1)
        const2 = CSByte(60UI)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionUIntegerToSByte1")
            Return 1
        End If
    End Function
End Module

