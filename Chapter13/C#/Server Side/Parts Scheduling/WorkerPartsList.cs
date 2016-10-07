using System;
using System.Collections;

using Asap.Cars.CommonTypes;

namespace Asap.Cars.PartsScheduling
{
  public class ScheduledPart
  {
    public WorkOrder workOrder;
    public string part;
    public DateTime deliveryDate;

    public string Id
    {
      get {return workOrder.Id;}
    }

    public ScheduledPart(WorkOrder theWorkOrder, string thePart, DateTime theDeliveryDate)
    {
      workOrder = theWorkOrder;
      part = thePart;
      deliveryDate = theDeliveryDate;
    }
  }

  public class WorkerPartsList
  {
    // key is WorkOrder ID, value is an ArrayList of ScheduledParts
    Hashtable partsList = new Hashtable();
    public Hashtable List
    {
      get {return partsList;}
    }

    // number of WorkOrders that are waiting for parts
    public int NumberOfWorkOrders
    {
      get {return partsList.Count;}
    }

    // number of WorkOrders that are waiting for parts
    public int TotalNumberOfScheduledParts
    {
      get 
      {
        int count = 0;
        foreach (ArrayList scheduledParts in partsList.Values)
          count += scheduledParts.Count;
        return count;
      }
    }

    public void AddPart(WorkOrder theWorkOrder, string thePart, DateTime theDeliveryDate)
    {
      ScheduledPart part = new ScheduledPart(theWorkOrder, thePart, theDeliveryDate);

      // see if this WorkOrder already has pending parts
      ArrayList pendingParts = partsList[theWorkOrder.Id] as ArrayList;
      if (pendingParts == null)
      {
        // no: create a new list and add it to the list
        pendingParts = new ArrayList();
        partsList.Add(theWorkOrder.Id, pendingParts);
      }

      pendingParts.Add(part);
    }

    public void Remove(WorkOrder theWorkOrder)
    {
       partsList.Remove(theWorkOrder.Id);
    }

    // find the date of the latest part to 
    // be delivered for a given WorkOrder
    public DateTime GetDeliveryDate(string theWorkOrderId)
    {
      ArrayList scheduledParts = partsList[theWorkOrderId] as ArrayList;
      if (scheduledParts == null) return DateTime.MinValue;

      DateTime latestDate = DateTime.MinValue;
      foreach (ScheduledPart part in scheduledParts)
      {
        if (part.deliveryDate > latestDate)
          latestDate = part.deliveryDate;
      }
      return latestDate;
    }

    // returns an ArrayList of WorkOrders who parts are available now
    public ArrayList GetWorkToAssemble()
    {
      ArrayList workOrdersReady = null;

      foreach (string workOrderId in partsList.Keys)
      {
        DateTime deliveryDate = GetDeliveryDate(workOrderId);
        if (deliveryDate == DateTime.MinValue) continue;
        if (deliveryDate <= DateTime.Now)
        {
          // WorkOrder is ready
          if (workOrdersReady == null)
            workOrdersReady = new ArrayList();
          ArrayList parts = partsList[workOrderId] as ArrayList;
          if (parts.Count > 0)
          {
            // if there is at least one scheduled part, get its WorkOrder
            // parent. All the parts are for the same WorkOrderID
            ScheduledPart part = parts[0] as ScheduledPart;
            workOrdersReady.Add(part.workOrder);
          }
        }
      }
      return workOrdersReady;
    }
  }
}
