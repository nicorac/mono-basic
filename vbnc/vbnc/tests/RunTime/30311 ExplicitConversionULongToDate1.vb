Module ExplicitConversionULongToDate1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As ULong
        Dim value2 As Date
        Dim const2 As Date

        value1 = 80UL
        value2 = CDate(value1)
        const2 = CDate(80UL)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionULongToDate1")
            Return 1
        End If
    End Function
End Module

