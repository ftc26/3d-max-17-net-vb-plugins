Imports Autodesk.Max
Imports System.Windows.Forms
Imports Autodesk.Max.Renderer

Public Class render
    Inherits Plugins.IScanRenderer

    Public Overrides ReadOnly Property ClassID As IClass_ID
        Get
            ClassID = GlobalInterface.Instance.Class_ID.Create(&H2B107DD4, &H743F000D)
            Return ClassID
        End Get
    End Property

    Public Overrides Property Antialias As Boolean
        Get
            Return Antialias
        End Get
        Set(value As Boolean)
            Antialias = value
        End Set
    End Property

    Public Overrides Property AntiAliasFilter As IFilterKernel
        Get
            Return AntiAliasFilter
        End Get
        Set(value As IFilterKernel)
            AntiAliasFilter = value
        End Set
    End Property

    Public Overrides Property AntiAliasFilterSz As Single
        Get
            Return AntiAliasFilterSz
        End Get
        Set(value As Single)
            AntiAliasFilterSz = value
        End Set
    End Property

    Public Overrides Property AutoReflect As Boolean
        Get
            Return AutoReflect
        End Get
        Set(value As Boolean)
            AutoReflect = value
        End Set
    End Property

    Public Overrides ReadOnly Property CompatibleWithAnyRenderElement As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Property Filter As Boolean
        Get
            Return Filter
        End Get
        Set(value As Boolean)
            Filter = value
        End Set
    End Property

    Public Overrides Property ForceWire As Boolean
        Get
            Return ForceWire
        End Get
        Set(value As Boolean)
            ForceWire = value
        End Set
    End Property

    Public Overrides ReadOnly Property IInteractiveRender As IIInteractiveRender
        Get

        End Get
    End Property

    Public Overrides ReadOnly Property IsPauseSupported As PauseSupport
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property IsStopSupported As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Property Mapping As Boolean
        Get
            Return Mapping
        End Get
        Set(value As Boolean)
            Mapping = value
        End Set
    End Property

    Public Overrides Property ObjMotBlur As Boolean
        Get
            Return ObjMotBlur
        End Get
        Set(value As Boolean)
            ObjMotBlur = value
        End Set
    End Property

    Public Overrides Property PixelSamplerEnable As Boolean
        Get
            Return PixelSamplerEnable
        End Get
        Set(value As Boolean)
            PixelSamplerEnable = value
        End Set
    End Property

    Public Overrides Property [Shadows] As Boolean
        Get
            Return [Shadows]
        End Get
        Set(value As Boolean)
            [Shadows] = value
        End Set
    End Property

    Public Overrides Property VelMotBlur As Boolean
        Get
            Return VelMotBlur
        End Get
        Set(value As Boolean)
            VelMotBlur = value
        End Set
    End Property

    Public Overrides Sub Close(hwnd As IntPtr, prog As IRendProgressCallback)

    End Sub

    Public Overrides Sub GetPlatformInformation(ByRef info As String)
        info = "Scanline SkinRender"

    End Sub

    Public Overrides Sub GetVendorInformation(ByRef info As String)
        info = "3ds max win"
    End Sub

    Public Overrides Sub PauseRendering()

    End Sub

    Public Overrides Sub ResetParams()

    End Sub

    Public Overrides Sub ResumeRendering()

    End Sub

    Public Overrides Sub SetAutoReflLevels(n As Integer)

    End Sub

    Public Overrides Sub SetNBlurFrames(n As Integer)

    End Sub

    Public Overrides Sub SetNBlurSamples(n As Integer)

    End Sub

    Public Overrides Sub SetObjBlurDuration(dur As Single)

    End Sub

    Public Overrides Sub SetVelBlurDuration(dur As Single)


    End Sub

    Public Overrides Sub SetWireThickness(t As Single)

    End Sub

    Public Overrides Sub StopRendering()

    End Sub

    Public Overrides Function CompatibleWithRenderElement(pIRenderElement As IIRenderElement) As Boolean
        Return True
    End Function

    Public Overrides Function CreateParamDialog(ir As IIRendParams, prog As Boolean) As IRendParamDlg

        'Dim pb As IIParamBlock2 = Me.GetParamBlock(0)
        'Dim gg = New System.Windows.Window()
        'gg.Content = New maxnetetst.renderolup()
        'gg.WindowStartupLocation = Windows.WindowStartupLocation.CenterOwner
        'gg.SizeToContent = Windows.SizeToContent.WidthAndHeight
        'Dim handler = New Windows.Interop.WindowInteropHelper(gg)
        'handler.Owner = ManagedServices.AppSDK.GetMaxHWND()
        'ManagedServices.AppSDK.ConfigureWindowForMax(gg)
        'gg.Show()

        ir.AddRollupPage(0, "rollup", ir.IRollup.Hwnd, "Myrender", 0, 0, 0)
        ' Dim masterDlg As IIAutoMParamDlg = sdescriptor.CreateParamDlgs(hwMtlEdit, ir, Me)
        'Return masterDlg
    End Function

    Public Overrides Function HasRequirement(requirement As Requirement) As Boolean
        Return False
    End Function

    Public Overrides Function NotifyRefChanged(changeInt As IInterval, hTarget As IReferenceTarget, ByRef partID As UIntPtr, message As RefMessage, propagate As Boolean) As RefResult
        Return RefResult.Succeed
    End Function

    Public Overrides Function Open(scene As IINode, vnode As IINode, viewPar As IViewParams, rp As IRendParams, hwnd As IntPtr, defaultLights As IDefaultLight, numDefLights As Integer, prog As IRendProgressCallback) As Integer
        Return 1
    End Function

    Public Overrides Function Render(t As Integer, tobm As IBitmap, frp As IFrameRendParams, hwnd As IntPtr, prog As IRendProgressCallback, viewPar As IViewParams) As Integer
        Return 1
    End Function
End Class
