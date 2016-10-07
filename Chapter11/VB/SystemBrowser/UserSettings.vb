Imports System.IO
Imports System.Xml

' This class holds the user's settings, and supports
' persistence of the settings, saving them in an XML file

Public Class UserSettings
  Private _persistentFilePath As String

  Private _showFoldersNavigator As Boolean ' ShowFolders if true, ShowSearch if false
  Public Property ShowFoldersNavigator() As Boolean
    Get
      Return _showFoldersNavigator
    End Get
    Set(ByVal Value As Boolean)
      _showFoldersNavigator = Value
    End Set
  End Property

  Public Sub ShowFolders()
    ShowFoldersNavigator = True
  End Sub

  Public Sub ShowSearch()
    ShowFoldersNavigator = False
  End Sub

  Public Sub New()
    _persistentFilePath = String.Format("{0}\settings.xml", Application.StartupPath)

    ' set default values for all settings (we only have one!)
    ShowFoldersNavigator = True
  End Sub

  Public Sub Save()
    Try
      Dim writer As New StreamWriter(_persistentFilePath)
      writer.WriteLine("<?xml version='1.0' encoding='UTF-8'?>")
      writer.WriteLine("<settings>")
      writer.WriteLine(String.Format("<ShowFolders>{0}</ShowFolders>", ShowFoldersNavigator))
      writer.WriteLine("</settings>")
      writer.Close()
    Catch ex As Exception
      MessageBox.Show(ex.ToString(), "Couldn't save settings")
    End Try
  End Sub

  Public Sub Load()
    Try
      If Not File.Exists(_persistentFilePath) Then Return
      Dim xmlDoc As New XmlDocument
      xmlDoc.Load(_persistentFilePath)
      Dim node As XmlNode = xmlDoc.SelectSingleNode("//ShowFolders")
      If node Is Nothing Then Return
      ShowFoldersNavigator = Boolean.Parse(node.InnerText.ToString())
    Catch ex As Exception
      MessageBox.Show(ex.ToString(), "Couldn't load settings")
    End Try
  End Sub

End Class