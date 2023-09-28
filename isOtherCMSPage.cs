using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using Component;

namespace AapnoGharWeb
{
    public class isOtherCMSPage : IRouteConstraint
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
            CMSData ObjCMSData = new CMSData();
            int CMSID = Convert.ToInt16(ObjCMSData.SelectActiveCMSIDbyURL(Convert.ToString(values["CMSAlias"])));
            if (CMSID > 0)
                return true;
            else
                return false;

        }
    }
}