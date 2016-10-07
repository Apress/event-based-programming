Imports System.Drawing
Imports Asap.Cars.CommonTypes

' OrderSystem is the sole server-side object that
' clients deal with. The class is derived from
' MarshalByRefObject to make it available as a
' distributed object using the .Net Remoting Framework
Public Class OrderSystem
  Inherits MarshalByRefObject

  Private Shared _ordersReceived As Integer
  Public Shared ReadOnly Property OrdersReceived() As Integer
    Get
      Return _ordersReceived
    End Get
  End Property

  Public Sub New()
  End Sub

  Private _router As Router
  Public ReadOnly Property Router() As Router
    Get
      If _router Is Nothing Then
        _router = New Router
      End If
      Return _router
    End Get
  End Property

  Public Function GetModels() As String()
    ' the following data would probably be fetched from a database
    Dim models As String() = New String() {"Model 1", "Model 2", "Model 3"}
    Return models
  End Function

  Public Function GetStyles(ByVal theModel As String) As String()
    ' the following data would probably be fetched from a database
    Dim styles As String() = New String() {"Style 1", "Style 2", "Style 3"}
    Return styles
  End Function

  Public Function GetColors(ByVal theModel As String, ByVal theStyle As String) As Color()
    ' the following data would probably be fetched from a database
    Dim colors As Color() = New Color() {Color.White, Color.Navy, Color.Lavender}
    Return colors
  End Function

  ' each entry in the returned array is a PricedItem[]
  Public Function GetOptions(ByVal theModel As String, ByVal theStyle As String) As ArrayList
    ' the following data would probably be fetched from a database
    Dim options As New ArrayList

    Dim category1 As New ArrayList
    Dim category1Items As PricedItem() = New PricedItem() _
    {New PricedItem("Category 1", 0), _
      New PricedItem("Option 1", 111), _
      New PricedItem("Option 2", 222), _
      New PricedItem("Option 3", 333)}
    options.Add(category1Items)

    Dim category2 As New ArrayList
    Dim category2Items As PricedItem() = New PricedItem() _
    {New PricedItem("Category 2", 0), _
      New PricedItem("Option 11", 777), _
      New PricedItem("Option 22", 888), _
      New PricedItem("Option 33", 999)}
    options.Add(category2Items)

    Return options
  End Function

  Public Sub SubmitOrder(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())
    Dim wo As New WorkOrder(theModel, theStyle, theColor, theOptions)
    Router.SubmitOrder(wo)
    _ordersReceived += 1
  End Sub

  Public Function GetAllQueuedMessages() As System.Messaging.Message()
    Return Router.GetAllQueuedMessages()
  End Function

  Public Sub ClearQueuedMessages()
    Router.ClearQueuedMessages()
  End Sub
End Class
