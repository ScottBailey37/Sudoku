' Copyright © 2010-2012 Scott Bailey. All rights reserved.

''' <summary>
''' Represents a Sudoku grid.
''' </summary>
''' <remarks></remarks>
Public Class Grid
    Inherits System.Windows.Forms.UserControl

#Region "Declarations"

    ''' <summary>
    ''' Grid style.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Style
        PlainGrid
        SudokuGrid
    End Enum

    ''' <summary>
    ''' Game difficulty levels.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Level
        Beginner
        Easy
        Medium
        Hard
    End Enum


    ''' <summary>
    ''' Boolean flag used to determine when certain character keys are pressed.
    ''' </summary>
    ''' <remarks></remarks>
    Private nonNumberEntered As Boolean = False
    ''' <summary>
    ''' The spacing between each region of the Sudoku grid.
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SudokuGridSpacing As Integer = 4
    ''' <summary>
    ''' The padding on all four sides of the Grid.
    ''' </summary>
    ''' <remarks></remarks>
    Private Const SudokuGridPadding As Integer = 2
    ''' <summary>
    ''' Holds the valid Sudoku puzzle.
    ''' </summary>
    ''' <remarks></remarks>
    Private sqList As List(Of Square)
    ''' <summary>
    ''' Used to display the LearningModeSystem to the user. 
    ''' </summary>
    ''' <remarks></remarks>
    Friend LearningMode As LearningModeSystem
    ''' <summary>
    ''' Used to animate items and incremental GUI updates.
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents Timer1 As New Timer

#End Region

    Sub New()
        Me.DoubleBuffered = True
        Me.Margin = New Padding(-1)

        ' Create Empty Grid. 
        ' This sub creates the sudoku puzzle after creating an empty grid.
        CreateEmptyGrid()

        ' Initialize the LearningMode control.
        LearningMode = New LearningModeSystem

        ' Set up some timer stuff.
        Me.Timer1.Interval = 4000
        AddHandler Timer1.Tick, AddressOf Me.Timer1_Tick
    End Sub


#Region "Learning Mode - Properties"
    Private _learningModeActivated As Boolean
    Friend Property LearningModeActivated() As Boolean
        Get
            Return Me._learningModeActivated
        End Get
        Set(ByVal value As Boolean)
            Me._learningModeActivated = value
            Me.LearningMode.PopupActivated = value

            ' Clear the Sudoku puzzle of selected or circled objects.
            Me.SelectedRows.Clear()
            Me.SelectedColumns.Clear()
            Me.SelectedRegions.Clear()
            Me.SelectedCells.Clear()
            Me.CircledNumbers.Clear()

            ' For a good UI we will Un-Select the normally selected cell.
            If value = True Then ' Learning Mode is ON
                ' Unselect the 'selected' cell.
                For Each c As Cell In Me.Cells
                    c.Selected = False
                    'c.AllowEdit = False
                Next
            Else ' Learning Mode is OFF
                ' Select the first Editable cell
                ' that we come to.
                For Each c As Cell In Me.Cells
                    If c.AllowEdit = True Then
                        ' Select only 1 cell and exit.
                        c.Selected = True
                        Exit For
                    End If
                Next
            End If

            ' If Learning Mode is ON then stop
            ' user interaction with the grid.
            If value = True Then
                ' Disable the grid.
                Me.Enabled = False
            Else ' Learning Mode is OFF
                ' Enable the grid.
                Me.Enabled = True
            End If

            ' If Learning Mode is ON then start the timer
            ' that takes care of all the Learning Mode stuff.
            If value = True Then
                Me.Timer1.Start()
            Else ' Learning Mode is OFF
                ' Stop the timer.
                Me.Timer1.Stop()
            End If

            ' Repaint the grid
            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _circlednumbers As New List(Of Rectangle)
    Friend Property CircledNumbers() As List(Of Rectangle)
        Get
            Return Me._circlednumbers
        End Get
        Set(ByVal value As List(Of Rectangle))
            Me._circlednumbers = value
        End Set
    End Property

    ''' <summary>
    ''' The row that is currently selected(border drawn around it).
    ''' </summary>
    ''' <remarks></remarks>
    Private _selectedrows As New List(Of Rectangle)
    Friend Property SelectedRows() As List(Of Rectangle)
        Get
            Return Me._selectedrows
        End Get
        Set(ByVal value As List(Of Rectangle))
            Me._selectedrows = value
        End Set
    End Property

    ''' <summary>
    ''' The column that is currently selected(border drawn around it).
    ''' </summary>
    ''' <remarks></remarks>
    Private _selectedcolumns As New List(Of Rectangle)
    Friend Property SelectedColumns() As List(Of Rectangle)
        Get
            Return Me._selectedcolumns
        End Get
        Set(ByVal value As List(Of Rectangle))
            Me._selectedcolumns = value
        End Set
    End Property

    ''' <summary>
    ''' The region that is currently selected(border drawn around it).
    ''' </summary>
    ''' <remarks></remarks>
    Private _selectedregions As New List(Of Rectangle)
    Friend Property SelectedRegions() As List(Of Rectangle)
        Get
            Return Me._selectedregions
        End Get
        Set(ByVal value As List(Of Rectangle))
            Me._selectedregions = value
        End Set
    End Property

    ''' <summary>
    ''' The cell that is currently selected(border drawn around it).
    ''' </summary>
    ''' <remarks></remarks>
    Private _selectedcells As New List(Of Rectangle)
    Friend Property SelectedCells() As List(Of Rectangle)
        Get
            Return Me._selectedcells
        End Get
        Set(ByVal value As List(Of Rectangle))
            Me._selectedcells = value
        End Set
    End Property

    Private _showcircled As Boolean = True
    Friend Property ShowCircled() As Boolean
        Get
            Return Me._showcircled
        End Get
        Set(ByVal value As Boolean)
            Me._showcircled = value
        End Set
    End Property

    Private _enablehints As Boolean
    Friend Property EnableHints() As Boolean
        Get
            Return Me._enablehints
        End Get
        Set(ByVal value As Boolean)
            Me._enablehints = value
        End Set
    End Property

    Private _enablehelppopup As Boolean = True
    Friend Property EnableHelpPopup() As Boolean
        Get
            Return Me._enablehelppopup
        End Get
        Set(ByVal value As Boolean)
            Me._enablehelppopup = value
        End Set
    End Property
#End Region


#Region "Properties"
    Private _cellList As New List(Of Cell)
    ''' <summary>
    ''' Holds all the grid's cells(squares).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
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

    Private _gridstyle As Style = Style.SudokuGrid
    ''' <summary>
    ''' Gets or sets the Grid Style.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridStyle() As Style
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

    Private _difficulty As Level
    Public Property Difficulty() As Level
        Get
            Return Me._difficulty
        End Get
        Set(ByVal value As Level)
            Me._difficulty = value
            'GeneratePuzzle()
        End Set
    End Property

    Private _cellfilledcolor As Color
    Public Property CellFilledColor() As Color
        Get
            Return Me._cellfilledcolor
        End Get
        Set(ByVal value As Color)
            Me._cellfilledcolor = value
            For Each _cell As Cell In _cellList
                'If _cell.Text <> "" Then
                _cell.FilledColor = value
                'End If
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellemptycolor As Color
    Public Property CellEmptyColor() As Color
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

    Private _cellhighlightcolor As Color
    Public Property CellHighlightColor() As Color
        Get
            Return Me._cellhighlightcolor
        End Get
        Set(ByVal value As Color)
            Me._cellhighlightcolor = value
            For Each _cell As Cell In _cellList
                'If _cell.Empty = "" Then
                _cell.HighlightColor = value
                'End If
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellanswerwrongcolor As Color
    Public Property CellAnswerWrongColor() As Color
        Get
            Return Me._cellanswerwrongcolor
        End Get
        Set(ByVal value As Color)
            Me._cellanswerwrongcolor = value
            For Each _cell As Cell In _cellList
                _cell.AnswerWrongColor = value
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellbordercolor As Color
    Public Property CellBorderColor() As Color
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

    Private _circledConflictColor As Color = Color.FromArgb(255, 200, 0, 0)
    Public Property CircledConflictColor() As Color
        Get
            Return Me._circledConflictColor
        End Get
        Set(ByVal value As Color)
            Me._circledConflictColor = value

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _givencelltextcolor As Color
    ''' <summary>
    ''' Gets or sets the text color of the given cells.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GivenCellTextColor() As Color
        Get
            Return Me._givencelltextcolor
        End Get
        Set(ByVal value As Color)
            Me._givencelltextcolor = value

            For Each _cell As Cell In _cellList
                ' Only set the given cells' text color.
                If _cell.AllowEdit = False Then
                    _cell.TextColor = value
                End If
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _opencelltextcolor As Color
    ''' <summary>
    ''' Gets or sets the text color of the blank(editable) cells.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OpenCellTextColor() As Color
        Get
            Return Me._opencelltextcolor
        End Get
        Set(ByVal value As Color)
            Me._opencelltextcolor = value

            For Each _cell As Cell In _cellList
                ' Only set the blank cells' text color.
                If _cell.AllowEdit = True Then
                    _cell.TextColor = value
                End If
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

    Private _showeditables As Boolean
    ''' <summary>
    ''' Gets or sets a value that determines(if the cell is editable) if it
    ''' should be drawn with a different color text than a NON-Editable cell.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>This property is to show the Editables from the NON-Editables just
    '''  in case the Editable cells have the same backsolor as the NON-Editable cells.
    '''  Otherwise, if the Editable cell has a number value in it and the backcolor 
    '''  is the same as the NON-Editable cell, you can't tell the difference between 
    '''  the two.</remarks>
    Public Property ShowAllEditables() As Boolean
        Get
            Return Me._showeditables
        End Get
        Set(ByVal value As Boolean)
            Me._showeditables = value
            For Each c As Cell In Me.Cells
                If c.AllowEdit Then
                    c.ShowAsEditable = value
                End If
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellbordersize As Integer = 1
    Public Property CellBorderSize() As Integer
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

    Private _cellemptyimage As Drawing.Bitmap
    Public Property CellEmptyImage() As Drawing.Bitmap
        Get
            Return Me._cellemptyimage
        End Get
        Set(ByVal value As Drawing.Bitmap)
            Me._cellemptyimage = value
            For Each _cell As Cell In _cellList
                'If _cell.Empty Then
                _cell.EmptyImage = value
                'End If
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellfilledimage As Drawing.Bitmap
    Public Property CellFilledImage() As Drawing.Bitmap
        Get
            Return Me._cellfilledimage
        End Get
        Set(ByVal value As Drawing.Bitmap)
            Me._cellfilledimage = value
            For Each _cell As Cell In _cellList
                'If Not _cell.Empty Then
                _cell.FilledImage = value
                'End If
            Next

            Me.Invalidate()
            Me.Update()
        End Set
    End Property

    Private _cellanswerwrongimage As Drawing.Bitmap
    Public Property CellAnswerWrongImage() As Drawing.Bitmap
        Get
            Return Me._cellanswerwrongimage
        End Get
        Set(ByVal value As Drawing.Bitmap)
            Me._cellanswerwrongimage = value
            For Each _cell As Cell In _cellList
                'If _cell.Empty Then 'And _cell.AnswerWrong
                _cell.AnswerWrongImage = value
                'End If
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

#End Region

#Region "Subs & Functions"
    ''' <summary>
    ''' Creates an empty grid void of a Sudoku puzzle.
    ''' </summary>
    ''' <remarks>Call 'GeneratePuzzle' to fill grid with a valid Sudoku.</remarks>
    Friend Sub CreateEmptyGrid()
        'Start with an empty list
        _cellList.Clear()

        Dim x As Single = SudokuGridPadding
        Dim y As Single = SudokuGridPadding

        For j As Integer = 1 To Me.SquaresHigh
            For i As Integer = 1 To Me.SquaresWide
                Dim _cell As New Cell(x, y, Me.SquareSize.Width, Me.SquareSize.Height)
                _cell.FilledColor = Me.CellFilledColor
                _cell.EmptyColor = Me.CellEmptyColor
                _cell.HighlightColor = Me.CellHighlightColor
                _cell.AnswerWrongColor = Me.CellAnswerWrongColor
                _cell.BorderColor = Me.CellBorderColor
                _cell.TextColor = Me.GivenCellTextColor
                _cell.EmptyImage = Me.CellEmptyImage
                _cell.FilledImage = Me.CellFilledImage
                _cell.AnswerWrongImage = Me.CellAnswerWrongImage
                _cell.HasBorder = Me.CellsHaveBorder
                _cell.BorderSize = Me.CellBorderSize
                _cell.Selected = False
                _cell.AnswerWrong = False
                _cell.AllowEdit = False

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

        ' Fill our empty grid with a valid Sudoku puzzle.
        GeneratePuzzle()
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
    ''' Generates a new sudoku puzzle.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub GeneratePuzzle()

        ' In case this is not the first puzzle of the game
        ' clear all the conflicting circles, selected squares,
        ' rows, columns, and regions from the grid.
        Me.CircledNumbers.Clear()

        ' Update the screen to clear any
        ' unwanted circles, selections, etc.
        Me.Update()

        ' Create a new puzzle.
        SudokuGenerator.GenerateGrid()
        sqList = SudokuGenerator.SudokuGrid

        ' Set all celld on the grid to their solution.
        For i As Integer = 0 To _cellList.Count - 1
            _cellList(i).CorrectValue = sqList(i).Value
            _cellList(i).Index = sqList(i).Index
            _cellList(i).Column = sqList(i).Column
            _cellList(i).Row = sqList(i).Row
            _cellList(i).Region = sqList(i).Region
            _cellList(i).Text = sqList(i).Value
            _cellList(i).FilledColor = Me.CellFilledColor
            _cellList(i).EmptyColor = Me.CellEmptyColor
            _cellList(i).HighlightColor = Me.CellHighlightColor
            _cellList(i).AnswerWrongColor = Me.CellAnswerWrongColor
            _cellList(i).BorderColor = Me.CellBorderColor
            _cellList(i).TextColor = Me.GivenCellTextColor
            _cellList(i).EmptyImage = Me.CellEmptyImage
            _cellList(i).FilledImage = Me.CellFilledImage
            _cellList(i).AnswerWrongImage = Me.CellAnswerWrongImage
            _cellList(i).HasBorder = Me.CellsHaveBorder
            _cellList(i).BorderSize = Me.CellBorderSize
            _cellList(i).Selected = False
            _cellList(i).AnswerWrong = False
            _cellList(i).AllowEdit = False
        Next

        Select Case Me.Difficulty
            Case Level.Beginner ' Difficulty
                'Clear some of the values out of random cells
                Dim rand As New Random
                Dim i As Integer
                Dim value As Integer
                While i <> 2 ' Number of cells to clear.
                    value = rand.Next(0, (_cellList.Count - 1))

                    If _cellList(value).Text <> "" Then
                        _cellList(value).Text = ""
                        _cellList(value).AllowEdit = True
                        ' This is a blank or editable cell so it's text color 
                        ' could be different than the given cells' text color
                        ' depending on if the user has changed them so that 
                        ' they are different. Since this is an option that 
                        ' they have, we set this color just in case.
                        _cellList(value).TextColor = Me.OpenCellTextColor
                        i += 1
                    End If
                End While
            Case Level.Easy ' Difficulty
                'Clear some of the values out of random cells
                Dim rand As New Random
                Dim i As Integer
                Dim value As Integer
                While i <> 20 ' Number of cells to clear.
                    value = rand.Next(0, (_cellList.Count - 1))

                    If _cellList(value).Text <> "" Then
                        _cellList(value).Text = ""
                        _cellList(value).AllowEdit = True
                        ' This is a blank or editable cell so it's text color 
                        ' could be different than the given cells' text color
                        ' depending on if the user has changed them so that 
                        ' they are different. Since this is an option that 
                        ' they have, we set this color just in case.
                        _cellList(value).TextColor = Me.OpenCellTextColor
                        i += 1
                    End If
                End While
            Case Level.Medium ' Difficulty
                'Clear some of the values out of random cells
                Dim rand As New Random
                Dim i As Integer
                Dim value As Integer
                While i <> 35 ' Number of cells to clear.
                    value = rand.Next(0, (_cellList.Count - 1))

                    If _cellList(value).Text <> "" Then
                        _cellList(value).Text = ""
                        _cellList(value).AllowEdit = True
                        ' This is a blank or editable cell so it's text color 
                        ' could be different than the given cells' text color
                        ' depending on if the user has changed them so that 
                        ' they are different. Since this is an option that 
                        ' they have, we set this color just in case.
                        _cellList(value).TextColor = Me.OpenCellTextColor
                        i += 1
                    End If
                End While
            Case Level.Hard ' Difficulty
                'Clear some of the values out of random cells
                Dim rand As New Random
                Dim i As Integer
                Dim value As Integer
                While i <> 45 ' Number of cells to clear.
                    value = rand.Next(0, (_cellList.Count - 1))

                    If _cellList(value).Text <> "" Then
                        _cellList(value).Text = ""
                        _cellList(value).AllowEdit = True
                        ' This is a blank or editable cell so it's text color 
                        ' could be different than the given cells' text color
                        ' depending on if the user has changed them so that 
                        ' they are different. Since this is an option that 
                        ' they have, we set this color just in case.
                        _cellList(value).TextColor = Me.OpenCellTextColor
                        i += 1
                    End If
                End While
        End Select

        ' Pre-select a empty cell.
        For Each c As Cell In Me.Cells
            ' Select the first editable (empty) cell that we come to.
            If c.AllowEdit Then
                c.Selected = True
                Exit For
            End If
        Next

        Me.Invalidate()
        Me.Update()
    End Sub

    ''' <summary>
    ''' Shows the current puzzle's solution.  
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ShowPuzzleSolution()

        ' Clear all the conflicting circles.
        Me.CircledNumbers.Clear()

        For Each _cell As Cell In _cellList
            _cell.Selected = False
            '_cell.FilledColor = Me.CellFilledColor
            '' Disable cell highlighting
            '_cell.EmptyColor = Me.CellEmptyColor
            ' The cells value is now correct
            ' This is in case the cell was modified by 
            ' the user and the value was incorrect.
            _cell.AnswerWrong = False
            ' Show the cells correct value
            _cell.Text = _cell.CorrectValue.ToString
            ' Prevent cell change by disabling it
            _cell.AllowEdit = False
        Next

        Me.Invalidate()
        Me.Update()
    End Sub

    ''' <summary>
    ''' Determines if the current puzzle was solved.
    ''' </summary>
    ''' <returns>A Boolean value indicating whether the puzzle was solved or not.</returns>
    ''' <remarks></remarks>
    Friend Function PuzzleSolved() As Boolean
        Dim i As Integer
        For Each _cell As Cell In _cellList
            If _cell.Text = _cell.CorrectValue.ToString Then
                i += 1
            End If
            If i = _cellList.Count Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Called when the user solves the current puzzle.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ShowUserSolved()
        If MsgBox("You solved the puzzle." + Chr(13) + "Do you want to play again?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            GeneratePuzzle()
        Else
            Me.Parent.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Checks the input values and highlights the cell if it's value is wrong.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ShowWrongAnswers()
        For Each _cell As Cell In _cellList
            ' Make sure we only check Editable cells.
            If _cell.AllowEdit Then
                ' See if the user has entered a number in the cell.
                If _cell.Text <> "" Then
                    ' Now, check the user's number against the solution number.
                    If _cell.Text <> _cell.CorrectValue.ToString Then
                        ' Is the cell selected?
                        If _cell.Selected Then


                            '' Answer was wrong so, update cell to reflect it.
                            '' Unselect the selected cell.
                            ' _cell.Selected = False
                            _cell.AnswerWrong = True
                        Else
                            _cell.AnswerWrong = True
                        End If
                    Else
                        ' Answer was right.
                        _cell.AnswerWrong = False
                    End If
                Else
                    ' Their is no number in this cell.
                    _cell.AnswerWrong = False
                End If
            End If

        Next

        Me.Invalidate()
        Me.Update()
    End Sub

    ''' <summary>
    ''' Checks the input values for wrong values.
    ''' </summary>
    ''' <returns>An integer value specifying the number of wrong cell values.</returns>
    ''' <remarks></remarks>
    Friend Function NumberOfWrong() As Integer
        ' Used to count number of wrong answers.
        Dim count As Integer
        For Each _cell As Cell In _cellList
            ' Make sure we only check Editable cells.
            If _cell.AllowEdit Then
                ' See if the user has entered a number in the cell.
                If _cell.Text <> "" Then
                    ' Now, check the user's number against the solution number.
                    If _cell.Text <> _cell.CorrectValue.ToString Then
                        ' Answer was wrong so count it.
                        count += 1
                    End If
                End If
            End If
        Next

        Return count
    End Function

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

                'Did the user solve the puzzle.
                If PuzzleSolved() Then
                    ShowUserSolved()
                End If

                ' No need to redraw every cell since only 1 cell can
                ' be selected at a time so we exit the for loop.
                Exit For
            End If
        Next
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

    Friend Sub SelectRow(ByVal row As Integer, Optional ByVal lineWidth As Integer = 2)
        Try
            Dim g As Graphics = Me.CreateGraphics
            Dim myPen As New Pen(Me.CircledConflictColor, lineWidth)
            Dim firstCell As Cell
            Dim lastCell As Cell
            Dim rowRect As Rectangle
            Dim firstCellIndex As Integer
            Dim lastCellIndex As Integer

            ' In order to get the specified row we need to first
            ' get the index of the first square in that row.
            firstCellIndex = (row * Me.SquaresWide)

            'Now, get the last square in that row.
            lastCellIndex = ((firstCellIndex + Me.SquaresWide) - 1)

            ' Create an instance of the first and last square
            ' in order to access their coordinates.
            firstCell = Me.Cells(firstCellIndex)
            lastCell = Me.Cells(lastCellIndex)

            ' Get the start point of the row.
            rowRect.X = firstCell.Rectangle.X
            rowRect.Y = firstCell.Rectangle.Y

            ' Now, get the height of the row.
            rowRect.Width = (lastCell.Rectangle.X + lastCell.Rectangle.Width)
            rowRect.Height = (lastCell.Rectangle.Height)

            ' Add this rectangle to our 'SelectedRows'.
            If Not Me.SelectedRows.Contains(rowRect) Then
                Me.SelectedRows.Add(rowRect)
            End If

            ' Draw a rectangle around the row to show it is selected.
            g.DrawRectangle(myPen, rowRect)

            ' We are done with the pen and graphics 
            ' object so release their resources.
            myPen.Dispose()
            g.Dispose()
        Catch ex As ArgumentOutOfRangeException
            MsgBox("The row you specified does not exist.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Sub SelectColumn(ByVal column As Integer, Optional ByVal lineWidth As Integer = 2)
        Try
            Dim g As Graphics = Me.CreateGraphics
            Dim myPen As New Pen(Me.CircledConflictColor, lineWidth)
            Dim firstCell As Cell
            Dim lastCell As Cell
            Dim columnRect As Rectangle
            Dim firstCellIndex As Integer
            Dim lastCellIndex As Integer

            ' In order to get the specified column we need to 
            ' get the index of the first square in that column.
            firstCellIndex = column
            lastCellIndex = (Me.SquaresHigh * Me.SquaresWide) - (Me.SquaresWide - column)

            ' Create an instance of the first and last square
            ' in order to access their coordinates.
            firstCell = Me.Cells(firstCellIndex)
            lastCell = Me.Cells(lastCellIndex)

            ' Get the start point of the column.
            columnRect.X = firstCell.Rectangle.X
            columnRect.Y = firstCell.Rectangle.Y

            ' Now, get the height of the column.
            columnRect.Width = (lastCell.Rectangle.Width)
            columnRect.Height = (lastCell.Rectangle.Y + lastCell.Rectangle.Height)

            ' Add this rectangle to our 'SelectedColumns'.
            If Not Me.SelectedColumns.Contains(columnRect) Then
                Me.SelectedColumns.Add(columnRect)
            End If

            ' Draw a rectangle around the column to show it is selected.
            g.DrawRectangle(myPen, columnRect)

            ' We are done with the pen and graphics 
            ' object so release their resources.
            myPen.Dispose()
            g.Dispose()
        Catch ex As ArgumentOutOfRangeException
            MsgBox("The column you specified does not exist.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Sub SelectRegion(ByVal region As Integer, Optional ByVal lineWidth As Integer = 2)
        Try
            Dim g As Graphics = Me.CreateGraphics
            Dim myPen As New Pen(Me.CircledConflictColor, lineWidth)
            Dim firstCell As Cell
            Dim lastCell As Cell
            Dim regionRect As Rectangle
            Dim firstCellIndex As Integer
            Dim lastCellIndex As Integer

            ' In order to get the specified region we need to 
            ' get the index of the first square in that region.
            ' ***** NOTE: Only works for 9x9 grids at the moment. *****
            Select Case region
                Case 0
                    firstCellIndex = 0
                Case 1
                    firstCellIndex = 3
                Case 2
                    firstCellIndex = 6
                Case 3
                    firstCellIndex = 27
                Case 4
                    firstCellIndex = 30
                Case 5
                    firstCellIndex = 33
                Case 6
                    firstCellIndex = 54
                Case 7
                    firstCellIndex = 57
                Case 8
                    firstCellIndex = 60
            End Select
            ' *********************************************************

            lastCellIndex = (firstCellIndex + 2)

            ' Create an instance of the first and last square
            ' in order to access their coordinates.
            firstCell = Me.Cells(firstCellIndex)
            lastCell = Me.Cells(lastCellIndex)

            ' Get the start point of the column.
            regionRect.X = firstCell.Rectangle.X
            regionRect.Y = firstCell.Rectangle.Y

            ' Now, get the height of the column.
            regionRect.Width = (firstCell.Rectangle.Width * 3)
            regionRect.Height = (lastCell.Rectangle.Height * 3)

            ' Add this rectangle to our 'SelectedRegions'.
            If Not Me.SelectedRegions.Contains(regionRect) Then
                Me.SelectedRegions.Add(regionRect)
            End If

            ' Draw a rectangle around the column to show it is selected.
            g.DrawRectangle(myPen, regionRect)

            ' We are done with the pen and graphics 
            ' object so release their resources.
            myPen.Dispose()
            g.Dispose()
        Catch ex As ArgumentOutOfRangeException
            MsgBox("The region you specified does not exist.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Sub SelectCell(ByVal cell As Integer, Optional ByVal lineWidth As Integer = 4)
        Try
            Dim g As Graphics = Me.CreateGraphics
            Dim myPen As New Pen(Me.CircledConflictColor, lineWidth)
            Dim cellRect As Rectangle

            ' Get the specified cell's rectangle.
            cellRect = Me.Cells(cell).Rectangle

            ' Add this rectangle to our 'SelectedCells'.
            If Not Me.SelectedCells.Contains(cellRect) Then
                Me.SelectedCells.Add(cellRect)
            End If

            ' Draw a rectangle around the column to show it is selected.
            g.DrawRectangle(myPen, cellRect)

            myPen.Dispose()
            g.Dispose()
        Catch ex As ArgumentOutOfRangeException
            MsgBox("The square you specified does not exist.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Sub CircleNumber(ByVal cell As Integer, Optional ByVal lineWidth As Integer = 4)
        Try
            Dim g As Graphics = Me.CreateGraphics
            Dim myPen As New Pen(Me.CircledConflictColor, lineWidth)
            Dim cellRect As Rectangle
            Dim center As Point
            Dim szF As SizeF = Me.Cells(cell).StringFontSizeF(g)
            Dim centerRect As New Point
            Dim circleRect As Rectangle

            ' Make sure that we have text that we can circle.
            If Me.Cells(cell).Text <> "" Then
                ' Get the specified cell's rectangle.
                cellRect = Me.Cells(cell).Rectangle

                ' Get the center of the specified cell's rectangle.
                centerRect = New Point(cellRect.X + (cellRect.Width \ 2), cellRect.Y + (cellRect.Height \ 2))

                ' Set the width & height of the circle to draw.
                circleRect.Width = szF.Width
                circleRect.Height = szF.Height

                ' Compute and set the location of the circle to draw.
                center = New Point(cellRect.X + (cellRect.Width \ 2) - (circleRect.Width \ 2), cellRect.Y + (cellRect.Height \ 2) - (circleRect.Height \ 2))
                circleRect.X = center.X
                circleRect.Y = center.Y

                ' Draw the main part of the circle.
                g.DrawArc(myPen, circleRect, -30, 360)
                Dim r As Rectangle = circleRect

                ' We don't really want the circle to look "computer drawn" so,
                ' calculate and draw the rest of the circle to look like an actual 
                ' person circled it.
                r.X -= 3
                r.Y -= 15
                g.DrawArc(myPen, r, 350, 80)

                ' We are done with the pen and graphics 
                ' object so release their resources.
                myPen.Dispose()
                g.Dispose()
                'Else
                '    MsgBox("No conflicting squares.")
            End If

        Catch ex As ArgumentOutOfRangeException
            MsgBox("The cell you specified does not exist.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Friend Function CircleConflictingCells(ByVal cellIndex As Integer) As Integer

        ' Only circle squares if Learning Mode is turned ON,
        If Me.LearningModeActivated Then
            ' and ShowCircled is enabled.
            If Me.ShowCircled = True Then
                Dim index As Integer
                Dim indexList As New List(Of Integer)

                ' Clear our circled rectangle list so we 
                ' don't keep adding circles for every square 
                ' every time we check it. If we didn't we would
                ' have circles all over the grid.
                Me.CircledNumbers.Clear()

                ' After clearing the circled rectangle list
                ' clear the buffer and repaint.
                Me.Refresh()


                ' **************************************************************************
                ' CHECK ROW FOR A CONFLICTING SQUARE
                ' **************************************************************************
                ' Iterate through the square list until we get 
                ' to the same row as the selected square.
                While index <= 80
                    ' Are we in the same row?
                    If sqList(index).Row = Me.UserSelectedCell.Row Then
                        ' Check it's value for a match with the selected square's text.
                        If Me.Cells(index).Text = Me.UserSelectedCell.Text Then
                            ' Make sure that we don't circle the  
                            ' square that is currently selected.
                            If sqList(index).Index <> Me.UserSelectedCell.Index Then
                                ' Make sure we don't reveal the answers to an open square.
                                ' In other words, if there is a square that has the wrong 
                                ' text in it and the real answer matches the currently selected
                                ' square, dont let this reveal the answer by matching it unless
                                ' the user has entered the correct value in that square.
                                If Me.Cells(index).AllowEdit = True Then
                                    ' Circle editable squares only if the user has 
                                    ' entered the correct number in them.
                                    '*******If Not Me.Cells(index).AnswerWrong Then
                                    ' Make sure that there is text in the square
                                    If Me.Cells(index).Text <> "" Then
                                        ' Make sure we aren't adding duplicates
                                        If Not indexList.Contains(index) Then
                                            ' Add this index to our list of index
                                            indexList.Add(index)

                                            ' Add this circle to our circle list
                                            AddCircle(index)

                                            ' Circle Editable squares
                                            CircleNumber(sqList(index).Index)
                                        End If
                                    End If
                                    '*******End If
                                Else
                                    ' Make sure we aren't adding duplicates
                                    If Not indexList.Contains(index) Then
                                        ' Add this index to our list of index
                                        indexList.Add(index)

                                        ' Add this circle to our circle list
                                        AddCircle(index)

                                        ' Circle NON-Editable squares
                                        CircleNumber(sqList(index).Index)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    index += 1
                End While
                ' **************************************************************************


                ' Reset our index
                index = 0


                ' **************************************************************************
                ' CHECK COLUMN FOR A CONFLICTING SQUARE
                ' **************************************************************************
                ' Iterate through the square list until we get 
                ' to the same row as the selected square.
                While index <= 80
                    ' Are we in the same row?
                    If sqList(index).Column = Me.UserSelectedCell.Column Then
                        ' Check it's value for a match with the selected square's text.
                        If Me.Cells(index).Text = Me.UserSelectedCell.Text Then
                            ' Make sure that we don't circle the  
                            ' square that is currently selected.
                            If sqList(index).Index <> Me.UserSelectedCell.Index Then
                                ' Make sure we don't reveal the answers to an open square.
                                ' In other words, if there is a square that has the wrong 
                                ' text in it and the real answer matches the currently selected
                                ' square, dont let this reveal the answer by matching it unless
                                ' the user has entered the correct value in that square.
                                If Me.Cells(index).AllowEdit = True Then
                                    ' Circle editable squares only if the user has 
                                    ' entered the correct number in them.
                                    '*******If Not Me.Cells(index).AnswerWrong Then
                                    ' Make sure that there is text in the square
                                    If Me.Cells(index).Text <> "" Then
                                        ' Make sure we aren't adding duplicates
                                        If Not indexList.Contains(index) Then
                                            ' Add this index to our list of index
                                            indexList.Add(index)

                                            ' Add this circle to our circle list
                                            AddCircle(index)

                                            ' Circle Editable squares
                                            CircleNumber(sqList(index).Index)
                                        End If
                                    End If
                                    '*******End If
                                Else
                                    ' Make sure we aren't adding duplicates
                                    If Not indexList.Contains(index) Then
                                        ' Add this index to our list of index
                                        indexList.Add(index)

                                        ' Add this circle to our circle list
                                        AddCircle(index)

                                        ' NON-Editable squares
                                        CircleNumber(sqList(index).Index)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    index += 1
                End While


                ' Reset our index
                index = 0


                ' **************************************************************************
                ' CHECK REGION FOR A CONFLICTING SQUARE
                ' **************************************************************************
                ' Iterate through the square list until we get 
                ' to the same row as the selected square.
                While index <= 80
                    ' Are we in the same row?
                    If sqList(index).Region = Me.UserSelectedCell.Region Then
                        ' Check it's value for a match with the selected square's text.
                        'sqList(index).Value.ToString
                        If Me.Cells(index).Text = Me.UserSelectedCell.Text Then


                            ' Make sure that we don't circle the  
                            ' square that is currently selected.
                            If sqList(index).Index <> Me.UserSelectedCell.Index Then


                                ' ****** GOT TO BE FIXED *******
                                ' Needs to match 'Editables' according to the text not the value.

                                ' Make sure we don't reveal the answers to an open square.
                                ' In other words, if there is a square that has the wrong 
                                ' text in it and the real answer matches the currently selected
                                ' square, dont let this reveal the answer by matching it unless
                                ' the user has entered the correct value in that square.
                                If Me.Cells(index).AllowEdit = True Then
                                    ' Circle editable squares only if the user has 
                                    ' entered the correct number in them.
                                    '*******If Not Me.Cells(index).AnswerWrong Then
                                    ' Make sure that there is text in the square
                                    If Me.Cells(index).Text <> "" Then
                                        ' Make sure we aren't adding duplicates
                                        If Not indexList.Contains(index) Then
                                            ' Add this index to our list of index
                                            indexList.Add(index)

                                            ' Add this circle to our circle list
                                            AddCircle(index)

                                            ' Circle Editable squares
                                            CircleNumber(sqList(index).Index)
                                        End If
                                    End If
                                    '******* End If
                                Else
                                    ' Make sure we aren't adding duplicates
                                    If Not indexList.Contains(index) Then
                                        ' Add this index to our list of index
                                        indexList.Add(index)

                                        ' Add this circle to our circle list
                                        AddCircle(index)

                                        ' NON-Editable squares
                                        CircleNumber(sqList(index).Index)
                                    End If
                                End If
                            End If
                        End If
                    End If
                    index += 1
                End While
            End If
        End If
    End Function

    Private Sub AddCircle(ByVal index As Integer)
        Dim cellRect As Rectangle
        Dim center As Point
        Dim centerRect As New Point
        Dim circleRect As Rectangle
        Dim g As Graphics = Me.CreateGraphics
        Dim szF As SizeF

        ' Get our text dimensions.
        szF = Me.Cells(index).StringFontSizeF(g)

        ' Release our graphics object
        g.Dispose()

        ' Get the specified cell's rectangle.
        cellRect = Me.Cells(index).Rectangle

        ' Get the center of the specified cell's rectangle.
        centerRect = New Point(cellRect.X + (cellRect.Width \ 2), cellRect.Y + (cellRect.Height \ 2))

        ' Set the width & height of the circle to draw.
        circleRect.Width = szF.Width
        circleRect.Height = szF.Height

        ' Compute and set the location of the circle to draw.
        center = New Point(cellRect.X + (cellRect.Width \ 2) - (circleRect.Width \ 2), cellRect.Y + (cellRect.Height \ 2) - (circleRect.Height \ 2))
        circleRect.X = center.X
        circleRect.Y = center.Y

        ' Add this circle to our list of circles to draw.
        Me.CircledNumbers.Add(circleRect)
    End Sub
#End Region

#Region "Subs For Events"
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


        '*********************************************************************
        ' DRAWS SELECTION RECTANGLE OF ANY ROWS, COLUMNS, REGIONS, OR CELLS
        '*********************************************************************
        For Each rect As Rectangle In Me.SelectedRows
            e.Graphics.DrawRectangle(New Pen(Me.CircledConflictColor, 4), rect)
        Next
        For Each rect As Rectangle In Me.SelectedColumns
            e.Graphics.DrawRectangle(New Pen(Me.CircledConflictColor, 4), rect)
        Next
        For Each rect As Rectangle In Me.SelectedRegions
            e.Graphics.DrawRectangle(New Pen(Me.CircledConflictColor, 4), rect)
        Next
        For Each rect As Rectangle In Me.SelectedCells
            e.Graphics.DrawRectangle(New Pen(Me.CircledConflictColor, 4), rect)
        Next
        '*********************************************************************


        '*********************************************************************
        ' DRAWS ALL THE LEARNING MODE STUFF
        '*********************************************************************
        ' If Learning Mode is activated show all hints, popup helps, etc.
        If Me.LearningModeActivated = True Then
            ' Draw the conflicting circles if activated
            If Me.ShowCircled = True Then
                For Each rect As Rectangle In Me.CircledNumbers
                    Dim myPen As New Pen(Me.CircledConflictColor, 4)
                    e.Graphics.DrawArc(myPen, rect, -30, 360)
                    Dim r As Rectangle = rect

                    ' We don't really want the circle to look "computer drawn" so,
                    ' calculate and draw the rest of the circle to look like an actual 
                    ' person circled it.
                    r.X -= 3
                    r.Y -= 15
                    e.Graphics.DrawArc(myPen, r, 350, 80)
                Next
            End If

            If Me.EnableHelpPopup = True Then
                ' If Learning Mode is activated then draw the LearningMode control.
                If LearningMode IsNot Nothing Then
                    Me.LearningMode.GraphicsObj = e.Graphics
                    LearningMode.Draw(e)
                End If
            End If
        End If
        '*********************************************************************

    End Sub


    Friend Sub AnimateConflictingSquares()
        If Timer1.Enabled Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)

        Me.LearningMode.NextStep()

        ' This calculation causes the popups to display based upon
        ' the the length of the text that it contains.
        ' The longer the text is the longer the time is that it is 
        ' displayed and vice versa.
        Me.Timer1.Interval = (Me.LearningMode.PopupCurrentText.Length) * 80

        ' In case the interval from the calculation above is too short
        ' for the user to have time to read it, we set a static time
        If Me.Timer1.Interval < 2500 Then
            Me.Timer1.Interval = 2500
        End If


        ' ********************* STEP ONE *************************
        If Me.LearningMode.CurrentStep = LearningModeSystem.Steps.One Then
            If Me.LearningMode.PopupCurrentText = "9 Rows," Then

                ' We are only selecting 1 row, the first one.
                Me.SelectRow(0)
            ElseIf Me.LearningMode.PopupCurrentText = "9 Columns," Then
                ' Clear out the previous selected row.
                Me.SelectedRows.Clear()

                ' We are only selecting 1 column, the first one.
                Me.SelectColumn(0)
            ElseIf Me.LearningMode.PopupCurrentText = "and 9 Regions." Then
                ' Clear out the previous selected column.
                Me.SelectedColumns.Clear()

                ' We are only selecting 1 region, the fourth one.
                Me.SelectRegion(3)
            Else
                ' Clear out the previous selected region.
                Me.SelectedRegions.Clear()
            End If

            ' ********************* STEP TWO *************************
        ElseIf Me.LearningMode.CurrentStep = LearningModeSystem.Steps.Two Then
            Select Case Me.LearningMode.PopupCurrentText
                Case "These squares are ""given"" squares."

                    ' Select all "given" squares on the grid
                    For Each sq As Cell In Me.Cells
                        If sq.AllowEdit = False Then
                            ' Select the "given" square.
                            Call SelectCell(sq.Index)
                        End If
                    Next

                Case "Their number is supplied as a clue " + Environment.NewLine + "to help you solve the puzzle.", _
                     "The given numbers can not be changed."

                    ' Circle the "given" squares' numbers.
                    For Each sq As Cell In Me.Cells
                        If sq.AllowEdit = False Then
                            ' Circle it's number.
                            Call AddCircle(sq.Index)
                        End If
                    Next

                    ' ************* SET THE POPUP'S LOCATION *************
                    'Dim cellRect As Rectangle = Me.Cells(11).Rectangle
                    'Dim popRect As Rectangle = Me.LearningMode.PopupRectangle
                    'Me.LearningMode.PopupRectangle = New Rectangle()
                    'Me.LearningMode.PopupLocation = New Point(cellRect.Right + 50, cellRect.Top + ((cellRect.Height / 2) - (popRect.Height / 2)))
                    ' ****************************************************
                Case "These squares are ""open"" squares.", "It is these squares that " + Environment.NewLine + "you will try to solve."

                    ' Clear out all "given" square selections.
                    Me.SelectedCells.Clear()

                    ' Clear all circled numbers.
                    Me.CircledNumbers.Clear()

                    ' Select all "open" squares on the grid
                    For Each sq As Cell In Me.Cells
                        If sq.AllowEdit = True Then
                            ' Select the "open" square.
                            Call SelectCell(sq.Index)
                        End If
                    Next
            End Select

            ' ********************* STEP THREE *************************
        ElseIf Me.LearningMode.CurrentStep = LearningModeSystem.Steps.Three Then

            ' Clear out all selected "open" squares.
            Me.SelectedCells.Clear()

        End If

        Me.Invalidate()
        Me.Update()
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

        ' We need the grid size to calculate the location
        ' for the Learning Mode help popup, etc.
        Me.LearningMode.GridSize = Me.Size

        ' Can't show circles unless we are in Learning Mode.
        If Me.LearningModeActivated = True Then
            ' No use of resizing rectangles
            ' if we aren't allowed to show them.
            If Me.ShowCircled = True Then
                ' Test whether we are minimized or not.
                ' This prevents us from getting width and height
                ' values of 0.
                If Not Me.Size.IsEmpty Then
                    CircleConflictingCells(Me.UserSelectedCell.Index)
                End If
            End If
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)

        'Me.Invalidate(Me.LS.PopupRectangle)
    End Sub

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

                        '' Update the circled squares when the selected square is changed.
                        'CircleConflictingCells(clickedCell.Index)

                        ' Add the previous clicked cell's rectangle to the next repaint.
                        Me.Invalidate(previousCell.Rectangle)
                    End If
                End If
            End If

            ' Force a repaint operation.
            ' Me.Update()
        End If

        'Me.Invalidate()
        'Me.Update()

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

        'CircleConflictingCells(Me.UserSelectedCell.Index)
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
                    For i As Integer = (index + 9) To 80 Step 9 '(80 - index(9 - index)) Step 9
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

            'CircleConflictingCells(Me.SelectedCell.Index)

            Me.Invalidate(selectedCell.Rectangle)
            Me.Invalidate(CellToMoveTo.Rectangle)
            Me.Update()
        End If

    End Sub
#End Region





    Friend Class LearningModeSystem
        ' Inherits System.Windows.Forms.Control

        Friend CalloutStringList As List(Of String)

        Private stepOneIndex As Integer
        Private stepTwoIndex As Integer
        Private stepThreeIndex As Integer

        Friend Enum Steps
            One = 1
            Two = 2
            Three = 3
        End Enum

        Sub New()
            CalloutStringList = New List(Of String)
            LoadCalloutStrings()
            LoadStepOneStrings()
            LoadStepTwoStrings()
            LoadStepThreeStrings()
        End Sub


#Region "Properties"
        Private _grfx As Graphics
        Friend Property GraphicsObj() As Graphics
            Get
                Return Me._grfx
            End Get
            Set(ByVal value As Graphics)
                Me._grfx = value
            End Set
        End Property

        Private _gridsize As Size
        Friend Property GridSize() As Size
            Get
                Return Me._gridsize
            End Get
            Set(ByVal value As Size)
                Me._gridsize = value
            End Set
        End Property
#End Region

#Region "Popup Properties"

        Private _currentstep As Steps = Steps.One
        Friend Property CurrentStep() As Steps
            Get
                Return Me._currentstep
            End Get
            Set(ByVal value As Steps)
                Me._currentstep = value
            End Set
        End Property

        Private _steponetextlist As New List(Of String)
        Friend Property StepOneTextList() As List(Of String)
            Get
                Return Me._steponetextlist
            End Get
            Set(ByVal value As List(Of String))
                Me._steponetextlist = value
            End Set
        End Property

        Private _steptwotextlist As New List(Of String)
        Friend Property StepTwoTextList() As List(Of String)
            Get
                Return Me._steptwotextlist
            End Get
            Set(ByVal value As List(Of String))
                Me._steptwotextlist = value
            End Set
        End Property

        Private _stepthreetextlist As New List(Of String)
        Friend Property StepThreeTextList() As List(Of String)
            Get
                Return Me._stepthreetextlist
            End Get
            Set(ByVal value As List(Of String))
                Me._stepthreetextlist = value
            End Set
        End Property

        Private _activated As Boolean
        Friend Property PopupActivated() As Boolean
            Get
                Return Me._activated
            End Get
            Set(ByVal value As Boolean)
                Me._activated = value
                ' Reset our string incrementer
                Me.stepOneIndex = 0
                Me.stepTwoIndex = 0
                Me.stepThreeIndex = 0
            End Set
        End Property

        Private _padding As Padding = New Padding(10)
        Friend Property PopupPadding() As Padding
            Get
                Return Me._padding
            End Get
            Set(ByVal value As Padding)
                Me._padding = value
            End Set
        End Property

        Private _popupfont As Drawing.Font = New Font("Arial", 18, FontStyle.Regular)
        Friend Property PopupFont() As Drawing.Font
            Get
                Return Me._popupfont
            End Get
            Set(ByVal value As Drawing.Font)
                Me._popupfont = value
            End Set
        End Property

        Private _popuptext As String = ""
        Friend Property PopupCurrentText() As String
            Get
                If Me._currentstep = Steps.One Then
                    Me._popuptext = _steponetextlist(stepOneIndex)
                ElseIf Me._currentstep = Steps.Two Then
                    Me._popuptext = _steptwotextlist(stepTwoIndex)
                ElseIf Me._currentstep = Steps.Three Then
                    Me._popuptext = _stepthreetextlist(stepThreeIndex)
                End If

                Return Me._popuptext
            End Get
            Set(ByVal value As String)
                Me._popuptext = value

                ' After the text is set, get its measurement.
                Dim szF As SizeF = Me.PopupTextSize

                ' From the text's measurement, create a rectangle adding the
                ' padding horizontal to it's width and vertical to it's height.
                ' NOTE: The location will get set from the Grid.
                Dim x As Integer = Me.PopupRectangle.X
                Dim y As Integer = Me.PopupRectangle.Y
                Dim w As Integer = szF.Width + (Me.PopupPadding.Horizontal + 10)
                Dim h As Integer = (szF.Height + 50) + Me.PopupPadding.Vertical

                ' Set our location and size to this new rectangle.
                Me.PopupLocation = New Point(x, y)
                Me.PopupSize = New Size(w, h)
            End Set
        End Property

        Private _popuptextcolor As Color = Color.Black
        Friend Property PopupTextColor() As Color
            Get
                Return Me._popuptextcolor
            End Get
            Set(ByVal value As Color)
                Me._popuptextcolor = value
            End Set
        End Property

        ''' <summary>
        ''' Measures the width and height of the text according to the font. 
        ''' </summary>
        ''' <value></value>
        ''' <returns>A System.Drawing.SizeF structure.</returns>
        ''' <remarks></remarks>
        Friend ReadOnly Property PopupTextSize() As Drawing.SizeF
            Get
                Dim szF As SizeF
                If Me.PopupCurrentText <> "" Then
                    szF = Me.GraphicsObj.MeasureString(Me.PopupCurrentText, Me.PopupFont)
                End If

                Return szF
            End Get
        End Property

        Private _popuptextlocation As Point
        Friend ReadOnly Property PopupTextLocation() As Point
            Get
                ' Get our text's size.
                Dim szF As SizeF = PopupTextSize()
                Dim ds As Rectangle = Me.PopupRectangle

                Dim cntrW As Integer = (ds.X + ((ds.Width - Me.PopupPadding.Horizontal) \ 2) - (szF.Width \ 2)) + Me.PopupPadding.Left
                Dim cntrH As Integer = (ds.Y + ((ds.Height - Me.PopupPadding.Vertical) \ 2) - (szF.Height \ 2)) '\ 3)) '- 15

                Return New Point(cntrW, cntrH)
            End Get
        End Property

        Private _popuprect As Rectangle = New Rectangle(0, 0, 50, 50)
        Friend Property PopupRectangle() As Rectangle
            Get
                Return Me._popuprect
            End Get
            Set(ByVal value As Rectangle)
                Me._popuprect = value
                Me._popupsize.Width = value.Width
                Me._popupsize.Height = value.Height
                Me._popuplocation.X = value.X
                Me._popuplocation.Y = value.Y
                Me._popupwidth = value.Width
                Me._popupheight = value.Height
            End Set
        End Property

        Private _popuplocation As Point
        Friend Property PopupLocation() As Point
            Get
                Return Me._popuplocation
            End Get
            Set(ByVal value As Point)
                Me._popuplocation = value
                Me._popuprect.X = value.X
                Me._popuprect.Y = value.Y
            End Set
        End Property

        Private _popupsize As Size = New Size(50, 50)
        Friend Property PopupSize() As Size
            Get
                ' After the text is set, get its measurement.
                Dim szF As SizeF = Me.PopupTextSize

                ' From the text's measurement, create a rectangle adding the
                ' padding horizontal to it's width and vertical to it's height.
                ' NOTE: The location will get set from the Grid.
                'Dim x As Integer = Me.PopupRectangle.X
                'Dim y As Integer = Me.PopupRectangle.Y
                Dim w As Integer = szF.Width + (Me.PopupPadding.Horizontal + 10)
                Dim h As Integer = (szF.Height + 50) + Me.PopupPadding.Vertical

                ' Set our location and size to this new rectangle.
                'Me.PopupLocation = New Point(x, y)
                Me._popupsize = New Size(w, h)

                Return Me._popupsize
            End Get
            Set(ByVal value As Size)
                Me._popupsize = value
                Me._popuprect.Width = value.Width
                Me._popuprect.Height = value.Height
                Me._popupwidth = value.Width
                Me._popupheight = value.Height
            End Set
        End Property

        Private _popupwidth As Integer = 50
        Friend Property PopupWidth() As Integer
            Get
                Return Me._popupwidth
            End Get
            Set(ByVal value As Integer)
                Me._popupwidth = value
                Me._popuprect.Width = value
                Me._popupsize.Width = value
            End Set
        End Property

        Private _popupheight As Integer = 50
        Friend Property PopupHeight() As Integer
            Get
                Return Me._popupheight
            End Get
            Set(ByVal value As Integer)
                Me._popupheight = value
                Me._popuprect.Height = value
                Me._popupsize.Height = value
            End Set
        End Property

        Friend ReadOnly Property LastIntroString() As Boolean
            Get
                If Me.stepOneIndex >= (_steponetextlist.Count - 1) Then
                    Return True
                End If
                Return False
            End Get
        End Property

#End Region


        Private Sub LoadStepOneStrings()
            Me._steponetextlist.Add("Welcome to the Sudoku Learning Mode.")
            Me._steponetextlist.Add("This feature is designed to teach you " + Environment.NewLine + "how to solve a Sudoku puzzle.")
            Me._steponetextlist.Add("Follow along with the popups then you " + Environment.NewLine + "will be given a chance to try it out.")
            Me._steponetextlist.Add("First, let me give you some " + Environment.NewLine + "information about the Sudoku grid.")
            Me._steponetextlist.Add("The normal Sudoku grid is made up of")
            Me._steponetextlist.Add("9 Rows,")
            Me._steponetextlist.Add("9 Columns,")
            Me._steponetextlist.Add("and 9 Regions.")
            Me._steponetextlist.Add("Each row, column, and region " + Environment.NewLine + "contains nine squares each.")
            Me._steponetextlist.Add("That's a total of 81 squares.")
            Me._steponetextlist.Add("Complete the puzzle so that every square " + Environment.NewLine + "in every row, column, and region " + Environment.NewLine + "contains the numbers 1 - 9 only once.")
            Me._steponetextlist.Add("Now, lets take a look at the squares.")
        End Sub

        Private Sub LoadStepTwoStrings()
            Me._steptwotextlist.Add("These squares are ""given"" squares.")
            Me._steptwotextlist.Add("Their number is supplied as a clue " + Environment.NewLine + "to help you solve the puzzle.")
            Me._steptwotextlist.Add("The given numbers can not be changed.")
            Me._steptwotextlist.Add("These squares are ""open"" squares.")
            Me._steptwotextlist.Add("It is these squares that " + Environment.NewLine + "you will try to solve.")
        End Sub

        Private Sub LoadStepThreeStrings()
            Me._stepthreetextlist.Add("Solve the puzzle by filling in the " + Environment.NewLine + "open squares with a single number.")
            Me._stepthreetextlist.Add("A number can only appear once in " + Environment.NewLine + "each row, column, and 3x3 region.")
            Me._stepthreetextlist.Add("You can start in any open square.")
            Me._stepthreetextlist.Add("Try it out for yourself.")

        End Sub

        Friend Sub NextStep()
            Select Case Me.CurrentStep
                Case Steps.One
                    If Me.stepOneIndex >= (Me.StepOneTextList.Count - 1) Then
                        ' Reset the index to 0 since we
                        ' aren't going to use it anymore.
                        Me.stepOneIndex = 0
                        ' Next step
                        Me.CurrentStep += 1
                    Else
                        ' Next string.
                        Me.stepOneIndex += 1
                    End If
                Case Steps.Two
                    If Me.stepTwoIndex >= (Me.StepTwoTextList.Count - 1) Then
                        ' Reset the index to 0 since we
                        ' aren't going to use it anymore.
                        Me.stepTwoIndex = 0
                        ' Next step
                        Me.CurrentStep += 1
                    Else
                        ' Next string.
                        Me.stepTwoIndex += 1
                    End If
                Case Steps.Three
                    If Me.stepThreeIndex >= (Me.StepThreeTextList.Count - 1) Then
                        ' Reset the index to 0 since we
                        ' aren't going to use it anymore.
                        Me.stepThreeIndex = 0
                        ' Back to the first step
                        Me.CurrentStep = 1
                    Else
                        ' Next string.
                        Me.stepThreeIndex += 1
                    End If
            End Select
        End Sub

        Private Sub LoadCalloutStrings()
            CalloutStringList.Add("Let's start with this square.")
            CalloutStringList.Add("Enter a number from 1 to 9 in this square.")
            CalloutStringList.Add("That number conflicts with another square.")
            CalloutStringList.Add("Choose a different number.")
            CalloutStringList.Add("That number conflicts with another number in this ")
            CalloutStringList.Add("Now that a square is solved, you " + Environment.NewLine + "should look to see if it will help " + Environment.NewLine + "us solve another square or two.")
            CalloutStringList.Add("Look at this row.")
            CalloutStringList.Add("Look at this column.")
            CalloutStringList.Add("Look at this 3x3 region.")
            CalloutStringList.Add("Do you notice that same number " + Environment.NewLine + "anywhere in this row?")
            CalloutStringList.Add("Do you notice that same number " + Environment.NewLine + "anywhere in this column?")
            CalloutStringList.Add("Do you notice that same number " + Environment.NewLine + "anywhere in this 3x3 region?")
            CalloutStringList.Add("You entered a number ")
            CalloutStringList.Add("Congratulations!")
            CalloutStringList.Add("Ok, let me help you a little more.")
            CalloutStringList.Add("Ok, let me help you to understand " + Environment.NewLine + "this a little better.")
            CalloutStringList.Add("Good!")
            CalloutStringList.Add("Good job!")
            CalloutStringList.Add("Great!")
            CalloutStringList.Add("Alright, I think you got it.")
            CalloutStringList.Add("Let's take a look at another square.")
            CalloutStringList.Add("These squares are ""given"" squares.")
            CalloutStringList.Add("Their number is a clue to help " + Environment.NewLine + "you solve the puzzle.")
            CalloutStringList.Add("These numbers can not be changed.")
            CalloutStringList.Add("These squares are ""open"" squares.")
            CalloutStringList.Add("It is these squares that " + Environment.NewLine + "you will try to solve.")
            CalloutStringList.Add("Welcome to the Sudoku Learning Mode.")
            CalloutStringList.Add("This feature is designed to teach you " + Environment.NewLine + "how to solve a Sudoku puzzle.")
            CalloutStringList.Add("There is only one correct number per square.")
            CalloutStringList.Add("Solve the puzzle by filling in the " + Environment.NewLine + "open squares with a single number.")
            CalloutStringList.Add("Only numbers 1 - 9 can be used.")
            CalloutStringList.Add("A number can only appear once in " + Environment.NewLine + "each row, column, and 3x3 region.")
            CalloutStringList.Add("Each region, row, and column contains nine squares each.")
            CalloutStringList.Add("It doesn't matter where you start.")
            CalloutStringList.Add("The more givens of a particular number usually " + Environment.NewLine + "means that it will be easier to solve.")
            CalloutStringList.Add("Look for the number that has several givens.")
            CalloutStringList.Add("Complete the puzzle so that every row, " + Environment.NewLine + "column, and region contains the numbers " + Environment.NewLine + "1 - 9 only once.")
            CalloutStringList.Add("Let me explain.")
            CalloutStringList.Add("Let me give you an example.")
        End Sub

        Friend Sub Draw(ByVal e As PaintEventArgs)

            ' We must be activated before we can draw our popup box.
            If Me.PopupActivated Then
                ' Don't draw anything unless our text is something.
                If Me.PopupCurrentText <> "" Then
                    Dim img As New Bitmap(50, 50)
                    Dim numbrush As New SolidBrush(Me.PopupTextColor)
                    ' Get the text's measurement.
                    Dim szF As SizeF = Me.PopupTextSize

                    ' From the text's measurement, create a rectangle, adding the
                    ' padding horizontal to it's width and vertical to it's height.
                    Dim x1 As Integer = Me.PopupRectangle.X
                    Dim y1 As Integer = Me.PopupRectangle.Y
                    Dim w1 As Integer = szF.Width + (Me.PopupPadding.Horizontal + 10)
                    Dim h1 As Integer = (szF.Height + 50) + Me.PopupPadding.Vertical

                    ' Set our location and size to this new rectangle.
                    Me.PopupLocation = New Point(x1, y1)
                    Me.PopupSize = New Size(w1, h1)

                    '*************************************************************
                    ' For now all popups are shown in the center of the grid.
                    ' ******************** STEP ONE ******************************
                    If Me.CurrentStep = Steps.One Then
                        ' Set our popup image.
                        img = My.Resources.rect2

                        ' Show all step one strings in the center of the grid.
                        If Me.stepOneIndex <= (Me._steponetextlist.Count - 1) Then
                            ' Set the popup's location to the center of the grid.
                            Dim x As Integer = ((Me.GridSize.Width \ 2) - Me.PopupWidth \ 2)
                            Dim y As Integer = ((Me.GridSize.Height \ 2) - Me.PopupHeight \ 2)

                            Me.PopupLocation = New Point(x, y)
                        Else
                            ' For every other string, the popup location will be set
                            ' according to the string. Based upon what the string says.
                        End If

                        ' ******************** STEP TWO **************************
                    ElseIf Me.CurrentStep = Steps.Two Then
                        ' Set our popup image.
                        img = My.Resources.rect2

                        ' Set the popup's location to the center of the grid.
                        Dim x As Integer = ((Me.GridSize.Width \ 2) - Me.PopupWidth \ 2)
                        Dim y As Integer = ((Me.GridSize.Height \ 2) - Me.PopupHeight \ 2)

                        Me.PopupLocation = New Point(x, y)

                        ' ******************** STEP THREE ************************
                    ElseIf Me.CurrentStep = Steps.Three Then
                        ' Set our popup image.
                        img = My.Resources.rect2

                        ' Show all step three strings in the center of the grid.
                        If Me.stepThreeIndex <= (Me._stepthreetextlist.Count - 1) Then
                            ' Set the popup's location to the center of the grid.
                            Dim x As Integer = ((Me.GridSize.Width \ 2) - Me.PopupWidth \ 2)
                            Dim y As Integer = ((Me.GridSize.Height \ 2) - Me.PopupHeight \ 2)

                            Me.PopupLocation = New Point(x, y)
                        Else
                            ' For every other string, the popup location will be set
                            ' according to the string. Based upon what the string says.
                        End If
                    End If

                    e.Graphics.DrawImage(img, Me.PopupRectangle)
                    e.Graphics.DrawString(Me.PopupCurrentText, Me.PopupFont, numbrush, Me.PopupTextLocation.X, Me.PopupTextLocation.Y)
                    'e.Graphics.DrawRectangle(Pens.Blue, Me.Rectangle)

                    ' Dispose the brush.
                    numbrush.Dispose()
                End If
            End If
        End Sub
    End Class

End Class


