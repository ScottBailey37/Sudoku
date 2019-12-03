Imports System.Windows.Forms

Public Class CustomPuzzleDialog

    Friend Solution() As Square

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Function FindSolution() As Boolean
        Dim pz() As Square = PreparePuzzle()
        Solution = GenerateSolution(pz)

        If Solution IsNot Nothing Then
            For i As Integer = 0 To (Solution.Length - 1)
                If Me.CustomGrid1.Cells(i).Text <> "" Then
                    'If Solution(i).Value.ToString <> Me.CustomGrid1.Cells(i).Text Then
                    '    MsgBox("User Square Changed at: " + i.ToString)
                    'End If
                Else
                    Me.CustomGrid1.Cells(i).TextColor = Color.Black
                End If
                Me.CustomGrid1.Cells(i).Text = Solution(i).Value.ToString
            Next

            Me.CustomGrid1.Invalidate()
            Me.CustomGrid1.Update()

            Return True
        Else
            ' Could not find a valid solution
            MsgBox("Sorry, but a valid solution could not be found.")
        End If

        Return False
    End Function

    ''' <summary>
    ''' Prepares the user submitted puzzle for finding a solution.
    ''' </summary>
    ''' <returns>An array of type Square containing the submitted puzzle.</returns>
    ''' <remarks></remarks>
    Private Function PreparePuzzle() As Square()
        Dim puzzle(80) As Square
        Dim sq As Square
        Dim row As Integer = 1
        Dim column As Integer = 1
        Dim region As Integer = 1
        Dim count As Integer = 1

        For i As Integer = 0 To (Me.CustomGrid1.Cells.Count - 1)
            sq = New Square

            '***********************************************************************
            ' CALCULATE THE SQUARE'S COLUMN AND ROW
            '***********************************************************************
            If i = (9 * count) Then
                column = 1
                row += 1
                count += 1
            End If

            '***********************************************************************
            ' SET THE SQUARE'S REGION
            '***********************************************************************
            If column = 1 OrElse column = 2 OrElse column = 3 Then  ' Region 1,4,7
                If row = 1 OrElse row = 2 OrElse row = 3 Then
                    region = 1
                End If
                If row = 4 OrElse row = 5 OrElse row = 6 Then
                    region = 4
                End If
                If row = 7 OrElse row = 8 OrElse row = 9 Then
                    region = 7
                End If
            ElseIf column = 4 OrElse column = 5 OrElse column = 6 Then  ' Region 2,5,8
                If row = 1 OrElse row = 2 OrElse row = 3 Then
                    region = 2
                End If
                If row = 4 OrElse row = 5 OrElse row = 6 Then
                    region = 5
                End If
                If row = 7 OrElse row = 8 OrElse row = 9 Then
                    region = 8
                End If
            ElseIf column = 7 OrElse column = 8 OrElse column = 9 Then ' Region 3,6,9
                If row = 1 OrElse row = 2 OrElse row = 3 Then
                    region = 3
                End If
                If row = 4 OrElse row = 5 OrElse row = 6 Then
                    region = 6
                End If
                If row = 7 OrElse row = 8 OrElse row = 9 Then
                    region = 9
                End If
            End If

            '***********************************************************************
            ' SET THE SQUARE'S VALUE
            '***********************************************************************
            If Me.CustomGrid1.Cells(i).Text <> "" Then
                sq.Value = Me.CustomGrid1.Cells(i).Text
            Else
                sq.Value = "0"
            End If

            '***********************************************************************
            ' SET THE SQUARE'S ROW, COLUMN, REGION, AND INDEX  
            '***********************************************************************
            sq.Row = row
            sq.Column = column
            sq.Region = region
            sq.Index = i


            puzzle(i) = sq

            column += 1
        Next

        Return puzzle
    End Function

    Private Function SavePuzzle(ByVal filepath As String) As Boolean
        Try
            Dim sw As New IO.StreamWriter(filepath, False)
            Dim solution As String = ""
            Dim puzzle As String = ""

            ' Set the puzzle's Editables based upon the cells
            ' that have text. The cells that have text will
            ' NOT be editable. The empty cells WILL be editable.
            For Each c As Cell In Me.CustomGrid1.Cells
                If c.Text = "" Then
                    c.AllowEdit = True
                Else
                    c.AllowEdit = False
                End If
            Next

            For i As Integer = 0 To (Me.CustomGrid1.Cells.Count - 1)
                ' Get the solution and the text.
                solution += ("," + Me.CustomGrid1.Cells(i).CorrectValue.ToString)

                If Me.CustomGrid1.Cells(i).Text = "" Then
                    puzzle += ("," + "0" + Me.CustomGrid1.Cells(i).AllowEdit.ToString)
                Else
                    puzzle += ("," + Me.CustomGrid1.Cells(i).Text + Me.CustomGrid1.Cells(i).AllowEdit.ToString)
                End If
            Next
            ' Trim the commas off the end.
            solution = solution.Trim(",")
            puzzle = puzzle.Trim(",")

            sw.WriteLine(solution)
            sw.WriteLine(puzzle)

            sw.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        End Try

        Return True
    End Function


    Private Sub lblFindSolution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFindSolution.Click
        If FindSolution() Then
            Me.lblFindSolution.Location = New Point(24, 440) ' Middle
            Me.lblPlayNow.Visible = True
            Me.lblSave.Visible = True
        End If
    End Sub

    Private Sub Labels_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblFindSolution.MouseDown, lblPlayNow.MouseDown, lblSave.MouseDown
        sender.BorderStyle = BorderStyle.Fixed3D
        sender.BackColor = SystemColors.AppWorkspace
        sender.Padding = New Padding(0, 2, 0, 0)
    End Sub

    Private Sub Labels_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFindSolution.MouseEnter, lblPlayNow.MouseEnter, lblSave.MouseEnter
        sender.BackColor = SystemColors.ControlDark
        sender.Padding = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub Labels_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFindSolution.MouseLeave, lblPlayNow.MouseLeave, lblSave.MouseLeave
        sender.BorderStyle = BorderStyle.None
        sender.BackColor = SystemColors.AppWorkspace
        sender.Padding = New Padding(2, 0, 0, 2)
    End Sub

    Private Sub Labels_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblFindSolution.MouseUp, lblPlayNow.MouseUp, lblSave.MouseUp
        sender.BorderStyle = BorderStyle.None
        sender.BackColor = SystemColors.ControlDark
        sender.Padding = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub CustomPuzzleDialog_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.lblFindSolution.Location = New Point((Me.Width / 2) - (Me.lblFindSolution.Width / 2), 440) ' Left
        Me.lblPlayNow.Visible = False
        Me.lblSave.Visible = False
    End Sub
End Class
