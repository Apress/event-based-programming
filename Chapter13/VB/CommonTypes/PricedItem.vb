<Serializable()> _
Public Class PricedItem

  Private _name As String
  Public Property Name() As String
    Get
      Return _name
    End Get
    Set(ByVal Value As String)
      _name = Value
    End Set
  End Property

  Private _cost As Decimal
  Public Property Cost() As Decimal
    Get
      Return _cost
    End Get
    Set(ByVal Value As Decimal)
      _cost = Value
    End Set
  End Property

  Public Overrides Function ToString() As String
    Return _name
  End Function

  ' public default constructor is required in serializable classes
  Public Sub New()
  End Sub

  Public Sub New(ByVal theName As String, ByVal theCost As Decimal)
    _name = theName
    _cost = theCost
  End Sub
End Class
