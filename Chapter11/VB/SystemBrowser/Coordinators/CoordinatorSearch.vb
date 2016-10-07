Imports System.Threading

' CoordinatorSearch manages the file-search process. It manages all
' thread-related logic. CoordinatorSearch handles all the search
' worker's notifications, and switches to the UI thread before firing
' any events of its own.

Public Class CoordinatorSearch
  Private _uiControl As Control
  Private _searchThread As Thread

  Public Sub New(ByVal theUiControl As Control)
    _uiControl = theUiControl
  End Sub

  Public Sub StartSearch(ByVal theFolderPath As String)
    If Not _searchThread Is Nothing Then
      If _searchThread.IsAlive Then
        _searchThread.Abort()
      End If
    End If

    FireMessage("Searching...")
    FireSearchRequested()
    StartBackgroundSearch()
  End Sub

  Public Sub ItemFound(ByVal thePath As String, ByVal theCurrentCount As Integer)
    FireItemFound(thePath, theCurrentCount)

    If (theCurrentCount = 1) Then
      FireMessage("1 item found")
    Else
      FireMessage(String.Format("{0} items found", theCurrentCount))
    End If
  End Sub

  ' a reference to the search entry point. We call this
  ' method on a background thread 
  Public OnSearchStart As ThreadStart

  ' start the search on a background thread
  Sub StartBackgroundSearch()
    If OnSearchStart Is Nothing Then Return
    _searchThread = New Thread(OnSearchStart)
    _searchThread.Start()
  End Sub

#Region "Events"
  ' ***********************************************************
  ' the following Fire methods switch to the UI thread
  ' before firing events
  ' ***********************************************************

  Public Delegate Sub SearchRequestedHandler()
  Public Event OnSearchRequested()
  Sub FireSearchRequested()
    _uiControl.Invoke(New SearchRequestedHandler(AddressOf DoFireSearchRequested))
  End Sub
  Sub DoFireSearchRequested()
    RaiseEvent OnSearchRequested()
  End Sub


  Public Delegate Sub ItemFoundHandler(ByVal thePath As String, ByVal theCurrentCount As Integer)
  Public Event OnItemFound As ItemFoundHandler
  Sub FireItemFound(ByVal thePath As String, ByVal theCurrentCount As Integer)
    _uiControl.Invoke(New ItemFoundHandler(AddressOf DoFireItemFound), New Object() {thePath, theCurrentCount})
  End Sub
  Sub DoFireItemFound(ByVal thePath As String, ByVal theCurrentCount As Integer)
    RaiseEvent OnItemFound(thePath, theCurrentCount)
  End Sub


  Public Delegate Sub MessageHandler(ByVal theMessage As String)
  Public Event OnMessage As MessageHandler
  Public Sub FireMessage(ByVal theMessage As String)
    _uiControl.Invoke(New MessageHandler(AddressOf DoFireMessage), New Object() {theMessage})
  End Sub
  Sub DoFireMessage(ByVal theMessage As String)
    RaiseEvent OnMessage(theMessage)
  End Sub
#End Region

End Class