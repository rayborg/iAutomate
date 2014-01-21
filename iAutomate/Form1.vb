Imports System.IO

Public Class Main
    Dim filePath As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Clear all the items in the listbox

        ListBox1.Items.Clear()

        'For every process which is running on the computer

        For Each p As Process In Process.GetProcesses

            'If the MainWindowTitle of the process is not empty

            If p.MainWindowTitle = String.Empty = False Then

                'Add the process name, the main window title, and the process ID (what windows uses to identify the process) to the listbox)

                ListBox1.Items.Add(p.MainWindowTitle)
            End If

        Next

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            filePath = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim progranName As String

        If filePath Is Nothing Then
            MsgBox("Please select a password file. Thanks!")
        Else
            progranName = ListBox1.SelectedItem
            If ListBox1.SelectedIndex < 0 Then
                ' Display message
                MsgBox("No program selected. Please select a program from the list below. Thanks!")
            Else
                Try
                   

                    Dim currentWord As String
                    Dim sr As StreamReader = New StreamReader(filePath)
                    Do While sr.Peek() >= 0
                        currentWord = sr.ReadLine()

                        'Activate the program (MyWinLocker)
                        AppActivate(progranName)

                        My.Computer.Keyboard.SendKeys(currentWord)
                        System.Threading.Thread.Sleep(2000)
                        SendKeys.Send("{ENTER}")
                        System.Threading.Thread.Sleep(2000)
                        SendKeys.Send("{ENTER}")
                        System.Threading.Thread.Sleep(2000)

                        If TextBox1.Text = 3 Then
                            SendKeys.Send("{ENTER}")
                            System.Threading.Thread.Sleep(2000)

                        End If

                        If TextBox1.Text = 4 Then
                            SendKeys.Send("{ENTER}")
                            System.Threading.Thread.Sleep(2000)
                            SendKeys.Send("{ENTER}")
                            System.Threading.Thread.Sleep(2000)

                        End If
                    Loop

                    sr.Close()
                Catch ex As Exception
                    MsgBox("File decryption program closed unexpectedly.")
                End Try

            End If


        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Clear all the items in the listbox

        ListBox1.Items.Clear()

        'For every process which is running on the computer

        For Each p As Process In Process.GetProcesses

            'If the MainWindowTitle of the process is not empty

            If p.MainWindowTitle = String.Empty = False Then

                'Add the process name, the main window title, and the process ID (what windows uses to identify the process) to the listbox)

                ListBox1.Items.Add(p.MainWindowTitle)
            End If

        Next
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MsgBox("iAutomate is a generic password cracking program suitable for many encryption programs. iAutomate was developed January 2014 by Raymond Borges." & vbNewLine & "Visit http://nkatasecurity.com for more cool tools!")
    End Sub


    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""

    End Sub

End Class
