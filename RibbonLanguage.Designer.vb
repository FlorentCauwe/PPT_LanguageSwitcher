Partial Class RibbonLanguage
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.DropDownLanguage = Me.Factory.CreateRibbonDropDown
        Me.ButtonSettings = Me.Factory.CreateRibbonButton
        Me.ButtonAbout = Me.Factory.CreateRibbonButton
        Me.ButtonSwitch = Me.Factory.CreateRibbonButton
        Me.CB_Presentation = Me.Factory.CreateRibbonCheckBox
        Me.CB_Slide = Me.Factory.CreateRibbonCheckBox
        Me.CB_Selection = Me.Factory.CreateRibbonCheckBox
        Me.Tab1.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.Tab1.Groups.Add(Me.Group1)
        Me.Tab1.Label = "TabAddIns"
        Me.Tab1.Name = "Tab1"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.DropDownLanguage)
        Me.Group1.Items.Add(Me.ButtonSettings)
        Me.Group1.Items.Add(Me.ButtonAbout)
        Me.Group1.Items.Add(Me.CB_Presentation)
        Me.Group1.Items.Add(Me.CB_Slide)
        Me.Group1.Items.Add(Me.CB_Selection)
        Me.Group1.Items.Add(Me.ButtonSwitch)
        Me.Group1.Label = "Languages"
        Me.Group1.Name = "Group1"
        '
        'DropDownLanguage
        '
        Me.DropDownLanguage.Label = "Switch to"
        Me.DropDownLanguage.Name = "DropDownLanguage"
        '
        'ButtonSettings
        '
        Me.ButtonSettings.Image = Global.PPT_LanguageSwitcher.My.Resources.Resources.settings
        Me.ButtonSettings.Label = "Settings"
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.ShowImage = True
        '
        'ButtonAbout
        '
        Me.ButtonAbout.Label = "About..."
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.OfficeImageId = "About"
        Me.ButtonAbout.ShowImage = True
        '
        'ButtonSwitch
        '
        Me.ButtonSwitch.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.ButtonSwitch.Image = Global.PPT_LanguageSwitcher.My.Resources.Resources.languageswitch
        Me.ButtonSwitch.Label = "Switch Language"
        Me.ButtonSwitch.Name = "ButtonSwitch"
        Me.ButtonSwitch.ShowImage = True
        '
        'CB_Presentation
        '
        Me.CB_Presentation.Checked = True
        Me.CB_Presentation.Label = "Presentation"
        Me.CB_Presentation.Name = "CB_Presentation"
        Me.CB_Presentation.ScreenTip = "switch for the whole presentation"
        '
        'CB_Slide
        '
        Me.CB_Slide.Label = "Current slide"
        Me.CB_Slide.Name = "CB_Slide"
        Me.CB_Slide.ScreenTip = "switch only the current slide"
        '
        'CB_Selection
        '
        Me.CB_Selection.Label = "Selected slides"
        Me.CB_Selection.Name = "CB_Selection"
        Me.CB_Selection.ScreenTip = "switch for the selected slides"
        '
        'RibbonLanguage
        '
        Me.Name = "RibbonLanguage"
        Me.RibbonType = "Microsoft.PowerPoint.Presentation"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents DropDownLanguage As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents ButtonAbout As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents ButtonSwitch As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents ButtonSettings As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents CB_Presentation As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents CB_Slide As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents CB_Selection As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property RibbonLanguage() As RibbonLanguage
        Get
            Return Me.GetRibbon(Of RibbonLanguage)()
        End Get
    End Property
End Class
