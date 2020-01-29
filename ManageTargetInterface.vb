Public Class ManageTargetInterface
    Public Reference As Dictionary(Of String, Integer)
    Public Target As Dictionary(Of String, Integer)
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        fillReference()
        fillTarget()
    End Sub
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fillReference()
        Me.Reference = New Dictionary(Of String, Integer)

        Dim FullName As String
        For Each i As Integer In System.Enum.GetValues(GetType(Microsoft.Office.Core.MsoLanguageID))
            Try
                'LanguageID = i
                FullName = CType(i, Microsoft.Office.Core.MsoLanguageID).ToString()
                Me.Reference.Add(Strings.Right(FullName, FullName.Length - 13), CInt(i))                 'prefix msoLanguageID --> 13 letters
            Catch ex As Exception

            End Try
        Next
        'remove first two and last
        Me.Reference.Remove(Me.Reference.Keys.First)
        Me.Reference.Remove(Me.Reference.Keys.First)
        Me.Reference.Remove(Me.Reference.Keys.Last)
        'sort alphabetically
        Me.Reference = Me.Reference.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
        ListBoxRef.DataSource = Me.Reference.Keys.ToList()
    End Sub
    Private Sub FillTarget()
        Me.Target = New Dictionary(Of String, Integer)
        Dim FullName As String
        Globals.Ribbons.RibbonLanguage.IdListInteger.ForEach(Sub(i)
                                                                 FullName = CType(i, Microsoft.Office.Core.MsoLanguageID).ToString()
                                                                 Me.Target.Add(Strings.Right(FullName, FullName.Length - 13), CInt(i))
                                                             End Sub)
        Me.ListBoxTarget.DataSource = Me.Target.Keys.ToList()
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim SelectedStrings As List(Of String) = New List(Of String)
        For Each s In ListBoxRef.SelectedItems
            SelectedStrings.Add(s.ToString())
        Next

        '### something selected ?
        If SelectedStrings.Count > 0 Then
            'remove what is already in target and add the rest
            SelectedStrings.Except(Me.Target.Keys.ToList()).ToList().ForEach(Sub(s) Me.Target.Add(s, Me.Reference(s)))
        End If
        Me.ListBoxTarget.DataSource = Me.Target.Keys.ToList()
    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        Dim SelectedStrings As List(Of String) = New List(Of String)
        For Each s In ListBoxTarget.SelectedItems
            SelectedStrings.Add(s.ToString())
        Next

        If SelectedStrings.Count > 0 Then
            'remove what is already in target and add the rest
            SelectedStrings.ForEach(Sub(s) Me.Target.Remove(s))
        End If
        Me.ListBoxTarget.DataSource = Me.Target.Keys.ToList()
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        If Me.Target.Count() = 0 Then
            MsgBox("Please select at least one language.", vbExclamation, "No language selected")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonDefault_Click(sender As Object, e As EventArgs) Handles ButtonDefault.Click
        'read settings
        Me.Target.Clear()
        Dim IdListString As List(Of String) = My.Settings.LanguageIDList.Split(";").ToList()
        Dim fullName As String
        IdListString.ForEach(Sub(s)
                                 fullName = CType(s, Microsoft.Office.Core.MsoLanguageID).ToString()
                                 Me.Target.Add(Strings.Right(fullName, fullName.Length - 13), CInt(s))
                             End Sub) 'prefix msoLanguageID --> 13 letters
        Me.ListBoxTarget.DataSource = Me.Target.Keys.ToList()
    End Sub
End Class