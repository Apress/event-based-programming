using System;
using System.Drawing;
using System.Collections;

namespace Asap.Cars.CommonTypes
{
	/// <summary>
	/// Summary description for WorkOrder.
	/// </summary>
	[Serializable]
	public class WorkOrder
	{
    string model;
    public string Model
    {
      get {return model;}
      set {model = value;}
    }

    string style;
    public string Style
    {
      get {return style;}
      set {style = value;}
    }

    string color;
    public string Color
    {
      get {return color;}
      set {color = value;}
    }

    PricedItem[] options;
    public PricedItem[] Options
    {
      get {return options;}
      set {options = value;}
    }

    string id;
    public string Id
    {
      get {return id;}
      set {id = value;}
    }

    // public default constructor is required in serializable classes
    public WorkOrder()
    {
    }

    public WorkOrder(string theModel, string theStyle, Color theColor, PricedItem[] theOptions)
    {
      model = theModel;
      style = theStyle;
      color = theColor.Name;
      options = theOptions;

      id = Guid.NewGuid().ToString();
		}
	}
}
