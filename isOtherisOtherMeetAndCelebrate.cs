using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using Component;

namespace AapnoGharWeb
{
    public class isOtherisOtherMeetAndCelebrate : IRouteConstraint
    {
        public bool Match
         (
             HttpContextBase httpContext,
             Route route,
             string parameterName,
             RouteValueDictionary values,
             RouteDirection routeDirection
         )
        {
            WeddeingEventData ObjWeddeingEventData = new WeddeingEventData();
            int WeddeingEventID = Convert.ToInt16(ObjWeddeingEventData.SelectActiveWeddeingEventIDbyURL(Convert.ToString(values["WeddeingEventAlias"])));
            if (WeddeingEventID > 0)
                return true;
            else
                return false;

        }
    }
}