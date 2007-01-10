' 
' Visual Basic.Net COmpiler
' Copyright (C) 2004 - 2006 Rolf Bjarne Kvinge, rbjarnek at users.sourceforge.net
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
''' A list of tests.
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class Tests
    Inherits TestList

    Private m_Path As String

    Private m_ContainedTests As New Generic.List(Of Tests)
    Private m_SkipCleanTests As Boolean

    Sub WriteLinuxScript()
        For Each nested As Tests In m_ContainedTests
            nested.WriteLinuxScript()
        Next
        If Me.Count > 0 Then
            Using writer As New IO.StreamWriter(System.IO.Path.Combine(m_Path, "all.sh"))
                For Each test As Test In Me
                    test.CreateVerifications()
                    Dim cmd As String
                    cmd = test.VBNCVerification.Process.ExpandedCmdLine
                    cmd = cmd.Replace(m_Path & "\", "")
                    cmd = cmd.Replace("/", "-")
                    cmd = cmd.Replace("\", "/")
                    cmd = cmd.Replace("#", "\#")
                    cmd = "vbnc " & cmd & " >>all.log 2>&1"
                    writer.Write(cmd & vbLf)
                    'System.IO.File.WriteAllText(System.IO.Path.Combine(m_Path, test.Name) & ".sh", cmd)
                Next
            End Using
        End If
    End Sub

    ''' <summary>
    ''' The total time all tests have been executing.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    ReadOnly Property ExecutionTimeRecursive() As TimeSpan
        Get
            Dim result As TimeSpan
            result = MyBase.ExecutionTime

            For Each list As Tests In m_ContainedTests
                result += list.ExecutionTimeRecursive
            Next
            Return result
        End Get
    End Property

    Property SkipCleanTests() As Boolean
        Get
            Return m_SkipCleanTests
        End Get
        Set(ByVal value As Boolean)
            m_SkipCleanTests = value
            For Each item As Tests In m_ContainedTests
                item.SkipCleanTests = value
            Next
        End Set
    End Property

    ReadOnly Property RecursiveCount() As Integer
        Get
            Dim result As Integer
            For Each item As Tests In m_ContainedTests
                result += item.RecursiveCount
            Next
            result += Me.Count
            Return result
        End Get
    End Property

    ReadOnly Property GetGreenRecursiveCount() As Integer
        Get
            Dim result As Integer
            For Each item As Tests In m_ContainedTests
                result += item.GetGreenRecursiveCount
            Next
            result += Me.GetTestsCount(Test.Results.Success, Test.Results.Success)
            Return result
        End Get
    End Property

    ReadOnly Property GetGreenCount() As Integer
        Get
            Return Me.GetTestsCount(Test.Results.Success, Test.Results.Success)
        End Get
    End Property

    ReadOnly Property GetRedRecursiveCount() As Integer
        Get
            Dim result As Integer
            For Each item As Tests In m_ContainedTests
                result += item.GetRedRecursiveCount
            Next
            result += Me.GetTestsCount(Test.Results.Failed, Test.Results.Failed)
            Return result
        End Get
    End Property

    ReadOnly Property GetRedCount() As Integer
        Get
            Return Me.GetTestsCount(Test.Results.Failed, Test.Results.Failed)
        End Get
    End Property

    Function GetAllTestsInTree() As TestList
        Dim result As New TestList()
        result.AddRange(Me)
        For Each tests As Tests In m_ContainedTests
            result.AddRange(tests.GetAllTestsInTree)
        Next
        Return result
    End Function

    ReadOnly Property ContainedTests() As Generic.List(Of Tests)
        Get
            Return m_ContainedTests
        End Get
    End Property

    ReadOnly Property Path() As String
        Get
            Return m_Path
        End Get
    End Property

    ''' <summary>
    ''' Create a new test run.
    ''' </summary>
    ''' <param name="Path">The path to the folders where the tests are.</param>
    ''' <param name="CompilerPath">The path to the compiler.</param>
    ''' <remarks></remarks>
    Sub New(ByVal Path As String, ByVal CompilerPath As String, ByVal VBCPath As String)
        MyBase.New(CompilerPath, VBCPath)

        m_Path = Path

        Refresh()
    End Sub

    Sub Update()
        'Get all the code files in the directory.
        Dim files() As String = IO.Directory.GetFiles(m_Path, "*.vb")

        'Remove files that aren't there anymore
        Dim j As Integer = 0
        While j < Me.Count
            Dim test As Test = Me(j)
            Do While test.Files.Count > 0 AndAlso Array.BinarySearch(files, test.Files(0)) < 0
                test.Files.RemoveAt(0)
            Loop
            If test.Files.Count = 0 Then
                Me.RemoveAt(j)
            Else
                j += 1
            End If
        End While

        'Add all new files
        For Each file As String In files
            Dim newName As String = Test.GetTestName(file)
            Dim newTest, oldTest As Test
            oldTest = Item(newName)
            If oldTest Is Nothing Then
                newTest = New Test(file, Me)
                Add(newTest)
            ElseIf oldTest.Files.Contains(file) = False Then
                oldTest.Files.Add(file)
            End If
        Next

        Dim dirs As Generic.List(Of String) = GetContainedTestDirectories()
        For i As Integer = 0 To m_ContainedTests.Count - 1
            Dim tests As Tests = m_ContainedTests(i)
            If dirs.Contains(tests.Path) = False Then
                m_ContainedTests.RemoveAt(i) : i -= 1
            End If
        Next
        For i As Integer = 0 To dirs.Count - 1
            Dim dir As String = dirs(i)
            Dim oldTests As Tests = Nothing

            For Each containedtests As Tests In m_ContainedTests
                If containedtests.Path = dir Then
                    oldTests = containedtests
                    Exit For
                End If
            Next
            If oldTests IsNot Nothing Then
                oldTests.Update()
            Else
                m_ContainedTests.Add(New Tests(dir, MyBase.VBNCPath, MyBase.VBCPath))
            End If
        Next
    End Sub

    Sub Refresh()
        Me.Clear()
        Me.m_ContainedTests.Clear()

        'Get all the code files in the directory.
        Dim files() As String = IO.Directory.GetFiles(m_Path, "*.vb")
        For Each file As String In files
            Dim newTest, oldTest As Test
            newTest = New Test(file, Me)
            oldTest = Item(newTest.Name)
            If oldTest Is Nothing Then
                Add(newTest)
            ElseIf oldTest.Files.Contains(file) = False Then
                oldTest.Files.Add(file)
            End If
        Next

        Dim dirs As Generic.List(Of String) = GetContainedTestDirectories()
        For Each dir As String In dirs
            m_ContainedTests.Add(New Tests(dir, MyBase.VBNCPath, MyBase.VBCPath))
        Next
    End Sub

    Private Function GetContainedTestDirectories() As Generic.List(Of String)
        Dim result As New Generic.List(Of String)
        Dim dirs() As String = IO.Directory.GetDirectories(m_Path)

        'Add all the subdirectories (only if they are neither hidden nor system directories and they 
        'must not be named "testoutput"
        For Each dir As String In dirs
            Dim dirAttr As IO.FileAttributes = IO.File.GetAttributes(dir)
            If Not (CBool(dirAttr And (IO.FileAttributes.Hidden Or IO.FileAttributes.System))) Then
                If dir.EndsWith("testoutput", StringComparison.InvariantCultureIgnoreCase) = False Then
                    result.Add(IO.Path.GetFullPath(dir))
                End If
            End If
        Next
        Return result
    End Function

    Function FindContainedTestList(ByVal Path As String) As Tests
        For Each item As Tests In m_ContainedTests
            If item.Path = Path Then Return item
        Next
        Return Nothing
    End Function
End Class
