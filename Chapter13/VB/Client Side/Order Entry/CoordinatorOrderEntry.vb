Imports Asap.Cars.CommonTypes

Public Class CoordinatorOrderEntry

  Public Function GetColors(ByVal theModel As String, ByVal theStyle As String) As Color()
    Return FireGetColors(theModel, theStyle)
  End Function

  ' each entry in the returned ArrayList is a PriceItem[]
  Public Function GetOptions(ByVal theModel As String, ByVal theStyle As String) As ArrayList
    Return FireGetOptions(theModel, theStyle)
  End Function

  Public Function GetStyles(ByVal theModel As String) As String()
    Return FireGetStyles(theModel)
  End Function

  Public Sub SubmitOrder(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())
    FireSubmit(theModel, theStyle, theColor, theOptions)
  End Sub

  Public Function ComputeCostOfOptions(ByVal theOptions As PricedItem()) As Decimal
    Dim totalPrice As Decimal = 0

    For Each opt As PricedItem In theOptions
      totalPrice += opt.Cost
    Next

    Return totalPrice
  End Function

  Public Delegate Function GetStylesHandler(ByVal theModel As String) As String()
  Public OnGetStyles As GetStylesHandler
  Function FireGetStyles(ByVal theModel As String) As String()
    If OnGetStyles Is Nothing Then Return Nothing
    Return OnGetStyles(theModel)
  End Function

  Public Delegate Function GetColorsHandler(ByVal theModel As String, ByVal theStyle As String) As Color()
  Public OnGetColors As GetColorsHandler
  Function FireGetColors(ByVal theModel As String, ByVal theStyle As String) As Color()
    If OnGetColors Is Nothing Then Return Nothing
    Return OnGetColors(theModel, theStyle)
  End Function

  ' each entry in the returned ArrayList is a PriceItem
  Public Delegate Function GetOptionsHandler(ByVal theModel As String, ByVal theStyle As String) As ArrayList
  Public OnGetOptions As GetOptionsHandler
  Function FireGetOptions(ByVal theModel As String, ByVal theStyle As String) As ArrayList
    If OnGetOptions Is Nothing Then Return Nothing
    Return OnGetOptions(theModel, theStyle)
  End Function

  Public Event OnSubmit(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())
  Sub FireSubmit(ByVal theModel As String, ByVal theStyle As String, ByVal theColor As Color, ByVal theOptions As PricedItem())
    RaiseEvent OnSubmit(theModel, theStyle, theColor, theOptions)
  End Sub
End Class
