Public Class SettingsForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CheckBoxCommon.Checked = Globals.Ribbons.RibbonLanguage.TargetSlides
        Me.CheckBoxMaster.Checked = Globals.Ribbons.RibbonLanguage.TargetMaster

    End Sub

    Private Sub ButtonManage_Click(sender As Object, e As EventArgs) Handles ButtonManage.Click
        Dim TargetSelection As New ManageTargetInterface
        TargetSelection.ShowDialog()
        If TargetSelection.DialogResult <> Windows.Forms.DialogResult.OK Then Exit Sub
        '### retrieve the new integer for Languages
        Globals.Ribbons.RibbonLanguage.IdListInteger = TargetSelection.Target.Values.ToList()
        If My.Settings.UseUserSettings = True Then
            My.Settings.LanguageIDUser = Globals.Ribbons.RibbonLanguage.ListToString(Globals.Ribbons.RibbonLanguage.IdListInteger)
            My.Settings.Save()
        End If
        Globals.Ribbons.RibbonLanguage.DropDownLanguage.Items.Clear()
        Globals.Ribbons.RibbonLanguage.IdListInteger.ForEach(Sub(i) Globals.Ribbons.RibbonLanguage.AddLanguage(i))
    End Sub

    Private Sub CheckBoxMaster_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMaster.CheckedChanged
        Globals.Ribbons.RibbonLanguage.TargetMaster = Me.CheckBoxMaster.Checked
    End Sub

    Private Sub CheckBoxCommon_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCommon.CheckedChanged
        Globals.Ribbons.RibbonLanguage.TargetSlides = Me.CheckBoxCommon.Checked
    End Sub
End Class