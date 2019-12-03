Imports System.Windows.Forms

Public Class LMSettingsDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Form1.Grid1.ShowCircled = Me.cbCircle.Checked
        Form1.Grid1.EnableHints = Me.cbEnableHints.Checked
        Form1.Grid1.EnableHelpPopup = Me.cbEnableHelp.Checked

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub LMSettingsDialog_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.cbEnableHelp.Checked = Form1.Grid1.EnableHelpPopup
        Me.cbEnableHints.Checked = Form1.Grid1.EnableHints
        Me.cbCircle.Checked = Form1.Grid1.ShowCircled
    End Sub
End Class
