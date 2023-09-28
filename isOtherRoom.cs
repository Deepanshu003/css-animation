using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using Component;

namespace AapnoGharWeb
{
    public class isOtherRoom : IRouteConstraint
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
            RoomData ObjRoomData = new RoomData();
            int RoomID = Convert.ToInt16(ObjRoomData.SelectRoomIDbyRoomNameAlias(Convert.ToString(values["RoomNameAlias"])));
            if (RoomID > 0)
                return true;
            else
                return false;

        }
    }
}