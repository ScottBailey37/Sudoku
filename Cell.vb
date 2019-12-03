' Copyright © 2010-2012 Scott Bailey. All rights reserved.



''' <summary>
''' Represents a cell(square) on a Sudoku grid.
''' </summary>
''' <remarks></remarks>
Public Class Cell

    ''' <summary>
    ''' Font size multiplier. (Change to suit your needs)
    ''' </summary>
    ''' <remarks>Used in calculating the size that the font 
    ''' of the cell should be relative its size.</remarks>
    Private FontSizeMultiplier As Single = 1.5

    ''' <summary>
    ''' Creates a new instance of the Cell class.
    ''' </summary>
    ''' <param name="x">The x coordinate of the upper left corner of the cell.</param>
    ''' <param name="y">The y coordinate of the upper left corner of the cell.</param>
    ''' <param name="width">The width of the cell.</param>
    ''' <param name="height">The height of the cell.</param>
    ''' <remarks></remarks>
    Sub New(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        Me._rect = New Rectangle(x, y, width, height)
    End Sub

    ''' <summary>
    ''' Creates a new instance of the Cell class.
    ''' </summary>
    ''' <param name="rect">The System.Drawing.Rectangle structure that determines the location and size of the cell.</param>
    ''' <remarks></remarks>
    Sub New(ByVal rect As Rectangle)
        Me._rect = rect
    End Sub

    ''' <summary>
    ''' Gets or sets a value that determines if the border of the cell should be drawn.
    ''' </summary>
    ''' <remarks></remarks>
    Private _hasborder As Boolean
    Friend Property HasBorder() As Boolean
        Get
            Return Me._hasborder
        End Get
        Set(ByVal value As Boolean)
            Me._hasborder = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the System.Drawing.Color structure that is used to draw the border of the cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private _bordercolor As Color
    Friend Property BorderColor() As Color
        Get
            Return Me._bordercolor
        End Get
        Set(ByVal value As Color)
            Me._bordercolor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the border size of the cell .
    ''' </summary>
    ''' <remarks></remarks>
    Private _bordersize As Single
    Friend Property BorderSize() As Single
        Get
            Return Me._bordersize
        End Get
        Set(ByVal value As Single)
            Me._bordersize = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the System.Drawing.Color structure that is used to draw the 'Text' of the cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private _textcolor As Color '= Color.Black
    Friend Property TextColor() As Color
        Get
            Return Me._textcolor
        End Get
        Set(ByVal value As Color)
            Me._textcolor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the 'Solution'(answer) of the cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private _correctvalue As Integer
    Friend Property CorrectValue() As Integer
        Get
            Return Me._correctvalue
        End Get
        Set(ByVal value As Integer)
            Me._correctvalue = value
        End Set
    End Property

    Private _index As Integer
    Friend Property Index() As Integer
        Get
            Return Me._index
        End Get
        Set(ByVal value As Integer)
            Me._index = value
        End Set
    End Property

    Private _region As Integer
    Friend Property Region() As Integer
        Get
            Return Me._region
        End Get
        Set(ByVal value As Integer)
            Me._region = value
        End Set
    End Property

    Private _column As Integer
    Friend Property Column() As Integer
        Get
            Return Me._column
        End Get
        Set(ByVal value As Integer)
            Me._column = value
        End Set
    End Property

    Private _row As Integer
    Friend Property Row() As Integer
        Get
            Return Me._row
        End Get
        Set(ByVal value As Integer)
            Me._row = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the string displayed in the cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private _text As String
    Friend Property Text() As String
        Get
            Return Me._text
        End Get
        Set(ByVal value As String)
            Me._text = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the System.Drawing.Color structure that is used to fill the cell when its 'Editable' property is False.
    ''' </summary>
    ''' <remarks></remarks>
    Private _filledcolor As Color '= SystemColors.Control
    Friend Property FilledColor() As Color
        Get
            Return Me._filledcolor
        End Get
        Set(ByVal value As Color)
            Me._filledcolor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the System.Drawing.Color structure that is used to fill the cell when its 'Editable' property is True.
    ''' </summary>
    ''' <remarks></remarks>
    Private _emptycolor As Color '= Color.White
    Friend Property EmptyColor() As Color
        Get
            Return Me._emptycolor
        End Get
        Set(ByVal value As Color)
            Me._emptycolor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the System.Drawing.Color structure that is used to fill the cell when its 'Selected' property if True.
    ''' </summary>
    ''' <remarks></remarks>
    Private _highlightcolor As Color '= Color.LightGreen
    Friend Property HighlightColor() As Color
        Get
            Return Me._highlightcolor
        End Get
        Set(ByVal value As Color)
            Me._highlightcolor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the System.Drawing.Color structure that is used to fill the cell when the 'Text' property is different than the 'Number' property and therefore determined to be wrong.
    ''' </summary>
    ''' <remarks></remarks>
    Private _answerwrongcolor As Color '= Color.White
    Friend Property AnswerWrongColor() As Color
        Get
            Return Me._answerwrongcolor
        End Get
        Set(ByVal value As Color)
            Me._answerwrongcolor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a System.Drawing.Rectangle structure that represents the cells location and size.
    ''' </summary>
    ''' <remarks></remarks>
    Private _rect As Rectangle
    Friend Property Rectangle() As Rectangle
        Get
            Return Me._rect
        End Get
        Set(ByVal value As Rectangle)
            Me._rect = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value that determines if the cell is selected or not.
    ''' </summary>
    ''' <remarks></remarks>
    Private _selected As Boolean
    Friend Property Selected() As Boolean
        Get
            Return Me._selected
        End Get
        Set(ByVal value As Boolean)
            Me._selected = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value that determines if the cell can be edited or not.
    ''' </summary>
    ''' <remarks></remarks>
    Private _allowedit As Boolean
    Friend Property AllowEdit() As Boolean
        Get
            Return Me._allowedit
        End Get
        Set(ByVal value As Boolean)
            Me._allowedit = value
        End Set
    End Property

    Private _showeditables As Boolean = True
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
    Friend Property ShowAsEditable() As Boolean
        Get
            Return Me._showeditables
        End Get
        Set(ByVal value As Boolean)
            Me._showeditables = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value whether the cell's Text property is different than it's Number property.
    ''' </summary>
    ''' <remarks></remarks>
    Private _answerwrong As Boolean
    Friend Property AnswerWrong() As Boolean
        Get
            Return Me._answerwrong
        End Get
        Set(ByVal value As Boolean)
            Me._answerwrong = value
        End Set
    End Property

    ''' <summary>
    ''' Gets a System.Drawing.SizeF structure that specifies the measurement of the cell's System.Drawing.Font and text. 
    ''' </summary>
    ''' <param name="g">The Drawing.Graphics object used to measure the string.</param>
    ''' <value></value>
    ''' <returns>A System.Drawing.SizeF structure.</returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property StringFontSizeF(ByVal g As Graphics) As Drawing.SizeF
        Get
            Return g.MeasureString(Me.Text, Me.Font)
        End Get
    End Property

    ''' <summary>
    ''' Determines the font size according to the cell's Drawing.Size.
    ''' </summary>
    ''' <remarks></remarks>
    Friend ReadOnly Property FontSize() As Integer
        Get
            Dim fSz As Integer
            fSz = ((Math.Sqrt(Me.Rectangle.Width * Me.Rectangle.Height)) / Math.PI) * FontSizeMultiplier '(Size multiplier. Change to suit your needs)

            ' If for some reason our size is 0 or negative
            ' then we need to re-set our size to at least 1.
            ' This will prevent errors.
            If fSz <= 0 Then
                fSz = 1
            End If

            Return fSz
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the System.Drawing.Font that is used to display the cells text.
    ''' </summary>
    ''' <remarks></remarks>
    Private _font As Drawing.Font '= New Font("Arial", 12, Drawing.FontStyle.Regular)
    Friend Property Font() As Drawing.Font
        Get
            Me._font = New Drawing.Font("Times New Roman", Me.FontSize, Drawing.FontStyle.Regular)
            Return Me._font
        End Get
        Set(ByVal value As Drawing.Font)
            Me._font = New Drawing.Font(value.Name, _
            Me.FontSize, value.Style)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the image that is displayed when the cell is empty.
    ''' </summary>
    ''' <remarks></remarks>
    Private _emptyimage As Drawing.Bitmap
    Friend Property EmptyImage() As Drawing.Bitmap
        Get
            Return Me._emptyimage
        End Get
        Set(ByVal value As Drawing.Bitmap)
            Me._emptyimage = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the image that is displayed when the cell is filled.
    ''' </summary>
    ''' <remarks></remarks>
    Private _filledimage As Drawing.Bitmap
    Friend Property FilledImage() As Drawing.Bitmap
        Get
            Return Me._filledimage
        End Get
        Set(ByVal value As Drawing.Bitmap)
            Me._filledimage = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the image that is displayed when the value of the cell is wrong.
    ''' </summary>
    ''' <remarks></remarks>
    Private _answerwrongimage As Drawing.Bitmap
    Friend Property AnswerWrongImage() As Drawing.Bitmap
        Get
            Return Me._answerwrongimage
        End Get
        Set(ByVal value As Drawing.Bitmap)
            Me._answerwrongimage = value
        End Set
    End Property

    ''' <summary>
    ''' Draws the cell.
    ''' </summary>
    ''' <param name="e">The System.Windows.Form.PaintEventArgs object used to draw the cell.</param>
    ''' <remarks></remarks>
    Friend Sub Draw(ByVal e As PaintEventArgs)
        'Normal border pen
        Dim bdrPen As New Pen(Me.BorderColor, Me.BorderSize)

        'Border pen to use if cell is selected and answer is shown to be wrong
        Dim bdrPenWrong As New Pen(Me.HighlightColor, Me.BorderSize + 2)

        'Number brush
        Dim numbrush As New System.Drawing.SolidBrush(Me.TextColor)

        'FilledBackColor brush
        Dim filledbackcolorbrush As New System.Drawing.SolidBrush(Me.FilledColor)

        'EmptyBackColor brush
        Dim emptybackcolorbrush As New System.Drawing.SolidBrush(Me.EmptyColor)

        'HighlightColor brush
        Dim highlightcolorbrush As New System.Drawing.SolidBrush(Me.HighlightColor)

        'Answer wrong brush
        Dim answerwrongcolorbrush As New System.Drawing.SolidBrush(Me.AnswerWrongColor)

        'EDITABLE, NOT SELECTED, NOT WRONG
        If Me.AllowEdit And Not Me.Selected And Not Me.AnswerWrong Then 'I'm empty and NOT selected

            If Me.EmptyImage Is Nothing Then
                'Fill empty with empty color
                e.Graphics.FillRectangle(emptybackcolorbrush, Me.Rectangle)
            Else
                'Fill empty with image
                e.Graphics.DrawImage(Me.EmptyImage, Me.Rectangle)
            End If

            'EDITABLE, NOT SELECTED, WRONG
        ElseIf Me.AllowEdit And Not Me.Selected And Me.AnswerWrong Then
            e.Graphics.FillRectangle(answerwrongcolorbrush, Me.Rectangle)

            'EDITABLE, SELECTED, NOT WRONG
        ElseIf Me.AllowEdit And Me.Selected And Not Me.AnswerWrong Then
            e.Graphics.FillRectangle(highlightcolorbrush, Me.Rectangle)

            ' EDITABLE, SELECTED, WRONG
        ElseIf Me.AllowEdit And Me.Selected And Me.AnswerWrong Then
            Dim r As Rectangle = Me.Rectangle
            Dim rect As New Rectangle(r.X + 2, r.Y + 2, r.Width - 3, r.Height - 3)
            e.Graphics.FillRectangle(answerwrongcolorbrush, rect)

            'NOT EDITABLE, NOT SELECTED, NOT WRONG
        ElseIf Not Me.AllowEdit And Not Me.Selected And Not Me.AnswerWrong Then 'I'm NOT empty and NOT selected.
            If Me.FilledImage Is Nothing Then
                e.Graphics.FillRectangle(filledbackcolorbrush, Me.Rectangle)
            Else
                e.Graphics.DrawImage(Me.FilledImage, Me.Rectangle)
            End If
        End If


        ' ******************************************************************************************
        '                                   BORDERS GET DRAWN BELOW
        ' ******************************************************************************************

        ' *** SHOW SELECTED(HIGHLIGHTED) CELL EVEN WHEN IT IS SHOWED AS WRONG VALUE
        If Me.AllowEdit And Me.Selected And Me.AnswerWrong Then
            'If we have a border
            If Me.HasBorder Then
                ' Create a rectangle a little smaller than the cell's rectangle.
                ' We do this so that we don't overdraw another cell.
                Dim cBSize As Single = 2
                Dim rcb As Rectangle = Me.Rectangle

                rcb.X = (Me.Rectangle.X + cBSize)
                rcb.Y = (Me.Rectangle.Y + cBSize)
                rcb.Width = (Me.Rectangle.Width - cBSize * 2)
                rcb.Height = (Me.Rectangle.Height - cBSize * 2)

                ' DRAW THE HIGHLIGHTED BORDER
                Dim rect As New Rectangle(rcb.X, rcb.Y, rcb.Width, rcb.Height)
                e.Graphics.DrawRectangle(bdrPenWrong, rect)

                ' DRAW THE OUTER BORDER              
                e.Graphics.DrawRectangle(bdrPen, Me.Rectangle)
            Else
                ' Create a rectangle a little smaller than the cell's rectangle.
                ' We do this so that we don't overdraw another cell.
                Dim r As Rectangle = Me.Rectangle
                Dim rect As New Rectangle(r.X + 2, r.Y + 2, r.Width - 5, r.Height - 5)

                ' DRAW THE HIGHLIGHTED BORDER
                Dim highlightPen As New Pen(Me.HighlightColor, 3)
                e.Graphics.DrawRectangle(highlightPen, rect)

                ' DRAW THE OUTER BORDER
                Dim r1 As Rectangle = Me.Rectangle
                Dim rect1 As New Rectangle(r1.X, r1.Y, r1.Width - 1, r1.Height - 1)
                e.Graphics.DrawRectangle(New Pen(Color.Black, 1), rect1)
            End If
        Else
            'If we have a border
            If Me.HasBorder Then
                ' DRAW THE OUTER BORDER          
                e.Graphics.DrawRectangle(bdrPen, Me.Rectangle)
            End If
        End If

        'Draw the cell's text if it is not empty.
        If Me.Text <> "" Then
            Dim numMes As SizeF = Me.StringFontSizeF(e.Graphics)
            Dim numX As Single = (Me.Rectangle.X + (Me.Rectangle.Width / 2) - (numMes.Width / 2))
            Dim numY As Single = (Me.Rectangle.Y + (Me.Rectangle.Height / 2) - (numMes.Height / 2))

            If Me.AllowEdit Then
                e.Graphics.DrawString(Me.Text, Me.Font, numbrush, numX, numY)
            Else
                e.Graphics.DrawString(Me.Text, Me.Font, numbrush, numX, numY)
            End If

        End If
    End Sub

End Class
