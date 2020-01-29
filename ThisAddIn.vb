Imports PPT = Microsoft.Office.Interop.PowerPoint
Imports Microsoft.Office.Core
Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup

    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub
    Private Sub Opendocument() Handles Application.PresentationOpen
        Globals.Ribbons.RibbonLanguage.AddLanguageFromDocument()
    End Sub
    Public Sub LanguageChange(LanguageID As Integer)

        Dim sld As PPT.Slide
        'Dim shp As PPT.Shape
        If Globals.Ribbons.RibbonLanguage.TargetSlides = True Then
            For Each sld In Me.Application.ActivePresentation.Slides
                ShapesCollectionLanguageChange(sld.Shapes, LanguageID)
                ShapesCollectionLanguageChange(sld.NotesPage.Shapes, LanguageID)
                'System.Diagnostics.Debug.WriteLine(sld.SlideID)
            Next
        End If
        'slide Master
        If Globals.Ribbons.RibbonLanguage.TargetMaster = True Then
            ShapesCollectionLanguageChange(Me.Application.ActivePresentation.SlideMaster.Shapes, LanguageID)
            For Each layout As PPT.CustomLayout In Me.Application.ActivePresentation.SlideMaster.CustomLayouts
                ShapesCollectionLanguageChange(layout.Shapes, LanguageID)
            Next
        End If

    End Sub
    Private Sub ShapesCollectionLanguageChange(ShapesCollection As PPT.Shapes, LanguageID As Integer)
        Dim shp As PPT.Shape
        For Each shp In ShapesCollection
            'System.Diagnostics.Debug.WriteLine(shp.Name & "     " & Err.Number)
            If shp.HasTextFrame Then
                shp.TextFrame.TextRange.LanguageID = LanguageID
            Else
                ShapeLanguageChange(shp, LanguageID)
            End If
        Next
    End Sub

    Private Sub ShapeLanguageChange(sh As Object, LanguageID As Integer)
        Dim sha As PPT.Shape
        Dim tbl As PPT.Table
        System.Diagnostics.Debug.WriteLine("Type: " & sh.Type)
        If sh.Type = MsoShapeType.msoGroup Then
            For Each sha In sh.GroupItems
                If sha.Type = MsoShapeType.msoGroup Then
                    ShapeLanguageChange(sha, LanguageID)
                ElseIf sha.HasTextFrame Then
                    sha.TextFrame.TextRange.LanguageID = LanguageID
                End If
            Next
        ElseIf sh.Type = MsoShapeType.msoTable Then
            Try
                tbl = sh.table 'CType(sh, PPT.Table)
            Catch ex As Exception
                Exit Sub
            End Try
            Dim I, J As Integer
            For I = 1 To tbl.Rows.Count
                For J = 1 To tbl.Columns.Count
                    tbl.Cell(I, J).Shape.TextFrame.TextRange.LanguageID = LanguageID
                Next
            Next
        End If
    End Sub
    Public Function GetLanguageIdFromFirstTextFrame() As Integer
        Dim sld As PPT.Slide
        Dim shp As PPT.Shape
        Try
            If Me.Application.ActivePresentation.Slides.Count() = 0 Then
                Return -1
            End If
        Catch ex As Exception
            Return -1
        End Try
        For Each sld In Me.Application.ActivePresentation.Slides
            For Each shp In sld.Shapes
                If shp.HasTextFrame Then
                    Return shp.TextFrame.TextRange.LanguageID
                    Exit Function
                End If
            Next
        Next
        Return -1
    End Function
End Class
