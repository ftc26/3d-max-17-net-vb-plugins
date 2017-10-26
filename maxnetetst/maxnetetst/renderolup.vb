Imports ManagedServices
Imports Autodesk.Max
Imports System.Windows.Forms
Imports UiViewModels.Actions
Imports MaxCustomControls


Public Class renderolup


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub renderolup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ip = Autodesk.Max.GlobalInterface.Instance.COREInterface13
        Dim rs = ip.GetCurrentRenderer(False)
        TextBox1.Text = "hello from vb"
    End Sub

End Class
