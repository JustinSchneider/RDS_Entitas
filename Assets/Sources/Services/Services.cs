using System;
using System.Collections.Generic;
using System.Reflection;
using Sources.Services.Interface;
using Sources.Services.LoggingService.Interface;
using Sources.Services.ViewService.Interface;
using UnityEngine;

namespace Sources.Services
{
    public class Services
    {
        public readonly ILogService LogService;
        public readonly IViewService SymbolViewService;
        public readonly IViewService TextViewService;
        public readonly IViewService LineViewService;
        public readonly IViewService GripViewService;
        public readonly IViewService PolygonViewService;

        public Services(Dictionary<string, IService> services)
        {
            foreach (KeyValuePair<string, IService> service in services)
            {
                FieldInfo serviceField = GetType().GetField(service.Key);
                
                if (serviceField != null)
                {
                    object item = Convert.ChangeType(service.Value, service.Value.GetType());
                
                    serviceField.SetValue(this, item);
                }
                else
                {
                    Debug.LogError("Service " + service.Key + " does not exist.");
                }
            }
        }
    }
}