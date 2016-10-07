using System;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Asap.Cars.CommonTypes;
using Asap.Cars.OrderProcessor;

namespace Asap.Cars.OrderEntry
{
	/// <summary>
	/// Summary description for Router.
	/// </summary>
  public class Router
  {
    OrderProcessor.OrderSystem orderSystem;
    
	  public Router()
	  {
      EstablishConnectionToServer();
	  }

    void EstablishConnectionToServer()
    {
      try
      {
        string configFile = System.Windows.Forms.Application.ExecutablePath + ".config";
        RemotingConfiguration.Configure(configFile);

        orderSystem = (OrderProcessor.OrderSystem)Activator.GetObject(typeof(OrderProcessor.OrderSystem), "tcp://localhost:8011/AsapOrders");
      }
      catch (Exception ex)
      {
        throw new Exception("Couldn't connect to Order Processing server. Details:\n\n" + ex.Message);
      }
    }

    public void SubmitOrder(string theModel, string theStyle, Color theColor, PricedItem[] theOptions)
    {
      orderSystem.SubmitOrder(theModel, theStyle, theColor, theOptions);
    }

    public string[] GetModels()
    {
      return orderSystem.GetModels();
    }

    public string[] GetStyles(string theModel)
    {
      return orderSystem.GetStyles(theModel);
    }

    public Color[] GetColors(string theModel, string theStyle)
    {
      return orderSystem.GetColors(theModel, theStyle);
    }

    // each entry in the returned array is a PricedItem[]
    public ArrayList GetOptions(string theModel, string theStyle)
    {
      return orderSystem.GetOptions(theModel, theStyle);
    }
  }
}
