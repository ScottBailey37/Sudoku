' Copyright © 2010-2012 Scott Bailey. All rights reserved.




''' <summary>
''' Creates(solves) a sudoku puzzle by recursion and backtracking.
''' </summary>
''' <remarks></remarks>
Module SudokuGenerator
    'Private stopWatch As New Stopwatch

    ''' <summary>
    ''' Holds the entire Sudoku grid.
    ''' </summary>
    ''' <remarks></remarks>
    Friend SudokuGrid As New List(Of Square)
    ''' <summary>
    ''' Used to get random numbers from the list of available numbers.
    ''' </summary>
    ''' <remarks></remarks>
    Private r As New Random

    ''' <summary>
    ''' A Sudoku square.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Structure Square
        Dim Column As Integer 'Across
        Dim Row As Integer 'Down
        Dim Region As Integer
        Dim Value As Integer
        Dim Index As Integer
    End Structure

    ''' <summary>
    ''' Generates a new Sudoku grid.
    ''' </summary>
    ''' <remarks>This algorithm produces a valid Sudoku grid in an average of 0.02 seconds, tested over 5000 iterations.
    ''' </remarks>
    Friend Sub GenerateGrid()
        ' Start with a fresh, empty grid.
        ClearGrid()

        ' A temporary array to hold our squares.
        Dim Squares(80) As Square

        ' A temporary arraylist to hold a value of which numbers
        ' are available(that we can still use) in which squares.
        Dim Available(80) As List(Of Integer)

        ' Used to count what square on the grid we are at.
        Dim c As Integer = 0

        ' Initialize numbers 1-9 for every square on the grid.
        For x As Integer = 0 To Available.Length - 1
            Available(x) = New List(Of Integer)
            For i As Integer = 1 To 9
                Available(x).Add(i)
            Next
        Next

        ' Fill every square with a value.
        Do Until c = 81
            ' Have we tried every number and failed?
            If Not Available(c).Count = 0 Then
                ' Grab a random number from our list of available numbers.
                Dim i As Integer = GetRandomNumber(0, Available(c).Count - 1)
                Dim z As Integer = Available(c).Item(i)
                ' See if this number conflicts with any other square's
                ' number across, down, or in this square's region(3x3). 
                If Conflicts(Squares, Item(c, z)) = False Then
                    ' No conflict, so add it to the list of numbers.
                    Squares(c) = Item(c, z)
                    ' Now, this number has been used so 
                    ' remove it from the available numbers.
                    Available(c).RemoveAt(i)
                    ' Move on to the next number.
                    c += 1
                Else
                    ' This number conflicts with another square's number 
                    ' across, and/or down, and/or in this region so we
                    ' need to remove it from our available numbers so 
                    ' that we don't try and use it again.
                    Available(c).RemoveAt(i)
                End If
            Else
                ' All numbers failed so, we need to backtrack.
                ' Reset the current square's available numbers.
                For y As Integer = 1 To 9
                    Available(c).Add(y)
                Next
                ' Now, go back and try a different number in the previous square.
                Squares(c - 1) = Nothing
                c -= 1
            End If
        Loop

        ' All of our squares have been assigned valid numbers 
        ' so, add all of our squares to our Sudoku grid.
        Dim j As Integer
        For j = 0 To 80
            SudokuGrid.Add(Squares(j))
        Next
    End Sub

    ''' <summary>
    ''' Clears the Sudoku grid.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ClearGrid()
        SudokuGrid.Clear()
    End Sub

    ''' <summary>
    ''' Gets a pseudo-random number equal to or between lower and upper bounds.
    ''' </summary>
    ''' <param name="lower">The lower bound number.</param>
    ''' <param name="upper">The upper bound number.</param>
    ''' <returns>A pseudo-random number</returns>
    ''' <remarks></remarks>
    Private Function GetRandomNumber(ByVal lower As Integer, ByVal upper As Integer) As Integer
        Try
            Dim divider As Double
            If upper > 0 Then
                divider = upper
            Else
                divider = Date.Now.Ticks 'My.Computer.Clock.TickCount
            End If
            r = New Random(My.Computer.Clock.TickCount / divider)
            Return r.Next(lower, upper + 1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Checks to see if the test square's value conflicts with a value in the current squares.
    ''' </summary>
    ''' <param name="currentSquares">The list of squares to check against.</param>
    ''' <param name="testSquare">The square to check for.</param>
    ''' <returns>A Boolean value whether the test square passed or failed.</returns>
    ''' <remarks></remarks>
    Friend Function Conflicts(ByVal currentSquares As Square(), ByVal testSquare As Square) As Boolean
        ' This should be where I can keep the Sudoku grid from having more 
        ' than 1 solution by counting how many squares conflict with testSquare.
        Dim count As Integer
        For Each sq As Square In currentSquares
            count += 1
            If (sq.Column <> 0 And sq.Column = testSquare.Column) OrElse _
               (sq.Row <> 0 And sq.Row = testSquare.Row) OrElse _
               (sq.Region <> 0 And sq.Region = testSquare.Region) Then

                If sq.Value = testSquare.Value Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Function Item(ByVal n As Integer, ByVal v As Integer) As Square
        n += 1
        Item.Column = GetAcrossFromNumber(n)
        Item.Row = GetDownFromNumber(n)
        Item.Region = GetRegionFromNumber(n)
        Item.Value = v
        Item.Index = n - 1
    End Function

    ''' <summary>
    ''' Gets the number across from the given number.
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetAcrossFromNumber(ByVal n As Integer) As Integer
        Dim k As Integer
        k = n Mod 9
        If k = 0 Then Return 9 Else Return k
    End Function

    ''' <summary>
    ''' Gets the number down from the given number.
    ''' </summary>
    ''' <param name="n"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetDownFromNumber(ByVal n As Integer) As Integer
        Dim k As Integer
        If GetAcrossFromNumber(n) = 9 Then
            k = n \ 9
        Else
            k = n \ 9 + 1
        End If
        Return k
    End Function

    Private Function GetRegionFromNumber(ByVal n As Integer) As Integer
        Dim k As Integer
        Dim a As Integer = GetAcrossFromNumber(n)
        Dim d As Integer = GetDownFromNumber(n)

        If 1 <= a And a < 4 And 1 <= d And d < 4 Then
            k = 1
        ElseIf 4 <= a And a < 7 And 1 <= d And d < 4 Then
            k = 2
        ElseIf 7 <= a And a < 10 And 1 <= d And d < 4 Then
            k = 3
        ElseIf 1 <= a And a < 4 And 4 <= d And d < 7 Then
            k = 4
        ElseIf 4 <= a And a < 7 And 4 <= d And d < 7 Then
            k = 5
        ElseIf 7 <= a And a < 10 And 4 <= d And d < 7 Then
            k = 6
        ElseIf 1 <= a And a < 4 And 7 <= d And d < 10 Then
            k = 7
        ElseIf 4 <= a And a < 7 And 7 <= d And d < 10 Then
            k = 8
        ElseIf 7 <= a And a < 10 And 7 <= d And d < 10 Then
            k = 9
        End If
        Return k
    End Function

    Private Function PuzzleValid(ByVal userPuzzle() As Square) As Boolean
        '**************************************************************************
        '' Before we do anything, check the values entered
        '' by the user. It is possible that they have entered
        '' conflicting numbers. If they have then there is no
        '' use of trying to find a solution.
        '**************************************************************************
        ' *************** CHECK EACH ROW FOR DUPLICATES ***************
        '**************************************************************************
        Dim Rows(8) As List(Of Square)
        For i As Integer = 0 To (Rows.Length - 1)
            Rows(i) = New List(Of Square)
        Next

        For u As Integer = 0 To (Rows.Length - 1)
            For h As Integer = 0 To 80
                If userPuzzle(h).Row = (u + 1) Then
                    Rows(u).Add(userPuzzle(h))
                End If
            Next
        Next

        Dim rowToMatch As Square
        For i As Integer = 0 To (Rows.Length - 1) ' For ALL 9 Regions
            For v As Integer = 0 To Rows(i).Count - 1 ' For ALL 9 Squares in the Region
                rowToMatch = Rows(i)(v)
                If rowToMatch.Value <> 0 Then
                    For Each squ As Square In Rows(i)
                        If squ.Value = rowToMatch.Value Then
                            If squ.Index <> rowToMatch.Index Then
                                'MsgBox("Sorry, but a valid solution could not be found." + Environment.NewLine + _
                                '       "Make sure that you entered the numbers correctly and try again." + Environment.NewLine + _
                                '       "[Row]")
                                Return False
                            End If
                        End If
                    Next
                End If
            Next
        Next

        ' *************** CHECK EACH COLUMN FOR DUPLICATES ***************
        Dim Columns(8) As List(Of Square)
        For i As Integer = 0 To (Columns.Length - 1)
            Columns(i) = New List(Of Square)
        Next

        For u As Integer = 0 To (Columns.Length - 1)
            For h As Integer = 0 To 80
                If userPuzzle(h).Column = (u + 1) Then
                    Columns(u).Add(userPuzzle(h))
                End If
            Next
        Next

        Dim columnToMatch As Square
        For i As Integer = 0 To (Columns.Length - 1) ' For ALL 9 Regions
            For v As Integer = 0 To Columns(i).Count - 1 ' For ALL 9 Squares in the Region
                columnToMatch = Columns(i)(v)
                If columnToMatch.Value <> 0 Then
                    For Each squ As Square In Columns(i)
                        If squ.Value = columnToMatch.Value Then
                            If squ.Index <> columnToMatch.Index Then
                                'MsgBox("Sorry, but a valid solution could not be found." + Environment.NewLine + _
                                '       "Make sure that you entered the numbers correctly and try again." + Environment.NewLine + _
                                '       "[Column]")
                                Return False
                            End If
                        End If
                    Next
                End If
            Next
        Next

        ' *************** CHECK EACH REGION FOR DUPLICATES ***************
        Dim Regions(8) As List(Of Square)
        For i As Integer = 0 To (Regions.Length - 1)
            Regions(i) = New List(Of Square)
        Next

        For u As Integer = 0 To (Regions.Length - 1)
            For h As Integer = 0 To 80
                If userPuzzle(h).Region = (u + 1) Then
                    Regions(u).Add(userPuzzle(h))
                End If
            Next
        Next

        Dim sqToMatch As Square
        For i As Integer = 0 To (Regions.Length - 1) ' For ALL 9 Regions
            For v As Integer = 0 To Regions(i).Count - 1 ' For ALL 9 Squares in the Region
                sqToMatch = Regions(i)(v)
                If sqToMatch.Value <> 0 Then
                    For Each squ As Square In Regions(i)
                        If squ.Value = sqToMatch.Value Then
                            If squ.Index <> sqToMatch.Index Then
                                'MsgBox("Sorry, but a valid solution could not be found." + Environment.NewLine + _
                                '       "Make sure that you entered the numbers correctly and try again." + Environment.NewLine + _
                                '       "[Region]")
                                Return False
                            End If
                        End If
                    Next
                End If
            Next
        Next

        Return True
    End Function

    ''' <summary>
    ''' Tries to generate a solution for the user submitted puzzle.
    ''' </summary>
    ''' <param name="userPuzzle">The user submitted puzzle.</param>
    ''' <returns>A valid solution for the submitted puzzle if one can be found. Otherwise returns nothing</returns>
    ''' <remarks></remarks>
    Friend Function GenerateSolution(ByVal userPuzzle() As Square) As Square()

        If userPuzzle IsNot Nothing Then
            ' Check the submitted puzzle for validity
            ' before proceeding to find a solution.
            If PuzzleValid(userPuzzle) Then
                Try

                    '*****************************************************************************
                    ' FIND A SOLUTION TO THE USER SUBMITTED PUZZLE
                    '*****************************************************************************

                    '' Start the timer
                    'stopWatch.Start()

                    ' A temporary array to hold our squares.
                    Dim Solution(80) As Square

                    ' A list of user squares that we cant touch.
                    ' These are the squares that the user entered
                    ' numbers in and therefore, should not be altered.
                    Dim UserSquares As New List(Of Integer)

                    Dim count As Integer
                    For i As Integer = 0 To (userPuzzle.Length - 1)
                        If userPuzzle(i).Value = 0 Then
                            count += 1
                        Else
                            UserSquares.Add(i)
                        End If
                    Next

                    ' A temporary arraylist to hold a value of which numbers
                    ' are available(that we can still use) in which squares.
                    Dim Available(80) As List(Of Integer)

                    ' Initialize numbers 1-9 for every square on the grid.
                    For x As Integer = 0 To Available.Length - 1
                        Available(x) = New List(Of Integer)
                        For i As Integer = 1 To 9
                            Available(x).Add(i)
                        Next
                    Next

                    ' Used to count what square on the grid we are at.
                    Dim c As Integer = 0

                    ' Fill every square with a value.
                    Do Until c = 81
                        ' If a square value is not 0 then leave it alone.
                        ' If it is not 0 then the user has added a number 
                        ' to this square as part of their puzzle.
                        If userPuzzle(c).Value = 0 Then
                            ' Have we tried every number and failed?
                            If Not Available(c).Count = 0 Then
                                ' Grab a random number from our list of available numbers.
                                Dim i As Integer = GetRandomNumber(0, Available(c).Count - 1)
                                Dim z As Integer = Available(c).Item(i)

                                If c > 46 Then
                                    Dim nghg = 8
                                End If

                                ' See if this number conflicts with any other square's
                                ' number across, down, or in this square's region(3x3).
                                If Conflicts(userPuzzle, Item(c, z)) = False Then
                                    ' No conflict, so add it to the list of numbers.
                                    userPuzzle(c) = Item(c, z)

                                    ' Now, this number has been used so 
                                    ' remove it from the available numbers.
                                    Available(c).RemoveAt(i)

                                    ' Move on to the next number.
                                    c += 1
                                Else
                                    ' This number conflicts with another square's number 
                                    ' across, and/or down, and/or in this region so we
                                    ' need to remove it from our available numbers so 
                                    ' that we don't try and use it again.
                                    Dim num As Integer = Available(c)(i)
                                    Available(c).RemoveAt(i)
                                End If

                            Else    '** NO MORE NUMBERS AVAILABLE FOR CURRENT SQUARE ***
                                ' All numbers failed so, we need to backtrack.
                                ' Reset the current square's available numbers.
                                For y As Integer = 1 To 9
                                    Available(c).Add(y)
                                Next

                                ' Keep going back until we find a square that
                                ' we are allowed to alter. Then try a different number
                                ' in that square. 
                                ' NOTE: If we go all the way back to square '0' and
                                '       it is a square that we are NOT allowed to alter 
                                '       then we will go forward until we find a square that
                                '       we ARE allowed to alter.

                                Dim counter As Integer = c
                                ' If we can go back 1 square without interfering
                                ' with our restricted squares then do it.
                                If Not UserSquares.Contains(counter - 1) Then
                                    counter -= 1
                                Else
                                    ' Going back 1 square is not enough to get
                                    ' to an UN-RESTRICTED square. So, we will keep
                                    ' going back until it is enough.
                                    Do While UserSquares.Contains(counter - 1) OrElse UserSquares.Contains(counter)
                                        counter -= 1
                                        If Not UserSquares.Contains(counter) Then
                                            Exit Do
                                        End If
                                    Loop
                                End If

                                ' If we had to go back to the beginning and
                                ' went back too far then we just set our counter
                                ' to the first square.
                                If counter < 0 Then
                                    counter = 0
                                    ' If the first square is a RESTRICTED square
                                    ' then we will go forward until we find a square
                                    ' that is UN-RESTRICTED.
                                    Do While UserSquares.Contains(counter)
                                        counter += 1
                                    Loop
                                End If

                                ' Double check that we aren't 
                                ' altering any RESTRICTED squares.
                                For Each i As Integer In UserSquares
                                    If counter = i Then
                                        Dim mnmn = 8
                                    End If
                                Next

                                If counter < 0 OrElse counter > 80 Then
                                    MsgBox("Counter is < 0  OrElse counter > 80: " + "COUNTER [" + counter.ToString + "]")
                                End If
                                c = counter
                                userPuzzle(c).Value = 0
                            End If
                        Else
                            ' Skip the square and go on to the next one.
                            c += 1
                        End If
                    Loop

                    ' All of our squares have been assigned valid numbers 
                    ' so, add all of our squares to our Sudoku grid.
                    Dim j As Integer
                    For j = 0 To 80
                        Solution(j) = userPuzzle(j)
                    Next

                    'stopWatch.Stop()
                    'MsgBox("Solved in: " + stopWatch.Elapsed.ToString)
                    'stopWatch.Reset()

                    Return Solution
                Catch ex As Exception
                    'stopWatch.Stop()
                    'stopWatch.Reset()
                    'MsgBox(ex.Message)
                    MsgBox("Sorry, but a valid solution could not be found.")
                    Return Nothing
                End Try
            Else
                MsgBox("That is not a valid puzzle." + Environment.NewLine + _
                       "Make sure that you typed the numbers correctly and try again.")
            End If
        End If

        Return Nothing
    End Function
End Module