' Copyright © 2010-2012 Scott Bailey. All rights reserved.




<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SavePuzzleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadPuzzleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DifficultyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeginnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EasyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckAnswersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ShowPuzzleSolutionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreatePuzzleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlankSquareColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlankSquareNumberColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.GivenSquareColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GivenNumberColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.SquareHighlightColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BorderColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HasBorderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripBorderSizeTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.GridStyleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlainGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SudokuGridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.HideKeyPadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LearningModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartLearningModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl4 = New System.Windows.Forms.Label()
        Me.lbl5 = New System.Windows.Forms.Label()
        Me.lbl6 = New System.Windows.Forms.Label()
        Me.lbl9 = New System.Windows.Forms.Label()
        Me.lbl7 = New System.Windows.Forms.Label()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl8 = New System.Windows.Forms.Label()
        Me.lblClear = New System.Windows.Forms.Label()
        Me.gbKeyPad = New System.Windows.Forms.GroupBox()
        Me.TimerUpdateClock = New System.Windows.Forms.Timer(Me.components)
        Me.lblClock = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Grid1 = New Sudoku.Grid()
        Me.MenuStrip1.SuspendLayout()
        Me.gbKeyPad.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.GameToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.LearningModeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(588, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveSettingsToolStripMenuItem, Me.ToolStripSeparator4, Me.SavePuzzleToolStripMenuItem, Me.LoadPuzzleToolStripMenuItem, Me.ToolStripSeparator10, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SaveSettingsToolStripMenuItem
        '
        Me.SaveSettingsToolStripMenuItem.Enabled = False
        Me.SaveSettingsToolStripMenuItem.Name = "SaveSettingsToolStripMenuItem"
        Me.SaveSettingsToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SaveSettingsToolStripMenuItem.Text = "&Save Settings"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(140, 6)
        '
        'SavePuzzleToolStripMenuItem
        '
        Me.SavePuzzleToolStripMenuItem.Name = "SavePuzzleToolStripMenuItem"
        Me.SavePuzzleToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SavePuzzleToolStripMenuItem.Text = "&Save Puzzle"
        '
        'LoadPuzzleToolStripMenuItem
        '
        Me.LoadPuzzleToolStripMenuItem.Name = "LoadPuzzleToolStripMenuItem"
        Me.LoadPuzzleToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.LoadPuzzleToolStripMenuItem.Text = "&Load Puzzle"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(140, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "[ Esc ]"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ToolStripSeparator2, Me.DifficultyToolStripMenuItem, Me.CheckAnswersToolStripMenuItem, Me.ToolStripSeparator3, Me.ShowPuzzleSolutionToolStripMenuItem, Me.ToolStripSeparator12, Me.CreatePuzzleToolStripMenuItem})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.GameToolStripMenuItem.Text = "&Game"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.ShortcutKeyDisplayString = "[ N ]"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.NewGameToolStripMenuItem.Text = "&New Game"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(180, 6)
        '
        'DifficultyToolStripMenuItem
        '
        Me.DifficultyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeginnerToolStripMenuItem, Me.EasyToolStripMenuItem, Me.MediumToolStripMenuItem, Me.HardToolStripMenuItem})
        Me.DifficultyToolStripMenuItem.Name = "DifficultyToolStripMenuItem"
        Me.DifficultyToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.DifficultyToolStripMenuItem.Text = "&Difficulty"
        '
        'BeginnerToolStripMenuItem
        '
        Me.BeginnerToolStripMenuItem.CheckOnClick = True
        Me.BeginnerToolStripMenuItem.Name = "BeginnerToolStripMenuItem"
        Me.BeginnerToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.BeginnerToolStripMenuItem.Text = "&Beginner"
        '
        'EasyToolStripMenuItem
        '
        Me.EasyToolStripMenuItem.CheckOnClick = True
        Me.EasyToolStripMenuItem.Name = "EasyToolStripMenuItem"
        Me.EasyToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.EasyToolStripMenuItem.Text = "&Easy"
        '
        'MediumToolStripMenuItem
        '
        Me.MediumToolStripMenuItem.CheckOnClick = True
        Me.MediumToolStripMenuItem.Name = "MediumToolStripMenuItem"
        Me.MediumToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.MediumToolStripMenuItem.Text = "&Medium"
        '
        'HardToolStripMenuItem
        '
        Me.HardToolStripMenuItem.CheckOnClick = True
        Me.HardToolStripMenuItem.Name = "HardToolStripMenuItem"
        Me.HardToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.HardToolStripMenuItem.Text = "&Hard"
        '
        'CheckAnswersToolStripMenuItem
        '
        Me.CheckAnswersToolStripMenuItem.Name = "CheckAnswersToolStripMenuItem"
        Me.CheckAnswersToolStripMenuItem.ShortcutKeyDisplayString = "[ C ]"
        Me.CheckAnswersToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CheckAnswersToolStripMenuItem.Text = "&Check Answers"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
        '
        'ShowPuzzleSolutionToolStripMenuItem
        '
        Me.ShowPuzzleSolutionToolStripMenuItem.Name = "ShowPuzzleSolutionToolStripMenuItem"
        Me.ShowPuzzleSolutionToolStripMenuItem.ShortcutKeyDisplayString = "[ S ]"
        Me.ShowPuzzleSolutionToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ShowPuzzleSolutionToolStripMenuItem.Text = "&Solve"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(180, 6)
        '
        'CreatePuzzleToolStripMenuItem
        '
        Me.CreatePuzzleToolStripMenuItem.Name = "CreatePuzzleToolStripMenuItem"
        Me.CreatePuzzleToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CreatePuzzleToolStripMenuItem.Text = "Create &Puzzle"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlankSquareColorToolStripMenuItem, Me.BlankSquareNumberColorToolStripMenuItem, Me.ToolStripSeparator5, Me.GivenSquareColorToolStripMenuItem, Me.GivenNumberColorToolStripMenuItem, Me.ToolStripSeparator6, Me.SquareHighlightColorToolStripMenuItem, Me.ToolStripSeparator7, Me.BorderColorToolStripMenuItem, Me.HasBorderToolStripMenuItem, Me.ToolStripSeparator8, Me.GridStyleToolStripMenuItem, Me.ToolStripSeparator9, Me.HideKeyPadToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "&Options"
        '
        'BlankSquareColorToolStripMenuItem
        '
        Me.BlankSquareColorToolStripMenuItem.Name = "BlankSquareColorToolStripMenuItem"
        Me.BlankSquareColorToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.BlankSquareColorToolStripMenuItem.Text = "&Blank Square Color"
        '
        'BlankSquareNumberColorToolStripMenuItem
        '
        Me.BlankSquareNumberColorToolStripMenuItem.Name = "BlankSquareNumberColorToolStripMenuItem"
        Me.BlankSquareNumberColorToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.BlankSquareNumberColorToolStripMenuItem.Text = "Blank Square Number Color"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(219, 6)
        '
        'GivenSquareColorToolStripMenuItem
        '
        Me.GivenSquareColorToolStripMenuItem.Name = "GivenSquareColorToolStripMenuItem"
        Me.GivenSquareColorToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.GivenSquareColorToolStripMenuItem.Text = "&Given Square Color"
        '
        'GivenNumberColorToolStripMenuItem
        '
        Me.GivenNumberColorToolStripMenuItem.Name = "GivenNumberColorToolStripMenuItem"
        Me.GivenNumberColorToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.GivenNumberColorToolStripMenuItem.Text = "&Given Square Number Color"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(219, 6)
        '
        'SquareHighlightColorToolStripMenuItem
        '
        Me.SquareHighlightColorToolStripMenuItem.Name = "SquareHighlightColorToolStripMenuItem"
        Me.SquareHighlightColorToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.SquareHighlightColorToolStripMenuItem.Text = "&Highlight Color"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(219, 6)
        '
        'BorderColorToolStripMenuItem
        '
        Me.BorderColorToolStripMenuItem.Name = "BorderColorToolStripMenuItem"
        Me.BorderColorToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.BorderColorToolStripMenuItem.Text = "&Border Color"
        '
        'HasBorderToolStripMenuItem
        '
        Me.HasBorderToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnToolStripMenuItem, Me.OffToolStripMenuItem, Me.ToolStripSeparator1, Me.SizeToolStripMenuItem})
        Me.HasBorderToolStripMenuItem.Name = "HasBorderToolStripMenuItem"
        Me.HasBorderToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.HasBorderToolStripMenuItem.Text = "&Show Border"
        '
        'OnToolStripMenuItem
        '
        Me.OnToolStripMenuItem.CheckOnClick = True
        Me.OnToolStripMenuItem.Name = "OnToolStripMenuItem"
        Me.OnToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.OnToolStripMenuItem.Text = "&Yes"
        '
        'OffToolStripMenuItem
        '
        Me.OffToolStripMenuItem.CheckOnClick = True
        Me.OffToolStripMenuItem.Name = "OffToolStripMenuItem"
        Me.OffToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.OffToolStripMenuItem.Text = "&No"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(91, 6)
        '
        'SizeToolStripMenuItem
        '
        Me.SizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripBorderSizeTextBox})
        Me.SizeToolStripMenuItem.Name = "SizeToolStripMenuItem"
        Me.SizeToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.SizeToolStripMenuItem.Text = "&Size"
        '
        'ToolStripBorderSizeTextBox
        '
        Me.ToolStripBorderSizeTextBox.AutoSize = False
        Me.ToolStripBorderSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripBorderSizeTextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripBorderSizeTextBox.MaxLength = 1
        Me.ToolStripBorderSizeTextBox.Name = "ToolStripBorderSizeTextBox"
        Me.ToolStripBorderSizeTextBox.Size = New System.Drawing.Size(50, 23)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(219, 6)
        '
        'GridStyleToolStripMenuItem
        '
        Me.GridStyleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlainGridToolStripMenuItem, Me.SudokuGridToolStripMenuItem})
        Me.GridStyleToolStripMenuItem.Name = "GridStyleToolStripMenuItem"
        Me.GridStyleToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.GridStyleToolStripMenuItem.Text = "Gri&d Style"
        '
        'PlainGridToolStripMenuItem
        '
        Me.PlainGridToolStripMenuItem.CheckOnClick = True
        Me.PlainGridToolStripMenuItem.Name = "PlainGridToolStripMenuItem"
        Me.PlainGridToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.PlainGridToolStripMenuItem.Text = "&Plain Grid"
        '
        'SudokuGridToolStripMenuItem
        '
        Me.SudokuGridToolStripMenuItem.CheckOnClick = True
        Me.SudokuGridToolStripMenuItem.Name = "SudokuGridToolStripMenuItem"
        Me.SudokuGridToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.SudokuGridToolStripMenuItem.Text = "S&udoku Grid"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(219, 6)
        '
        'HideKeyPadToolStripMenuItem
        '
        Me.HideKeyPadToolStripMenuItem.Name = "HideKeyPadToolStripMenuItem"
        Me.HideKeyPadToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.HideKeyPadToolStripMenuItem.Text = "&Hide Key Pad"
        '
        'LearningModeToolStripMenuItem
        '
        Me.LearningModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartLearningModeToolStripMenuItem, Me.ToolStripSeparator11, Me.SettingsToolStripMenuItem})
        Me.LearningModeToolStripMenuItem.Name = "LearningModeToolStripMenuItem"
        Me.LearningModeToolStripMenuItem.Size = New System.Drawing.Size(99, 20)
        Me.LearningModeToolStripMenuItem.Text = "&Learning Mode"
        '
        'StartLearningModeToolStripMenuItem
        '
        Me.StartLearningModeToolStripMenuItem.Name = "StartLearningModeToolStripMenuItem"
        Me.StartLearningModeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.StartLearningModeToolStripMenuItem.Text = "Start &Learning Mode"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(178, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'lbl4
        '
        Me.lbl4.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4.ForeColor = System.Drawing.Color.LightGray
        Me.lbl4.Image = Global.Sudoku.My.Resources.Resources.black4
        Me.lbl4.Location = New System.Drawing.Point(9, 65)
        Me.lbl4.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl4.Size = New System.Drawing.Size(37, 37)
        Me.lbl4.TabIndex = 29
        Me.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl5
        '
        Me.lbl5.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5.ForeColor = System.Drawing.Color.LightGray
        Me.lbl5.Image = Global.Sudoku.My.Resources.Resources.black5
        Me.lbl5.Location = New System.Drawing.Point(50, 65)
        Me.lbl5.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl5.Size = New System.Drawing.Size(37, 37)
        Me.lbl5.TabIndex = 30
        Me.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6
        '
        Me.lbl6.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6.ForeColor = System.Drawing.Color.LightGray
        Me.lbl6.Image = Global.Sudoku.My.Resources.Resources.black6
        Me.lbl6.Location = New System.Drawing.Point(91, 65)
        Me.lbl6.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl6.Size = New System.Drawing.Size(37, 37)
        Me.lbl6.TabIndex = 31
        Me.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl9
        '
        Me.lbl9.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl9.ForeColor = System.Drawing.Color.LightGray
        Me.lbl9.Image = Global.Sudoku.My.Resources.Resources.black9
        Me.lbl9.Location = New System.Drawing.Point(91, 106)
        Me.lbl9.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl9.Name = "lbl9"
        Me.lbl9.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl9.Size = New System.Drawing.Size(37, 37)
        Me.lbl9.TabIndex = 34
        Me.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl7
        '
        Me.lbl7.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7.ForeColor = System.Drawing.Color.LightGray
        Me.lbl7.Image = Global.Sudoku.My.Resources.Resources.black7
        Me.lbl7.Location = New System.Drawing.Point(9, 106)
        Me.lbl7.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl7.Name = "lbl7"
        Me.lbl7.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl7.Size = New System.Drawing.Size(37, 37)
        Me.lbl7.TabIndex = 32
        Me.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3
        '
        Me.lbl3.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3.ForeColor = System.Drawing.Color.LightGray
        Me.lbl3.Image = Global.Sudoku.My.Resources.Resources.black3
        Me.lbl3.Location = New System.Drawing.Point(91, 24)
        Me.lbl3.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl3.Size = New System.Drawing.Size(37, 37)
        Me.lbl3.TabIndex = 37
        Me.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl2
        '
        Me.lbl2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.ForeColor = System.Drawing.Color.LightGray
        Me.lbl2.Image = Global.Sudoku.My.Resources.Resources.black2
        Me.lbl2.Location = New System.Drawing.Point(50, 24)
        Me.lbl2.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl2.Size = New System.Drawing.Size(37, 37)
        Me.lbl2.TabIndex = 36
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.Color.LightGray
        Me.lbl1.Image = Global.Sudoku.My.Resources.Resources.black1
        Me.lbl1.Location = New System.Drawing.Point(9, 24)
        Me.lbl1.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl1.Size = New System.Drawing.Size(37, 37)
        Me.lbl1.TabIndex = 35
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl8
        '
        Me.lbl8.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl8.ForeColor = System.Drawing.Color.LightGray
        Me.lbl8.Image = Global.Sudoku.My.Resources.Resources.black8
        Me.lbl8.Location = New System.Drawing.Point(50, 106)
        Me.lbl8.Margin = New System.Windows.Forms.Padding(2)
        Me.lbl8.Name = "lbl8"
        Me.lbl8.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lbl8.Size = New System.Drawing.Size(37, 37)
        Me.lbl8.TabIndex = 33
        Me.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClear
        '
        Me.lblClear.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClear.ForeColor = System.Drawing.Color.White
        Me.lblClear.Image = Global.Sudoku.My.Resources.Resources.blackClearA
        Me.lblClear.Location = New System.Drawing.Point(9, 147)
        Me.lblClear.Margin = New System.Windows.Forms.Padding(2)
        Me.lblClear.Name = "lblClear"
        Me.lblClear.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lblClear.Size = New System.Drawing.Size(119, 37)
        Me.lblClear.TabIndex = 38
        Me.lblClear.Text = "Clear"
        Me.lblClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbKeyPad
        '
        Me.gbKeyPad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbKeyPad.Controls.Add(Me.lbl2)
        Me.gbKeyPad.Controls.Add(Me.lbl5)
        Me.gbKeyPad.Controls.Add(Me.lbl1)
        Me.gbKeyPad.Controls.Add(Me.lblClear)
        Me.gbKeyPad.Controls.Add(Me.lbl7)
        Me.gbKeyPad.Controls.Add(Me.lbl8)
        Me.gbKeyPad.Controls.Add(Me.lbl4)
        Me.gbKeyPad.Controls.Add(Me.lbl9)
        Me.gbKeyPad.Controls.Add(Me.lbl6)
        Me.gbKeyPad.Controls.Add(Me.lbl3)
        Me.gbKeyPad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbKeyPad.Location = New System.Drawing.Point(446, 24)
        Me.gbKeyPad.Name = "gbKeyPad"
        Me.gbKeyPad.Size = New System.Drawing.Size(136, 193)
        Me.gbKeyPad.TabIndex = 39
        Me.gbKeyPad.TabStop = False
        Me.gbKeyPad.Text = "Key Pad"
        '
        'TimerUpdateClock
        '
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.Location = New System.Drawing.Point(509, 0)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(79, 20)
        Me.lblClock.TabIndex = 41
        Me.lblClock.Text = "00:00:00"
        Me.lblClock.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "sdku"
        Me.OpenFileDialog1.Filter = "Sudoku Puzzles|*.sdku"
        Me.OpenFileDialog1.Title = "Load - Sudoku Puzzle"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "sdku"
        Me.SaveFileDialog1.Filter = "Sudoku Puzzles|*.sdku"
        Me.SaveFileDialog1.Title = "Save - Sudoku Puzzle"
        '
        'Grid1
        '
        Me.Grid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid1.BackColor = System.Drawing.SystemColors.Control
        Me.Grid1.CellAnswerWrongColor = System.Drawing.Color.Brown
        Me.Grid1.CellAnswerWrongImage = Nothing
        Me.Grid1.CellBorderColor = System.Drawing.Color.Black
        Me.Grid1.CellBorderSize = 1
        Me.Grid1.CellEmptyColor = System.Drawing.Color.DimGray
        Me.Grid1.CellEmptyImage = Nothing
        Me.Grid1.CellFilledColor = System.Drawing.Color.Gray
        Me.Grid1.CellFilledImage = Nothing
        Me.Grid1.CellHighlightColor = System.Drawing.Color.Black
        Me.Grid1.CellsHaveBorder = True
        Me.Grid1.CircledConflictColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Grid1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Grid1.Difficulty = Sudoku.Grid.Level.Beginner
        Me.Grid1.GivenCellTextColor = System.Drawing.Color.Black
        Me.Grid1.GridStyle = Sudoku.Grid.Style.SudokuGrid
        Me.Grid1.Location = New System.Drawing.Point(2, 24)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.OpenCellTextColor = System.Drawing.Color.White
        Me.Grid1.ShowAllEditables = False
        Me.Grid1.Size = New System.Drawing.Size(438, 416)
        Me.Grid1.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 444)
        Me.Controls.Add(Me.lblClock)
        Me.Controls.Add(Me.gbKeyPad)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sudoku"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gbKeyPad.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid1 As Sudoku.Grid
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DifficultyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EasyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorderColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlankSquareColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GivenSquareColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SquareHighlightColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GivenNumberColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HasBorderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripBorderSizeTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents GridStyleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlainGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SudokuGridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckAnswersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowPuzzleSolutionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents lbl9 As System.Windows.Forms.Label
    Friend WithEvents lbl7 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lbl8 As System.Windows.Forms.Label
    Friend WithEvents lblClear As System.Windows.Forms.Label
    Friend WithEvents gbKeyPad As System.Windows.Forms.GroupBox
    Friend WithEvents BlankSquareNumberColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HideKeyPadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerUpdateClock As System.Windows.Forms.Timer
    Friend WithEvents lblClock As System.Windows.Forms.Label
    Friend WithEvents SavePuzzleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadPuzzleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents LearningModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartLearningModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeginnerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CreatePuzzleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
