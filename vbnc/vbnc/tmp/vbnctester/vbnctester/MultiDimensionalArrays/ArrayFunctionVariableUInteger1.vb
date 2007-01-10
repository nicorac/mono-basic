Public Module ArrayFunctionVariableUInteger1
    Dim _a As UInteger()
    Dim _b As UInteger(,)
    Dim _c As UInteger(,,)
    Dim _d As UInteger(,,,)
    Dim _aa() As UInteger
    Dim _bb(,) As UInteger
    Dim _cc(,,) As UInteger
    Dim _dd(,,,) As UInteger

    Function a() As UInteger()
        Return _a
    End Function

    Function b() As UInteger(,)
        Return _b
    End Function

    Function c() As UInteger(,,)
        Return _c
    End Function

    Function d() As UInteger(,,,)
        Return _d
    End Function

    Function aa() As UInteger()
        Return _aa
    End Function

    Function bb() As UInteger(,)
        Return _bb
    End Function

    Function cc() As UInteger(,,)
        Return _cc
    End Function

    Function dd() As UInteger(,,,)
        Return _dd
    End Function

    Function Main() As Int32
        Dim result As Int32

        _a = New UInteger() {}
        _b = New UInteger(,) {}
        _c = New UInteger(,,) {}
        _d = New UInteger(,,,) {}

        _aa = New UInteger() {}
        _bb = New UInteger(,) {}
        _cc = New UInteger(,,) {}
        _dd = New UInteger(,,,) {}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += ArrayVerifier.Report()
        If b.Length <> 0 Then result += ArrayVerifier.Report()
        If c.Length <> 0 Then result += ArrayVerifier.Report()
        If d.Length <> 0 Then result += ArrayVerifier.Report()

        If aa.Length <> 0 Then result += ArrayVerifier.Report()
        If bb.Length <> 0 Then result += ArrayVerifier.Report()
        If cc.Length <> 0 Then result += ArrayVerifier.Report()
        If dd.Length <> 0 Then result += ArrayVerifier.Report()

        _a = New UInteger() {}
        _b = New UInteger(,) {{}}
        _c = New UInteger(,,) {{{}}}
        _d = New UInteger(,,,) {{{{}}}}

        _aa = New UInteger() {}
        _bb = New UInteger(,) {{}}
        _cc = New UInteger(,,) {{{}}}
        _dd = New UInteger(,,,) {{{{}}}}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += ArrayVerifier.Report()
        If b.Length <> 0 Then result += ArrayVerifier.Report()
        If c.Length <> 0 Then result += ArrayVerifier.Report()
        If d.Length <> 0 Then result += ArrayVerifier.Report()

        If aa.Length <> 0 Then result += ArrayVerifier.Report()
        If bb.Length <> 0 Then result += ArrayVerifier.Report()
        If cc.Length <> 0 Then result += ArrayVerifier.Report()
        If dd.Length <> 0 Then result += ArrayVerifier.Report()


        _a = New UInteger() {1UI, 2UI}
        _b = New UInteger(,) {{10UI, 11UI}, {12UI, 13UI}}
        _c = New UInteger(,,) {{{20UI, 21UI}, {22UI, 23UI}}, {{24UI, 25UI}, {26UI, 27UI}}}
        _d = New UInteger(,,,) {{{{30UI, 31UI}, {32UI, 33UI}}, {{34UI, 35UI}, {36UI, 37UI}}}, {{{40UI, 41UI}, {42UI, 43UI}}, {{44UI, 45UI}, {46UI, 47UI}}}}

        _aa = New UInteger() {1UI, 2UI}
        _bb = New UInteger(,) {{10UI, 11UI}, {12UI, 13UI}}
        _cc = New UInteger(,,) {{{20UI, 21UI}, {22UI, 23UI}}, {{24UI, 25UI}, {26UI, 27UI}}}
        _dd = New UInteger(,,,) {{{{30UI, 31UI}, {32UI, 33UI}}, {{34UI, 35UI}, {36UI, 37UI}}}, {{{40UI, 41UI}, {42UI, 43UI}}, {{44UI, 45UI}, {46UI, 47UI}}}}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 2 Then result += ArrayVerifier.Report()
        If b.Length <> 4 Then result += ArrayVerifier.Report()
        If c.Length <> 8 Then result += ArrayVerifier.Report()
        If d.Length <> 16 Then result += ArrayVerifier.Report()

        If aa.Length <> 2 Then result += ArrayVerifier.Report()
        If bb.Length <> 4 Then result += ArrayVerifier.Report()
        If cc.Length <> 8 Then result += ArrayVerifier.Report()
        If dd.Length <> 16 Then result += ArrayVerifier.Report()

        _a = New UInteger() {51UI, 52UI}
        _b = New UInteger(,) {{50UI, 51UI}, {52UI, 53UI}}
        _c = New UInteger(,,) {{{60UI, 61UI}, {62UI, 63UI}}, {{64UI, 65UI}, {66UI, 67UI}}}
        _d = New UInteger(,,,) {{{{70UI, 71UI}, {72UI, 73UI}}, {{74UI, 75UI}, {76UI, 77UI}}}, {{{80UI, 81UI}, {82UI, 83UI}}, {{84UI, 85UI}, {86UI, 87UI}}}}

        aa(0) = 51UI
        aa(1) = 52UI
        bb(0, 0) = 50UI
        bb(0, 1) = 51UI
        bb(1, 0) = 52UI
        bb(1, 1) = 53UI
        cc(0, 0, 0) = 60UI
        cc(0, 0, 1) = 61UI
        cc(0, 1, 0) = 62UI
        cc(0, 1, 1) = 63UI
        cc(1, 0, 0) = 64UI
        cc(1, 0, 1) = 65UI
        cc(1, 1, 0) = 66UI
        cc(1, 1, 1) = 67UI

        dd(0, 0, 0, 0) = 70UI
        dd(0, 0, 0, 1) = 71UI
        dd(0, 0, 1, 0) = 72UI
        dd(0, 0, 1, 1) = 73UI
        dd(0, 1, 0, 0) = 74UI
        dd(0, 1, 0, 1) = 75UI
        dd(0, 1, 1, 0) = 76UI
        dd(0, 1, 1, 1) = 77UI

        dd(1, 0, 0, 0) = 80UI
        dd(1, 0, 0, 1) = 81UI
        dd(1, 0, 1, 0) = 82UI
        dd(1, 0, 1, 1) = 83UI
        dd(1, 1, 0, 0) = 84UI
        dd(1, 1, 0, 1) = 85UI
        dd(1, 1, 1, 0) = 86UI
        dd(1, 1, 1, 1) = 87UI

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 2 Then result += ArrayVerifier.Report()
        If b.Length <> 4 Then result += ArrayVerifier.Report()
        If c.Length <> 8 Then result += ArrayVerifier.Report()
        If d.Length <> 16 Then result += ArrayVerifier.Report()

        If aa.Length <> 2 Then result += ArrayVerifier.Report()
        If bb.Length <> 4 Then result += ArrayVerifier.Report()
        If cc.Length <> 8 Then result += ArrayVerifier.Report()
        If dd.Length <> 16 Then result += ArrayVerifier.Report()

        Return result
    End Function

End Module
