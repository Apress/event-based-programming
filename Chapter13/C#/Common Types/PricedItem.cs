using System;

namespace Asap.Cars.CommonTypes
{
	/// <summary>
	/// Summary description for PricedItem.
	/// </summary>
  [Serializable]
  public class PricedItem
	{
    string name;
    public string Name
    {
      get {return name;}
      set {name = value;}
    }

    decimal cost;
    public decimal Cost
    {
      get {return cost;}
      set {cost = value;}
    }

    public override string ToString()
    {
      return name;
    }

    // public default constructor is required in serializable classes
    public PricedItem()
    {
    }
    
    public PricedItem(string theName, decimal theCost)
		{
      name = theName;
      cost = theCost;
		}
	}
}
