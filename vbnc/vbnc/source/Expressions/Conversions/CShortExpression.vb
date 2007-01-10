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

Public Class CShortExpression
    Inherits ConversionExpression

    Sub New(ByVal Parent As ParsedObject, ByVal Expression As Expression)
        MyBase.New(Parent, Expression)
    End Sub

    Sub New(ByVal Parent As ParsedObject)
        MyBase.New(Parent)
    End Sub

    Protected Overrides Function GenerateCodeInternal(ByVal Info As EmitInfo) As Boolean
        Return GenerateCode(Me.Expression, Info)
    End Function

    Overloads Shared Function GenerateCode(ByVal Expression As Expression, ByVal Info As EmitInfo) As Boolean
        Dim result As Boolean = True

        Dim expType As Type = Expression.ExpressionType
        Dim expTypeCode As TypeCode = Helper.GetTypeCode(expType)

        result = Expression.Classification.GenerateCode(Info.Clone(expType)) AndAlso result

        Select Case expTypeCode
            Case TypeCode.Boolean
                Emitter.EmitLoadI4Value(Info, 0I, expType)
                Emitter.EmitGT_Un(Info, expType)
                Emitter.EmitNeg(Info)
                Emitter.EmitConv_I2(Info, expType)
            Case TypeCode.Int16
                'Nothing to do
            Case TypeCode.Char
                Info.Compiler.Report.ShowMessage(Messages.VBNC32006, exptype.Name)
                result = False
            Case TypeCode.DateTime
                info.Compiler.Report.ShowMessage(Messages.VBNC30311, expType.Name, expType.Name)
                result = False
            Case TypeCode.SByte, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64
                Emitter.EmitConv_I2_Overflow(Info, expType)
            Case TypeCode.Byte, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64
                Emitter.EmitConv_I2_Overflow_Underflow(Info, expType)
            Case TypeCode.Double
                Emitter.EmitCall(Info, Info.Compiler.TypeCache.System_Math_Round__Double)
                Emitter.EmitConv_I2_Overflow(Info, expType)
            Case TypeCode.Single
                Emitter.EmitConv_R8(Info, expType)
                Emitter.EmitCall(Info, Info.Compiler.TypeCache.System_Math_Round__Double)
                Emitter.EmitConv_I2_Overflow(Info, Info.Compiler.TypeCache.Double)
            Case TypeCode.Object
                If Helper.CompareType(expType, Info.Compiler.TypeCache.Object) Then
                    Emitter.EmitCall(Info, Info.Compiler.TypeCache.MS_VB_CS_Conversions_ToShort__Object)
                Else
                    Helper.NotImplemented()
                End If
            Case TypeCode.String
                Emitter.EmitCall(Info, Info.Compiler.TypeCache.MS_VB_CS_Conversions_ToShort__String)
            Case TypeCode.Decimal
                Emitter.EmitCall(Info, Info.Compiler.TypeCache.System_Convert_ToInt16__Decimal)
            Case Else
                Helper.NotImplemented()
        End Select

        Return result
    End Function

    Public Overrides ReadOnly Property ConstantValue() As Object
        Get
            Dim tpCode As TypeCode
            Dim originalValue As Object
            originalValue = Expression.ConstantValue
            tpCode = Helper.GetTypeCode(originalValue.GetType)
            Select Case tpCode
                Case TypeCode.Boolean, TypeCode.SByte, TypeCode.Byte, TypeCode.Int16
                    Return CShort(originalValue) 'No range checking needed.
                Case TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.UInt64, TypeCode.Int64, TypeCode.Single, TypeCode.Double, TypeCode.Decimal
                    Dim resultvalue As Object = 0
                    If Compiler.TypeResolution.CheckNumericRange(originalValue, resultvalue, ExpressionType) Then
                        Return resultvalue
                    Else
                        Compiler.Report.ShowMessage(Messages.VBNC30439, ExpressionType.ToString)
                        Return New Short
                    End If
                Case Else
                    Compiler.Report.ShowMessage(Messages.VBNC30060, originalValue.ToString, ExpressionType.ToString)
                    Return New Short
            End Select
        End Get
    End Property

    Overrides ReadOnly Property ExpressionType() As Type
        Get
            Return Compiler.TypeCache.Short '_Descriptor
        End Get
    End Property
End Class
