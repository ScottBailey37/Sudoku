<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LMSettingsDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.cbCircle = New System.Windows.Forms.CheckBox
        Me.cbEnableHints = New System.Windows.Forms.CheckBox
        Me.cbEnableHelp = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(52, 132)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'cbCircle
        '
        Me.cbCircle.AutoSize = True
        Me.cbCircle.Checked = True
        Me.cbCircle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCircle.Location = New System.Drawing.Point(11, 29)
        Me.cbCircle.Name = "cbCircle"
        Me.cbCircle.Size = New System.Drawing.Size(149, 17)
        Me.cbCircle.TabIndex = 1
        Me.cbCircle.Text = "Circle Conflicting Numbers"
        Me.cbCircle.UseVisualStyleBackColor = True
        '
        'cbEnableHints
        '
        Me.cbEnableHints.AutoSize = True
        Me.cbEnableHints.Checked = True
        Me.cbEnableHints.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEnableHints.Location = New System.Drawing.Point(11, 52)
        Me.cbEnableHints.Name = "cbEnableHints"
        Me.cbEnableHints.Size = New System.Drawing.Size(86, 17)
        Me.cbEnableHints.TabIndex = 3
        Me.cbEnableHints.Text = "Enable Hints"
        Me.cbEnableHints.UseVisualStyleBackColor = True
        '
        'cbEnableHelp
        '
        Me.cbEnableHelp.AutoSize = True
        Me.cbEnableHelp.Checked = True
        Me.cbEnableHelp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEnableHelp.Location = New System.Drawing.Point(11, 75)
        Me.cbEnableHelp.Name = "cbEnableHelp"
        Me.cbEnableHelp.Size = New System.Drawing.Size(118, 17)
        Me.cbEnableHelp.TabIndex = 4
        Me.cbEnableHelp.Text = "Enable Help Popup"
        Me.cbEnableHelp.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbCircle)
        Me.GroupBox1.Controls.Add(Me.cbEnableHelp)
        Me.GroupBox1.Controls.Add(Me.cbEnableHints)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 108)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'LMSettingsDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(210, 173)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LMSettingsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Learning Mode "
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cbCircle As System.Windows.Forms.CheckBox
    Friend WithEvents cbEnableHints As System.Windows.Forms.CheckBox
    Friend WithEvents cbEnableHelp As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
