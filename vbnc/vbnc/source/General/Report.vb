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

Imports System.Resources
#If DEBUG Then
#Const STOPONERROR = True
#Const STOPONWARNING = True
#End If

''' <summary>
''' The report class for the compiler. Is used to show all the
''' messages from the compiler.
''' </summary>
Public Class Report
    ''' <summary>
    ''' The count of each message shown (by message level).
    ''' </summary>
    ''' <remarks>Depends on the fact that the first message level is 0 </remarks>
    Private m_MessageCount(MessageLevel.Error) As Integer

    ''' <summary>
    ''' The max number of errors before quit compiling.
    ''' </summary>
    ''' <remarks></remarks>
    Const MAXERRORS As Integer = 50

    ''' <summary>
    ''' The resource manager for this report.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared m_Resources As ResourceManager

#If DEBUG Then
    ''' <summary>
    ''' The filename for an xml-report.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_xmlFileName As String
#End If

    ''' <summary>
    ''' A list of all the errors / warnings shown.
    ''' Messages are not added until they are shown
    ''' (if they are saved).
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Messages As New ArrayList

    ''' <summary>
    ''' A list of all the saved errors / warnings to show.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SavedMessages As New ArrayList

    ''' <summary>
    ''' The executing compiler.
    ''' </summary>
    Private m_Compiler As Compiler


    Enum ReportLevels
        ''' <summary>
        ''' Always show the message.
        ''' </summary>
        ''' <remarks></remarks>
        Always
        ''' <summary>
        ''' Only show if verbose
        ''' </summary>
        ''' <remarks></remarks>
        Verbose
        ''' <summary>
        ''' Only show in debug builds
        ''' </summary>
        ''' <remarks></remarks>
        Debug
    End Enum

    Private m_ReportLevel As ReportLevels = ReportLevels.Debug
    Private m_Listeners As New Generic.List(Of Diagnostics.TraceListener)

    ''' <summary>
    ''' The listeners who will receive text output.
    ''' A console writer is here by default.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Listeners() As Generic.List(Of Diagnostics.TraceListener)
        Get
            Return m_Listeners
        End Get
    End Property

    Sub Write(ByVal Level As ReportLevels, Optional ByVal Value As String = "")
        If Level <= m_ReportLevel Then
            Write(Value)
        End If
    End Sub

    Sub Write(Optional ByVal Value As String = "")
        For Each d As Diagnostics.TraceListener In m_Listeners
            d.Write(Value)
        Next
        Console.Write(Value)
    End Sub

    Sub Indent()
        For Each d As Diagnostics.TraceListener In m_Listeners
            d.IndentLevel += 1
        Next
    End Sub

    Sub Unindent()
        For Each d As Diagnostics.TraceListener In m_Listeners
            d.IndentLevel -= 1
        Next
    End Sub

    Sub WriteLine(ByVal Level As ReportLevels, Optional ByVal Value As String = "")
        Write(Level, Value & VB.vbNewLine)
    End Sub

    Sub WriteLine(Optional ByVal Value As String = "")
        Write(Value & VB.vbNewLine)
    End Sub

    ''' <summary>
    ''' The executing compiler.
    ''' </summary>
    ReadOnly Property Compiler() As Compiler
        Get
            Return m_Compiler
        End Get
    End Property

#If DEBUG Then
    ''' <summary>
    ''' The xml writer for this report.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public Property XMLFileName() As String
        Get
            Return m_xmlFileName
        End Get
        Set(ByVal value As String)
            m_xmlFileName = value
        End Set
    End Property
#End If

    ''' <summary>
    ''' Creates a new default report.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New(ByVal Compiler As Compiler)
        m_Compiler = Compiler
        'm_Listeners.Add(New System.Diagnostics.TextWriterTraceListener(Console.Out))
#If DEBUG Then
        For Each i As Diagnostics.TraceListener In System.Diagnostics.Debug.Listeners
            m_Listeners.Add(i)
        Next
#End If
    End Sub

    ''' <summary>
    ''' Looks up the specified error code and returns the string
    ''' </summary>
    ''' <param name="ErrorCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function LookupErrorCode(ByVal ErrorCode As Integer) As String
        Dim result As Object

        If m_Resources Is Nothing Then
            m_Resources = New ResourceManager("vbnc.Errors", System.Reflection.Assembly.GetExecutingAssembly())
        End If

        result = m_Resources.GetObject(ErrorCode.ToString)

        If result Is Nothing Then
            Helper.Stop()
            Return ""
        Else
            Return result.ToString
        End If

    End Function

    ''' <summary>
    ''' The number of messages shown for the specified message level
    ''' </summary>
    ReadOnly Property MessageCount(ByVal Level As MessageLevel) As Integer
        Get
            Return m_MessageCount(Level)
        End Get
    End Property

    ''' <summary>
    ''' The number of errors so far.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    ReadOnly Property Errors() As Integer
        Get
            Return m_MessageCount(MessageLevel.Error)
        End Get
    End Property

    ''' <summary>
    ''' The number of warnings so far.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    ReadOnly Property Warnings() As Integer
        Get
            Return m_MessageCount(MessageLevel.Warning)
        End Get
    End Property

    ''' <summary>
    ''' Show the saved messages. Returns true if any messages have been shown.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ShowSavedMessages() As Boolean
        ShowSavedMessages = m_SavedMessages.Count > 0
        For Each msg As Message In m_SavedMessages
            ShowMessage(False, msg) 'Compiler.Report.WriteLine(str)
        Next
        m_SavedMessages.Clear()
    End Function

    ' <Obsolete()> _
    ''' <summary>
    ''' Shows the message with the specified level
    ''' </summary>
    ''' <param name="Level"></param>
    ''' <param name="Msg"></param>
    ''' <remarks></remarks>
    Private Sub ShowMessage(ByVal Level As MessageLevel, ByVal Msg As String)
        Select Case Level
            Case MessageLevel.Error
                Compiler.Report.WriteLine(Msg.Replace("%MSGTYPE%", "error"))
                If Errors > MAXERRORS Then
                    Throw New TooManyErrorsException() ' ApplicationException("To many errors. Quitting.")
                End If
            Case MessageLevel.Warning ' MessageLevel.PickyWarning, MessageLevel.SlightWarning, MessageLevel.NormalWarning, MessageLevel.SevereWarning
                Compiler.Report.WriteLine(Msg.Replace("%MSGTYPE%", "warning"))
            Case Else
                Throw New InternalException("Invalid WarningLevel: " & Level.ToString & " (" & Msg & ")")
        End Select
#If StopOnMsg Then
		If Debugger.IsAttached Then Helper.Stop()
#End If
    End Sub

    ''' <summary>
    ''' Helper to construct a message for a multiline message when every line after the first one
    ''' is the same message. Message() must be an array with two elements, FirstParameters() is applied
    ''' to the first one, then the second element is multiplied by the number of SubsequentParameters()
    ''' and then a message is created with the corresponding SubsequentParameters() for every line after the 
    ''' first one.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> Sub ShowMessageHelper(ByVal Message() As Messages, ByVal Location As Span, ByVal FirstParameters() As String, ByVal SubsequentParameters() As String)
        Dim msg() As Messages
        Dim params()() As String

        ReDim msg(SubsequentParameters.Length)
        ReDim params(SubsequentParameters.Length)
        msg(0) = Message(0)
        params(0) = FirstParameters
        For i As Integer = 1 To msg.GetUpperBound(0)
            msg(i) = Message(1)
            params(i) = New String() {SubsequentParameters(i - 1)}
        Next

        ShowMessage(msg, Location, params)
    End Sub

    ''' <summary>
    ''' Shows the message with the specified location and parameters
    ''' </summary>
    <Diagnostics.DebuggerHidden()> Sub ShowMessage(ByVal Message As Messages, ByVal Location As Span, ByVal ParamArray Parameters() As String)
        ShowMessage(False, New Message(Message, Parameters, Location))
    End Sub

    ''' <summary>
    ''' Shows the message with the specified parameters.
    ''' Tries to look up the current location in the token manager.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> Sub ShowMessage(ByVal Message As Messages, ByVal ParamArray Parameters() As String)
        If Compiler IsNot Nothing AndAlso Compiler.tm IsNot Nothing AndAlso Compiler.tm.IsCurrentTokenValid Then
            ShowMessage(Message, Compiler.tm.CurrentToken.Location, Parameters)
        Else
            Dim loc As Span = Nothing
            ShowMessage(Message, loc, Parameters)
        End If
    End Sub

    ''' <summary>
    ''' Shows the multiline message with the specified parameters.
    ''' Tries to look up the current location in the token manager.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> Sub ShowMessage(ByVal Message() As Messages, ByVal ParamArray Parameters()() As String)
        If Compiler.tm.IsCurrentTokenValid Then
            ShowMessage(False, New Message(Message, Parameters, Compiler.tm.CurrentToken.Location))
        Else
            ShowMessage(False, New Message(Message, Parameters, Nothing))
        End If
    End Sub

    ''' <summary>
    ''' Shows the multiline message with the specified location and parameters.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> Sub ShowMessage(ByVal Message() As Messages, ByVal Location As Span, ByVal ParamArray Parameters()() As String)
        ShowMessage(False, New Message(Message, Parameters, Location))
    End Sub

    ''' <summary>
    ''' Saves the multiline message with the specified parameters.
    ''' Tries to look up the current location in the token manager.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> Sub SaveMessage(ByVal Message() As Messages, ByVal ParamArray Parameters()() As String)
        If Compiler.tm.IsCurrentTokenValid Then
            ShowMessage(True, New Message(Message, Parameters, Compiler.tm.CurrentToken.Location))
        Else
            ShowMessage(True, New Message(Message, Parameters, Nothing))
        End If
    End Sub

    ''' <summary>
    ''' Saves the multiline message with the specified location and parameters.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> Sub SaveMessage(ByVal Message() As Messages, ByVal Location As Span, ByVal ParamArray Parameters()() As String)
        ShowMessage(True, New Message(Message, Parameters, Location))
    End Sub

    ''' <summary>
    ''' Saves the message with the specified location and parameters.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> _
    Sub SaveMessage(ByVal Message As Messages, ByVal Location As Span, ByVal ParamArray Parameters() As String)
        ShowMessage(True, New Message(Message, Parameters, Location))
    End Sub

    ''' <summary>
    ''' Saves the message with the specified parameters.
    ''' Tries to look up the current location in the token manager.
    ''' </summary>
    <Diagnostics.DebuggerHidden()> _
    Sub SaveMessage(ByVal Message As Messages, ByVal ParamArray Parameters() As String)
        If Compiler IsNot Nothing AndAlso Compiler.tm IsNot Nothing AndAlso Compiler.tm.IsCurrentTokenValid Then
            SaveMessage(Message, Compiler.tm.CurrentToken.Location, Parameters)
        Else
            SaveMessage(Message, Nothing, Parameters)
        End If
    End Sub

    ''' <summary>
    ''' Shows the specified message. Can optionally save it (not show it)
    ''' to show it later with ShowSavedMessages()
    ''' </summary>
    <Diagnostics.DebuggerHidden()> _
    Sub ShowMessage(ByVal SaveIt As Boolean, ByVal Message As Message)
        If SaveIt Then
            m_SavedMessages.Add(Message)
        Else
            m_Messages.Add(Message)
            Compiler.Report.WriteLine(vbnc.Report.ReportLevels.Always, Message.ToString())
            m_MessageCount(Message.Level) += 1
            If m_MessageCount(MessageLevel.Error) > MAXERRORS Then
                Throw New TooManyErrorsException()
            End If
        End If

#If STOPONERROR Then
        If Helper.IsDebugging AndAlso Message.Level = MessageLevel.Error Then
            Helper.Stop()
        ElseIf Helper.IsBootstrapping Then
            Throw New InternalException(Message.ToString)
        End If
#ElseIf STOPONWARNING Then
        If Debugger.IsAttached AndAlso Message.Level = MessageLevel.Warning Then
            Helper.Stop()
        End If
#End If
    End Sub

#If DEBUG Then
    ''' <summary>
    ''' Tries to write pending messages to the xml file (if any).
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Flush()
        If m_xmlFileName <> "" Then
            If m_Messages.Count > 0 Then
                Dim m_xml As Xml.XmlTextWriter
                m_xml = New Xml.XmlTextWriter(m_xmlFileName, Text.Encoding.UTF8)
                m_xml.Formatting = Xml.Formatting.Indented
                For Each msg As Message In m_Messages
                    msg.Dump(m_xml)
                Next
                m_xml.Close()
            ElseIf IO.File.Exists(m_xmlFileName) Then
                Try
                    IO.File.Delete(m_xmlFileName)
                Catch ex As Exception
                    'Nothing to handle.
                End Try
            End If
        End If
    End Sub
#End If
End Class
