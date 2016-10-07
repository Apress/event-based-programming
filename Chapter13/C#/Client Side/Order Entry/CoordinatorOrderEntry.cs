using System;
using System.Drawing;
using System.Collections;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.OrderEntry
{
	/// <summary>
	/// Summary description for CoordinatorOrderEntry.
	/// </summary>
  public class CoordinatorOrderEntry
  {
    public Color[] GetColors(string theModel, string theStyle)
    {
      return FireGetColors(theModel, theStyle);
    }

    // each entry in the returned ArrayList is a PriceItem[]
    public ArrayList GetOptions(string theModel, string theStyle)
    {
      return FireGetOptions(theModel, theStyle);
    }

    public string[] GetStyles(string theModel)
    {
      return FireGetStyles(theModel);
    }

    public void SubmitOrder(string theModel, string theStyle, Color theColor, PricedItem[] theOptions)
    {
      FireSubmit(theModel, theStyle, theColor, theOptions);
    }

    public decimal ComputeCostOfOptions(PricedItem[] theOptions)
    {
      decimal totalPrice = 0;

      foreach (PricedItem option in theOptions)
        totalPrice += option.Cost;

      return totalPrice;
    }

    public delegate string[] GetStylesHandler(string theModel);
    public event GetStylesHandler OnGetStyles;
    string[] FireGetStyles(string theModel)
    {
      if (OnGetStyles == null)
        return null;
      return OnGetStyles(theModel);
    }

    public delegate Color[] GetColorsHandler(string theModel, string theStyle);
    public event GetColorsHandler OnGetColors;
    Color[] FireGetColors(string theModel, string theStyle)
    {
      if (OnGetColors == null)
        return null;
      return OnGetColors(theModel, theStyle);
    }

    // each entry in the returned ArrayList is a PriceItem array
    public delegate ArrayList GetOptionsHandler(string theModel, string theStyle);
    public event GetOptionsHandler OnGetOptions;
    ArrayList FireGetOptions(string theModel, string theStyle)
    {
      if (OnGetOptions == null)
        return null;
      return OnGetOptions(theModel, theStyle);
    }

    public delegate void SubmitHandler(string theModel, string theStyle, Color theColor, PricedItem[] theOptions);
    public event SubmitHandler OnSubmit;
    void FireSubmit(string theModel, string theStyle, Color theColor, PricedItem[] theOptions)
    {
      if (OnSubmit != null)
        OnSubmit(theModel, theStyle, theColor, theOptions);
    }
  }
}
