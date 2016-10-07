Imports System.Text
Imports System.Threading

Imports HttpService

' Coordinator handles all the threading logic

Public Class Coordinator
  ' object used to synchronize events with UI thread
  Private _uiControl As Control

  ' the component to test
  Private _requestHandler As HttpService.CoordinatorRequestHandler

  Public Sub New(ByVal theUiControl As Control)
    _uiControl = theUiControl
    _requestHandler = HttpService.CoordinatorRequestHandler.Singleton
  End Sub

  Public Sub Send(ByVal theNumberOfPipelinedRequests As Integer)
    For i As Integer = 0 To theNumberOfPipelinedRequests - 1
      Dim thread As New Thread(AddressOf SendRequest)
      thread.Name = String.Format("Request{0}", i)
      thread.IsBackground = True
      thread.Start()
    Next
  End Sub

  ' this method runs on a background thread
  Sub SendRequest()
    Dim startTime As DateTime = DateTime.Now
    FireRequestSent()

    ' RequestHandler.Send blocks until a response comes back
    Dim sequenceNumber As Integer
    Dim response As String = _requestHandler.Send("http://localhost", startTime.ToString("HH:mm:ss.ffffff"), sequenceNumber)

    Dim responseTime As TimeSpan = DateTime.Now.Subtract(startTime)
    FireResponseReceived(sequenceNumber, response, responseTime)
  End Sub

#Region "Events"

  ' the following events are fired on the UI thread

  Public Delegate Sub RequestSentHandler()
  Public Event OnRequestSent As RequestSentHandler
  Sub FireRequestSent()
    _uiControl.Invoke(New RequestSentHandler(AddressOf DoFireRequestSent))
  End Sub
  Sub DoFireRequestSent()
    RaiseEvent OnRequestSent()
  End Sub

  Public Delegate Sub ResponseReceivedHandler(ByVal theSequenceNumber As Integer, ByVal theResponse As String, ByVal theProcessingTime As TimeSpan)
  Public Event OnResponseReceived As ResponseReceivedHandler
  Sub FireResponseReceived(ByVal theSequenceNumber As Integer, ByVal theResponse As String, ByVal theProcessingTime As TimeSpan)
    _uiControl.Invoke(New ResponseReceivedHandler(AddressOf DoFireResponseReceived), New Object() {theSequenceNumber, theResponse, theProcessingTime})
  End Sub
  Sub DoFireResponseReceived(ByVal theSequenceNumber As Integer, ByVal theResponse As String, ByVal theProcessingTime As TimeSpan)
    RaiseEvent OnResponseReceived(theSequenceNumber, theResponse, theProcessingTime)
  End Sub
#End Region
End Class
