Module ExplicitConversionByteToSByte1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Byte
        Dim value2 As SByte
        Dim const2 As SByte

        value1 = CByte(10)
        value2 = CSByte(value1)
        const2 = CSByte(CByte(10))

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionByteToSByte1")
            Return 1
        End If
    End Function
End Module

