Public Module JaggedArrayLocalsVariableUInteger1
    Function Main() As Int32
        Dim result As Int32

        Dim a As UInteger()
        Dim b As UInteger()()
        Dim c As UInteger()()()
        Dim d As UInteger()()()()
        Dim aa() As UInteger
        Dim bb()() As UInteger
        Dim cc()()() As UInteger
        Dim dd()()()() As UInteger

        a = New UInteger() {}
        b = New UInteger()() {}
        c = New UInteger()()() {}
        d = New UInteger()()()() {}

        aa = New UInteger() {}
        bb = New UInteger()() {}
        cc = New UInteger()()() {}
        dd = New UInteger()()()() {}

        result += JaggedArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If b.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If c.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If d.Length <> 0 Then result += JaggedArrayVerifier.Report()

        If aa.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If bb.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If cc.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If dd.Length <> 0 Then result += JaggedArrayVerifier.Report()


        a = New UInteger() {}
        b = New UInteger()() {New UInteger() {}}
        c = New UInteger()()() {New UInteger()() {New UInteger() {}}}
        d = New UInteger()()()() {New UInteger()()() {New UInteger()() {New UInteger() {}}}}

        aa = New UInteger() {}
        bb = New UInteger()() {New UInteger() {}}
        cc = New UInteger()()() {New UInteger()() {New UInteger() {}}}
        dd = New UInteger()()()() {New UInteger()()() {New UInteger()() {New UInteger() {}}}}

        result += JaggedArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If b.Length <> 1 Then result += JaggedArrayVerifier.Report()
        If c.Length <> 1 Then result += JaggedArrayVerifier.Report()
        If d.Length <> 1 Then result += JaggedArrayVerifier.Report()

        If aa.Length <> 0 Then result += JaggedArrayVerifier.Report()
        If bb.Length <> 1 Then result += JaggedArrayVerifier.Report()
        If cc.Length <> 1 Then result += JaggedArrayVerifier.Report()
        If dd.Length <> 1 Then result += JaggedArrayVerifier.Report()

        a = New UInteger() {1UI, 2UI}
        b = New UInteger()() {New UInteger() {10UI, 11UI}, New UInteger() {12UI, 13UI}}
        c = New UInteger()()() {New UInteger()() {New UInteger() {20UI, 21UI}, New UInteger() {22UI, 23UI}}, New UInteger()() {New UInteger() {24UI, 25UI}, New UInteger() {26UI, 27UI}}}
        d = New UInteger()()()() {New UInteger()()() {New UInteger()() {New UInteger() {30UI, 31UI}, New UInteger() {32UI, 33UI}}, New UInteger()() {New UInteger() {34UI, 35UI}, New UInteger() {36UI, 37UI}}}, New UInteger()()() {New UInteger()() {New UInteger() {40UI, 41UI}, New UInteger() {42UI, 43UI}}, New UInteger()() {New UInteger() {44UI, 45UI}, New UInteger() {46UI, 47UI}}}}

        aa = New UInteger() {1UI, 2UI}
        bb = New UInteger()() {New UInteger() {10UI, 11UI}, New UInteger() {12UI, 13UI}}
        cc = New UInteger()()() {New UInteger()() {New UInteger() {20UI, 21UI}, New UInteger() {22UI, 23UI}}, New UInteger()() {New UInteger() {24UI, 25UI}, New UInteger() {26UI, 27UI}}}
        dd = New UInteger()()()() {New UInteger()()() {New UInteger()() {New UInteger() {30UI, 31UI}, New UInteger() {32UI, 33UI}}, New UInteger()() {New UInteger() {34UI, 35UI}, New UInteger() {36UI, 37UI}}}, New UInteger()()() {New UInteger()() {New UInteger() {40UI, 41UI}, New UInteger() {42UI, 43UI}}, New UInteger()() {New UInteger() {44UI, 45UI}, New UInteger() {46UI, 47UI}}}}

        result += JaggedArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If b.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If c.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If d.Length <> 2 Then result += JaggedArrayVerifier.Report()

        If aa.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If bb.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If cc.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If dd.Length <> 2 Then result += JaggedArrayVerifier.Report()

        a = New UInteger() {51UI, 52UI}
        b = New UInteger()() {New UInteger() {50UI, 51UI}, New UInteger() {52UI, 53UI}}
        c = New UInteger()()() {New UInteger()() {New UInteger() {60UI, 61UI}, New UInteger() {62UI, 63UI}}, New UInteger()() {New UInteger() {64UI, 65UI}, New UInteger() {66UI, 67UI}}}
        d = New UInteger()()()() {New UInteger()()() {New UInteger()() {New UInteger() {70UI, 71UI}, New UInteger() {72UI, 73UI}}, New UInteger()() {New UInteger() {74UI, 75UI}, New UInteger() {76UI, 77UI}}}, New UInteger()()() {New UInteger()() {New UInteger() {80UI, 81UI}, New UInteger() {82UI, 83UI}}, New UInteger()() {New UInteger() {84UI, 85UI}, New UInteger() {86UI, 87UI}}}}

        aa(0) = 51UI
        aa(1) = 52UI
        bb(0)(0) = 50UI
        bb(0)(1) = 51UI
        bb(1)(0) = 52UI
        bb(1)(1) = 53UI
        cc(0)(0)(0) = 60UI
        cc(0)(0)(1) = 61UI
        cc(0)(1)(0) = 62UI
        cc(0)(1)(1) = 63UI
        cc(1)(0)(0) = 64UI
        cc(1)(0)(1) = 65UI
        cc(1)(1)(0) = 66UI
        cc(1)(1)(1) = 67UI

        dd(0)(0)(0)(0) = 70UI
        dd(0)(0)(0)(1) = 71UI
        dd(0)(0)(1)(0) = 72UI
        dd(0)(0)(1)(1) = 73UI
        dd(0)(1)(0)(0) = 74UI
        dd(0)(1)(0)(1) = 75UI
        dd(0)(1)(1)(0) = 76UI
        dd(0)(1)(1)(1) = 77UI

        dd(1)(0)(0)(0) = 80UI
        dd(1)(0)(0)(1) = 81UI
        dd(1)(0)(1)(0) = 82UI
        dd(1)(0)(1)(1) = 83UI
        dd(1)(1)(0)(0) = 84UI
        dd(1)(1)(0)(1) = 85UI
        dd(1)(1)(1)(0) = 86UI
        dd(1)(1)(1)(1) = 87UI

        result += JaggedArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If b.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If c.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If d.Length <> 2 Then result += JaggedArrayVerifier.Report()

        If aa.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If bb.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If cc.Length <> 2 Then result += JaggedArrayVerifier.Report()
        If dd.Length <> 2 Then result += JaggedArrayVerifier.Report()

        Return result
    End Function
End Module
