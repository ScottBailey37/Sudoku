




Public Class CustomGrid
    Inherits UserControl

    Private SudokuGridPadding As Integer = 4
    Private SudokuGridSpacing As Integer = 4
    ''' <summary>
    ''' Boolean flag used to determine when certain character keys are pressed.
    ''' </summary>
    ''' <remarks></remarks>
    Private nonNumberEntered As Boolean = False

    Friend Enum Style
        PlainGrid
        SudokuGrid
    End Enum


    Sub New()
        Me.DoubleBuffered = True

        GenerateNewSudokuGrid()
    End Sub


    Private _cellList As New List(Of Cell)
    Friend Property Cells() As List(Of Cell)
        Get
            Return Me._cellList
        End Get
        Set(ByVal value As List(Of Cell))
            Me._cellList = value
        End Set
    End Property

    Private _userselectedcell As Cell
    ''' <summary>
    ''' Gets the cell that is currently selected on the grid.
    ''' </summary>
    ''' <value></value>
    ''' <returns>The Cell that is currently selected.</returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property UserSelectedCell() As Cell
        Get
            For i As Integer = 0 To (Me.Cells.Count - 1)
                If Me.Cells(i).Selected = True Then
                    Me._userselectedcell = Me.Cells(i)
                    Exit For
                End If
            Next
            Return Me._userselectedcell
        End Get
    End Property

    Private _cellfilledcolor As Color = Color.Beige
    Friend Property CellFilledColor() As Color
        Get
            Return Me._cellfilledcolor
        End Get
        Set(ByVal value As Color)
            Me._cellfilledcolor = value
            For Each _cell As Cell In _cellList
                _cell.FilledColor = value
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellemptycolor As Color = Color.White
    Friend Property CellEmptyColor() As Color
        Get
            Return Me._cellemptycolor
        End Get
        Set(ByVal value As Color)
            Me._cellemptycolor = value
            For Each _cell As Cell In _cellList
                'If _cell.Empty Then
                _cell.EmptyColor = value
                'End If
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellhighlightcolor As Color = Color.LightBlue
    Friend Property CellHighlightColor() As Color
        Get
            Return Me._cellhighlightcolor
        End Get
        Set(ByVal value As Color)
            Me._cellhighlightcolor = value
            For Each _cell As Cell In _cellList
                _cell.HighlightColor = value
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _celltextcolor As Color = Color.Black
    ''' <summary>
    ''' Gets or sets the text color of the given cells.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CellTextColor() As Color
        Get
            Return Me._celltextcolor
        End Get
        Set(ByVal value As Color)
            Me._celltextcolor = value

            For Each _cell As Cell In _cellList
                ' Only set the given cells' text color.
                _cell.TextColor = value
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellbordercolor As Color = Color.Black
    Friend Property CellBorderColor() As Color
        Get
            Return Me._cellbordercolor
        End Get
        Set(ByVal value As Color)
            Me._cellbordercolor = value
            For Each _cell As Cell In _cellList
                _cell.BorderColor = value
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellshaveborder As Boolean = True
    Public Property CellsHaveBorder() As Boolean
        Get
            Return Me._cellshaveborder
        End Get
        Set(ByVal value As Boolean)
            Me._cellshaveborder = value
            For Each _cell As Cell In _cellList
                _cell.HasBorder = value
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellbordersize As Integer = 2
    Friend Property CellBorderSize() As Integer
        Get
            Return Me._cellbordersize
        End Get
        Set(ByVal value As Integer)
            Me._cellbordersize = value
            For Each _cell As Cell In _cellList
                _cell.BorderSize = value
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _gridstyle As Style = Style.SudokuGrid
    ''' <summary>
    ''' Gets or sets the Grid Style.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property GridStyle() As Style
        Get
            Return Me._gridstyle
        End Get
        Set(ByVal value As Style)
            Me._gridstyle = value

            Dim x As Single = SudokuGridPadding
            Dim y As Single = SudokuGridPadding
            Dim index As Integer

            For j As Integer = 1 To Me.SquaresHigh
                For i As Integer = 1 To Me.SquaresWide
                    Me._cellList(index).Rectangle = New Rectangle(x, y, Me.SquareSize.Width, Me.SquareSize.Height)

                    ' ********** ROWS **********
                    Select Case i
                        Case 3, 6
                            If Me.GridStyle = Style.SudokuGrid Then
                                'Create a space between cells for a SudokuGrid
                                x += Me.SquareSize.Width + SudokuGridSpacing
                            Else
                                x += Me.SquareSize.Width
                            End If
                        Case Else
                            x += Me.SquareSize.Width
                    End Select

                    index += 1
                Next

                ' ********** COLUMNS **********
                Select Case Me.SquaresWide * j
                    Case 27, 54 ' START of 2nd and 3rd REGION COLUMN
                        If Me.GridStyle = Style.SudokuGrid Then
                            'Create a space between cells for a SudokuGrid
                            y += Me.SquareSize.Height + SudokuGridSpacing
                            x = SudokuGridPadding
                        Else
                            y += Me.SquareSize.Height
                            x = SudokuGridPadding
                        End If
                    Case Else
                        x = SudokuGridPadding
                        y += Me.SquareSize.Height
                End Select
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    ''' <summary>
    ''' Gets the square size of each square based upon the grid's size.
    ''' </summary>
    ''' <value></value>
    ''' <returns>A System.Drawing.SizeF structure of the square's size.</returns>
    ''' <remarks>We can't always get whole numbers from the computation 
    ''' of the Grid's drawing area so we use the SizeF structure instead of Size.</remarks>
    Friend ReadOnly Property SquareSize() As SizeF
        Get
            ' Use singles because we can't always obtain a whole value.
            Dim SW As Single
            Dim SH As Single
            Dim DW As Single
            Dim DH As Single

            ' ********** PLAIN GRID **********
            If Me.GridStyle = Style.PlainGrid Then
                ' Get the area of the Grid that we can draw in.
                ' This is the area of the grid left over after
                ' subtracting the padding from each of the four sides.
                DW = (Me.Width - (SudokuGridPadding * 2)) ' Area Width
                DH = (Me.Height - (SudokuGridPadding * 2)) ' Area Height

                ' Get the width and height of each Square
                ' based upon the drawing area that we obtained.
                SW = Math.Round((DW / Me.SquaresWide))
                SH = Math.Round((DH / Me.SquaresHigh))

                ' ********** SUDOKU GRID **********
            ElseIf Me.GridStyle = Style.SudokuGrid Then
                ' Get the area of the Grid that we can draw in.
                ' This is the area of the grid left over after
                ' subtracting the padding from each of the four sides and
                ' subtracting the spacing between each of the 3x3 regions.
                DW = ((Me.Width - (SudokuGridPadding * 2)) - (SudokuGridSpacing * 2)) ' Area Width
                DH = ((Me.Height - (SudokuGridPadding * 2)) - (SudokuGridSpacing * 2)) ' Area Height

                ' Get the width and height of each Square
                ' based upon the drawing area that we obtained.
                ' NOTE: These values must be rounded to prevent gaps 
                '       between the squares when borders are turned off.
                SW = Math.Round((DW / Me.SquaresWide))
                SH = Math.Round((DH / Me.SquaresHigh))
            End If

            Return New SizeF(SW, SH)
        End Get
    End Property

    Private _squareswide As Integer = 9
    Friend Property SquaresWide() As Integer
        Get
            Return Me._squareswide
        End Get
        Set(ByVal value As Integer)
            Me._squareswide = value
        End Set
    End Property

    Private _squareshigh As Integer = 9
    Friend Property SquaresHigh() As Integer
        Get
            Return Me._squareshigh
        End Get
        Set(ByVal value As Integer)
            Me._squareshigh = value
        End Set
    End Property


    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)

        ' Try to select a cell(square) only if the Left mouse button was pressed.
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim clickedCell As Cell = Nothing
            Dim previousCell As Cell = Nothing

            For Each _cell As Cell In _cellList
                If _cell.Rectangle.Contains(e.Location) Then
                    'Get the cell that was clicked.
                    clickedCell = _cell
                Else
                    ' Get the cell that was selected 
                    ' because they are different.
                    If _cell.Selected Then
                        previousCell = _cell
                    End If
                End If
            Next

            If clickedCell IsNot Nothing Then
                If clickedCell.AllowEdit = True Then ' An Editable cell.
                    clickedCell.Selected = True

                    ' Add the clicked cell's rectangle to the next repaint.
                    Me.Invalidate(clickedCell.Rectangle)

                    If previousCell IsNot Nothing Then
                        ' The cell that the user clicked was an editable cell.
                        ' So, we need to un-select the previous cell to keep
                        ' from having duplicate cells highlighted simultaneously.
                        previousCell.Selected = False

                        ' Add the previous clicked cell's rectangle to the next repaint.
                        Me.Invalidate(previousCell.Rectangle)
                    End If
                End If
            End If
        End If


        If e.Button = Windows.Forms.MouseButtons.Right Then

        End If
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D1 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad1 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Delete Then
                    'If e.KeyCode <> Keys.Left And e.KeyCode <> Keys.Right _
                    'And e.KeyCode <> Keys.Up And e.KeyCode <> Keys.Down Then
                    ' A key other than 'Backspace', 'Delete', a number key (1-9)
                    ' or a mnemonic was pressed.
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                    'End If
                Else
                    ' Backspace or Delete key was pressed.
                    KeyDown_ClearKey()
                End If
            Else
                ' A number key other than '0' from the 'NumPad' was pressed.
                KeyDown_NumberKey(e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1))
            End If
        Else
            ' A number key other than '0' from the top of the keyboard(OEM keys) was pressed.
            KeyDown_NumberKey(e.KeyData.ToString.Substring(e.KeyData.ToString.Length - 1, 1))
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        ' Me.SelectedCell.Text = e.KeyChar
        ' Check for the flag that was set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control.
            e.Handled = True
            'Else
            '    CircleConflictingCells(Me.SelectedCell.Index)
        End If
    End Sub

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyUp(e)

        Dim selectedCell As Cell = Nothing
        Dim CellToMoveTo As Cell = Nothing
        Dim index As Integer = 0

        ' If a cell is selected get it and its index.
        For Each c As Cell In Me.Cells
            If c.Selected Then
                selectedCell = c
                Exit For
            End If
            index += 1
        Next

        ' Move Left, Right, UP, Down, according to the arrow  
        ' key pressed, and select the next available cell.
        Select Case e.KeyCode
            ' ***** Left Arrow *****
            Case Keys.Left
                If index > 0 Then
                    For i As Integer = (index - 1) To 0 Step -1
                        If Me.Cells(i).AllowEdit = True Then
                            CellToMoveTo = Me.Cells(i)
                            Exit For
                        End If
                    Next
                End If

                ' ***** Right Arrow *****
            Case Keys.Right
                If index < (Me.Cells.Count - 1) Then
                    For i As Integer = (index + 1) To (Me.Cells.Count - 1)
                        If Me.Cells(i).AllowEdit = True Then
                            CellToMoveTo = Me.Cells(i)
                            Exit For
                        End If
                    Next
                End If

                ' ***** Up Arrow *****
            Case Keys.Up
                Dim canGoUp As Boolean = True
                ' Are we in the top-most row?
                If (index - 9) < 0 Then
                    ' Can't go up any farther
                    canGoUp = False
                End If

                If canGoUp = True Then
                    For i As Integer = (index - 9) To 0 Step -9
                        If Me.Cells(i).AllowEdit = True Then
                            CellToMoveTo = Me.Cells(i)
                            Exit For
                        End If
                    Next
                End If

                ' ***** Down Arrow *****
            Case Keys.Down
                Dim canGoDown As Boolean = True
                ' Are we in the bottom-most row?
                If (index + 9) > 80 Then
                    ' Can't go down any farther
                    canGoDown = False
                End If

                If canGoDown = True Then
                    For i As Integer = (index + 9) To 80 Step 9
                        If Me.Cells(i).AllowEdit = True Then
                            CellToMoveTo = Me.Cells(i)
                            Exit For
                        End If
                    Next
                End If
        End Select

        If selectedCell IsNot Nothing And CellToMoveTo IsNot Nothing Then
            selectedCell.Selected = False
            CellToMoveTo.Selected = True

            Me.Invalidate(selectedCell.Rectangle)
            Me.Invalidate(CellToMoveTo.Rectangle)
            Me.Update()
        End If
    End Sub

    ''' <summary>
    ''' Occurs when the size of the Grid is changed.
    ''' </summary>
    ''' <param name="e">A System.EventArgs that contains the event data.</param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)

        ' The form size has changed; update our 
        ' Sudoku grid to the same scale.
        UpdateGridSize()
    End Sub

    ''' <summary>
    ''' Updates the grid's interface when its container has been resized.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub UpdateGridSize()
        Dim x As Single = SudokuGridPadding
        Dim y As Single = SudokuGridPadding
        Dim index As Integer

        For j As Integer = 1 To Me.SquaresHigh
            For i As Integer = 1 To Me.SquaresWide
                Me._cellList(index).Rectangle = New Rectangle(x, y, Me.SquareSize.Width, Me.SquareSize.Height)

                ' ********** ROWS **********
                Select Case i
                    Case 3, 6 ' This is when we hit the beginning of a 3x3 region.
                        If Me.GridStyle = Style.SudokuGrid Then
                            'Create a space between cells for a SudokuGrid
                            x += Me.SquareSize.Width + SudokuGridSpacing
                        Else
                            x += Me.SquareSize.Width
                        End If
                    Case Else
                        x += Me.SquareSize.Width
                End Select

                index += 1
            Next

            ' ********** COLUMNS **********
            Select Case Me.SquaresWide * j
                Case 27, 54 ' This is when we hit the beginning of a 3x3 region.
                    If Me.GridStyle = Style.SudokuGrid Then
                        'Create a space between 3x3 region for a SudokuGrid style.
                        y += Me.SquareSize.Height + SudokuGridSpacing
                        x = SudokuGridPadding
                    Else
                        y += Me.SquareSize.Height
                        x = SudokuGridPadding
                    End If
                Case Else
                    x = SudokuGridPadding
                    y += Me.SquareSize.Height
            End Select
        Next

        Me.Invalidate()
        Me.Update()
    End Sub

    ''' <summary>
    ''' Called when the 'Backspace' or 'Delete' keys are pressed.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub KeyDown_ClearKey()
        ' Find the selected cell.
        For Each _cell As Cell In _cellList
            If _cell.Selected Then
                _cell.Text = ""
                '_cell.EmptyColor = Me.CellEmptyColor
                _cell.AnswerWrong = False
                Me.Invalidate(_cell.Rectangle)
                Me.Update()
            End If
        Next
    End Sub

    ''' <summary>
    ''' Called when a number key, i.e 1-9 (either OEM key or DPad key), is pressed.
    ''' </summary>
    ''' <param name="number">The number of the key that was pressed</param>
    ''' <remarks></remarks>
    Private Sub KeyDown_NumberKey(ByVal number As String)
        For Each _cell As Cell In _cellList
            ' Get the cell that the user has selected.
            If _cell.Selected Then
                ' Set its text(number).
                _cell.Text = number

                ' Redraw the cell to show changes.
                Me.Invalidate(_cell.Rectangle)
                Me.Update()

                ' No need to redraw every cell since only 1 cell can
                ' be selected at a time so we exit the for loop.
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' Creates an empty grid void of a Sudoku puzzle.
    ''' </summary>
    ''' <remarks>Call 'GeneratePuzzle' to fill grid with a valid Sudoku.</remarks>
    Private Sub GenerateNewSudokuGrid()
        Dim x As Single = SudokuGridPadding
        Dim y As Single = SudokuGridPadding
       

        For j As Integer = 1 To Me.SquaresHigh
            For i As Integer = 1 To Me.SquaresWide
                Dim _cell As New Cell(x, y, Me.SquareSize.Width, Me.SquareSize.Height)
                _cell.FilledColor = Me.CellFilledColor
                _cell.EmptyColor = Me.CellEmptyColor
                _cell.HighlightColor = Me.CellHighlightColor
                _cell.TextColor = Me.CellTextColor
                _cell.HasBorder = Me.CellsHaveBorder
                _cell.BorderColor = Me.CellBorderColor
                _cell.BorderSize = Me.CellBorderSize
                _cell.Selected = False
                _cell.AnswerWrong = False
                _cell.AllowEdit = True

                Me._cellList.Add(_cell)

                ' ********** ROWS **********
                Select Case i
                    Case 3, 6
                        If Me.GridStyle = Style.SudokuGrid Then
                            'Create a space between cells for a SudokuGrid
                            x += Me.SquareSize.Width + SudokuGridSpacing
                        Else
                            x += Me.SquareSize.Width
                        End If
                    Case Else
                        x += Me.SquareSize.Width
                End Select
            Next

            ' ********** COLUMNS **********
            Select Case Me.SquaresWide * j
                Case 27, 54
                    If Me.GridStyle = Style.SudokuGrid Then
                        'Create a space between cells for a SudokuGrid
                        y += Me.SquareSize.Height + SudokuGridSpacing
                        x = SudokuGridPadding
                    Else
                        y += Me.SquareSize.Height
                        x = SudokuGridPadding
                    End If
                Case Else
                    x = SudokuGridPadding
                    y += Me.SquareSize.Height
            End Select
        Next

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        '*********************************************************************
        ' DRAWS THE SUDOKU GRID
        '*********************************************************************
        For Each _cell As Cell In _cellList
            ' Only draw a cell if it needs to be repainted.
            If e.ClipRectangle <> _cell.Rectangle Then
                _cell.Draw(e)
            Else
                If _cell.Rectangle = e.ClipRectangle Then
                    _cell.Draw(e)
                    Exit For
                End If
            End If
        Next
        '*********************************************************************
    End Sub
End Class
