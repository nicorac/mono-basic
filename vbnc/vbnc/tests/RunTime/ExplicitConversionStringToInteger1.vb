Module ExplicitConversionStringToInteger1
    Function Main() As Integer
        Dim result As Boolean
        Dim value1 As String
        Dim value2 As Integer
        Dim const2 As Integer

        value1 = "testvalue"
        value2 = CInt(value1)
        const2 = CInt("testvalue")

        result = value2 = const2

        If result = False Then
            System.Console.WriteLine("FAIL ExplicitConversionStringToInteger1")
            Return 1
        End If
    End Function
End Module

