Module ImplicitConversionBooleanToSByte1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Boolean
        Dim value2 As SByte
        Dim const2 As SByte

        value1 = True
        value2 = value1
        const2 = True

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ImplicitConversionBooleanToSByte1")
            Return 1
        End If
    End Function
End Module
