Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Services
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp

Imports Asap.Cars.CommonTypes
Imports Asap.Cars.OrderProcessor

Public Class Router
  Private _orderSystem As OrderProcessor.OrderSystem

  Public Sub New()
    EstablishConnectionToServer()
  End Sub

  Sub EstablishConnectionToServer()
    Try
      Dim configFile As String = System.Windows.Forms.Application.ExecutablePath + ".config"
      RemotingConfiguration.Configure(configFile)

      _orderSystem = DirectCast(Activator.GetObject(GetType(OrderProcessor.OrderSystem), "tcp://localhost:8011/AsapOrders"), OrderProcessor.OrderSystem)
    Catch ex As Exception
      Throw New Exception("Couldn't connect to Order Processing server. Details:\n\n" + ex.Message)
    End Try
  End Sub

  Public Sub SubmitOrder(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())
    _orderSystem.SubmitOrder(theModel, theStyle, theColor, theOptions)
  End Sub

  Public Function GetModels() As String()
    Return _orderSystem.GetModels()
  End Function

  Public Function GetStyles(ByVal theModel As String) As String()
    Return _orderSystem.GetStyles(theModel)
  End Function

  Public Function GetColors(ByVal theModel As String, ByVal theStyle As String) As Color()
    Return _orderSystem.GetColors(theModel, theStyle)
  End Function

  ' each entry in the returned array is a PricedItem[]
  Public Function GetOptions(ByVal theModel As String, ByVal theStyle As String) As ArrayList
    Return _orderSystem.GetOptions(theModel, theStyle)
  End Function
End Class
