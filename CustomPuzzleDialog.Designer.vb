<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomPuzzleDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblFindSolution = New System.Windows.Forms.Label
        Me.lblPlayNow = New System.Windows.Forms.Label
        Me.lblSave = New System.Windows.Forms.Label
        Me.CustomGrid1 = New Sudoku.CustomGrid
        Me.SuspendLayout()
        '
        'lblFindSolution
        '
        Me.lblFindSolution.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblFindSolution.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblFindSolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFindSolution.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblFindSolution.Image = Global.Sudoku.My.Resources.Resources.blackClearA
        Me.lblFindSolution.Location = New System.Drawing.Point(24, 440)
        Me.lblFindSolution.Margin = New System.Windows.Forms.Padding(2)
        Me.lblFindSolution.Name = "lblFindSolution"
        Me.lblFindSolution.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lblFindSolution.Size = New System.Drawing.Size(117, 36)
        Me.lblFindSolution.TabIndex = 36
        Me.lblFindSolution.Text = "Find Solution"
        Me.lblFindSolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPlayNow
        '
        Me.lblPlayNow.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblPlayNow.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblPlayNow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayNow.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblPlayNow.Image = Global.Sudoku.My.Resources.Resources.blackClearA
        Me.lblPlayNow.Location = New System.Drawing.Point(163, 440)
        Me.lblPlayNow.Margin = New System.Windows.Forms.Padding(2)
        Me.lblPlayNow.Name = "lblPlayNow"
        Me.lblPlayNow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lblPlayNow.Size = New System.Drawing.Size(117, 36)
        Me.lblPlayNow.TabIndex = 37
        Me.lblPlayNow.Text = "Play Now"
        Me.lblPlayNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayNow.Visible = False
        '
        'lblSave
        '
        Me.lblSave.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSave.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblSave.Image = Global.Sudoku.My.Resources.Resources.blackClearA
        Me.lblSave.Location = New System.Drawing.Point(302, 440)
        Me.lblSave.Margin = New System.Windows.Forms.Padding(2)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.lblSave.Size = New System.Drawing.Size(117, 36)
        Me.lblSave.TabIndex = 38
        Me.lblSave.Text = "Save Puzzle"
        Me.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSave.Visible = False
        '
        'CustomGrid1
        '
        Me.CustomGrid1.CellsHaveBorder = True
        Me.CustomGrid1.CellTextColor = System.Drawing.Color.Black
        Me.CustomGrid1.Location = New System.Drawing.Point(12, 12)
        Me.CustomGrid1.Name = "CustomGrid1"
        Me.CustomGrid1.Size = New System.Drawing.Size(419, 410)
        Me.CustomGrid1.TabIndex = 1
        '
        'CustomPuzzleDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 493)
        Me.Controls.Add(Me.lblSave)
        Me.Controls.Add(Me.lblPlayNow)
        Me.Controls.Add(Me.lblFindSolution)
        Me.Controls.Add(Me.CustomGrid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomPuzzleDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Puzzle Creator"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CustomGrid1 As Sudoku.CustomGrid
    Friend WithEvents lblFindSolution As System.Windows.Forms.Label
    Friend WithEvents lblPlayNow As System.Windows.Forms.Label
    Friend WithEvents lblSave As System.Windows.Forms.Label

End Class
