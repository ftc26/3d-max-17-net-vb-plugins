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
    Friend ParamBlockDesc As IParamBlockDesc2
    Friend classidd As IClass_ID

    Public Sub New(globals As IGlobal)
        Me.m_global = globals
        classidd = GlobalInterface.Instance.Class_ID.Create(&H67AC6F4C, &H6EE11439)

        ParamBlockDesc = Me.m_global.ParamBlockDesc2.Create(0, "shaderParameters", IntPtr.Zero, Me, ParamBlock2Flags.Version Or ParamBlock2Flags.AutoConstruct Or ParamBlock2Flags.AutoUi, New Object() {1, 0})
        ParamBlockDesc.AddParam(0, New Object() {"ColorAmount", ParamType2.Float, ParamBlock2Flags.Animatable, 0, 5.0F, 0.0F, 100.0F})
        ParamBlockDesc.AddParam(1, New Object() {"Color", ParamType2.Rgba, ParamBlock2Flags.Animatable, 0, 0.5F, 0.0F, 1.0F}) ''
        ParamBlockDesc.AddParam(2, New Object() {"SpecularAmount", ParamType2.Float, ParamBlock2Flags.Animatable, 0, 0.5F, 0.0F, 1.0F})
        ParamBlockDesc.AddParam(3, New Object() {"SpecularColor", ParamType2.Rgba, ParamBlock2Flags.Animatable, 0, 0.5F, 0.0F, 1.0F})

    End Sub

    Public Overrides ReadOnly Property Category As String
        Get
            Return "Scanline SkinShader"

        End Get
    End Property

    Public Overrides ReadOnly Property ClassID As IClass_ID
        Get
            Return classidd
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
        Return New shader(Me, m_global)
    End Function

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
        i.AddClass(New MyrenderShadeClassDesc(g))
        i.AddClass(New MyutilityClassDesc)
    End Sub

    Public Shared Sub AssemblyShutdown()
    End Sub
End Class


#End Region