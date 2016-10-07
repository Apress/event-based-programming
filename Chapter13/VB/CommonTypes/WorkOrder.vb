<Serializable()> _
Public Class WorkOrder

  Private _model As String
  Public Property Model() As String
    Get
      Return _model
    End Get
    Set(ByVal Value As String)
      _model = Value
    End Set
  End Property

  Private _style As String
  Public Property Style() As String
    Get
      Return _style
    End Get
    Set(ByVal Value As String)
      _style = Value
    End Set
  End Property

  Private _color As String
  Public Property Color() As String
    Get
      Return _color
    End Get
    Set(ByVal Value As String)
      _color = Value
    End Set
  End Property

  Private _options As PricedItem()
  Public Property Options() As PricedItem()
    Get
      Return _options
    End Get
    Set(ByVal Value As PricedItem())
      _options = Value
    End Set
  End Property

  Private _id As String
  Public Property Id() As String
    Get
      Return _id
    End Get
    Set(ByVal Value As String)
      _id = Value
    End Set
  End Property

  ' public default constructor is required in serializable classes
  Public Sub New()
  End Sub

  Public Sub New(ByVal theModel As String, ByVal theStyle As String, _
                 ByVal theColor As System.Drawing.Color, _
                 ByVal theOptions As PricedItem())
    _model = theModel
    _style = theStyle
    _color = theColor.Name
    _options = theOptions

    _id = Guid.NewGuid().ToString()
  End Sub
End Class
