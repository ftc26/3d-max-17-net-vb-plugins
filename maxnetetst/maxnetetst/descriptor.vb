Imports Autodesk.Max
Imports System.Windows.Forms
Imports UiViewModels.Actions
Imports Autodesk.Max.Renderer
Imports maxnetetst.utility
Imports maxnetetst.render
Imports maxnetetst.shader
Imports ManagedServices

#Region "descriptors"

Public Class MyutilityClassDesc
    Inherits Plugins.ClassDesc2

    Public Overrides ReadOnly Property Category As String
        Get
            Return "mynet Utility"
        End Get
    End Property

    Public Overrides ReadOnly Property ClassID As IClass_ID
        Get
            Return GlobalInterface.Instance.Class_ID.Create(&H4AFA7C9E, &H260902F3)
        End Get
    End Property

    Public Overrides ReadOnly Property ClassName As String
        Get
            Return "MyUtility"
        End Get
    End Property

    Public Overrides ReadOnly Property IsPublic As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property SuperClassID As SClass_ID
        Get
            Return SuperClassID.Utility

        End Get
    End Property

    Public Overrides Function Create(loading As Boolean) As Object
        Return New utility
    End Function
End Class

Public Class MyrenderClassDesc
    Inherits Plugins.ClassDesc2

    Public Overrides ReadOnly Property Category As String
        Get
            Return "Scanline SkinRender"
        End Get
    End Property

    Public Overrides ReadOnly Property ClassID As IClass_ID
        Get
            ClassID = GlobalInterface.Instance.Class_ID.Create(&H2B107DD4, &H743F000D)
            Return ClassID
        End Get
    End Property

    Public Overrides ReadOnly Property ClassName As String
        Get
            Return "Scanline SkinRender"
        End Get
    End Property

    Public Overrides ReadOnly Property IsPublic As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property SuperClassID As SClass_ID
        Get
            Dim ssc As SClass_ID
            Return ssc.Renderer
            'Dim ren As SClass_ID = &HF00
            'Return SClass_ID.Renderer
        End Get
    End Property

    Public Overrides Function Create(loading As Boolean) As Object
        Return New render()
    End Function
End Class

Public Class MyrenderShadeClassDesc
    Inherits Plugins.ClassDesc2
    Private m_global As IGlobal
    Private m_paramBlockDesc As IParamBlockDesc2
    Public ReadOnly Property ParamBlockDesc() As IParamBlockDesc2
        Get
            Return Me.m_paramBlockDesc
        End Get
    End Property

    ' Public Sub New()
    'Me.ParamBlockDesc = Me.Global.ParamBlockDesc2.Create(0, "Parameters",
    '                                                     IntPtr.Zero, Me,
    '                                                     ParamBlock2Flags.Version + ParamBlock2Flags.AutoConstruct + ParamBlock2Flags.AutoUi,
    '                                                     ParamBlock2Flags, New Object() {1, 0})
    '' Add parameter and specify name, type, flags, control id, default, minimum, and maximum values
    'Me.ParamBlockDesc.AddParam(0, New Object() {"color", ParamType2.Float, ParamBlock2Flags.Animatable, 0, 0.5F, 0F,
    '    1.0F})
    'End Sub

    Public ReadOnly Property [Global]() As IGlobal
        Get
            Return Me.m_global
        End Get
    End Property
    Public Overrides ReadOnly Property Category As String
        Get
            Return "Scanline SkinShader"

        End Get
    End Property

    Public Overrides ReadOnly Property ClassID As IClass_ID
        Get
            ClassID = GlobalInterface.Instance.Class_ID.Create(&H67AC6F4C, &H6EE11439)
            Return ClassID
        End Get
    End Property

    Public Overrides ReadOnly Property ClassName As String
        Get
            Return "Scanline SkinShader"
        End Get
    End Property

    Public Overrides ReadOnly Property IsPublic As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property SuperClassID As SClass_ID
        Get
            Dim ssc As SClass_ID
            Return ssc.Material

        End Get
    End Property

    Public Overrides Function Create(loading As Boolean) As Object
        Return New shader()
    End Function

End Class

#End Region

#Region "param blocks"

Public Class GlobalVariables
    'Public Shared valid As IInterval

    'Dim pb2 As IIParamBlock2 = Me.GetParamBlock(0)
    'Dim pb2dc As IParamBlockDesc2 = pb2.Desc
End Class

#End Region

#Region "assembly"

Public NotInheritable Class AssemblyFunctions
    Private Sub New()
    End Sub
    Public Shared Sub AssemblyMain()
        Dim g = Autodesk.Max.GlobalInterface.Instance
        Dim i = g.COREInterface13
        i.AddClass(New MyrenderClassDesc)
        i.AddClass(New MyrenderShadeClassDesc)
        i.AddClass(New MyutilityClassDesc)
    End Sub

    Public Shared Sub AssemblyShutdown()
    End Sub
End Class


#End Region