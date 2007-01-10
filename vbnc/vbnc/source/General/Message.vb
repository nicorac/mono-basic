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

''' <summary>
''' Represents a compiler message (might be a warning, an error or an information).
''' A compiler message might have several lines.
''' </summary>
Public Class Message

    ''' <summary>
    ''' The actual message itself.
    ''' Might be several messages if this is a multiline message.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Message As Messages()

    ''' <summary>
    ''' The location of the code corresponding to the the message.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Location As Span

    ''' <summary>
    ''' The parameters of the message(s)
    ''' </summary>
    Private m_Parameters()() As String

    ''' <summary>
    ''' The format of the message
    ''' </summary>
    ''' <remarks></remarks>
    Private Const MESSAGEFORMATWITHLOCATION As String = "%LOCATION% : %MESSAGELEVEL% %MESSAGE%"

    ''' <summary>
    ''' The format of the message
    ''' </summary>
    ''' <remarks></remarks>
    Private Const MESSAGEFORMAT As String = "%MESSAGELEVEL% : %MESSAGE%"

    ''' <summary>
    ''' Get the severity level of this message.
    ''' </summary>
    ReadOnly Property Level() As MessageLevel
        Get
            Dim attr As MessageAttribute
            attr = DirectCast(System.Attribute.GetCustomAttribute(GetType(Messages).GetField(m_Message(0).ToString), GetType(MessageAttribute)), MessageAttribute)
            Return attr.Level
        End Get
    End Property

    ''' <summary>
    ''' The actual message itself.
    ''' Might be several messages if this is a multiline message.
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property Message() As Messages()
        Get
            Return m_Message
        End Get
    End Property

    ''' <summary>
    ''' The location of the code corresponding to the the message.
    ''' </summary>
    ''' <remarks></remarks>
    ReadOnly Property Location() As Span
        Get
            Return m_Location
        End Get
    End Property

    ''' <summary>
    ''' The parameters of the message(s)
    ''' </summary>
    ReadOnly Property Parameters() As String()()
        Get
            Return m_Parameters
        End Get
    End Property

    ''' <summary>
    ''' Create a new message with the specified data.
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Sub New(ByVal Message As Messages, ByVal Location As Span)
        Me.m_Message = New Messages() {Message}
        Me.m_Location = Location
        Me.m_Parameters = New String()() {}
    End Sub

    ''' <summary>
    ''' Create a new message with the specified data.
    ''' </summary>
    Sub New(ByVal Message As Messages(), ByVal Parameters()() As String, ByVal Location As Span)
        Me.m_Message = Message
        Me.m_Location = Location
        Me.m_Parameters = Parameters
    End Sub

    ''' <summary>
    ''' Create a new message with the specified data.
    ''' </summary>
    Sub New(ByVal Message As Messages, ByVal Parameters() As String, ByVal Location As Span)
        Me.m_Message = New Messages() {Message}
        Me.m_Location = Location
        Me.m_Parameters = New String()() {Parameters}
    End Sub

    ''' <summary>
    ''' Formats the message to a string.
    ''' The returned string might have several lines.
    ''' </summary>
    Overrides Function ToString() As String
        Dim strMessages(), strMessage, strLocation As String
        Dim result As String

        Console.WriteLine("Message.ToString()")

        'Get the message string and format it with the message parameters.
        ReDim strMessages(m_Message.GetUpperBound(0))
        For i As Integer = 0 To m_Message.GetUpperBound(0)
            Console.WriteLine("Params: " & VB.Join(Me.m_Parameters(i), ";"))
            strMessages(i) = Report.LookupErrorCode(m_Message(i))
            Select Case m_Parameters(i).Length
                Case 0
                    'strMessages(i) = String.Format(strMessages(i), m_Parameters(i))
                Case 1
                    strMessages(i) = String.Format(strMessages(i), m_Parameters(i)(0))
                Case 2
                    strMessages(i) = String.Format(strMessages(i), m_Parameters(i)(0), m_Parameters(i)(1))
                Case 3
                    strMessages(i) = String.Format(strMessages(i), m_Parameters(i)(0), m_Parameters(i)(1)(2))
                Case Else
                    Helper.NotImplemented("")
            End Select
            If i = 0 Then strMessages(i) = m_Message(i).ToString & ": " & strMessages(i)
        Next
        strMessage = Microsoft.VisualBasic.Join(strMessages, Microsoft.VisualBasic.vbNewLine)

        'Get the location string
        If Location IsNot Nothing Then
            strLocation = Location.ToString()
            result = MESSAGEFORMATWITHLOCATION
        Else
            strLocation = ""
            result = MESSAGEFORMAT
        End If

        'Format the entire message.
        result = result.Replace("%LOCATION%", strLocation)
        result = result.Replace("%MESSAGE%", strMessage)
        result = result.Replace("%MESSAGELEVEL%", Level.ToString)

        Return result
    End Function

#If DEBUG Then
    ''' <summary>
    ''' Dump this message to an xmlwriter.
    ''' </summary>
    ''' <param name="xml"></param>
    ''' <remarks></remarks>
    Sub Dump(ByVal xml As Xml.XmlWriter)
        xml.WriteStartElement("Message")
        xml.WriteAttributeString("Level", Level.ToString)
        If Location IsNot Nothing Then Location.Dump(xml)
        For i As Integer = 0 To m_Message.GetUpperBound(0)
            xml.WriteString(Me.ToString)
        Next
        xml.WriteEndElement()
    End Sub
#End If
End Class