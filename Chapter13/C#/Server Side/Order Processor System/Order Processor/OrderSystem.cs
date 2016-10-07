using System;
using System.Drawing;
using System.Collections;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.OrderProcessor
{
	/// <summary>
	/// OrderSystem is the sole server-side object that
	/// clients deal with. The class is derived from
	/// MarshalByRefObject to make it available as a
	/// distributed object using the .Net Remoting Framework
	/// </summary>
	public class OrderSystem: MarshalByRefObject
	{
    static int ordersReceived;
    static public int OrdersReceived
    {
      get {return ordersReceived;}
    }

		public OrderSystem()
		{
		}

    Router router;
    public Router Router
    {
      get
      {
        if (router == null)
          router = new Router();
        return router;
      }
    }

    public string[] GetModels()
    {
      // the following data would probably be fetched from a database
      string[] models = new string[] {"Model 1", "Model 2", "Model 3"};
      return models;
    }

    public string[] GetStyles(string theModel)
    {
      // the following data would probably be fetched from a database
      string[] styles = new string[] {"Style 1", "Style 2", "Style 3"};
      return styles;
    }

    public Color[] GetColors(string theModel, string theStyle)
    {
      // the following data would probably be fetched from a database
      Color[] colors = new Color[] {Color.White, Color.Navy, Color.Lavender};
      return colors;
    }

    // each entry in the returned array is a PricedItem[]
    public ArrayList GetOptions(string theModel, string theStyle)
    {
      // the following data would probably be fetched from a database
      ArrayList options = new ArrayList();

      ArrayList category1 = new ArrayList();
      PricedItem[] category1Items = new PricedItem[] {
        new PricedItem("Category 1", 0),
        new PricedItem("Option 1", 111),
        new PricedItem("Option 2", 222),
        new PricedItem("Option 3", 333)};
      options.Add(category1Items);

      ArrayList category2 = new ArrayList();
      PricedItem[] category2Items = new PricedItem[] {
        new PricedItem("Category 2", 0),
        new PricedItem("Option 11", 777),
        new PricedItem("Option 22", 888),
        new PricedItem("Option 33", 999)};
      options.Add(category2Items);

      return options;
    }

    public void SubmitOrder(string theModel, string theStyle, Color theColor, PricedItem[] theOptions)
    {
      WorkOrder workOrder = new WorkOrder(theModel, theStyle, theColor, theOptions);
      Router.SubmitOrder(workOrder);
      ordersReceived++;
    }

    public System.Messaging.Message[] GetAllQueuedMessages()
    {
      return Router.GetAllQueuedMessages();
    }

    public void ClearQueuedMessages()
    {
      Router.ClearQueuedMessages();
    }
  }
}
