Imports Autodesk.Max
Imports System.Windows.Forms
Imports UiViewModels.Actions
Imports Autodesk.Max.Renderer
Public Class menu
    Inherits UiViewModels.Actions.CuiActionCommandAdapter

    Public Overrides ReadOnly Property ActionText As String
        Get
            Return InternalActionText
        End Get
    End Property

    Public Overrides ReadOnly Property Category As String
        Get
            Return InternalCategory
        End Get
    End Property

    Public Overrides ReadOnly Property InternalActionText As String
        Get
            Return "Maxnexttest.dll Demo"
        End Get
    End Property

    Public Overrides ReadOnly Property InternalCategory As String
        Get
            Return "just testing some shit"
        End Get
    End Property

    Public Overrides Sub Execute(parameter As Object)
        Try

            MessageBox.Show("executing")
        Catch ex As Exception
            MessageBox.Show("Uncaught exception occurred: " + ex.Message)
        End Try
    End Sub
End Class
