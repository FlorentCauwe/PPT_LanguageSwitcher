Imports Microsoft.Office.Tools.Ribbon
Imports Microsoft.Office.Core

Public Class RibbonLanguage
    Public Property IdListInteger As List(Of Integer)

    Private Sub RibbonLanguage_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load
        'add the language entries to the drop down list
        AddLanguages()
    End Sub
    Private Sub AddLanguages()
        'check user settings
        Dim UserSetting As String = My.Settings.LanguageIDUser
        If My.Settings.UseUserSettings = True AndAlso Not (String.IsNullOrEmpty(UserSetting)) AndAlso UserSetting <> My.Settings.LanguageIDList Then
            'use the user settings
            AddLanguagesFromIdString(UserSetting)
        Else
            'use the application settings
            AddLanguagesFromIdString(My.Settings.LanguageIDList)
        End If
    End Sub

    Private Sub AddLanguagesFromIdString(IdString As String)
        DropDownLanguage.Items.Clear()
        Me.IdListInteger = New List(Of Integer)

        'From Settings
        Dim IdListString As List(Of String) = IdString.Split(";").ToList()
        'Dim IdListInteger As List(Of Integer) = New List(Of Integer)
        IdListString.ForEach(Sub(s) IdListInteger.Add(CInt(s)))
        IdListInteger.ForEach(Sub(i) AddLanguage(i))
    End Sub
    Public Sub AddLanguageFromDocument()
        'From the current Document
        'use the first textframe to set the languageId. add it to the list if not in the settings
        Dim LanguageIdFromdocument As Integer = Globals.ThisAddIn.GetLanguageIdFromFirstTextFrame()
        If LanguageIdFromdocument = -1 Then Exit Sub
        'check if in the list
        Dim indexOfLanguage As Integer
        indexOfLanguage = IdListInteger.IndexOf(LanguageIdFromdocument)
            If indexOfLanguage = -1 Then
            'if not add it
            AddLanguage(LanguageIdFromdocument)
            DropDownLanguage.SelectedItemIndex = DropDownLanguage.Items.Count - 1
        Else
            DropDownLanguage.SelectedItemIndex = indexOfLanguage
        End If
    End Sub
    Private Sub AddLanguage(LanguageID As MsoLanguageID)
        Dim DropDownItem As RibbonDropDownItem = Globals.Factory.GetRibbonFactory.CreateRibbonDropDownItem()
        Dim fullName = LanguageID.ToString()
        DropDownItem.Label = Right(fullName, fullName.Length - 13) 'prefix msoLanguageID --> 13 letters

        DropDownItem.Tag = CInt(LanguageID)
        DropDownLanguage.Items.Add(DropDownItem)
    End Sub

    Private Sub ButtonSwitch_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonSwitch.Click
        'get language id from dropdown list
        Dim currentLanguageId As Integer = DropDownLanguage.SelectedItem.Tag
        'change language
        Globals.ThisAddIn.LanguageChange(currentLanguageId)
    End Sub

    Private Sub ButtonAbout_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonAbout.Click
        Dim Message As String = "This Add-in allows you to switch the language for a complete document." & vbNewLine & "Select a language in the drop down list and click on the button Switch language. Done!"
        Message += vbNewLine & "Version: " & My.Application.Info.Version.ToString()
        MsgBox(Message, vbQuestion, "About PPT_LanguageSwitcher")
    End Sub

    Private Sub ButtonManage_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonManage.Click
        Dim TargetSelection As New ManageTargetInterface
        TargetSelection.ShowDialog()
        If TargetSelection.DialogResult <> Windows.Forms.DialogResult.OK Then Exit Sub
        '### retrieve the new integer for Languages
        Me.IdListInteger = TargetSelection.Target.Values.ToList()
        If My.Settings.UseUserSettings = True Then
            My.Settings.LanguageIDUser = ListToString(Me.IdListInteger)
            My.Settings.Save()
        End If
        DropDownLanguage.Items.Clear()
        IdListInteger.ForEach(Sub(i) AddLanguage(i))
    End Sub
    Private Function ListToString(InputList As List(Of Integer)) As String
        Dim result As String = ""
        InputList.ForEach(Sub(i) result += i & ";")
        result = result.Remove(result.Length - 1)
        Return result
    End Function
End Class
