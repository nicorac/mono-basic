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

Imports System.Reflection
Imports System.Reflection.Emit
''' <summary>
''' DelegateDeclaration  ::=
''' [  Attributes  ]  [  TypeModifier+  ]  "Delegate" MethodSignature  StatementTerminator
''' MethodSignature  ::=  SubSignature  |  FunctionSignature
''' 
''' LAMESPEC: should be something like:
''' [  Attributes  ]  [  TypeModifier+  ]  "Delegate" FunctionOrSub MethodSignature  StatementTerminator
''' FunctionOrSub ::= "Function" | "Sub"
''' </summary>
''' <remarks></remarks>
Public Class DelegateDeclaration
    Inherits GenericTypeDeclaration
    Implements IHasImplicitTypes

    Public Const STR_Invoke As String = "Invoke"
    Public Const STR_EndInvoke As String = "EndInvoke"
    Public Const STR_BeginInvoke As String = "BeginInvoke"

    Private m_Signature As SubSignature

    Private m_Constructor As ConstructorDeclaration
    Private m_Invoke As SubDeclaration
    Private m_BeginInvoke As FunctionDeclaration
    Private m_EndInvoke As SubDeclaration

    Sub New(ByVal Parent As ParsedObject, ByVal [Namespace] As String)
        MyBase.New(Parent, [Namespace])
    End Sub

    Public Sub New(ByVal Parent As TypeDeclaration, ByVal Name As String, ByVal Modifiers As Modifiers, ByVal Parameters As ParameterList, Optional ByVal ReturnType As Type = Nothing)
        Me.New(Parent, Parent.Namespace)

        If ReturnType Is Nothing Then
            m_Signature = New SubSignature(Me, Name, Parameters)
        Else
            m_Signature = New FunctionSignature(Me, Name, Parameters, ReturnType, Parent.Location)
        End If

        Me.Init(New Attributes(Me), Modifiers, m_Signature)
    End Sub

    Shadows Sub Init(ByVal CustomAttributes As Attributes, ByVal Modifiers As Modifiers, ByVal Signature As SubSignature)
        MyBase.Init(CustomAttributes, Modifiers, New MemberDeclarations(Me), Signature.Identifier, Signature.TypeParameters)
        m_Signature = Signature
    End Sub

    Function CreateImplicitElements() As Boolean Implements IHasImplicitTypes.CreateImplicitTypes
        Dim result As Boolean = True
        Dim ReturnType As TypeName
        Dim Parameters As ParameterList = m_Signature.Parameters

        Helper.Assert(Me.Members.Count = 0)

        If TypeOf m_Signature Is FunctionSignature Then
            ReturnType = DirectCast(m_Signature, FunctionSignature).TypeName
        Else
            ReturnType = Nothing
        End If

        'Create the constructor
        m_Constructor = New ConstructorDeclaration(Me)
        m_Constructor.Init(Nothing)
        m_Constructor.Signature.Parameters.Add("TargetObject", Compiler.TypeCache.Object)
        m_Constructor.Signature.Parameters.Add("TargetMethod", Compiler.TypeCache.IntPtr)
        m_Constructor.Attributes = Reflection.MethodAttributes.Public Or Reflection.MethodAttributes.SpecialName Or Reflection.MethodAttributes.RTSpecialName
        m_Constructor.SetImplementationFlags(MethodImplAttributes.Runtime)

        Members.Add(m_Constructor)

        Dim paramCount As Integer
        If Parameters IsNot Nothing Then paramCount = Parameters.Count

        Dim invokeParameters As ParameterList
        Dim beginInvokeParameters As ParameterList
        Dim endInvokeParameters As ParameterList

        Dim invokeSignature As SubSignature
        Dim beginInvokeSignature As FunctionSignature
        Dim endInvokeSignature As SubSignature

        'Invoke takes same types as delegate, and same return type
        'BeginInvoke takes same types as delegate + AsyncCallback + Object, and return type is IAsyncResult
        'EndInvoke takes byref types of delegate + IAsyncResult, and same return type

        If ReturnType Is Nothing Then
            m_Invoke = New SubDeclaration(Me)
            m_EndInvoke = New SubDeclaration(Me)
        Else
            m_Invoke = New FunctionDeclaration(Me)
            m_EndInvoke = New FunctionDeclaration(Me)
        End If
        m_BeginInvoke = New FunctionDeclaration(Me)

        invokeParameters = New ParameterList(m_Invoke)
        beginInvokeParameters = New ParameterList(m_BeginInvoke)
        endInvokeParameters = New ParameterList(m_EndInvoke)

        For i As Integer = 0 To paramCount - 1
            invokeParameters.Add(Parameters(i).Clone(invokeParameters))
            beginInvokeParameters.Add(Parameters(i).Clone(beginInvokeParameters))
            If Parameters(i).Modifiers.Is(KS.ByRef) Then
                endInvokeParameters.Add(Parameters(i).Clone(endInvokeParameters))
            End If
        Next
        beginInvokeParameters.Add(New Parameter(beginInvokeParameters, "DelegateCallback", Compiler.TypeCache.AsyncCallback))
        beginInvokeParameters.Add(New Parameter(beginInvokeParameters, "DelegateAsyncState", Compiler.TypeCache.Object))
        endInvokeParameters.Add(New Parameter(endInvokeParameters, "DelegateAsyncResult", Compiler.TypeCache.IAsyncResult))

        If ReturnType Is Nothing Then
            invokeSignature = New SubSignature(m_Invoke, STR_Invoke, invokeParameters)
            endInvokeSignature = New SubSignature(m_EndInvoke, STR_EndInvoke, endInvokeParameters)
        Else
            invokeSignature = New FunctionSignature(m_Invoke)
            DirectCast(invokeSignature, FunctionSignature).Init(STR_Invoke, Nothing, invokeParameters, Nothing, ReturnType, New Span())
            endInvokeSignature = New FunctionSignature(m_EndInvoke)
            DirectCast(endInvokeSignature, FunctionSignature).Init(STR_EndInvoke, Nothing, endInvokeParameters, Nothing, ReturnType, New Span())
        End If
        beginInvokeSignature = New FunctionSignature(m_BeginInvoke, STR_BeginInvoke, beginInvokeParameters, Compiler.TypeCache.IAsyncResult, New Span())

        m_Invoke.Init(Nothing, New Modifiers(m_Invoke), invokeSignature, Nothing, Nothing)
        m_BeginInvoke.Init(Nothing, New Modifiers(m_BeginInvoke), beginInvokeSignature, Nothing, Nothing)
        m_EndInvoke.Init(Nothing, New Modifiers(m_EndInvoke), endInvokeSignature, Nothing, Nothing)

        Dim attr As MethodAttributes
        Dim implattr As MethodImplAttributes = MethodImplAttributes.Runtime
        attr = MethodAttributes.Public Or MethodAttributes.NewSlot Or MethodAttributes.Virtual Or MethodAttributes.CheckAccessOnOverride

        'If Me.DeclaringType IsNot Nothing AndAlso Me.DeclaringType.TypeDescriptor.IsInterface Then
        '    attr = attr Or MethodAttributes.CheckAccessOnOverride
        'End If

        m_Invoke.Attributes = attr
        m_BeginInvoke.attributes = attr
        m_EndInvoke.Attributes = attr

        m_Invoke.SetImplementationFlags(implattr)
        m_BeginInvoke.SetImplementationFlags(implattr)
        m_EndInvoke.SetImplementationFlags(implattr)

        Members.Add(m_BeginInvoke)
        Members.Add(m_EndInvoke)
        Members.Add(m_Invoke)

        Return result
    End Function

    Overrides Function ResolveType() As Boolean
        Dim result As Boolean = True

        BaseType = Compiler.TypeCache.MulticastDelegate

        result = m_Signature.ResolveTypeReferences(False) AndAlso result

        result = MyBase.ResolveType AndAlso result

        Return result
    End Function

    Shared Function IsMe(ByVal tm As tm) As Boolean
        Dim i As Integer
        While tm.PeekToken(i).Equals(Enums.TypeModifiers)
            i += 1
        End While
        Return tm.PeekToken(i).Equals(KS.Delegate)
    End Function

    ReadOnly Property Signature() As SubSignature
        Get
            Return m_Signature
        End Get
    End Property

    Public Overrides ReadOnly Property TypeAttributes() As System.Reflection.TypeAttributes
        Get
            Return Helper.getTypeAttributeScopeFromScope(Modifiers, IsNestedType) Or Reflection.TypeAttributes.Sealed
        End Get
    End Property
End Class