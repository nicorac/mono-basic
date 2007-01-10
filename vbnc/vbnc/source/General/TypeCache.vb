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

Public Class TypeCache
    Private m_Compiler As Compiler

    Public [Nothing] As System.Type
    Public [Boolean] As System.Type
    Public [Byte] As System.Type
    Public [Char] As System.Type
    Public [Date] As System.Type
    Public [Decimal] As System.Type
    Public [Double] As System.Type
    Public [Integer] As System.Type
    Public [Long] As System.Type
    Public [Object] As System.Type
    Public [Short] As System.Type
    Public [Single] As System.Type
    Public [String] As System.Type
    Public [String_ByRef] As System.Type
    Public [SByte] As System.Type
    Public [UShort] As System.Type
    Public [UInteger] As System.Type
    Public [ULong] As System.Type
    Public [Integer_Array] As System.Type
    Public [String_Array] As System.Type
    Public [Enum] As System.Type
    Public [Structure] As System.Type
    Public [Delegate] As System.Type
    Public [MulticastDelegate] As System.Type
    Public [AsyncCallback] As System.Type
    Public [IAsyncResult] As System.Type
    Public [IEnumerator] As System.Type
    Public [IEnumerator_get_Current] As System.Reflection.MethodInfo
    Public [IEnumerator_MoveNext] As System.Reflection.MethodInfo
    Public [IEnumerable] As System.Type
    Public [IEnumerable_GetEnumerator] As System.Reflection.MethodInfo
    Public [IDisposable] As System.Type
    Public [IDisposable_Dispose] As System.Reflection.MethodInfo
    Public [ValueType] As System.Type
    Public [System_RuntimeTypeHandle] As System.Type
    Public [Type] As System.Type
    Public [Type__GetTypeFromHandle_RuntimeTypeHandle] As System.Reflection.MethodInfo
    Public [Void] As System.Type
    Public [Exception] As System.Type
    Public [Array] As System.Type
    Public [Array_SetValue] As System.Reflection.MethodInfo
    Public [Array_GetValue] As System.Reflection.MethodInfo
    Public [Array_CreateInstance] As System.Reflection.MethodInfo
    Public [System_Collections_Generic_IList1] As System.Type
    Public [System_Collections_Generic_ICollection1] As System.Type
    Public [System_Collections_Generic_IEnumerable1] As System.Type
    Public [System_Reflection_AssemblyVersionAttribute] As System.Type
    Public [System_Reflection_AssemblyProductAttribute] As System.Type
    Public [System_Reflection_AssemblyCompanyAttribute] As System.Type
    Public [System_Reflection_AssemblyCopyrightAttribute] As System.Type
    Public [System_Reflection_AssemblyTrademarkAttribute] As System.Type
    Public [System_Diagnostics_DebuggableAttribute] As System.Type
    Public [System_Diagnostics_DebuggableAttribute_DebuggingModes] As System.Type
    Public [System_Diagnostics_DebuggableAttribute__ctor_DebuggingModes] As System.Reflection.ConstructorInfo
    Public [System_ParamArrayAttribute] As System.Type
    Public [System_ParamArrayAttribute__ctor] As System.Reflection.ConstructorInfo
    Public [System_Nullable] As System.Type
    Public [RuntimeHelpers] As System.Type
    Public [STAThreadAttribute] As System.Type
    Public [STAThreadAttribute_Ctor] As System.Reflection.ConstructorInfo
    Public [IntPtr] As System.Type
    Public [DateTimeConstantAttribute] As System.Type
    Public [DateConstructor_Int64] As System.Reflection.ConstructorInfo
    Public [DecimalConstructor_Int32] As System.Reflection.ConstructorInfo
    Public [DecimalConstructor_Int64] As System.Reflection.ConstructorInfo
    Public [DecimalConstructor_Double] As System.Reflection.ConstructorInfo
    Public [DecimalConstructor_Single] As System.Reflection.ConstructorInfo
    Public [DecimalConstructor_UInt64] As System.Reflection.ConstructorInfo
    Public [DecimalConstructor_Int32_Int32_Int32_Boolean_Byte] As System.Reflection.ConstructorInfo
    Public [Decimal_Zero] As System.Reflection.FieldInfo
    Public [Decimal_One] As System.Reflection.FieldInfo
    Public [Decimal_MinusOne] As System.Reflection.FieldInfo
    Public [DecimalConstantAttribute] As System.Type
    Public [DecimalConstantAttributeConstructor_Byte_Byte_UInt32_UInt32_UInt32] As System.Reflection.ConstructorInfo
    Public [DecimalConstantAttributeConstructor_Byte_Byte_Int32_Int32_Int32] As System.Reflection.ConstructorInfo
    Public [Decimal_Compare__Decimal_Decimal] As System.Reflection.MethodInfo
    Public [Date_Compare__Date_Date] As System.Reflection.MethodInfo
    Public [Decimal_Add__Decimal_Decimal] As System.Reflection.MethodInfo
    Public [Decimal_Subtract__Decimal_Decimal] As System.Reflection.MethodInfo
    Public [Decimal_Divide__Decimal_Decimal] As System.Reflection.MethodInfo
    Public [Decimal_Multiply__Decimal_Decimal] As System.Reflection.MethodInfo
    Public [Decimal_Remainder__Decimal_Decimal] As System.Reflection.MethodInfo
    Public [Decimal_Negate__Decimal] As System.Reflection.MethodInfo
    Public [ParamArrayAttribute] As System.Type
    Public [ParamArrayAttributeConstructor] As System.Reflection.ConstructorInfo
    Public [DefaultMemberAttribute] As System.Type
    Public [DefaultMemberAttributeConstructor] As System.Reflection.ConstructorInfo
    Public System_Convert As Type
    Public [System_Convert_ToSingle__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToDouble__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToBoolean__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToByte__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToSByte__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToInt16__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToUInt16__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToInt32__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToUInt32__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToInt64__Decimal] As System.Reflection.MethodInfo
    Public [System_Convert_ToUInt64__Decimal] As System.Reflection.MethodInfo
    Public [String_Concat__String_String] As System.Reflection.MethodInfo
    Public [System_Diagnostics_Debugger_Break] As System.Reflection.MethodInfo
    Public [System_Reflection_Missing_Value] As System.Reflection.FieldInfo
    Public [System_Threading_Monitor] As System.Type
    Public [System_Threading_Monitor_Enter__Object] As System.Reflection.MethodInfo
    Public [System_Threading_Monitor_Exit__Object] As System.Reflection.MethodInfo
    Public [System_Runtime_CompilerServices_RuntimeHelpers__GetObjectValue_Object] As System.Reflection.MethodInfo
    Public [System_Math] As System.Type
    Public [System_Math_Round__Double] As System.Reflection.MethodInfo
    Public [System_Math_Pow__Double_Double] As System.Reflection.MethodInfo
    Public [System_Runtime_InteropServices_DllImportAttribute] As System.Type
    Public [StandardModuleAttribute] As System.Type
    Public [MS_VB_CompareMethod] As System.Type
    Public [MS_VB_CS_Conversions] As System.Type
    Public [MS_VB_CS_ProjectData] As System.Type
    Public [MS_VB_CS_LikeOperator] As System.Type
    Public [MS_VB_Strings] As System.Type
    Public [MS_VB_CS_StringType] As System.Type
    Public [MS_VB_CS_StandardModuleAttribute] As System.Type
    Public [MS_VB_CS_Operators] As System.Type
    Public [MS_VB_CS_OFC] As System.Type
    Public [MS_VB_CS_Utils] As System.Type
    Public [MS_VB_CS_OptionCompareAttribute] As System.Type
    Public [MS_VB_CS_OptionTextAttribute] As System.Type
    Public [MS_VB_CS_StaticLocalInitFlag] As System.Type
    Public [MS_VB_CS_StaticLocalInitFlag_State] As System.Reflection.FieldInfo
    Public [MS_VB_CS_StaticLocalInitFlag_Ctor] As System.Reflection.ConstructorInfo
    Public [MS_VB_CS_IncompleteInitializationException] As System.Type
    Public [MS_VB_CS_IncompleteInitializationException__ctor] As System.Reflection.ConstructorInfo
    Public [MS_VB_CS_PD_EndApp] As System.Reflection.MethodInfo
    Public [MS_VB_CS_PD_CreateProjectError__Integer] As System.Reflection.MethodInfo
    Public [MS_VB_CS_PD_ClearProjectError] As System.Reflection.MethodInfo
    Public [MS_VB_CS_PD_SetProjectError__Exception] As System.Reflection.MethodInfo
    Public [MS_VB_CS_PD_SetProjectError__Exception_Integer] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToBoolean__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToChar__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToDate__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToByte__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToSByte__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToShort__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToUShort__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToInteger__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToUInteger__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToLong__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToULong__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToSingle__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToDouble__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToDecimal__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToBoolean__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToChar__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToDate__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToByte__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToSByte__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToShort__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToUShort__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToInteger__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToUInteger__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToLong__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToULong__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToSingle__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToDouble__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToDecimal__String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToDecimal__Boolean] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Decimal] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Boolean] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Char] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Date] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Byte] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__SByte] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Integer] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__UInteger] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Long] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__ULong] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Single] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Double] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToString__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Conversions_ToGenericParameter_T__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_LikeOperator_LikeString__String_String_CompareMethod] As System.Reflection.MethodInfo
    Public [MS_VB_CS_LikeOperator_LikeObject__Object_Object_CompareMethod] As System.Reflection.MethodInfo
    Public [MS_VB_CS_StringType_MidStmtStr__String_Integer_Integer_String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_OFC_CheckForSyncLockOnValueType__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Utils__CopyArray_Array_Array] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ConditionalCompareObjectEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ConditionalCompareObjectNotEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ConditionalCompareObjectGreater__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ConditionalCompareObjectGreaterEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ConditionalCompareObjectLess__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ConditionalCompareObjectLessEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_CompareString__String_String_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ConcatenateObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_AddObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_AndObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_DivideObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ExponentObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_IntDivideObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_LeftShiftObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_ModObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_MultiplyObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_NegateObject__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_NotObject__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_OrObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_PlusObject__Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_RightShiftObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_SubtractObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_XorObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_LikeObject__Object_Object] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_LikeString__String_String] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_CompareObjectEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_CompareObjectNotEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_CompareObjectGreater__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_CompareObjectGreaterEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_CompareObjectLess__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [MS_VB_CS_Operators_CompareObjectLessEqual__Object_Object_Bool] As System.Reflection.MethodInfo
    Public [Delegate_Combine] As System.Reflection.MethodInfo
    Public [Delegate_Remove] As System.Reflection.MethodInfo
    Public [MS_VB_Assembly] As System.Reflection.Assembly
    Public [mscorlib] As System.Reflection.Assembly

    Sub New(ByVal Compiler As Compiler)
        m_Compiler = Compiler
    End Sub

    ReadOnly Property Compiler() As Compiler
        Get
            Return m_Compiler
        End Get
    End Property

    Private Sub Init_corlib()
        Compiler.TypeCache.Boolean = mscorlib.GetType("System.Boolean")
        Compiler.TypeCache.Byte = mscorlib.GetType("System.Byte")
        Compiler.TypeCache.Char = mscorlib.GetType("System.Char")
        Compiler.TypeCache.Date = mscorlib.GetType("System.DateTime")
        Compiler.TypeCache.Decimal = mscorlib.GetType("System.Decimal")
        Compiler.TypeCache.Double = mscorlib.GetType("System.Double")
        Compiler.TypeCache.Integer = mscorlib.GetType("System.Int32")
        Compiler.TypeCache.Long = mscorlib.GetType("System.Int64")
        Compiler.TypeCache.Object = mscorlib.GetType("System.Object")
        Compiler.TypeCache.Short = mscorlib.GetType("System.Int16")
        Compiler.TypeCache.Single = mscorlib.GetType("System.Single")
        Compiler.TypeCache.String = mscorlib.GetType("System.String")
        Compiler.TypeCache.String_ByRef = [String].MakeByRefType
        Compiler.TypeCache.SByte = mscorlib.GetType("System.SByte")
        Compiler.TypeCache.UShort = mscorlib.GetType("System.UInt16")
        Compiler.TypeCache.UInteger = mscorlib.GetType("System.UInt32")
        Compiler.TypeCache.ULong = mscorlib.GetType("System.UInt64")
        Compiler.TypeCache.Integer_Array = [Integer].MakeArrayType
        Compiler.TypeCache.String_Array = [String].MakeArrayType
        Compiler.TypeCache.Enum = mscorlib.GetType("System.Enum")
        Compiler.TypeCache.Structure = mscorlib.GetType("System.ValueType")
        Compiler.TypeCache.Delegate = mscorlib.GetType("System.Delegate")
        Compiler.TypeCache.MulticastDelegate = mscorlib.GetType("System.MulticastDelegate")
        Compiler.TypeCache.AsyncCallback = mscorlib.GetType("System.AsyncCallback")
        Compiler.TypeCache.IAsyncResult = mscorlib.GetType("System.IAsyncResult")
        Compiler.TypeCache.IEnumerator = mscorlib.GetType("System.Collections.IEnumerator")
        Compiler.TypeCache.IEnumerator_get_Current = IEnumerator.GetProperty("Current").GetGetMethod(False)
        Compiler.TypeCache.IEnumerator_MoveNext = IEnumerator.GetMethod("MoveNext")
        Compiler.TypeCache.IEnumerable = mscorlib.GetType("System.Collections.IEnumerable")
        Compiler.TypeCache.IEnumerable_GetEnumerator = IEnumerable.GetMethod("GetEnumerator")
        Compiler.TypeCache.IDisposable = mscorlib.GetType("System.IDisposable")
        Compiler.TypeCache.IDisposable_Dispose = IDisposable.GetMethod("Dispose")
        Compiler.TypeCache.ValueType = mscorlib.GetType("System.ValueType")
        Compiler.TypeCache.System_RuntimeTypeHandle = mscorlib.GetType("System.RuntimeTypeHandle")
        Compiler.TypeCache.Type = mscorlib.GetType("System.Type")
        Compiler.TypeCache.Type__GetTypeFromHandle_RuntimeTypeHandle = Type.GetMethod("GetTypeFromHandle", New Type() {System_RuntimeTypeHandle})
        Compiler.TypeCache.Void = mscorlib.GetType("System.Void")
        Compiler.TypeCache.Exception = mscorlib.GetType("System.Exception")
        Compiler.TypeCache.Array = mscorlib.GetType("System.Array")
        Compiler.TypeCache.Array_SetValue = Array.GetMethod("SetValue", BindingFlags.ExactBinding Or BindingFlags.Instance Or BindingFlags.Public, Nothing, Nothing, New Type() {Compiler.TypeCache.Object, Compiler.TypeCache.Integer_Array}, Nothing)
        Compiler.TypeCache.Array_GetValue = Array.GetMethod("GetValue", BindingFlags.ExactBinding Or BindingFlags.Instance Or BindingFlags.Public, Nothing, Nothing, New Type() {Compiler.TypeCache.Integer_Array}, Nothing)
        Compiler.TypeCache.Array_CreateInstance = Array.GetMethod("CreateInstance", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.Static, Nothing, Nothing, New Type() {Compiler.TypeCache.Type, Compiler.TypeCache.Integer_Array}, Nothing)
        Compiler.TypeCache.System_Collections_Generic_IList1 = mscorlib.GetType("System.Collections.Generic.IList`1")
        Compiler.TypeCache.System_Collections_Generic_ICollection1 = mscorlib.GetType("System.Collections.Generic.ICollection`1")
        Compiler.TypeCache.System_Collections_Generic_IEnumerable1 = mscorlib.GetType("System.Collections.Generic.IEnumerable`1")
        Compiler.TypeCache.System_Reflection_AssemblyVersionAttribute = mscorlib.GetType("System.Reflection.AssemblyVersionAttribute")
        Compiler.TypeCache.System_Reflection_AssemblyProductAttribute = mscorlib.GetType("System.Reflection.AssemblyProductAttribute")
        Compiler.TypeCache.System_Reflection_AssemblyCompanyAttribute = mscorlib.GetType("System.Reflection.AssemblyCompanyAttribute")
        Compiler.TypeCache.System_Reflection_AssemblyCopyrightAttribute = mscorlib.GetType("System.Reflection.AssemblyCopyrightAttribute")
        Compiler.TypeCache.System_Reflection_AssemblyTrademarkAttribute = mscorlib.GetType("System.Reflection.AssemblyTrademarkAttribute")
        Compiler.TypeCache.System_Diagnostics_DebuggableAttribute = mscorlib.GetType("System.Diagnostics.DebuggableAttribute")
        Compiler.TypeCache.System_Diagnostics_DebuggableAttribute_DebuggingModes = mscorlib.GetType("System.Diagnostics.DebuggableAttribute+DebuggingModes")
        Compiler.TypeCache.System_Diagnostics_DebuggableAttribute__ctor_DebuggingModes = System_Diagnostics_DebuggableAttribute.GetConstructor(New Type() {System_Diagnostics_DebuggableAttribute_DebuggingModes})
        Compiler.TypeCache.System_ParamArrayAttribute = mscorlib.GetType("System.ParamArrayAttribute")
        Compiler.TypeCache.System_ParamArrayAttribute__ctor = System_ParamArrayAttribute.GetConstructor(Type.EmptyTypes)
        Compiler.TypeCache.System_Nullable = mscorlib.GetType("System.Nullable`1")
        Compiler.TypeCache.RuntimeHelpers = mscorlib.GetType("System.Runtime.CompilerServices.RuntimeHelpers")
        Compiler.TypeCache.STAThreadAttribute = mscorlib.GetType("System.STAThreadAttribute")
        Compiler.TypeCache.STAThreadAttribute_Ctor = STAThreadAttribute.GetConstructor(Type.EmptyTypes)
        Compiler.TypeCache.IntPtr = mscorlib.GetType("System.IntPtr")
        Compiler.TypeCache.DateTimeConstantAttribute = mscorlib.GetType("System.Runtime.CompilerServices.DateTimeConstantAttribute")
        Compiler.TypeCache.DateConstructor_Int64 = Compiler.TypeCache.Date.GetConstructor(New Type() {Compiler.TypeCache.Long})
        Compiler.TypeCache.DecimalConstructor_Int32 = Compiler.TypeCache.Decimal.GetConstructor(New Type() {Compiler.TypeCache.Integer})
        Compiler.TypeCache.DecimalConstructor_Int64 = Compiler.TypeCache.Decimal.GetConstructor(New Type() {Compiler.TypeCache.Long})
        Compiler.TypeCache.DecimalConstructor_Double = Compiler.TypeCache.Decimal.GetConstructor(New Type() {Compiler.TypeCache.Double})
        Compiler.TypeCache.DecimalConstructor_Single = Compiler.TypeCache.Decimal.GetConstructor(New Type() {Compiler.TypeCache.Single})
        Compiler.TypeCache.DecimalConstructor_UInt64 = Compiler.TypeCache.Decimal.GetConstructor(New Type() {Compiler.TypeCache.ULong})
        Compiler.TypeCache.DecimalConstructor_Int32_Int32_Int32_Boolean_Byte = Compiler.TypeCache.Decimal.GetConstructor(New Type() {Compiler.TypeCache.Integer, Compiler.TypeCache.Integer, Compiler.TypeCache.Integer, Compiler.TypeCache.Boolean, Compiler.TypeCache.Byte})
        Compiler.TypeCache.Decimal_Zero = Compiler.TypeCache.Decimal.GetField("Zero")
        Compiler.TypeCache.Decimal_One = Compiler.TypeCache.Decimal.GetField("One")
        Compiler.TypeCache.Decimal_MinusOne = Compiler.TypeCache.Decimal.GetField("MinusOne")
        Compiler.TypeCache.DecimalConstantAttribute = mscorlib.GetType("System.Runtime.CompilerServices.DecimalConstantAttribute")
        Compiler.TypeCache.DecimalConstantAttributeConstructor_Byte_Byte_UInt32_UInt32_UInt32 = Compiler.TypeCache.DecimalConstantAttribute.GetConstructor(New Type() {Compiler.TypeCache.Byte, Compiler.TypeCache.Byte, Compiler.TypeCache.UInteger, Compiler.TypeCache.UInteger, Compiler.TypeCache.UInteger})
        Compiler.TypeCache.DecimalConstantAttributeConstructor_Byte_Byte_Int32_Int32_Int32 = Compiler.TypeCache.DecimalConstantAttribute.GetConstructor(New Type() {Compiler.TypeCache.Byte, Compiler.TypeCache.Byte, Compiler.TypeCache.Integer, Compiler.TypeCache.Integer, Compiler.TypeCache.Integer})
        Compiler.TypeCache.Decimal_Compare__Decimal_Decimal = Compiler.TypeCache.Decimal.GetMethod("Compare", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Decimal, Compiler.TypeCache.Decimal}, Nothing)
        Compiler.TypeCache.Date_Compare__Date_Date = Compiler.TypeCache.Date.GetMethod("Compare", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Date, Compiler.TypeCache.Date}, Nothing)
        Compiler.TypeCache.Decimal_Add__Decimal_Decimal = Compiler.TypeCache.Decimal.GetMethod("Add", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Decimal, Compiler.TypeCache.Decimal}, Nothing)
        Compiler.TypeCache.Decimal_Subtract__Decimal_Decimal = Compiler.TypeCache.Decimal.GetMethod("Subtract", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Decimal, Compiler.TypeCache.Decimal}, Nothing)
        Compiler.TypeCache.Decimal_Divide__Decimal_Decimal = Compiler.TypeCache.Decimal.GetMethod("Divide", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Decimal, Compiler.TypeCache.Decimal}, Nothing)
        Compiler.TypeCache.Decimal_Multiply__Decimal_Decimal = Compiler.TypeCache.Decimal.GetMethod("Multiply", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Decimal, Compiler.TypeCache.Decimal}, Nothing)
        Compiler.TypeCache.Decimal_Remainder__Decimal_Decimal = Compiler.TypeCache.Decimal.GetMethod("Remainder", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Decimal, Compiler.TypeCache.Decimal}, Nothing)
        Compiler.TypeCache.Decimal_Negate__Decimal = Compiler.TypeCache.Decimal.GetMethod("Negate", BindingFlags.Public Or BindingFlags.Static, Nothing, New Type() {Compiler.TypeCache.Decimal}, Nothing)
        Compiler.TypeCache.ParamArrayAttribute = mscorlib.GetType("System.ParamArrayAttribute")
        Compiler.TypeCache.ParamArrayAttributeConstructor = ParamArrayAttribute.GetConstructor(System.Type.EmptyTypes)
        Compiler.TypeCache.DefaultMemberAttribute = mscorlib.GetType("System.Reflection.DefaultMemberAttribute")
        Compiler.TypeCache.DefaultMemberAttributeConstructor = DefaultMemberAttribute.GetConstructor(New Type() {Compiler.TypeCache.String})
        Compiler.TypeCache.System_Convert = mscorlib.GetType("System.Convert")
        Compiler.TypeCache.System_Convert_ToSingle__Decimal = System_Convert.GetMethod("ToSingle", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToDouble__Decimal = System_Convert.GetMethod("ToDouble", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToBoolean__Decimal = System_Convert.GetMethod("ToBoolean", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToByte__Decimal = System_Convert.GetMethod("ToByte", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToSByte__Decimal = System_Convert.GetMethod("ToSByte", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToInt16__Decimal = System_Convert.GetMethod("ToInt16", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToUInt16__Decimal = System_Convert.GetMethod("ToUInt16", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToInt32__Decimal = System_Convert.GetMethod("ToInt32", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToUInt32__Decimal = System_Convert.GetMethod("ToUInt32", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToInt64__Decimal = System_Convert.GetMethod("ToInt64", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.System_Convert_ToUInt64__Decimal = System_Convert.GetMethod("ToUInt64", New Type() {Compiler.TypeCache.Decimal})
        Compiler.TypeCache.String_Concat__String_String = Compiler.TypeCache.String.GetMethod("Concat", New Type() {Compiler.TypeCache.String, Compiler.TypeCache.String})
        Compiler.TypeCache.System_Diagnostics_Debugger_Break = mscorlib.GetType("System.Diagnostics.Debugger").GetMethod("Break", System.Type.EmptyTypes)
        Compiler.TypeCache.System_Reflection_Missing_Value = mscorlib.GetType("System.Reflection.Missing").GetField("Value")
        Compiler.TypeCache.System_Threading_Monitor = mscorlib.GetType("System.Threading.Monitor")
        Compiler.TypeCache.System_Threading_Monitor_Enter__Object = System_Threading_Monitor.GetMethod("Enter", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Compiler.TypeCache.Object}, Nothing)
        Compiler.TypeCache.System_Threading_Monitor_Exit__Object = System_Threading_Monitor.GetMethod("Exit", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Compiler.TypeCache.Object}, Nothing)
        Compiler.TypeCache.System_Runtime_CompilerServices_RuntimeHelpers__GetObjectValue_Object = RuntimeHelpers.GetMethod("GetObjectValue", BindingFlags.ExactBinding Or BindingFlags.Static Or BindingFlags.Public, Nothing, CallingConventions.Any, New Type() {Compiler.TypeCache.Object}, Nothing)
        Compiler.TypeCache.System_Math = mscorlib.GetType("System.Math")
        Compiler.TypeCache.System_Math_Round__Double = System_Math.GetMethod("Round", BindingFlags.ExactBinding Or BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Compiler.TypeCache.Double}, Nothing)
        Compiler.TypeCache.System_Math_Pow__Double_Double = System_Math.GetMethod("Pow", New Type() {Compiler.TypeCache.Double, Compiler.TypeCache.Double})
        Compiler.TypeCache.System_Runtime_InteropServices_DllImportAttribute = GetType(System.Runtime.InteropServices.DllImportAttribute)

    End Sub

    Private Sub Init()

        Init_corlib()
        Init_vbruntime()

        Compiler.TypeCache.Nothing = GetType([Nothing])

    End Sub

    Private Function GetVBType(ByVal Name As String) As Type
        If Compiler.CommandLine.NoVBRuntimeRef AndAlso MS_VB_Assembly Is Nothing Then
            Dim tps As Generic.List(Of Type)
            tps = Compiler.TypeManager.GetType(Name, True)
            Helper.Assert(tps.Count = 1)
            Return tps(0)
        Else
            Return MS_VB_Assembly.GetType(Name)
        End If
    End Function

    Sub Init_vbruntime(Optional ByVal WithCurrentAssembly As Boolean = False)
        If MS_VB_Assembly Is Nothing AndAlso WithCurrentAssembly = False Then Return
        If MS_VB_CompareMethod IsNot Nothing Then Return 'already loaded
        MS_VB_CompareMethod = GetVBType("Microsoft.VisualBasic.CompareMethod")
        MS_VB_CS_Conversions = GetVBType("Microsoft.VisualBasic.CompilerServices.Conversions")
        MS_VB_CS_ProjectData = GetVBType("Microsoft.VisualBasic.CompilerServices.ProjectData")
        MS_VB_CS_LikeOperator = GetVBType("Microsoft.VisualBasic.CompilerServices.LikeOperator")
        MS_VB_Strings = GetVBType("Microsoft.VisualBasic.Strings")
        MS_VB_CS_StringType = GetVBType("Microsoft.VisualBasic.CompilerServices.StringType")
        MS_VB_CS_StandardModuleAttribute = GetVBType("Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute")
        MS_VB_CS_Operators = GetVBType("Microsoft.VisualBasic.CompilerServices.Operators")
        MS_VB_CS_OFC = GetVBType("Microsoft.VisualBasic.CompilerServices.ObjectFlowControl")
        MS_VB_CS_Utils = GetVBType("Microsoft.VisualBasic.CompilerServices.Utils")
        MS_VB_CS_OptionCompareAttribute = GetVBType("Microsoft.VisualBasic.CompilerServices.OptionCompareAttribute")
        MS_VB_CS_OptionTextAttribute = GetVBType("Microsoft.VisualBasic.CompilerServices.OptionTextAttribute")
        MS_VB_CS_StaticLocalInitFlag = GetVBType("Microsoft.VisualBasic.CompilerServices.StaticLocalInitFlag")
        MS_VB_CS_StaticLocalInitFlag_State = MS_VB_CS_StaticLocalInitFlag.GetField("State", BindingFlags.Public Or BindingFlags.Instance)
        MS_VB_CS_StaticLocalInitFlag_Ctor = MS_VB_CS_StaticLocalInitFlag.GetConstructor(Type.EmptyTypes)
        MS_VB_CS_IncompleteInitializationException = GetVBType("Microsoft.VisualBasic.CompilerServices.IncompleteInitialization")
        MS_VB_CS_IncompleteInitializationException__ctor = MS_VB_CS_IncompleteInitializationException.GetConstructor(Type.EmptyTypes)
        MS_VB_CS_PD_EndApp = MS_VB_CS_ProjectData.GetMethod("EndApp", BindingFlags.Static Or BindingFlags.Public, Nothing, Nothing, Type.EmptyTypes, Nothing)
        MS_VB_CS_PD_CreateProjectError__Integer = MS_VB_CS_ProjectData.GetMethod("CreateProjectError", BindingFlags.ExactBinding Or BindingFlags.Public Or BindingFlags.Static, Nothing, CallingConventions.Standard, New Type() {[Integer]}, Nothing)
        MS_VB_CS_PD_ClearProjectError = MS_VB_CS_ProjectData.GetMethod("ClearProjectError", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.ExactBinding, Nothing, Nothing, Type.EmptyTypes, Nothing)
        MS_VB_CS_PD_SetProjectError__Exception = MS_VB_CS_ProjectData.GetMethod("SetProjectError", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Exception}, Nothing)
        MS_VB_CS_PD_SetProjectError__Exception_Integer = MS_VB_CS_ProjectData.GetMethod("SetProjectError", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Exception, [Integer]}, Nothing)
        MS_VB_CS_Conversions_ToBoolean__Object = MS_VB_CS_Conversions.GetMethod("ToBoolean", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToChar__Object = MS_VB_CS_Conversions.GetMethod("ToChar", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToDate__Object = MS_VB_CS_Conversions.GetMethod("ToDate", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToByte__Object = MS_VB_CS_Conversions.GetMethod("ToByte", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToSByte__Object = MS_VB_CS_Conversions.GetMethod("ToSByte", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToShort__Object = MS_VB_CS_Conversions.GetMethod("ToShort", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToUShort__Object = MS_VB_CS_Conversions.GetMethod("ToUShort", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToInteger__Object = MS_VB_CS_Conversions.GetMethod("ToInteger", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToUInteger__Object = MS_VB_CS_Conversions.GetMethod("ToUInteger", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToLong__Object = MS_VB_CS_Conversions.GetMethod("ToLong", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToULong__Object = MS_VB_CS_Conversions.GetMethod("ToULong", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToSingle__Object = MS_VB_CS_Conversions.GetMethod("ToSingle", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToDouble__Object = MS_VB_CS_Conversions.GetMethod("ToDouble", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToDecimal__Object = MS_VB_CS_Conversions.GetMethod("ToDecimal", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToBoolean__String = MS_VB_CS_Conversions.GetMethod("ToBoolean", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToChar__String = MS_VB_CS_Conversions.GetMethod("ToChar", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToDate__String = MS_VB_CS_Conversions.GetMethod("ToDate", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToByte__String = MS_VB_CS_Conversions.GetMethod("ToByte", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToSByte__String = MS_VB_CS_Conversions.GetMethod("ToSByte", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToShort__String = MS_VB_CS_Conversions.GetMethod("ToShort", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToUShort__String = MS_VB_CS_Conversions.GetMethod("ToUShort", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToInteger__String = MS_VB_CS_Conversions.GetMethod("ToInteger", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToUInteger__String = MS_VB_CS_Conversions.GetMethod("ToUInteger", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToLong__String = MS_VB_CS_Conversions.GetMethod("ToLong", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToULong__String = MS_VB_CS_Conversions.GetMethod("ToULong", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToSingle__String = MS_VB_CS_Conversions.GetMethod("ToSingle", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToDouble__String = MS_VB_CS_Conversions.GetMethod("ToDouble", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToDecimal__String = MS_VB_CS_Conversions.GetMethod("ToDecimal", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String}, Nothing)
        MS_VB_CS_Conversions_ToDecimal__Boolean = MS_VB_CS_Conversions.GetMethod("ToDecimal", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Boolean}, Nothing)
        MS_VB_CS_Conversions_ToString__Decimal = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Decimal}, Nothing)
        MS_VB_CS_Conversions_ToString__Boolean = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Boolean}, Nothing)
        MS_VB_CS_Conversions_ToString__Char = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Char}, Nothing)
        MS_VB_CS_Conversions_ToString__Date = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Date}, Nothing)
        MS_VB_CS_Conversions_ToString__Byte = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Byte}, Nothing)
        MS_VB_CS_Conversions_ToString__SByte = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.SByte}, Nothing)
        MS_VB_CS_Conversions_ToString__Integer = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Integer}, Nothing)
        MS_VB_CS_Conversions_ToString__UInteger = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.UInteger}, Nothing)
        MS_VB_CS_Conversions_ToString__Long = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Long}, Nothing)
        MS_VB_CS_Conversions_ToString__ULong = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.ULong}, Nothing)
        MS_VB_CS_Conversions_ToString__Single = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Single}, Nothing)
        MS_VB_CS_Conversions_ToString__Double = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Double}, Nothing)
        MS_VB_CS_Conversions_ToString__Object = MS_VB_CS_Conversions.GetMethod("ToString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Conversions_ToGenericParameter_T__Object = MS_VB_CS_Conversions.GetMethod("ToGenericParameter", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_LikeOperator_LikeString__String_String_CompareMethod = MS_VB_CS_LikeOperator.GetMethod("LikeString", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.String, Me.String, MS_VB_CompareMethod}, Nothing)
        MS_VB_CS_LikeOperator_LikeObject__Object_Object_CompareMethod = MS_VB_CS_LikeOperator.GetMethod("LikeObject", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object, Me.Object, MS_VB_CompareMethod}, Nothing)
        MS_VB_CS_StringType_MidStmtStr__String_Integer_Integer_String = MS_VB_CS_StringType.GetMethod("MidStmtStr", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {String_ByRef, Me.Integer, Me.Integer, Me.String}, Nothing)
        MS_VB_CS_OFC_CheckForSyncLockOnValueType__Object = MS_VB_CS_OFC.GetMethod("CheckForSyncLockOnValueType", BindingFlags.Static Or BindingFlags.Public Or BindingFlags.ExactBinding, Nothing, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Utils__CopyArray_Array_Array = MS_VB_CS_Utils.GetMethod("CopyArray", BindingFlags.Public Or BindingFlags.Static Or BindingFlags.ExactBinding, Nothing, New Type() {Array, Array}, Nothing)
        MS_VB_CS_Operators_ConditionalCompareObjectEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("ConditionalCompareObjectEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_ConditionalCompareObjectNotEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("ConditionalCompareObjectNotEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_ConditionalCompareObjectGreater__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("ConditionalCompareObjectGreater", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_ConditionalCompareObjectGreaterEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("ConditionalCompareObjectGreaterEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_ConditionalCompareObjectLess__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("ConditionalCompareObjectLess", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_ConditionalCompareObjectLessEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("ConditionalCompareObjectLessEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_CompareString__String_String_Bool = MS_VB_CS_Operators.GetMethod("CompareString", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.String, Me.String, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_ConcatenateObject__Object_Object = MS_VB_CS_Operators.GetMethod("ConcatenateObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_AddObject__Object_Object = MS_VB_CS_Operators.GetMethod("AddObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_AndObject__Object_Object = MS_VB_CS_Operators.GetMethod("AndObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_DivideObject__Object_Object = MS_VB_CS_Operators.GetMethod("DivideObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_ExponentObject__Object_Object = MS_VB_CS_Operators.GetMethod("ExponentObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_IntDivideObject__Object_Object = MS_VB_CS_Operators.GetMethod("IntDivideObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_LeftShiftObject__Object_Object = MS_VB_CS_Operators.GetMethod("LeftShiftObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_ModObject__Object_Object = MS_VB_CS_Operators.GetMethod("ModObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_MultiplyObject__Object_Object = MS_VB_CS_Operators.GetMethod("MultiplyObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_NegateObject__Object = MS_VB_CS_Operators.GetMethod("NegateObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Operators_NotObject__Object = MS_VB_CS_Operators.GetMethod("NotObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Operators_OrObject__Object_Object = MS_VB_CS_Operators.GetMethod("OrObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_PlusObject__Object = MS_VB_CS_Operators.GetMethod("PlusObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object}, Nothing)
        MS_VB_CS_Operators_RightShiftObject__Object_Object = MS_VB_CS_Operators.GetMethod("RightShiftObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_SubtractObject__Object_Object = MS_VB_CS_Operators.GetMethod("SubtractObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_XorObject__Object_Object = MS_VB_CS_Operators.GetMethod("XorObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object}, Nothing)
        MS_VB_CS_Operators_LikeObject__Object_Object = MS_VB_CS_Operators.GetMethod("LikeObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, MS_VB_CompareMethod}, Nothing)
        MS_VB_CS_Operators_LikeString__String_String = MS_VB_CS_Operators.GetMethod("StringObject", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.String, Me.String, MS_VB_CompareMethod}, Nothing)
        MS_VB_CS_Operators_CompareObjectEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("CompareObjectEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_CompareObjectNotEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("CompareObjectNotEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_CompareObjectGreater__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("CompareObjectGreater", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_CompareObjectGreaterEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("CompareGreaterNotEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_CompareObjectLess__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("CompareObjectLess", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        MS_VB_CS_Operators_CompareObjectLessEqual__Object_Object_Bool = MS_VB_CS_Operators.GetMethod("CompareObjectLessEqual", BindingFlags.Static Or BindingFlags.Public, Nothing, New Type() {Me.Object, Me.Object, Me.Boolean}, Nothing)
        Delegate_Combine = Me.Delegate.GetMethod("Combine", New Type() {Me.Delegate, Me.Delegate})
        Delegate_Remove = Me.Delegate.GetMethod("Remove", New Type() {Me.Delegate, Me.Delegate})
        StandardModuleAttribute = GetVBType("Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute")
    End Sub

    Sub Init(ByVal Assemblies As Generic.List(Of Assembly))
        For Each a As Assembly In Assemblies
            If a.GetName.Name = "Microsoft.VisualBasic" Then
                MS_VB_Assembly = a : Continue For
            ElseIf a.GetName.Name = "mscorlib" Then
                mscorlib = a : Continue For
            End If
        Next

        Init()
        If MS_VB_Assembly IsNot Nothing Then
            Init_vbruntime()
        End If
    End Sub

    Shared Function GetCombination(ByVal tp1 As TypeCode, ByVal tp2 As TypeCode) As TypeCombinations
        Return CType(CInt(tp1) << TypeCombinations.SHIFT Or CInt(tp2), TypeCombinations)
    End Function
End Class

