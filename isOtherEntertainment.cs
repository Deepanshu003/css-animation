using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using Component;

namespace AapnoGharWeb
{
    public class isOtherEntertainment : IRouteConstraint
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
            EntertainmentData ObjEntertainmentData = new EntertainmentData();
            int EntertainmentID = Convert.ToInt16(ObjEntertainmentData.SelectEntertainmentIDbyEntertainmentNameAlias(Convert.ToString(values["EntertainmentNameAlias"])));
            if (EntertainmentID > 0)
                return true;
            else
                return false;

        }
    }
}