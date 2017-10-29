Imports Autodesk.Max
Imports System
Imports System.Windows.Forms
Imports Autodesk.Max.Plugins

#Region "shader"

Public Class shader
    Inherits Plugins.Mtl
    Dim vals As IInterval
    Private sdescriptor As MyrenderShadeClassDesc
    Private globals As IGlobal
    Shared shaderClassID As IClass_ID
    Private paramBlock As IIParamBlock2
    Private paramMap As IIParamMap2
    Private paramMap1 As IIParamMap2
    Private manager As IManager
    Private diffuse As IColor
    Private scene As INode

    Public Overrides ReadOnly Property NumparamBlocks() As Integer
        Get
            Return 1
        End Get
    End Property

    Public Property Pblock2() As IIParamBlock2
        Get
            Return Me.paramBlock
        End Get
        Set(value As IIParamBlock2)
            Me.paramBlock = value
        End Set
    End Property

    Public Sub New(shadeclassdesc As MyrenderShadeClassDesc, global_ As IGlobal)
        'MyBase.New()

        sdescriptor = shadeclassdesc
        Me.globals = global_
        Me.manager = Me.globals.Manager
        vals = Autodesk.Max.GlobalInterface.Instance.Interval.Create()
        vals.SetInfinite()
        Me.sdescriptor.MakeAutoParamBlocks(Me)
    End Sub

    Public ReadOnly Property getDesc2 As MyrenderShadeClassDesc
        Get
            Return sdescriptor
        End Get
    End Property

    Public Overrides ReadOnly Property ClassID As IClass_ID
        Get

            ClassID = GlobalInterface.Instance.Class_ID.Create(&H67AC6F4C, &H6EE11439)
            shaderClassID = ClassID
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

    Public Overrides Sub SetReference(i As Integer, rtarg As IReferenceTarget)
        If i = 0 Then
            paramBlock = DirectCast(rtarg, IIParamBlock2)
        End If
    End Sub

    Public Overrides Sub SetAmbient(c As IColor, t As Integer)

    End Sub

    Public Overrides Sub SetDiffuse(c As IColor, t As Integer)
        'diffuse = c
        'Dim gh As Short = 0
        'paramBlock.SetValue(gh, t, diffuse, 0)
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

        'imp.AddRollupPage(0, "rollup", hwMtlEdit, "Myshader", 0, 0, 0)
        Dim i = Autodesk.Max.GlobalInterface.Instance.COREInterface13
        scene = i.GetSelNode(0)
        Me.paramMap = Me.sdescriptor.ParamBlockDesc.CreateParamMap2(Nothing, imp, hwMtlEdit, Me.GetparamBlock(0))
        ' Me.paramMap1 = Me.sdescriptor.ParamBlockDesc.CreateParamMap2(Nothing, imp, hwMtlEdit, Me.GetparamBlock(1))
        'Dim masterDlg As IIAutoMParamDlg = sdescriptor.CreateParamDlgs(hwMtlEdit, imp, Me)
        'Return masterDlg

    End Function

    Public Overrides Function GetAmbient(mtlNum As Integer, backFace As Boolean) As IColor

    End Function

    Public Overrides Function GetDiffuse(mtlNum As Integer, backFace As Boolean) As IColor

    End Function

    Public Overrides Function GetShininess(mtlNum As Integer, backFace As Boolean) As Single
        Return 40.0F
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
        Dim f As Single = 0.0F
        Dim sh As Short = 0
        Me.Pblock2.GetValue(sh, t, f, vals, 0)
        Return vals
    End Function

    Public Overrides Function SubAnim(i As Integer) As IAnimatable
        Return If(i = 0, paramBlock, Nothing)
    End Function

    Public Overrides Function GetparamBlock(i As Integer) As IIParamBlock2
        Return If(i = 0, paramBlock, Nothing)
    End Function

    Public Overrides Sub BeginEditParams(ip As IIObjParam, flags As UInteger, prev As IAnimatable)
        MyBase.BeginEditParams(ip, flags, prev)

        Me.paramMap = sdescriptor.ParamBlockDesc.CreateParamMap2(ip, Nothing, IntPtr.Zero, Me.paramBlock)
    End Sub

    Public Overrides Sub EndEditParams(ip As IIObjParam, flags As UInteger, [next] As IAnimatable)
        MyBase.EndEditParams(ip, flags, [next])

        If Me.paramMap IsNot Nothing Then
            Me.globals.DestroyCPParamMap2(Me.paramMap)
            Me.paramMap = Nothing
        End If
    End Sub


End Class

#End Region