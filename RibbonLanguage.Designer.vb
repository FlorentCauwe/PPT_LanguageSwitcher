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
        Me.ButtonManage = Me.Factory.CreateRibbonButton
        Me.CheckBox1 = Me.Factory.CreateRibbonCheckBox
        Me.ButtonAbout = Me.Factory.CreateRibbonButton
        Me.ButtonSettings = Me.Factory.CreateRibbonButton
        Me.ButtonSwitch = Me.Factory.CreateRibbonButton
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
        Me.Group1.Items.Add(Me.ButtonSwitch)
        Me.Group1.Items.Add(Me.ButtonManage)
        Me.Group1.Items.Add(Me.CheckBox1)
        Me.Group1.Label = "Languages"
        Me.Group1.Name = "Group1"
        '
        'DropDownLanguage
        '
        Me.DropDownLanguage.Label = "Target"
        Me.DropDownLanguage.Name = "DropDownLanguage"
        '
        'ButtonManage
        '
        Me.ButtonManage.Enabled = False
        Me.ButtonManage.Label = "Manage languages list"
        Me.ButtonManage.Name = "ButtonManage"
        Me.ButtonManage.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Label = "Change master"
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Visible = False
        '
        'ButtonAbout
        '
        Me.ButtonAbout.Label = "About..."
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.OfficeImageId = "About"
        Me.ButtonAbout.ShowImage = True
        '
        'ButtonSettings
        '
        Me.ButtonSettings.Image = Global.PPT_LanguageSwitcher.My.Resources.Resources.settings
        Me.ButtonSettings.Label = "Settings"
        Me.ButtonSettings.Name = "ButtonSettings"
        Me.ButtonSettings.ShowImage = True
        '
        'ButtonSwitch
        '
        Me.ButtonSwitch.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.ButtonSwitch.Image = Global.PPT_LanguageSwitcher.My.Resources.Resources.languageswitch
        Me.ButtonSwitch.Label = "Switch Language"
        Me.ButtonSwitch.Name = "ButtonSwitch"
        Me.ButtonSwitch.ShowImage = True
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
    Friend WithEvents ButtonManage As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents CheckBox1 As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents ButtonSettings As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property RibbonLanguage() As RibbonLanguage
        Get
            Return Me.GetRibbon(Of RibbonLanguage)()
        End Get
    End Property
End Class
