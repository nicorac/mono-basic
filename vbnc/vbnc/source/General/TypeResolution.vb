' 
' Visual Basic.Net Compiler
' Copyright (C) 2004 - 2007 Rolf Bjarne Kvinge, RKvinge@novell.com
' 
' This library is free software; you can redistribute it and/or
' modify it under the terms of the GNU Lesser General Public
' License as published by the Free Software Foundation; either
' version 2.1 of the License, or (at your option) any later version.
' 
' This library is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
' Lesser General Public License for more details.
' 
' You should have received a copy of the GNU Lesser General Public
' License along with this library; if not, write to the Free Software
' Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
' 

#If DEBUG Then
#Const EXTENDEDDEBUG = 0
#End If

Public Class TypeResolution
    Inherits Helper

    Friend BuiltInTypes As New ArrayList(New Type() {Compiler.TypeCache.Boolean, Compiler.TypeCache.Byte, Compiler.TypeCache.Char, Compiler.TypeCache.Date, Compiler.TypeCache.Double, Compiler.TypeCache.Integer, Compiler.TypeCache.Long, Compiler.TypeCache.Object, Compiler.TypeCache.Short, Compiler.TypeCache.Single, Compiler.TypeCache.String, Compiler.TypeCache.SByte, Compiler.TypeCache.UShort, Compiler.TypeCache.UInteger, Compiler.TypeCache.ULong})
    Friend NumericTypes As New ArrayList(New Type() {Compiler.TypeCache.Byte, Compiler.TypeCache.SByte, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single, Compiler.TypeCache.Short, Compiler.TypeCache.UShort, Compiler.TypeCache.Integer, Compiler.TypeCache.UInteger, Compiler.TypeCache.Long, Compiler.TypeCache.ULong})
    Friend IntegralTypes As New ArrayList(New Type() {Compiler.TypeCache.Byte, Compiler.TypeCache.SByte, Compiler.TypeCache.Short, Compiler.TypeCache.UShort, Compiler.TypeCache.Integer, Compiler.TypeCache.UInteger, Compiler.TypeCache.Long, Compiler.TypeCache.ULong})

    Private valCanBeContainBy(15)() As Type

    Public Shared Conversion As TypeConversionInfo(,)

    Shared Sub New()
        Dim highest As Integer

        Dim tmp As Array = System.Enum.GetValues(GetType(TypeCode))
        highest = CInt(tmp.GetValue(tmp.GetUpperBound(0)))

        ReDim Conversion(highest, highest)
        For i As Integer = 0 To highest
            For j As Integer = 0 To highest
                Conversion(i, j) = New TypeConversionInfo
                If j = TypeCode.Object OrElse j = i Then
                    Conversion(i, j).Conversion = ConversionType.Implicit
                Else
                    Conversion(i, j).Conversion = ConversionType.Explicit
                End If
            Next
        Next

        setImplicit(TypeCode.SByte, New TypeCode() {TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.Byte, New TypeCode() {TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.Int16, New TypeCode() {TypeCode.Int32, TypeCode.Int64, TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.UInt16, New TypeCode() {TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.Int32, New TypeCode() {TypeCode.Int64, TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.UInt32, New TypeCode() {TypeCode.Int64, TypeCode.UInt64, TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.Int64, New TypeCode() {TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.UInt64, New TypeCode() {TypeCode.Decimal, TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.Decimal, New TypeCode() {TypeCode.Single, TypeCode.Double})
        setImplicit(TypeCode.Single, New TypeCode() {TypeCode.Double})
        setImplicit(TypeCode.Double, New TypeCode() {})
        setImplicit(TypeCode.Char, New TypeCode() {TypeCode.String})

        Conversion(TypeCode.Byte, TypeCode.Byte).BinaryAddResult = TypeCode.Byte
        Conversion(TypeCode.Boolean, TypeCode.Boolean).BinaryAddResult = TypeCode.SByte
    End Sub

    Sub New(ByVal Compiler As Compiler)
        MyBase.New(Compiler)

        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Boolean)) = Nothing
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Byte)) = New Type() {Compiler.TypeCache.Byte, Compiler.TypeCache.Short, Compiler.TypeCache.UShort, Compiler.TypeCache.Integer, Compiler.TypeCache.UInteger, Compiler.TypeCache.Long, Compiler.TypeCache.ULong, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Char)) = Nothing
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Date)) = Nothing
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Decimal)) = New Type() {Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Double)) = New Type() {Compiler.TypeCache.Double}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Integer)) = New Type() {Compiler.TypeCache.Integer, Compiler.TypeCache.Long, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Long)) = New Type() {Compiler.TypeCache.Long, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Object)) = Nothing
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.[SByte])) = New Type() {Compiler.TypeCache.SByte, Compiler.TypeCache.Short, Compiler.TypeCache.Integer, Compiler.TypeCache.Long, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Short)) = New Type() {Compiler.TypeCache.Short, Compiler.TypeCache.Integer, Compiler.TypeCache.Long, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.Single)) = New Type() {Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.String)) = Nothing
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.[UInteger])) = New Type() {Compiler.TypeCache.UInteger, Compiler.TypeCache.Long, Compiler.TypeCache.ULong, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.[ULong])) = New Type() {Compiler.TypeCache.ULong, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}
        valCanBeContainBy(getTypeIndex(BuiltInDataTypes.[UShort])) = New Type() {Compiler.TypeCache.UShort, Compiler.TypeCache.Integer, Compiler.TypeCache.UInteger, Compiler.TypeCache.Long, Compiler.TypeCache.ULong, Compiler.TypeCache.Decimal, Compiler.TypeCache.Double, Compiler.TypeCache.Single}


 
    End Sub

    ''' <summary>
    ''' Returns the type of the builtin type.
    ''' If it isn't a builtin type, then it returns nothing,
    ''' </summary>
    ''' <param name="tp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function BuiltInTypeToType(ByVal tp As BuiltInDataTypes) As Type
        Return KeywordToType(CType(tp, KS))
    End Function

    Function IsBuiltInType(ByVal Type As Type) As Boolean
        Return BuiltInTypes.Contains(Type)
    End Function

    Shared Function TypeCodeToBuiltInType(ByVal tp As TypeCode) As BuiltInDataTypes
        Select Case tp
            Case TypeCode.Boolean
                Return BuiltInDataTypes.Boolean
            Case TypeCode.Byte
                Return BuiltInDataTypes.Byte
            Case TypeCode.Char
                Return BuiltInDataTypes.Char
            Case TypeCode.DateTime
                Return BuiltInDataTypes.Date
            Case TypeCode.DBNull
                Throw New InternalException("")
            Case TypeCode.Decimal
                Return BuiltInDataTypes.Decimal
            Case TypeCode.Double
                Return BuiltInDataTypes.Double
            Case TypeCode.Empty
                Throw New InternalException("")
            Case TypeCode.Int16
                Return BuiltInDataTypes.Short
            Case TypeCode.Int32
                Return BuiltInDataTypes.Integer
            Case TypeCode.Int64
                Return BuiltInDataTypes.Long
            Case TypeCode.Object
                Return BuiltInDataTypes.Object
            Case TypeCode.SByte
                Return BuiltInDataTypes.SByte
            Case TypeCode.Single
                Return BuiltInDataTypes.Single
            Case TypeCode.String
                Return BuiltInDataTypes.String
            Case TypeCode.UInt16
                Return BuiltInDataTypes.UShort
            Case TypeCode.UInt32
                Return BuiltInDataTypes.UInteger
            Case TypeCode.UInt64
                Return BuiltInDataTypes.ULong
            Case Else
                Throw New InternalException("")
        End Select
    End Function

    Shared Function BuiltInTypeToTypeCode(ByVal Type As BuiltInDataTypes) As TypeCode
        Select Case Type
            Case BuiltInDataTypes.Boolean
                Return TypeCode.Boolean
            Case BuiltInDataTypes.Byte
                Return TypeCode.Byte
            Case BuiltInDataTypes.Char
                Return TypeCode.Char
            Case BuiltInDataTypes.Date
                Return TypeCode.DateTime
            Case BuiltInDataTypes.Decimal
                Return TypeCode.Decimal
            Case BuiltInDataTypes.Double
                Return TypeCode.Double
            Case BuiltInDataTypes.Integer
                Return TypeCode.Int32
            Case BuiltInDataTypes.Long
                Return TypeCode.Int64
            Case BuiltInDataTypes.Object
                Return TypeCode.Object
            Case BuiltInDataTypes.SByte
                Return TypeCode.SByte
            Case BuiltInDataTypes.Short
                Return TypeCode.Int16
            Case BuiltInDataTypes.Single
                Return TypeCode.Single
            Case BuiltInDataTypes.String
                Return TypeCode.String
            Case BuiltInDataTypes.UInteger
                Return TypeCode.UInt32
            Case BuiltInDataTypes.ULong
                Return TypeCode.UInt64
            Case BuiltInDataTypes.UShort
                Return TypeCode.UInt16
            Case Else
                Throw New InternalException("")
        End Select
    End Function

    Function TypeCodeToTypeDescriptor(ByVal Code As TypeCode) As Type
        Return TypeCodeToType(Code)
    End Function

    Function TypeCodeToType(ByVal Code As TypeCode) As Type
        Select Case Code
            Case TypeCode.Boolean
                Return Compiler.TypeCache.Boolean
            Case TypeCode.Byte
                Return Compiler.TypeCache.Byte
            Case TypeCode.Char
                Return Compiler.TypeCache.Char
            Case TypeCode.DateTime
                Return Compiler.TypeCache.Date
            Case TypeCode.DBNull
                Throw New InternalException("")
            Case TypeCode.Decimal
                Return Compiler.TypeCache.Decimal
            Case TypeCode.Double
                Return Compiler.TypeCache.Double
            Case TypeCode.Empty
                Throw New InternalException("")
            Case TypeCode.Int16
                Return Compiler.TypeCache.Short
            Case TypeCode.Int32
                Return Compiler.TypeCache.Integer
            Case TypeCode.Int64
                Return Compiler.TypeCache.Long
            Case TypeCode.Object
                Return Compiler.TypeCache.Object
            Case TypeCode.SByte
                Return Compiler.TypeCache.SByte
            Case TypeCode.Single
                Return Compiler.TypeCache.Single
            Case TypeCode.String
                Return Compiler.TypeCache.String
            Case TypeCode.UInt16
                Return Compiler.TypeCache.UShort
            Case TypeCode.UInt32
                Return Compiler.TypeCache.UInteger
            Case TypeCode.UInt64
                Return Compiler.TypeCache.ULong
            Case Else
                Throw New InternalException("")
        End Select
    End Function

    Private Shared Function getTypeIndex(ByVal special As BuiltInDataTypes) As Integer
        Select Case special
            Case BuiltInDataTypes.Boolean
                Return 0
            Case BuiltInDataTypes.Byte
                Return 1
            Case BuiltInDataTypes.Char
                Return 2
            Case BuiltInDataTypes.Date
                Return 3
            Case BuiltInDataTypes.Decimal
                Return 4
            Case BuiltInDataTypes.Double
                Return 5
            Case BuiltInDataTypes.Integer
                Return 6
            Case BuiltInDataTypes.Long
                Return 7
            Case BuiltInDataTypes.Object
                Return 8
            Case BuiltInDataTypes.[SByte]
                Return 9
            Case BuiltInDataTypes.Short
                Return 10
            Case BuiltInDataTypes.Single
                Return 11
            Case BuiltInDataTypes.String
                Return 12
            Case BuiltInDataTypes.[UInteger]
                Return 13
            Case BuiltInDataTypes.[ULong]
                Return 14
            Case BuiltInDataTypes.[UShort]
                Return 15
            Case Else
                Throw New InternalException("")
        End Select
    End Function

    Function StringToBuiltInType(ByVal Name As String) As Type
        Select Case Name.ToLower
            Case "boolean"
                Return Compiler.TypeCache.Boolean
            Case "byte"
                Return Compiler.TypeCache.Byte
            Case "char"
                Return Compiler.TypeCache.Char
            Case "date"
                Return Compiler.TypeCache.Date
            Case "decimal"
                Return Compiler.TypeCache.Decimal
            Case "double"
                Return Compiler.TypeCache.Double
            Case "integer"
                Return Compiler.TypeCache.Integer
            Case "long"
                Return Compiler.TypeCache.Long
            Case "object"
                Return Compiler.TypeCache.Object
            Case "short"
                Return Compiler.TypeCache.Short
            Case "string"
                Return Compiler.TypeCache.String
#If WHIDBEY Then
            Case "sbyte"
                Return Compiler.TypeCache.SByte
            Case "ushort"
                Return Compiler.TypeCache.UShort
            Case "uinteger"
                Return Compiler.TypeCache.UInteger
            Case "ulong"
                Return Compiler.TypeCache.ULong
#End If
            Case Else
                Return Nothing
        End Select
    End Function

    Shared Function KeywordToTypeCode(ByVal Keyword As KS) As TypeCode
        Select Case Keyword
            Case KS.Boolean
                Return TypeCode.Boolean
            Case KS.Byte
                Return TypeCode.Byte
            Case KS.Char
                Return TypeCode.Char
            Case KS.Date
                Return TypeCode.DateTime
            Case KS.Decimal
                Return TypeCode.Decimal
            Case KS.Double
                Return TypeCode.Double
            Case KS.Integer
                Return TypeCode.Int32
            Case KS.Long
                Return TypeCode.Int64
            Case KS.Object
                Return TypeCode.Object
            Case KS.Single
                Return TypeCode.Single
            Case KS.Short
                Return TypeCode.Int16
            Case KS.String
                Return TypeCode.String
            Case KS.SByte
                Return TypeCode.SByte
            Case KS.UShort
                Return TypeCode.UInt16
            Case KS.UInteger
                Return TypeCode.UInt32
            Case KS.ULong
                Return TypeCode.UInt64
            Case Else
                Throw New InternalException("")
        End Select
    End Function

    ''' <summary>
    ''' Returns the type of the specified keyword. Throws an internalexception if the keyword isn't a type.
    ''' </summary>
    ''' <param name="Keyword"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Function KeywordToType(ByVal Keyword As KS) As Type
        Select Case Keyword
            Case KS.Boolean
                Return Compiler.TypeCache.Boolean
            Case KS.Byte
                Return Compiler.TypeCache.Byte
            Case KS.Char
                Return Compiler.TypeCache.Char
            Case KS.Date
                Return Compiler.TypeCache.Date
            Case KS.Decimal
                Return Compiler.TypeCache.Decimal
            Case KS.Double
                Return Compiler.TypeCache.Double
            Case KS.Integer
                Return Compiler.TypeCache.Integer
            Case KS.Long
                Return Compiler.TypeCache.Long
            Case KS.Object
                Return Compiler.TypeCache.Object
            Case KS.Single
                Return Compiler.TypeCache.Single
            Case KS.Short
                Return Compiler.TypeCache.Short
            Case KS.String
                Return Compiler.TypeCache.String
            Case KS.[SByte]
                Return Compiler.TypeCache.SByte
            Case KS.[UShort]
                Return Compiler.TypeCache.UShort
            Case KS.[UInteger]
                Return Compiler.TypeCache.UInteger
            Case KS.[ULong]
                Return Compiler.TypeCache.ULong
            Case Else
                'Throw New InternalException("Don't know if this can actually happen, though. KS = " & Keyword.ToString)
                Return Nothing
        End Select
    End Function

    Function TypeToKeyword(ByVal Type As Type) As KS
        If Helper.CompareType(Type, Compiler.TypeCache.Boolean) Then
            Return KS.Boolean
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Byte) Then
            Return KS.Byte
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Char) Then
            Return KS.Char
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Date) Then
            Return KS.Date
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Decimal) Then
            Return KS.Decimal
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Double) Then
            Return KS.Double
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Integer) Then
            Return KS.Integer
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Long) Then
            Return KS.Long
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Object) Then
            Return KS.Object
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Short) Then
            Return KS.Short
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.Single) Then
            Return KS.Single
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.String) Then
            Return KS.String
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.SByte) Then
            Return KS.[SByte]
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.UShort) Then
            Return KS.[UShort]
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.UInteger) Then
            Return KS.[UInteger]
        ElseIf Helper.CompareType(Type, Compiler.TypeCache.ULong) Then
            Return KS.[ULong]
        Else
            Return KS.None
        End If
    End Function

    Function IsImplicitlyConvertible(ByVal Compiler As Compiler, ByVal FromType As TypeDescriptor, ByVal ToType As TypeDescriptor) As Boolean
        Return IsImplicitlyConvertible(Compiler, FromType.TypeInReflection, ToType.TypeInReflection)
    End Function

    Function IsImplicitlyConvertible(ByVal Compiler As Compiler, ByVal FromType As Type, ByVal ToType As Type) As Boolean
        Dim tpFrom, tpTo As TypeCode
        If Helper.CompareType(Compiler.TypeCache.Nothing, FromType) Then Return True
        If FromType.IsByRef Then FromType = FromType.GetElementType
        If ToType.IsByRef Then ToType = ToType.GetElementType
        tpFrom = Helper.GetTypeCode(FromType)
        tpTo = Helper.GetTypeCode(ToType)
        If tpTo = TypeCode.Object Then
            Return Helper.IsAssignable(Compiler, FromType, ToType) ' ToType.IsAssignableFrom(FromType)
        ElseIf Helper.IsEnum(ToType) AndAlso Helper.IsEnum(FromType) = False Then
            Return False
        ElseIf Helper.IsEnum(ToType) AndAlso Helper.IsEnum(FromType) Then
            Return Helper.CompareType(ToType, FromType)
        Else
            Dim result As Boolean
            result = Conversion(tpFrom, tpTo).Conversion = ConversionType.Implicit
            'Helper.Assert(result = ToType.IsAssignableFrom(FromType) )
            Return result
        End If
    End Function

    Function IsNumericType(ByVal Type As Type) As Boolean
        For Each t As Type In NumericTypes
            If Helper.CompareType(t, Type) Then Return True
        Next
    End Function

    Function IsIntegralType(ByVal Type As Type) As Boolean
        For Each t As Type In IntegralTypes
            If Helper.CompareType(t, Type) Then Return True
        Next
        Return False
    End Function

    Function IsIntegralType(ByVal Type As TypeCode) As Boolean
        For Each t As Type In IntegralTypes
            If Helper.GetTypeCode(t) = Type Then Return True
        Next
        Return False
    End Function

    Function IsIntegralType(ByVal Type As BuiltInDataTypes) As Boolean
        Return IsIntegralType(BuiltInTypeToTypeCode(Type))
    End Function

    Function IsSignedIntegralType(ByVal Type As Type) As Boolean
        Return Helper.CompareType(Type, Compiler.TypeCache.SByte) OrElse _
         Helper.CompareType(Type, Compiler.TypeCache.Short) OrElse _
         Helper.CompareType(Type, Compiler.TypeCache.Integer) OrElse _
         Helper.CompareType(Type, Compiler.TypeCache.Long)
    End Function

    Function IsUnsignedIntegralType(ByVal Type As Type) As Boolean
        Return Helper.CompareType(Type, Compiler.TypeCache.Byte) OrElse _
         Helper.CompareType(Type, Compiler.TypeCache.UShort) OrElse _
         Helper.CompareType(Type, Compiler.TypeCache.UInteger) OrElse _
         Helper.CompareType(Type, Compiler.TypeCache.ULong)
    End Function

    ''' <summary>
    ''' If the type is an enum type returns the base (integral type),
    ''' otherwise returns the same type.
    ''' </summary>
    ''' <param name="tp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetIntegralType(ByVal tp As Type) As Type
        If tp.IsEnum Then
            Return tp.GetField(EnumDeclaration.EnumTypeMemberName).FieldType
        Else
            Helper.Assert(IsIntegralType(tp))
            Return tp
        End If
    End Function

    ''' <summary>
    ''' Finds the smallest type that can hold both specified types.
    ''' If tp1 = Integer and tp2 = Long would return Long
    ''' </summary>
    ''' <param name="tp1"></param>
    ''' <param name="tp2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSmallestIntegralType(ByVal tp1 As Type, ByVal tp2 As Type) As Type
        Dim cont1(), cont2() As Type

        Dim itp1, itp2 As Type
        itp1 = GetIntegralType(tp1)
        itp2 = GetIntegralType(tp2)
        cont1 = valCanBeContainBy(getTypeIndex(CType(TypeToKeyword(itp1), BuiltInDataTypes)))
        cont2 = valCanBeContainBy(getTypeIndex(CType(TypeToKeyword(itp2), BuiltInDataTypes)))

        If cont1 Is Nothing Or cont2 Is Nothing Then Return Nothing

        Dim found As New ArrayList
        For Each t1 As Type In cont1
            For Each t2 As Type In cont2
                If Helper.CompareType(t1, t2) Then
                    found.Add(t1)
                End If
            Next
        Next

        If found.Count = 0 Then
            Return Nothing
        Else
            Return CType(found(0), Type)
        End If
    End Function


    Private Shared Sub setImplicit(ByVal type As TypeCode, ByVal implicit() As TypeCode)
        For i As Integer = 0 To VB.UBound(implicit)
            Conversion(type, implicit(i)).Conversion = ConversionType.Implicit
        Next
    End Sub

    ''' <summary>
    ''' Tries to convert the value into the desired type. Returns true if successful, 
    ''' returns false otherwise. 
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="result"></param>
    ''' <param name="desiredType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckNumericRange(ByVal value As Object, ByRef result As Object, ByVal desiredType As Type) As Boolean
        Dim builtInType As BuiltInDataTypes = TypeResolution.TypeCodeToBuiltInType(Helper.GetTypeCode(desiredType))

        If value Is Nothing Then 'Nothing can be converted into anything.
            result = Nothing
            Return True
        End If

        If IsIntegralType(builtInType) AndAlso IsIntegralType(Helper.GetTypeCode(value.GetType)) Then
            Return CheckIntegralRange(value, result, builtInType)
        Else
            Dim tpValue As TypeCode = Helper.GetTypeCode(value.GetType)
            Dim desiredCode As TypeCode = Helper.GetTypeCode(desiredType)

            If Helper.CompareType(value.GetType, desiredType) Then
                result = value
                Return True
            End If

            Select Case desiredCode
                Case TypeCode.Double
                    Select Case tpValue
                        Case TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Single, TypeCode.Double, TypeCode.Decimal
                            result = CDbl(value)
                            Return True
                    End Select
                Case TypeCode.Decimal
                    Select Case tpValue
                        Case TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Decimal
                            result = CDec(value)
                            Return True
                    End Select
                Case TypeCode.Single
                    Select Case tpValue
                        Case TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Single, TypeCode.Decimal
                            result = CSng(value)
                            Return True
                        Case TypeCode.Double
                            If CDbl(value) >= Single.MinValue AndAlso CDbl(value) <= Single.MaxValue Then
                                result = CSng(value)
                                Return True
                            Else
                                Return False
                            End If
                    End Select
                Case TypeCode.Int32
                    Select Case tpValue
                        Case TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.Boolean
                            result = CInt(value)
                            Return True
                    End Select
            End Select
            Helper.Stop()
            Select Case tpValue
                Case TypeCode.Byte, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64
                    Dim tmpValue As ULong = CULng(value)
                    Helper.Stop()
                Case TypeCode.SByte, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64
                    Dim tmpValue As Long = CLng(value)
                    'Dim t As Type
                    Helper.Stop()
                Case TypeCode.Char
                    Helper.Stop()
                Case TypeCode.Boolean
                    Helper.Stop()
                Case TypeCode.DateTime
                    Helper.Stop()
                Case TypeCode.Decimal
                    Helper.Stop()
                Case TypeCode.Double
                    Helper.Stop()
                Case TypeCode.Single
                    Helper.Stop()
                Case TypeCode.String
                    Helper.Stop()
                Case Else
                    Helper.Stop()
            End Select
            Helper.Stop()
        End If
    End Function

    ''' <summary>
    ''' Tries to convert the value into the desired type. Returns true if successful, 
    ''' returns false otherwise. Can only convert if value is already an integral type 
    ''' (does only do range-checking, not type conversion)
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="result"></param>
    ''' <param name="desiredType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckIntegralRange(ByVal value As Object, ByRef result As Object, ByVal desiredType As BuiltInDataTypes) As Boolean
        Helper.Assert(value IsNot Nothing)
        Helper.Assert(IsIntegralType(desiredType))
        Dim tpValue As TypeCode = Helper.GetTypeCode(value.GetType)
        Helper.Assert(IsIntegralType(tpValue))
        Select Case tpValue
            Case TypeCode.Byte, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64
                Dim tmpValue As ULong = CULng(value)
                Select Case desiredType
                    Case BuiltInDataTypes.Byte
                        If tmpValue <= Byte.MaxValue Then
                            result = CByte(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.UShort
                        If tmpValue <= UShort.MaxValue Then
                            result = CUShort(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.UInteger
                        If tmpValue <= UInteger.MaxValue Then
                            result = CUInt(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.ULong
                        result = tmpValue
                        Return True
                    Case BuiltInDataTypes.SByte
                        If tmpValue <= SByte.MaxValue Then
                            result = CSByte(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.Short
                        If tmpValue <= Short.MaxValue Then
                            result = CShort(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.Integer
                        If tmpValue <= Integer.MaxValue Then
                            result = CInt(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.Long
                        If tmpValue <= Long.MaxValue Then
                            result = CLng(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case Else
                        Throw New InternalException("")
                End Select
            Case TypeCode.SByte, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64
                Dim tmpValue As Long = CLng(value)
                Select Case desiredType
                    Case BuiltInDataTypes.Byte
                        If tmpValue >= Byte.MinValue AndAlso tmpValue <= Byte.MaxValue Then
                            result = CByte(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.UShort
                        If tmpValue >= UShort.MinValue AndAlso tmpValue <= UShort.MaxValue Then
                            result = CUShort(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.UInteger
                        If tmpValue >= UInteger.MinValue AndAlso tmpValue <= UInteger.MaxValue Then
                            result = CUInt(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.ULong
                        If tmpValue >= ULong.MinValue AndAlso tmpValue <= ULong.MaxValue Then
                            result = CULng(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.SByte
                        If tmpValue >= SByte.MinValue AndAlso tmpValue <= SByte.MaxValue Then
                            result = CSByte(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.Short
                        If tmpValue >= Short.MinValue AndAlso tmpValue <= Short.MaxValue Then
                            result = CShort(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.Integer
                        If tmpValue >= Integer.MinValue AndAlso tmpValue <= Integer.MaxValue Then
                            result = CInt(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case BuiltInDataTypes.Long
                        If tmpValue >= Long.MinValue AndAlso tmpValue <= Long.MaxValue Then
                            result = CLng(tmpValue)
                            Return True
                        Else
                            Return False
                        End If
                    Case Else
                        Throw New InternalException("")
                End Select
            Case Else
                Throw New InternalException("")
        End Select
    End Function

    Function TypeResolver(ByVal sender As Object, ByVal args As ResolveEventArgs) As System.Reflection.Assembly
        'Compiler.Report.WriteLine(vbnc.Report.ReportLevels.Debug, "Resolve event fired for type '" & args.Name & "'")
#If EXTENDEDDEBUG Then
        Compiler.Report.WriteLine("Looking for type: " & args.Name)
#End If
        Dim types As Generic.List(Of Type)
        types = Me.Compiler.TypeManager.GetType(args.Name, True)

        If types.Count = 0 Then
            Throw New InternalException("Type '" & args.Name & "' was been referenced while compiling, but it wasn't found...")
        ElseIf types.Count = 1 Then
            If TypeOf types(0) Is TypeDescriptor Then
                Dim result As Boolean = True
                result = DirectCast(types(0), TypeDescriptor).Declaration.CreateType() AndAlso result
                If result = False Then
                    Helper.NotImplemented()
                End If
            Else
                Throw New InternalException("Found type " & args.Name & ", but it isn't a TypeDescriptor!")
            End If
        Else
            Helper.AddError("Compiler cannot decide between several types with the name " & args.Name)
        End If

        Return Compiler.AssemblyBuilder
    End Function

    ''' <summary>
    ''' Looks up the specified type in the current compiling assembly.
    ''' This function looks up the name in the code / referenced assemblies
    ''' and returns an arraylist of found objects.
    ''' Can be anything:
    ''' If found in the parsing code, any Type* Object
    ''' If not found in the parsing code, but found in referenced assemblies, could be any of the following Reflection classes:
    '''   MemberInfo
    '''   Module
    ''' If a namespace was found, a string variable is returned with the name of the namespace.
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LookupType(ByVal Name As String) As ArrayList
        Dim result As New ArrayList

        result.Add(Compiler.AssemblyBuilder.GetType(Name))

        Return result
    End Function

    ''' <summary>
    ''' This function returns a list of Type objects
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="FromWhere"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LookupType(ByVal Name As TypeName, ByVal FromWhere As INameable, ByVal IsAttribute As Boolean) As ArrayList
        Helper.Assert(Name.Name <> "")
        Helper.Assert(Compiler.HasPassedSequencePoint(vbnc.Compiler.CompilerSequence.DefinedTypes))
        Dim strNames() As String = VB.Split(Name.Name, ".")
        LookupType = New ArrayList
        If strNames.GetLength(0) <= 0 Then
            Throw New InternalException("")
            Exit Function
        End If

        Dim foundFirst As New ArrayList

        Helper.NotImplemented() : Return Nothing
        ''First do a search upwards in the type tree of the code we are compiling
        'If TypeOf FromWhere Is AssemblyType Then
        '    'Compiler.Report.WriteLine(vbnc.Report.ReportLevels.Debug, "A bug!") 'Really?
        '    'Throw New InternalException 'Will happen when resolving assembly attributes, their parent is AssemblyType
        'End If

        'Dim found As ArrayList
        'Dim lookin As NamedObject = FromWhere
        'Dim strFindFirst As String = strNames(0)

        'found = lookin.FindInMe(strFindFirst, IsAttribute)
        'Do Until found.Count > 0 OrElse TypeOf lookin Is AssemblyType
        '    lookin = lookin.FindFirstNamedParent
        '    If TypeOf lookin Is AssemblyType Then
        '        'Reached the end of the type tree of the code. Exit loop
        '        Exit Do
        '    Else
        '        found = lookin.FindInMe(strFindFirst, IsAttribute)
        '        For i As Integer = found.Count - 1 To 0 Step -1
        '            If Not TypeOf found(i) Is BaseType Then
        '                'Remove elements which are not types.
        '                found.RemoveAt(i)
        '            End If
        '        Next
        '    End If
        'Loop

        'If found.Count > 0 Then
        '    Dim strFindNext As String
        '    Dim foundPrev As ArrayList = found
        '    If strNames.GetUpperBound(0) = 0 Then
        '        For Each obj As Object In found
        '            Dim o As BaseType = TryCast(obj, BaseType)
        '            Helper.Assert(o IsNot Nothing)
        '            Helper.Assert(o.TypeBuilder IsNot Nothing)
        '            foundFirst.Add(o.TypeBuilder)
        '        Next
        '    Else
        '        For i As Integer = 1 To strNames.GetUpperBound(0)
        '            strFindNext = strNames(i)
        '            For Each o As NamedObject In foundPrev
        '                found = o.FindInMe(strFindNext, IsAttribute)
        '                If found.Count = 0 Then
        '                    Helper.Stop() '?? Compiler.Report.Warning("Cannot find the nested type '" & strFindNext & "' in the type " & o.Name, MessageLevel.Warning)
        '                    Return LookupType
        '                End If
        '                For Each t As BaseType In found
        '                    Helper.Assert(t.TypeBuilder IsNot Nothing)
        '                    foundFirst.Add(t.TypeBuilder)
        '                Next
        '            Next
        '        Next
        '    End If
        'End If
        'LookupType.AddRange(foundFirst)

        'If LookupType.Count = 0 Then
        '    'Look in the referenced assemblies
        '    For Each asseml As Reflection.Assembly In Compiler.ReferencedAssemblies
        '        Dim fnd As Type = FindTypeInAssembly(asseml, Name.Name, IsAttribute)
        '        'Found a type!
        '        If Not fnd Is Nothing Then foundFirst.Add(fnd)
        '        Helper.Assert(Name IsNot Nothing)
        '        Helper.Assert(Name.Location IsNot Nothing)
        '        Helper.Assert(Name.Location.File IsNot Nothing)
        '        Helper.Assert(Name.Location.File.Imports IsNot Nothing)
        '        For Each timpo As Import In Name.Location.File.Imports
        '            If timpo.Alias = "" Then
        '                fnd = FindTypeInAssembly(asseml, timpo.Name & "." & Name.Name, IsAttribute)
        '                If Not fnd Is Nothing Then foundFirst.Add(fnd)
        '            End If
        '        Next
        '        If fnd Is Nothing Then
        '            For Each timpo As String In Compiler.CommandLine.Imports
        '                fnd = FindTypeInAssembly(asseml, timpo & "." & Name.Name, IsAttribute)
        '                If Not fnd Is Nothing Then foundFirst.Add(fnd)
        '            Next
        '        End If
        '        For Each tp As Type In foundFirst
        '            If Not LookupType.Contains(tp) Then
        '                LookupType.Add(tp)
        '            End If
        '        Next
        '    Next

        '    'TODO: Look in Aliased Imports
        '    For Each timpo As Import In Name.Location.File.Imports
        '        If VB.StrComp(timpo.Alias, strFindFirst) = 0 Then
        '            Dim strImportFind As String = timpo.Name & "." & Name.Name
        '            'Look again for this one...
        '        End If
        '    Next

        'End If

        Return LookupType
    End Function

    Private Shared Function FindTypeInAssembly(ByVal asseml As Reflection.Assembly, ByVal Name As String, ByVal IsAttribute As Boolean) As Type
        Dim result As Type = asseml.GetType(Name, False, True)

        If result Is Nothing AndAlso IsAttribute Then
            result = asseml.GetType(Name & "Attribute", False, True)
        End If

        Return result
    End Function
End Class

Public Enum ConversionType
    Implicit
    Explicit
    None
End Enum

Public Class TypeConversionInfo
    Public Conversion As ConversionType
    Public hasPrecisionLoss As Boolean
    Public BinaryAddResult As TypeCode
End Class
