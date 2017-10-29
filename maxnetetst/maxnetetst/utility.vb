Imports Autodesk.Max
Imports UiViewModels.Actions
Public Class utility
    Inherits Plugins.UtilityObj

    Public Overrides Sub BeginEditParams(ip As IInterface, iu As IIUtil)
        ip.AddRollupPage(0, "rollup", IntPtr.Zero, "", 0, 0, 0)
        ip.PushPrompt("mynetutility")
    End Sub

    Public Overrides Sub EndEditParams(ip As IInterface, iu As IIUtil)
        ip.PopPrompt()
    End Sub


End Class
