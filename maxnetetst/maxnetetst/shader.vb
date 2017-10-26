Imports Autodesk.Max
Imports System
Imports System.Windows.Forms

#Region "shader"

Public Class shader
    Inherits Plugins.Mtl
    Dim vals As IInterval

    Public Sub New()
        vals = Autodesk.Max.GlobalInterface.Instance.Interval.Create()
        vals.SetInfinite()
    End Sub

    Public Overrides ReadOnly Property ClassID As IClass_ID
        Get
            ClassID = GlobalInterface.Instance.Class_ID.Create(&H67AC6F4C, &H6EE11439)
            Return ClassID

        End Get
    End Property

    Public Overrides ReadOnly Property RefTarget As IReferenceTarget
        Get
            Return Me

        End Get
    End Property

    Public Overrides Sub Reset()

    End Sub

    Public Overrides Sub SetAmbient(c As IColor, t As Integer)

    End Sub

    Public Overrides Sub SetDiffuse(c As IColor, t As Integer)

    End Sub

    Public Overrides Sub SetShininess(v As Single, t As Integer)

    End Sub

    Public Overrides Sub SetSpecular(c As IColor, t As Integer)

    End Sub

    Public Overrides Sub Shade(sc As IShadeContext)

    End Sub

    Public Overrides Sub Update(t As Integer, valid As IInterval)

    End Sub

    Public Overrides Function CreateParamDlg(hwMtlEdit As IntPtr, imp As IIMtlParams) As IParamDlg

        'Dim masterDlg As IIAutoMParamDlg = Me.descriptor.CreateParamDlgs(hwMtlEdit, imp, Me)

        'Return masterDlg
    End Function

    Public Overrides Function GetAmbient(mtlNum As Integer, backFace As Boolean) As IColor

    End Function

    Public Overrides Function GetDiffuse(mtlNum As Integer, backFace As Boolean) As IColor

    End Function

    Public Overrides Function GetShininess(mtlNum As Integer, backFace As Boolean) As Single

    End Function

    Public Overrides Function GetShinStr(mtlNum As Integer, backFace As Boolean) As Single

    End Function

    Public Overrides Function GetSpecular(mtlNum As Integer, backFace As Boolean) As IColor

    End Function

    Public Overrides Function GetXParency(mtlNum As Integer, backFace As Boolean) As Single

    End Function

    Public Overrides Function MapSlotType(i As Integer) As Integer

    End Function

    Public Overrides Function NotifyRefChanged(changeInt As IInterval, hTarget As IReferenceTarget, ByRef partID As UIntPtr, message As RefMessage, propagate As Boolean) As RefResult
        Return RefResult.Succeed
    End Function

    Public Overrides Function Validity(ByVal t As Integer) As IInterval

        Return vals
    End Function
End Class

#End Region