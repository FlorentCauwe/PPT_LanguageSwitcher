<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.CheckBoxMaster = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCommon = New System.Windows.Forms.CheckBox()
        Me.ButtonManage = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBoxMaster
        '
        Me.CheckBoxMaster.AutoSize = True
        Me.CheckBoxMaster.Location = New System.Drawing.Point(12, 12)
        Me.CheckBoxMaster.Name = "CheckBoxMaster"
        Me.CheckBoxMaster.Size = New System.Drawing.Size(121, 17)
        Me.CheckBoxMaster.TabIndex = 0
        Me.CheckBoxMaster.Text = "Target Master-slides"
        Me.ToolTip1.SetToolTip(Me.CheckBoxMaster, "Switch the language of the master slides")
        Me.CheckBoxMaster.UseVisualStyleBackColor = True
        '
        'CheckBoxCommon
        '
        Me.CheckBoxCommon.AutoSize = True
        Me.CheckBoxCommon.Location = New System.Drawing.Point(12, 35)
        Me.CheckBoxCommon.Name = "CheckBoxCommon"
        Me.CheckBoxCommon.Size = New System.Drawing.Size(147, 17)
        Me.CheckBoxCommon.TabIndex = 1
        Me.CheckBoxCommon.Text = "Target presentation slides"
        Me.ToolTip1.SetToolTip(Me.CheckBoxCommon, "Switch the language of the common slides")
        Me.CheckBoxCommon.UseVisualStyleBackColor = True
        '
        'ButtonManage
        '
        Me.ButtonManage.Location = New System.Drawing.Point(12, 60)
        Me.ButtonManage.Name = "ButtonManage"
        Me.ButtonManage.Size = New System.Drawing.Size(147, 23)
        Me.ButtonManage.TabIndex = 2
        Me.ButtonManage.Text = "Manage language list"
        Me.ToolTip1.SetToolTip(Me.ButtonManage, "add or remove languages to the language list")
        Me.ButtonManage.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.PPT_LanguageSwitcher.My.Resources.Resources.languageswitch
        Me.PictureBox1.Location = New System.Drawing.Point(199, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 38)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 101)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonManage)
        Me.Controls.Add(Me.CheckBoxCommon)
        Me.Controls.Add(Me.CheckBoxMaster)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(275, 140)
        Me.MinimumSize = New System.Drawing.Size(275, 140)
        Me.Name = "SettingsForm"
        Me.Text = "Settings"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBoxMaster As Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCommon As Windows.Forms.CheckBox
    Friend WithEvents ButtonManage As Windows.Forms.Button
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
