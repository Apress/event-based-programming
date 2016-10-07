Imports Asap.Cars.CommonTypes

Public Class ScheduledPart
  Public _workOrder As WorkOrder
  Public _part As String
  Public _deliveryDate As DateTime

  Public ReadOnly Property Id() As String
    Get
      Return _workOrder.Id
    End Get
  End Property

  Public Sub New(ByVal theWorkOrder As WorkOrder, ByVal thePart As String, ByVal theDeliveryDate As DateTime)
    _workOrder = theWorkOrder
    _part = thePart
    _deliveryDate = theDeliveryDate
  End Sub
End Class

Public Class WorkerPartsList
  ' key is WorkOrder ID, value is an ArrayList of ScheduledParts
  Private _partsList As New Hashtable
  Public ReadOnly Property List() As Hashtable
    Get
      Return _partsList
    End Get
  End Property

  ' number of WorkOrders that are waiting for parts
  Public ReadOnly Property NumberOfWorkOrders() As Integer
    Get
      Return _partsList.Count
    End Get
  End Property

  ' number of WorkOrders that are waiting for parts
  Public ReadOnly Property TotalNumberOfScheduledParts() As Integer
    Get
      Dim count As Integer = 0
      For Each scheduledParts As ArrayList In _partsList.Values
        count += scheduledParts.Count
      Next
      Return count
    End Get
  End Property

  Public Sub AddPart(ByVal theWorkOrder As WorkOrder, ByVal thePart As String, ByVal theDeliveryDate As DateTime)
    Dim part As New ScheduledPart(theWorkOrder, thePart, theDeliveryDate)

    ' see if this WorkOrder already has pending parts
    Dim pendingParts As ArrayList = DirectCast(_partsList(theWorkOrder.Id), ArrayList)
    If pendingParts Is Nothing Then
      ' no: create a new list and add it to the list
      pendingParts = New ArrayList
      _partsList.Add(theWorkOrder.Id, pendingParts)
    End If

    pendingParts.Add(part)
  End Sub

  Public Sub Remove(ByVal theWorkOrder As WorkOrder)
    _partsList.Remove(theWorkOrder.Id)
  End Sub

  ' find the date of the latest part to 
  ' be delivered for a given WorkOrder
  Public Function GetDeliveryDate(ByVal theWorkOrderId As String) As DateTime
    Dim scheduledParts As ArrayList = DirectCast(_partsList(theWorkOrderId), ArrayList)
    If scheduledParts Is Nothing Then Return DateTime.MinValue

    Dim latestDate As DateTime = DateTime.MinValue
    For Each part As ScheduledPart In scheduledParts
      If DateTime.op_GreaterThan(part._deliveryDate, latestDate) Then
        latestDate = part._deliveryDate
      End If
    Next
    Return latestDate
  End Function

  ' returns an ArrayList of WorkOrders who parts are available now
  Public Function GetWorkToAssemble() As ArrayList
    Dim workOrdersReady As ArrayList = Nothing

    For Each workOrderId As String In _partsList.Keys
      Dim deliveryDate As DateTime = GetDeliveryDate(workOrderId)
      If DateTime.op_GreaterThan(deliveryDate, DateTime.MinValue) AndAlso DateTime.op_LessThanOrEqual(deliveryDate, DateTime.Now) Then
        ' WorkOrder is ready
        If workOrdersReady Is Nothing Then
          workOrdersReady = New ArrayList
        End If
        Dim parts As ArrayList = DirectCast(_partsList(workOrderId), ArrayList)
        If (parts.Count > 0) Then
          ' if there is at least one scheduled part, get its WorkOrder
          ' parent. All the parts are for the same WorkOrderID
          Dim part As ScheduledPart = DirectCast(parts(0), ScheduledPart)
          workOrdersReady.Add(part._workOrder)
        End If
      End If
    Next
    Return workOrdersReady
  End Function
End Class
