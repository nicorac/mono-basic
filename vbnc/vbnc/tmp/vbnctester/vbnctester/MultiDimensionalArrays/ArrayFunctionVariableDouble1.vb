Public Module ArrayFunctionVariableDouble1
    Dim _a As Double()
    Dim _b As Double(,)
    Dim _c As Double(,,)
    Dim _d As Double(,,,)
    Dim _aa() As Double
    Dim _bb(,) As Double
    Dim _cc(,,) As Double
    Dim _dd(,,,) As Double

    Function a() As Double()
        Return _a
    End Function

    Function b() As Double(,)
        Return _b
    End Function

    Function c() As Double(,,)
        Return _c
    End Function

    Function d() As Double(,,,)
        Return _d
    End Function

    Function aa() As Double()
        Return _aa
    End Function

    Function bb() As Double(,)
        Return _bb
    End Function

    Function cc() As Double(,,)
        Return _cc
    End Function

    Function dd() As Double(,,,)
        Return _dd
    End Function

    Function Main() As Int32
        Dim result As Int32

        _a = New Double() {}
        _b = New Double(,) {}
        _c = New Double(,,) {}
        _d = New Double(,,,) {}

        _aa = New Double() {}
        _bb = New Double(,) {}
        _cc = New Double(,,) {}
        _dd = New Double(,,,) {}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += ArrayVerifier.Report()
        If b.Length <> 0 Then result += ArrayVerifier.Report()
        If c.Length <> 0 Then result += ArrayVerifier.Report()
        If d.Length <> 0 Then result += ArrayVerifier.Report()

        If aa.Length <> 0 Then result += ArrayVerifier.Report()
        If bb.Length <> 0 Then result += ArrayVerifier.Report()
        If cc.Length <> 0 Then result += ArrayVerifier.Report()
        If dd.Length <> 0 Then result += ArrayVerifier.Report()

        _a = New Double() {}
        _b = New Double(,) {{}}
        _c = New Double(,,) {{{}}}
        _d = New Double(,,,) {{{{}}}}

        _aa = New Double() {}
        _bb = New Double(,) {{}}
        _cc = New Double(,,) {{{}}}
        _dd = New Double(,,,) {{{{}}}}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 0 Then result += ArrayVerifier.Report()
        If b.Length <> 0 Then result += ArrayVerifier.Report()
        If c.Length <> 0 Then result += ArrayVerifier.Report()
        If d.Length <> 0 Then result += ArrayVerifier.Report()

        If aa.Length <> 0 Then result += ArrayVerifier.Report()
        If bb.Length <> 0 Then result += ArrayVerifier.Report()
        If cc.Length <> 0 Then result += ArrayVerifier.Report()
        If dd.Length <> 0 Then result += ArrayVerifier.Report()


        _a = New Double() {1#, 2#}
        _b = New Double(,) {{10#, 11#}, {12#, 13#}}
        _c = New Double(,,) {{{20#, 21#}, {22#, 23#}}, {{24#, 25#}, {26#, 27#}}}
        _d = New Double(,,,) {{{{30#, 31#}, {32#, 33#}}, {{34#, 35#}, {36#, 37#}}}, {{{40#, 41#}, {42#, 43#}}, {{44#, 45#}, {46#, 47#}}}}

        _aa = New Double() {1#, 2#}
        _bb = New Double(,) {{10#, 11#}, {12#, 13#}}
        _cc = New Double(,,) {{{20#, 21#}, {22#, 23#}}, {{24#, 25#}, {26#, 27#}}}
        _dd = New Double(,,,) {{{{30#, 31#}, {32#, 33#}}, {{34#, 35#}, {36#, 37#}}}, {{{40#, 41#}, {42#, 43#}}, {{44#, 45#}, {46#, 47#}}}}

        result += ArrayVerifier.Verify(a, b, c, d, aa, bb, cc, dd)

        If a.Length <> 2 Then result += ArrayVerifier.Report()
        If b.Length <> 4 Then result += ArrayVerifier.Report()
        If c.Length <> 8 Then result += ArrayVerifier.Report()
        If d.Length <> 16 Then result += ArrayVerifier.Report()

        If aa.Length <> 2 Then result += ArrayVerifier.Report()
        If bb.Length <> 4 Then result += ArrayVerifier.Report()
        If cc.Length <> 8 Then result += ArrayVerifier.Report()
        If dd.Length <> 16 Then result += ArrayVerifier.Report()

        _a = New Double() {51#, 52#}
        _b = New Double(,) {{50#, 51#}, {52#, 53#}}
        _c = New Double(,,) {{{60#, 61#}, {62#, 63#}}, {{64#, 65#}, {66#, 67#}}}
        _d = New Double(,,,) {{{{70#, 71#}, {72#, 73#}}, {{74#, 75#}, {76#, 77#}}}, {{{80#, 81#}, {82#, 83#}}, {{84#, 85#}, {86#, 87#}}}}

        aa(0) = 51#
        aa(1) = 52#
        bb(0, 0) = 50#
        bb(0, 1) = 51#
        bb(1, 0) = 52#
        bb(1, 1) = 53#
        cc(0, 0, 0) = 60#
        cc(0, 0, 1) = 61#
        cc(0, 1, 0) = 62#
        cc(0, 1, 1) = 63#
        cc(1, 0, 0) = 64#
        cc(1, 0, 1) = 65#
        cc(1, 1, 0) = 66#
        cc(1, 1, 1) = 67#

        dd(0, 0, 0, 0) = 70#
        dd(0, 0, 0, 1) = 71#
        dd(0, 0, 1, 0) = 72#
        dd(0, 0, 1, 1) = 73#
        dd(0, 1, 0, 0) = 74#
        dd(0, 1, 0, 1) = 75#
        dd(0, 1, 1, 0) = 76#
        dd(0, 1, 1, 1) = 77#

        dd(1, 0, 0, 0) = 80#
        dd(1, 0, 0, 1) = 81#
        dd(1, 0, 1, 0) = 82#
        dd(1, 0, 1, 1) = 83#
        dd(1, 1, 0, 0) = 84#
        dd(1, 1, 0, 1) = 85#
        dd(1, 1, 1, 0) = 86#
        dd(1, 1, 1, 1) = 87#

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
