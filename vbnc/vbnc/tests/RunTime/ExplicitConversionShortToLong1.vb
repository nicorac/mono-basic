Module ExplicitConversionShortToLong1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As Short
        Dim value2 As Long
        Dim const2 As Long

        value1 = 30S
        value2 = CLng(value1)
        const2 = CLng(30S)

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionShortToLong1")
            Return 1
        End If
    End Function
End Module

