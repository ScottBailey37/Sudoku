' Copyright © 2010-2012 Scott Bailey. All rights reserved.




Public Class Form1

#Region "Declarations"
    'Hold the user's game and display settings.
    Private _UserSettings As UserSettings
    ' Boolean flag used to determine when certain character keys are pressed.
    Private nonNumberEntered As Boolean = False

    Private StopWch As Stopwatch

    Private NormalSize As Size
    Private NormalLoc As Point


    ''' <summary>
    ''' Structure to hold the user's game and display settings.
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure UserSettings
        Dim Difficulty As Grid.Level
        Dim GridStyle As Grid.Style
        Dim BorderSize As Integer
        Dim ShowBorder As Boolean
        Dim BorderColor As Color
        Dim EmptyColor As Color
        Dim FilledColor As Color
        Dim HighlightColor As Color
        Dim NumberColor As Color
    End Structure
#End Region

#Region "Subs For Menu Events"
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        AskIfExitApplication()
    End Sub
    Private Sub EasyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EasyToolStripMenuItem.Click
        Me.Grid1.Difficulty = Grid.Level.Easy

        Me.BeginnerToolStripMenuItem.Checked = False
        Me.MediumToolStripMenuItem.Checked = False
        Me.HardToolStripMenuItem.Checked = False
    End Sub
    Private Sub MediumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediumToolStripMenuItem.Click
        Me.Grid1.Difficulty = Grid.Level.Medium

        Me.BeginnerToolStripMenuItem.Checked = False
        Me.EasyToolStripMenuItem.Checked = False
        Me.HardToolStripMenuItem.Checked = False
    End Sub
    Private Sub HardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HardToolStripMenuItem.Click
        Me.Grid1.Difficulty = Grid.Level.Hard

        Me.BeginnerToolStripMenuItem.Checked = False
        Me.EasyToolStripMenuItem.Checked = False
        Me.MediumToolStripMenuItem.Checked = False
    End Sub
    Private Sub BeginnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeginnerToolStripMenuItem.Click
        Me.Grid1.Difficulty = Grid.Level.Beginner

        Me.EasyToolStripMenuItem.Checked = False
        Me.MediumToolStripMenuItem.Checked = False
        Me.HardToolStripMenuItem.Checked = False
    End Sub
    Private Sub BorderColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorderColorToolStripMenuItem.Click
        ColorDialog1.Color = Me.Grid1.CellBorderColor
        'ColorDialog1.Sit()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Grid1.CellBorderColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub BlankSquareColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlankSquareColorToolStripMenuItem.Click
        ColorDialog1.Color = Me.Grid1.CellEmptyColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Grid1.CellEmptyColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub GivenSquareColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GivenSquareColorToolStripMenuItem.Click
        ColorDialog1.Color = Me.Grid1.CellFilledColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Grid1.CellFilledColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub HighlightColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SquareHighlightColorToolStripMenuItem.Click
        ColorDialog1.Color = Me.Grid1.CellHighlightColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Grid1.CellHighlightColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub GivenNumberColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GivenNumberColorToolStripMenuItem.Click
        ColorDialog1.Color = Me.Grid1.GivenCellTextColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Grid1.GivenCellTextColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub HideKeyPadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideKeyPadToolStripMenuItem.Click
        If Me.gbKeyPad.Visible = True Then
            Me.gbKeyPad.Visible = False
            Me.HideKeyPadToolStripMenuItem.Text = "Show Key Pad"

            Me.Grid1.Width = (Me.ClientRectangle.Width - 2)
        Else
            Me.gbKeyPad.Visible = True
            Me.HideKeyPadToolStripMenuItem.Text = "Hide Key Pad"

            Dim crW As Integer = Me.ClientRectangle.Width
            Dim gbKPW As Integer = Me.gbKeyPad.Width
            Me.Grid1.Width = (crW - (gbKPW + (Me.gbKeyPad.Margin.Horizontal + 8)))
        End If
    End Sub
    Private Sub BlankSquareNumberColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlankSquareNumberColorToolStripMenuItem.Click
        ColorDialog1.Color = Me.Grid1.OpenCellTextColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Grid1.OpenCellTextColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub ShowBorder_OnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnToolStripMenuItem.Click
        If Me.OnToolStripMenuItem.Checked Then
            Me.OffToolStripMenuItem.Checked = False
            Me.Grid1.CellsHaveBorder = True
            Me.SizeToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub ShowBorder_OffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffToolStripMenuItem.Click
        If Me.OffToolStripMenuItem.Checked Then
            Me.OnToolStripMenuItem.Checked = False
            Me.Grid1.CellsHaveBorder = False
            Me.SizeToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub ToolStripTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBorderSizeTextBox.TextChanged
        If ToolStripBorderSizeTextBox.Text <> "" Then
            Try
                Me.Grid1.CellBorderSize = CInt(ToolStripBorderSizeTextBox.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub PlainGridToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlainGridToolStripMenuItem.Click
        Me.Grid1.GridStyle = Grid.Style.PlainGrid
        Me.SudokuGridToolStripMenuItem.Checked = False
    End Sub
    Private Sub SudokuGridToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SudokuGridToolStripMenuItem.Click
        Me.Grid1.GridStyle = Grid.Style.SudokuGrid
        Me.PlainGridToolStripMenuItem.Checked = False
    End Sub
    Private Sub CheckAnswersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAnswersToolStripMenuItem.Click
        Me.Grid1.ShowWrongAnswers()
        MsgBox("Number wrong: " + Me.Grid1.NumberOfWrong.ToString)
    End Sub
    Private Sub ShowPuzzleSolutionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPuzzleSolutionToolStripMenuItem.Click
        Me.Grid1.ShowPuzzleSolution()
    End Sub
    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        Me.Grid1.GeneratePuzzle()
    End Sub
    Private Sub SaveSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSettingsToolStripMenuItem.Click
        SaveSettings()
        MsgBox("Saved your settings.")
    End Sub
    Private Sub ToolStripBorderSizeTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripBorderSizeTextBox.KeyDown
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D1 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad1 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace or delete key.
                If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Delete Then
                    ' A key other than 'Backspace', 'Delete', a number key (1-9)
                    ' or a mnemonic was pressed.
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If


        '********************************************************************
        'NOTE: Having a problem with the computer beeping
        '      when the user presses the 'Enter' key. 
        '      Allowing it to be handled above will stop the beeping.
        '********************************************************************

        'If the user pressed 'Enter' key then close the dropdown menu.
        If e.KeyCode = Keys.Enter Then
            Me.OptionsToolStripMenuItem.HideDropDown()
        End If
    End Sub
    Private Sub ToolStripBorderSizeTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStripBorderSizeTextBox.KeyPress
        ' Check for the flag set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control.
            e.Handled = True
        End If
    End Sub
    Private Sub SizeToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SizeToolStripMenuItem.DropDownOpening
        ' Show the border size of the grid.
        ' We set it this way incase the user deletes the border size from the textbox
        ' and closes it without entering another number. This assures that the border
        ' size will always be shown when the user clicks the 'Size' menu item.
        Me.ToolStripBorderSizeTextBox.Text = Me.Grid1.CellBorderSize.ToString
    End Sub
#End Region

#Region "Form Subs For Events"
    Sub New()
        ' Initialize all of our form's components.
        InitializeComponent()

        ' Set our timer interval
        Me.TimerUpdateClock.Interval = 50

        ' Initialize our stopwatch
        StopWch = New Stopwatch

        'Me.lblClock.Text = StopWch.Elapsed.ToString

        ' Setup difficulty menu item checkmarks
        If Me.Grid1.Difficulty = Grid.Level.Beginner Then
            Me.BeginnerToolStripMenuItem.Checked = True
            Me.EasyToolStripMenuItem.Checked = False
            Me.MediumToolStripMenuItem.Checked = False
            Me.HardToolStripMenuItem.Checked = False
        ElseIf Me.Grid1.Difficulty = Grid.Level.Easy Then
            Me.BeginnerToolStripMenuItem.Checked = False
            Me.EasyToolStripMenuItem.Checked = True
            Me.MediumToolStripMenuItem.Checked = False
            Me.HardToolStripMenuItem.Checked = False
        ElseIf Me.Grid1.Difficulty = Grid.Level.Medium Then
            Me.MediumToolStripMenuItem.Checked = True
            Me.BeginnerToolStripMenuItem.Checked = False
            Me.EasyToolStripMenuItem.Checked = False
            Me.HardToolStripMenuItem.Checked = False
        ElseIf Me.Grid1.Difficulty = Grid.Level.Hard Then
            Me.HardToolStripMenuItem.Checked = True
            Me.BeginnerToolStripMenuItem.Checked = False
            Me.EasyToolStripMenuItem.Checked = False
            Me.MediumToolStripMenuItem.Checked = False
        End If

        ' Setup grid style menu item checkmarks
        If Me.Grid1.GridStyle = Grid.Style.PlainGrid Then
            Me.PlainGridToolStripMenuItem.Checked = True
            Me.SudokuGridToolStripMenuItem.Checked = False
        ElseIf Me.Grid1.GridStyle = Grid.Style.SudokuGrid Then
            Me.SudokuGridToolStripMenuItem.Checked = True
            Me.PlainGridToolStripMenuItem.Checked = False
        End If
        ' Setup cells have borders menu item checkmarks
        If Me.Grid1.CellsHaveBorder Then
            Me.OnToolStripMenuItem.Checked = True
            Me.OffToolStripMenuItem.Checked = False
            Me.SizeToolStripMenuItem.Enabled = True
        Else
            Me.OnToolStripMenuItem.Checked = False
            Me.OffToolStripMenuItem.Checked = True
            Me.SizeToolStripMenuItem.Enabled = False
        End If

        'CreateRegKeys()
    End Sub

    Private Sub StartStopClock()
        If StopWch.IsRunning Then
            ' Stop the stopwatch
            StopWch.Stop()
            ' Stop the timer
            Me.TimerUpdateClock.Stop()
        Else
            ' Start the timer that will update the clock label to show elapsed time.
            Me.TimerUpdateClock.Start()
            ' Reset the stopwatch and start time
            StopWch.Reset()
            StopWch.Start()
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SaveSettings()
    End Sub

    Private Sub NumberLabels_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl1.MouseEnter, lbl2.MouseEnter, lbl3.MouseEnter, lbl7.MouseEnter, lbl8.MouseEnter, lbl9.MouseEnter, lbl6.MouseEnter, lbl5.MouseEnter, lbl4.MouseEnter, lblClear.MouseEnter
        'sender.BorderStyle = BorderStyle.Fixed3D
        sender.BackColor = SystemColors.ControlDark
        sender.Padding = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub NumberLabels_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl1.MouseLeave, lbl2.MouseLeave, lbl3.MouseLeave, lbl7.MouseLeave, lbl8.MouseLeave, lbl9.MouseLeave, lbl6.MouseLeave, lbl5.MouseLeave, lbl4.MouseLeave, lblClear.MouseLeave
        sender.BorderStyle = BorderStyle.None
        sender.BackColor = SystemColors.AppWorkspace
        sender.Padding = New Padding(2, 0, 0, 3)
    End Sub

    Private Sub NumberLabels_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl1.MouseDown, lbl2.MouseDown, lbl3.MouseDown, lbl7.MouseDown, lbl8.MouseDown, lbl9.MouseDown, lbl6.MouseDown, lbl5.MouseDown, lbl4.MouseDown
        sender.BorderStyle = BorderStyle.Fixed3D
        sender.BackColor = SystemColors.AppWorkspace 'Control
        sender.Padding = New Padding(0, 2, 0, 0)

        'Make sure that a cell is selected
        If Me.Grid1.UserSelectedCell IsNot Nothing Then
            If Me.Grid1.UserSelectedCell.Selected = True Then
                ' Change it's text to the text of the clicked label.
                Me.Grid1.UserSelectedCell.Text = sender.name.substring(3, 1)

                '' Update the conflicting squares for the square.
                'Me.Grid1.CircleConflictingCells(Me.Grid1.UserSelectedCell.Index)

                ' Redraw to show changes.
                Me.Grid1.Invalidate(Me.Grid1.UserSelectedCell.Rectangle)
                Me.Grid1.Update()

                'Did the user solve the puzzle.
                If Me.Grid1.PuzzleSolved() Then
                    Me.Grid1.ShowUserSolved()
                End If
            End If
        End If
    End Sub

    Private Sub NumberLabels_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl1.MouseUp, lbl2.MouseUp, lbl3.MouseUp, lbl7.MouseUp, lbl8.MouseUp, lbl9.MouseUp, lbl6.MouseUp, lbl5.MouseUp, lbl4.MouseUp, lblClear.MouseUp
        sender.BorderStyle = BorderStyle.None
        sender.BackColor = SystemColors.ControlDark
        sender.Padding = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub lblClear_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblClear.MouseDown
        sender.BorderStyle = BorderStyle.Fixed3D
        sender.BackColor = SystemColors.AppWorkspace
        sender.Padding = New Padding(0, 2, 0, 0)

        'Make sure that a cell is selected
        If Me.Grid1.UserSelectedCell IsNot Nothing Then
            If Me.Grid1.UserSelectedCell.Selected = True Then
                ' Change it's text to empty.
                Me.Grid1.UserSelectedCell.Text = ""
                Me.Grid1.UserSelectedCell.AnswerWrong = False

                '' Update the conflicting squares for the square.
                'Me.Grid1.CircleConflictingCells(Me.Grid1.UserSelectedCell.Index)

                ' Redraw to show changes.
                Me.Grid1.Invalidate(Me.Grid1.UserSelectedCell.Rectangle)
                Me.Grid1.Update()
            End If
        End If
    End Sub

    Private Sub TimerUpdateClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerUpdateClock.Tick
        Dim ts As TimeSpan = StopWch.Elapsed

        ' Format and display the TimeSpan value.
        Me.lblClock.Text = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds)
    End Sub
#End Region

#Region "Grid Subs For Events"
    Private Sub Grid1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Escape Then  ' 27 - Close the application?
            Me.AskIfExitApplication()
            Exit Sub ' Return
        ElseIf e.KeyCode = Keys.S Then ' 83- Solve the current puzzle
            Me.Grid1.ShowPuzzleSolution()
            Exit Sub ' Return
        ElseIf e.KeyCode = Keys.N Then ' 78 -  Get a new puzzle
            Me.Grid1.GeneratePuzzle()
            Exit Sub ' Return
        ElseIf e.KeyCode = Keys.C Then ' 67 - Check the users answers
            Me.Grid1.ShowWrongAnswers()
            Exit Sub ' Return
            'ElseIf e.KeyCode = Keys.Left Then
            '    MsgBox("Left Arrow ")
            'ElseIf e.KeyCode = Keys.Right Then
            '    MsgBox("Right Arrow ")
            'ElseIf e.KeyCode = Keys.Up Then

            'ElseIf e.KeyCode = Keys.Down Then

        End If
    End Sub
#End Region

#Region "Subs And Functions"
    <System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
    Private Shared Function DestroyIcon(ByVal handle As IntPtr) As Boolean
    End Function
    Friend Sub AskIfExitApplication()
        If MsgBox("Are you sure you want to exit?", _
           MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub CreateRegKeys()
        My.Computer.Registry.CurrentUser.CreateSubKey("Sudoku")
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
        "Difficulty", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
                    "Difficulty", Me.Grid1.Difficulty)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
               "GridStyle", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
                  "GridStyle", Me.Grid1.GridStyle.ToString)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
               "BorderSize", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
                   "BorderSize", Me.Grid1.CellBorderSize.ToString)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                       "ShowBorder", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
            "ShowBorder", Me.Grid1.CellsHaveBorder.ToString)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                       "BorderColor", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
         "BorderColor", Me.Grid1.CellBorderColor.ToString)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                       "EmptyColor", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
           "EmptyColor", Me.Grid1.CellEmptyColor.ToString)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                       "FilledColor", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
        "FilledColor", Me.Grid1.CellFilledColor.ToString)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                               "HighlightColor", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
                   "HighlightColor", Me.Grid1.CellHighlightColor.ToString)
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                               "NumberColor", Nothing) Is Nothing Then
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
            "NumberColor", Me.Grid1.GivenCellTextColor.ToString)
        End If









        Me.Grid1.Difficulty = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                 "Difficulty", Nothing)

        Me.Grid1.GridStyle = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                "GridStyle", Nothing)

        Me.Grid1.CellBorderSize = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                "BorderSize", Nothing)

        Me.Grid1.CellsHaveBorder = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                       "ShowBorder", Nothing)

        Me.Grid1.CellBorderColor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                      "BorderColor", Nothing)

        Me.Grid1.CellEmptyColor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                       "EmptyColor", Nothing)

        Me.Grid1.CellFilledColor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                       "FilledColor", Nothing)

        Me.Grid1.CellHighlightColor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                               "HighlightColor", Nothing)

        Me.Grid1.GivenCellTextColor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Sudoku", _
                                "NumberColor", Nothing)

    End Sub
    Private Sub SaveSettings()
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
                        "Difficulty", Me.Grid1.Difficulty.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
              "GridStyle", Me.Grid1.GridStyle.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
               "BorderSize", Me.Grid1.CellBorderSize.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
        "ShowBorder", Me.Grid1.CellsHaveBorder.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
     "BorderColor", Me.Grid1.CellBorderColor.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
       "EmptyColor", Me.Grid1.CellEmptyColor.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
    "FilledColor", Me.Grid1.CellFilledColor.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
               "HighlightColor", Me.Grid1.CellHighlightColor.ToString)

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Sudoku", _
        "NumberColor", Me.Grid1.GivenCellTextColor.ToString)
    End Sub
    Private Sub CreateIcoFile()
        Dim g As Graphics = Me.CreateGraphics

        Dim bmp As Bitmap = My.Resources.SudokuGridIcon2

        ' Get an Hicon for myBitmap.
        Dim HIcon As IntPtr = bmp.GetHicon()

        ' Create a new icon from the handle.
        Dim newIcon As Icon = System.Drawing.Icon.FromHandle(HIcon)

        Me.Icon = newIcon
        ' Destroy the icon, since the form creates its 
        ' own copy of the icon.
        DestroyIcon(newIcon.Handle)
    End Sub
#End Region

    Private Function SavePuzzle(ByVal filepath As String) As Boolean
        Try
            Dim sw As New IO.StreamWriter(filepath, False)
            Dim solution As String = ""
            Dim puzzle As String = ""

            For i As Integer = 0 To (Me.Grid1.Cells.Count - 1)
                ' Get the solution and the text.
                solution += ("," + Me.Grid1.Cells(i).CorrectValue.ToString)

                If Me.Grid1.Cells(i).Text = "" Then
                    puzzle += ("," + "0" + Me.Grid1.Cells(i).AllowEdit.ToString)
                Else
                    puzzle += ("," + Me.Grid1.Cells(i).Text + Me.Grid1.Cells(i).AllowEdit.ToString)
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

    Private Function LoadPuzzle(ByVal filepath As String) As Boolean
        Try
            Dim sr As New IO.StreamReader(filepath)
            Dim line As String = ""
            Dim solution() As String = {}
            Dim puzzle() As String = {}
            Dim splitChar() As Char = {","}
            Dim ValidPuzzle As Boolean

            While Not sr.EndOfStream
                line = sr.ReadLine

                If line <> "" Then
                    ' The solution is first in the file
                    ' so 'solution=0' means that it hasn't 
                    ' been loaded yet.
                    If solution.Length = 0 Then
                        solution = line.Split(splitChar, StringSplitOptions.None)
                    Else
                        puzzle = line.Split(splitChar)
                    End If
                End If

            End While

            ' Verify the validity of the puzzle file.
            If solution.Length = 81 And puzzle.Length = 81 Then
                ValidPuzzle = True
            End If

            If Not ValidPuzzle Then
                Return False
            End If

            For i As Integer = 0 To (solution.Length - 1)
                Me.Grid1.Cells(i).Selected = False
                Me.Grid1.Cells(i).CorrectValue = solution(i).ToString

                'Value of "0" means EMPTY and EDITABLE.
                If puzzle(i).Substring(0, 1) = "0" Then
                    Me.Grid1.Cells(i).Text = ""
                Else
                    Me.Grid1.Cells(i).Text = puzzle(i).Substring(0, 1)
                End If

                ' Determine if the square is Editable or not.
                Dim AllowEdit As Boolean = puzzle(i).Substring(1, (puzzle(i).Length - 1))
                Me.Grid1.Cells(i).AllowEdit = AllowEdit

                ' Set the square's text color.
                If AllowEdit Then
                    Me.Grid1.Cells(i).TextColor = Me.Grid1.OpenCellTextColor
                Else
                    Me.Grid1.Cells(i).TextColor = Me.Grid1.GivenCellTextColor
                End If
            Next

            ' Select the first 'editable' cell we come to and exit the loop.
            For Each c As Cell In Me.Grid1.Cells
                If c.AllowEdit Then
                    c.Selected = True
                    Exit For
                End If
            Next

            ' Close the streamreader
            sr.Close()

            ' Clear all the conflicting squares circles.
            Me.Grid1.CircledNumbers.Clear()

            Me.Grid1.Invalidate()
            Me.Grid1.Update()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return True
    End Function

    Private Sub SavePuzzleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePuzzleToolStripMenuItem.Click
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If SavePuzzle(Me.SaveFileDialog1.FileName) Then
                MsgBox("Your puzzle was saved.")
            End If
        End If
    End Sub

    Private Sub LoadPuzzleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadPuzzleToolStripMenuItem.Click
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            LoadPuzzle(Me.OpenFileDialog1.FileName)
        End If
    End Sub


    Private Sub StartLearningModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartLearningModeToolStripMenuItem.Click
        ' If Learning Mode is OFF we will turn it ON 
        ' otherwise we will turn it OFF.
        If Me.Grid1.LearningModeActivated = False Then
            ' Disable some menu items.
            Me.FileToolStripMenuItem.Enabled = False
            Me.GameToolStripMenuItem.Enabled = False
            Me.OptionsToolStripMenuItem.Enabled = False
            Me.SettingsToolStripMenuItem.Enabled = False
            Me.gbKeyPad.Enabled = False

            ' Show checkmark and change text to indicate Learning Mode is ON.
            Me.StartLearningModeToolStripMenuItem.Checked = True
            Me.StartLearningModeToolStripMenuItem.Text = "Stop &Learning Mode"

            ' Maximize our window
            Me.Location = New Point(0, 0)
            Me.Size = My.Computer.Screen.WorkingArea.Size
            Me.WindowState = FormWindowState.Maximized
            Me.MaximizeBox = False

            ' Turn ON the Learning Mode
            Me.Grid1.LearningModeActivated = True
        Else
            ' Enable our menu items.
            Me.FileToolStripMenuItem.Enabled = True
            Me.GameToolStripMenuItem.Enabled = True
            Me.OptionsToolStripMenuItem.Enabled = True
            Me.SettingsToolStripMenuItem.Enabled = True
            Me.gbKeyPad.Enabled = True

            ' Turn OFF the Learning Mode
            Me.Grid1.LearningModeActivated = False

            ' Show checkmark and change text to indicate Learning Mode is OFF.
            Me.StartLearningModeToolStripMenuItem.Checked = False
            Me.StartLearningModeToolStripMenuItem.Text = "Start &Learning Mode"

            ' Reset our window back to normal.
            Me.WindowState = FormWindowState.Normal
            Me.MaximizeBox = True
            Me.Location = Me.NormalLoc
            Me.Size = Me.NormalSize
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        If LMSettingsDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Grid1.EnableHelpPopup = LMSettingsDialog.cbEnableHelp.Checked
            Me.Grid1.EnableHints = LMSettingsDialog.cbEnableHints.Checked
            Me.Grid1.ShowCircled = LMSettingsDialog.cbCircle.Checked

            Me.Grid1.Invalidate()
            Me.Grid1.Update()
        End If
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.NormalSize = Me.Size
        Me.NormalLoc = Me.Location
    End Sub

    Private Sub CreatePuzzleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreatePuzzleToolStripMenuItem.Click
        For Each c As Cell In CustomPuzzleDialog.CustomGrid1.Cells
            c.Text = ""
            c.Index = 0
            c.Row = 0
            c.Column = 0
            c.Region = 0
            c.Selected = False
        Next

        CustomPuzzleDialog.Solution = Nothing

        Dim result As DialogResult = CustomPuzzleDialog.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            ' What next?
        End If
    End Sub
End Class
