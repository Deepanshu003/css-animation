using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utility;
using System.Data;
namespace Component
{
  public  class RoomData
  {
      Connect ObjSql = new Connect();
      CommanFunction ObjComm = new CommanFunction();
      ManageException ObjEx = new ManageException();

      public RoomData()
      {
      }
      private int _RoomID = 0;
      private string _RoomName = string.Empty;
      private string _RoomNameAlias = string.Empty;
      private string _RoomDefaultImage = string.Empty;
      private string _RoomBannerImg = string.Empty;
      private string _RoomImage1 = string.Empty;
      private string _RoomImage2 = string.Empty;
      private string _RoomSmallDescription = string.Empty;
      private string _RoomDescription = string.Empty;
      private string _RoomCancellationPolicy = string.Empty;
      private string _RoomResortPolicy = string.Empty;
      private string _RoomOtherDescription = string.Empty;
      private int _TotalNoRoom = 0;
      private int _NoofAdults = 0;
      private int _NoofChildren = 0;
      private int _NoExtraBeds = 0;
      private int _RoomCheckInTimeHour = 0;
      private int _RoomCheckInTimeMin = 0;
      private string _RoomCheckInTimeType = string.Empty;
      private int _RoomCheckOutTimeHour = 0;
      private int _RoomCheckOutTimeMin = 0;
      private string _RoomCheckOutTimeType = string.Empty;
      private int _DiscountedPrice = 0;
      private int _RoomTaxes = 0;
      private int _RoomDefaultPrice = 0;

      public int TotalNoRoom
      {
          get { return _TotalNoRoom; }
          set { _TotalNoRoom = value; }
      }
     
      public int NoofAdults
      {
          get { return _NoofAdults; }
          set { _NoofAdults = value; }
      }
      
      public int NoofChildren
      {
          get { return _NoofChildren; }
          set { _NoofChildren = value; }
      }
      
      public int NoExtraBeds
      {
          get { return _NoExtraBeds; }
          set { _NoExtraBeds = value; }
      }
     
      public int RoomCheckInTimeHour
      {
          get { return _RoomCheckInTimeHour; }
          set { _RoomCheckInTimeHour = value; }
      }
     
      public int RoomCheckInTimeMin
      {
          get { return _RoomCheckInTimeMin; }
          set { _RoomCheckInTimeMin = value; }
      }
    
      public string RoomCheckInTimeType
      {
          get { return _RoomCheckInTimeType; }
          set { _RoomCheckInTimeType = value; }
      }
    
      public int RoomCheckOutTimeHour
      {
          get { return _RoomCheckOutTimeHour; }
          set { _RoomCheckOutTimeHour = value; }
      }
      
      public int RoomCheckOutTimeMin
      {
          get { return _RoomCheckOutTimeMin; }
          set { _RoomCheckOutTimeMin = value; }
      }
     
      public string RoomCheckOutTimeType
      {
          get { return _RoomCheckOutTimeType; }
          set { _RoomCheckOutTimeType = value; }
      }
      
      public int DiscountedPrice
      {
          get { return _DiscountedPrice; }
          set { _DiscountedPrice = value; }
      }
      
      public int RoomTaxes
      {
          get { return _RoomTaxes; }
          set { _RoomTaxes = value; }
      }
     

      private int _displayOrder = 0;
      private int _displayOnHome = 0;
      private int _activeStatus = 0;      
      private string _metaTitle = string.Empty;
      private string _metaKeyword = string.Empty;
      private string _metaDescription = string.Empty;
      private string _metaSchema = string.Empty;
      private string _updatedBy = string.Empty;
      private DateTime _updatedOn = DateTime.UtcNow;
      private DateTime _bookingDate = DateTime.UtcNow;
      private string _searchKeywordData = string.Empty;
            
      public int RoomID
      {
          get { return _RoomID; }
          set { _RoomID = value; }
      }
      public string RoomName
      {
          get { return _RoomName; }
          set { _RoomName = value; }
      }      
      public string RoomNameAlias
      {
          get { return _RoomNameAlias; }
          set { _RoomNameAlias = value; }
      }
      public string RoomDefaultImage
      {
          get { return _RoomDefaultImage; }
          set { _RoomDefaultImage = value; }
      }     
      public string RoomBannerImg
      {
          get { return _RoomBannerImg; }
          set { _RoomBannerImg = value; }
      }
      public string RoomImage1
      {
          get { return _RoomImage1; }
          set { _RoomImage1 = value; }
      }
      public string RoomImage2
      {
          get { return _RoomImage2; }
          set { _RoomImage2 = value; }
      }
      public string RoomSmallDescription
      {
          get { return _RoomSmallDescription; }
          set { _RoomSmallDescription = value; }
      }

      public string RoomDescription
      {
          get { return _RoomDescription; }
          set { _RoomDescription = value; }
      }


      public string RoomCancellationPolicy
      {
          get { return _RoomCancellationPolicy; }
          set { _RoomCancellationPolicy = value; }
      }


      public string RoomResortPolicy
      {
          get { return _RoomResortPolicy; }
          set { _RoomResortPolicy = value; }
      }
      public string RoomOtherDescription
      {
          get { return _RoomOtherDescription; }
          set { _RoomOtherDescription = value; }
      }
      public int RoomDefaultPrice
      {
          get { return _RoomDefaultPrice; }
          set { _RoomDefaultPrice = value; }
      }
      public int DisplayOrder
      {
          get { return _displayOrder; }
          set { _displayOrder = value; }
      }
      public int DisplayOnHome
      {
          get { return _displayOnHome; }
          set { _displayOnHome = value; }
      }
      public int ActiveStatus
      {
          get { return _activeStatus; }
          set { _activeStatus = value; }
      }      
      public string MetaTitle
      {
          get { return _metaTitle; }
          set { _metaTitle = value; }
      }
      public string MetaKeyword
      {
          get { return _metaKeyword; }
          set { _metaKeyword = value; }
      }
      public string MetaDescription
      {
          get { return _metaDescription; }
          set { _metaDescription = value; }
      }
      public string MetaSchema
      {
          get { return _metaSchema; }
          set { _metaSchema = value; }
      }
      public string UpdatedBy
      {
          get { return _updatedBy; }
          set { _updatedBy = value; }
      }
      public DateTime UpdatedOn
      {
          get { return _updatedOn; }
          set { _updatedOn = value; }
      }
      public DateTime BookingDate
      {
          get { return _bookingDate; }
          set { _bookingDate = value; }
      }
      public string SearchKeywordData
      {
          get { return _searchKeywordData; }
          set { _searchKeywordData = value; }
      }
      private string _Room360View = string.Empty;

      public string Room360View
      {
          get { return _Room360View; }
          set { _Room360View = value; }
      }
      private string _RoomViewSide = string.Empty;

      public string RoomViewSide
      {
          get { return _RoomViewSide; }
          set { _RoomViewSide = value; }
      }
      private string _RoomBedType = string.Empty;

      public string RoomBedType
      {
          get { return _RoomBedType; }
          set { _RoomBedType = value; }
      }
      private string _RoomSize = string.Empty;

      public string RoomSize
      {
          get { return _RoomSize; }
          set { _RoomSize = value; }
      }
      private string _ComplimentaryWiFiDevices = string.Empty;

      public string ComplimentaryWiFiDevices
      {
          get { return _ComplimentaryWiFiDevices; }
          set { _ComplimentaryWiFiDevices = value; }
      }
      //, ExtraBedCharges, ChildrenCharges
      private int _ExtraBedCharges = 0;

      public int ExtraBedCharges
      {
          get { return _ExtraBedCharges; }
          set { _ExtraBedCharges = value; }
      }
      private int _ChildrenCharges = 0;

      public int ChildrenCharges
      {
          get { return _ChildrenCharges; }
          set { _ChildrenCharges = value; }
      }
      private int _KidsAgeParameter = 0;

      public int KidsAgeParameter
      {
          get { return _KidsAgeParameter; }
          set { _KidsAgeParameter = value; }
      }
      #region Admin Panel
      public void SelectAllRoomData(System.Web.UI.WebControls.GridView GvRoomdataGrid)
      {
          SqlParameter[] _SqlParameter = new SqlParameter[2];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectAllRoomData");
              _SqlParameter[1] = new SqlParameter("@SearchKeywordData", SearchKeywordData);
              ObjSql.GdBind_SNO(GvRoomdataGrid, "Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure SelectAllRoomData()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
      }

      public void SelectRoomForDD(System.Web.UI.WebControls.DropDownList DdRoom, string RoomName, string RoomID)
      {
          SqlParameter[] _SqlParameter = new SqlParameter[1];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomForDD");
              ObjSql.DdBing(DdRoom, "Mst_Sp_RoomData", "RoomName", "RoomID", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure SelectRoomForDD()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
      }

      public SqlDataReader SelectRoomByRoomID()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[2];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomByRoomID");
              _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
              return ObjSql.GetDatareaderProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure SelectRoomByRoomID()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDatareaderProc("Mst_Sp_RoomData", _SqlParameter);
      }

      public int SaveNewRoomData()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[40];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SaveNewRoomData");
              _SqlParameter[1] = new SqlParameter("@RoomName", RoomName);
              _SqlParameter[2] = new SqlParameter("@RoomNameAlias", RoomNameAlias);
              _SqlParameter[3] = new SqlParameter("@RoomDefaultImage", RoomDefaultImage);
              _SqlParameter[4] = new SqlParameter("@RoomBannerImg", RoomBannerImg);
              _SqlParameter[5] = new SqlParameter("@RoomSmallDescription", RoomSmallDescription);
              _SqlParameter[6] = new SqlParameter("@RoomDescription", RoomDescription);
              _SqlParameter[7] = new SqlParameter("@RoomCancellationPolicy", RoomCancellationPolicy);
              _SqlParameter[8] = new SqlParameter("@RoomResortPolicy", RoomResortPolicy);
              _SqlParameter[9] = new SqlParameter("@TotalNoRoom", TotalNoRoom);
              _SqlParameter[10] = new SqlParameter("@NoofAdults", NoofAdults);
              _SqlParameter[11] = new SqlParameter("@NoofChildren", NoofChildren);
              _SqlParameter[12] = new SqlParameter("@NoExtraBeds", NoExtraBeds);
              _SqlParameter[13] = new SqlParameter("@RoomCheckInTimeHour", RoomCheckInTimeHour);
              _SqlParameter[14] = new SqlParameter("@RoomCheckInTimeMin", RoomCheckInTimeMin);
              _SqlParameter[15] = new SqlParameter("@RoomCheckInTimeType", RoomCheckInTimeType);
              _SqlParameter[16] = new SqlParameter("@RoomCheckOutTimeHour", RoomCheckOutTimeHour);
              _SqlParameter[17] = new SqlParameter("@RoomCheckOutTimeMin", RoomCheckOutTimeMin);
              _SqlParameter[18] = new SqlParameter("@RoomCheckOutTimeType", RoomCheckOutTimeType);
              _SqlParameter[19] = new SqlParameter("@RoomDefaultPrice", RoomDefaultPrice);
              _SqlParameter[20] = new SqlParameter("@DiscountdPrice", DiscountedPrice);
              _SqlParameter[21] = new SqlParameter("@RoomTaxes", RoomTaxes);
              _SqlParameter[22] = new SqlParameter("@DisplayOrder", DisplayOrder);
              _SqlParameter[23] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
              _SqlParameter[24] = new SqlParameter("@ActiveStatus", ActiveStatus);
              _SqlParameter[25] = new SqlParameter("@MetaTitle", MetaTitle);
              _SqlParameter[26] = new SqlParameter("@MetaKeyword", MetaKeyword);
              _SqlParameter[27] = new SqlParameter("@MetaDescription", MetaDescription);
              _SqlParameter[28] = new SqlParameter("@MetaSchema", MetaSchema);
              _SqlParameter[29] = new SqlParameter("@Room360View", Room360View);
              _SqlParameter[30] = new SqlParameter("@ExtraBedCharges", ExtraBedCharges);
              _SqlParameter[31] = new SqlParameter("@ChildrenCharges", ChildrenCharges);
              _SqlParameter[32] = new SqlParameter("@KidsAgeParameter", KidsAgeParameter);
              _SqlParameter[33] = new SqlParameter("@RoomViewSide", RoomViewSide);
              _SqlParameter[34] = new SqlParameter("@RoomBedType", RoomBedType);
              _SqlParameter[35] = new SqlParameter("@RoomSize", RoomSize);
              _SqlParameter[36] = new SqlParameter("@ComplimentaryWiFiDevices", ComplimentaryWiFiDevices);
              _SqlParameter[37] = new SqlParameter("@RoomOtherDescription", RoomOtherDescription);
              _SqlParameter[38] = new SqlParameter("@RoomImage1", RoomImage1);
              _SqlParameter[39] = new SqlParameter("@RoomImage2", RoomImage2);
              return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure SaveNewRoomData()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
      }

      public int UpdateRoomByRoomID()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[41];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "UpdateRoomByRoomID");
              _SqlParameter[1] = new SqlParameter("@RoomName", RoomName);
              _SqlParameter[2] = new SqlParameter("@RoomNameAlias", RoomNameAlias);
              _SqlParameter[3] = new SqlParameter("@RoomDefaultImage", RoomDefaultImage);
              _SqlParameter[4] = new SqlParameter("@RoomBannerImg", RoomBannerImg);
              _SqlParameter[5] = new SqlParameter("@RoomSmallDescription", RoomSmallDescription);
              _SqlParameter[6] = new SqlParameter("@RoomDescription", RoomDescription);
              _SqlParameter[7] = new SqlParameter("@RoomCancellationPolicy", RoomCancellationPolicy);
              _SqlParameter[8] = new SqlParameter("@RoomResortPolicy", RoomResortPolicy);
              _SqlParameter[9] = new SqlParameter("@TotalNoRoom", TotalNoRoom);
              _SqlParameter[10] = new SqlParameter("@NoofAdults", NoofAdults);
              _SqlParameter[11] = new SqlParameter("@NoofChildren", NoofChildren);
              _SqlParameter[12] = new SqlParameter("@NoExtraBeds", NoExtraBeds);
              _SqlParameter[13] = new SqlParameter("@RoomCheckInTimeHour", RoomCheckInTimeHour);
              _SqlParameter[14] = new SqlParameter("@RoomCheckInTimeMin", RoomCheckInTimeMin);
              _SqlParameter[15] = new SqlParameter("@RoomCheckInTimeType", RoomCheckInTimeType);
              _SqlParameter[16] = new SqlParameter("@RoomCheckOutTimeHour", RoomCheckOutTimeHour);
              _SqlParameter[17] = new SqlParameter("@RoomCheckOutTimeMin", RoomCheckOutTimeMin);
              _SqlParameter[18] = new SqlParameter("@RoomCheckOutTimeType", RoomCheckOutTimeType);
              _SqlParameter[19] = new SqlParameter("@RoomDefaultPrice", RoomDefaultPrice);
              _SqlParameter[20] = new SqlParameter("@DiscountdPrice", DiscountedPrice);
              _SqlParameter[21] = new SqlParameter("@RoomTaxes", RoomTaxes);
              _SqlParameter[22] = new SqlParameter("@DisplayOrder", DisplayOrder);
              _SqlParameter[23] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
              _SqlParameter[24] = new SqlParameter("@ActiveStatus", ActiveStatus);
              _SqlParameter[25] = new SqlParameter("@MetaTitle", MetaTitle);
              _SqlParameter[26] = new SqlParameter("@MetaKeyword", MetaKeyword);
              _SqlParameter[27] = new SqlParameter("@MetaDescription", MetaDescription);
              _SqlParameter[28] = new SqlParameter("@MetaSchema", MetaSchema);
              _SqlParameter[29] = new SqlParameter("@Room360View", Room360View);
              _SqlParameter[30] = new SqlParameter("@ExtraBedCharges", ExtraBedCharges);
              _SqlParameter[31] = new SqlParameter("@ChildrenCharges", ChildrenCharges);
              _SqlParameter[32] = new SqlParameter("@KidsAgeParameter", KidsAgeParameter);
              _SqlParameter[33] = new SqlParameter("@RoomViewSide", RoomViewSide);
              _SqlParameter[34] = new SqlParameter("@RoomBedType", RoomBedType);
              _SqlParameter[35] = new SqlParameter("@RoomSize", RoomSize);
              _SqlParameter[36] = new SqlParameter("@ComplimentaryWiFiDevices", ComplimentaryWiFiDevices);
              _SqlParameter[37] = new SqlParameter("@RoomOtherDescription", RoomOtherDescription);
              _SqlParameter[38] = new SqlParameter("@RoomImage1", RoomImage1);
              _SqlParameter[39] = new SqlParameter("@RoomImage2", RoomImage2);
              _SqlParameter[40] = new SqlParameter("@RoomID", RoomID);
              return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure UpdateRoomByRoomID()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
      }

      public int DeleteRoomByRoomID()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[2];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "DeleteRoomByRoomID");
              _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
              return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure DeleteRoomByRoomID()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
      }

      public int UpdateRoomDataDisplayOrder()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[3];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "UpdateRoomDataDisplayOrder");
              _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
              _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
              return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure UpdateRoomDataDisplayOrder()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
      }

      public int SelectMaxDisplayOrder()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[1];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
              return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.ExcuteProce("Mst_Sp_RoomData", _SqlParameter);
      }

      public DataSet SelectAllRoomForAdmin()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[1];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectAllRoomForAdmin");
              return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception ex)
          {
              ObjEx.PublishError("Error in procedure SelectAllRoomForAdmin()", ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
      }
      #endregion

      #region Front End
      public DataSet SelectAllActiveRoomForMenu()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[1];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomForMenu");
              return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception ex)
          {
              ObjEx.PublishError("Error in procedure SelectAllActiveRoomForMenu()", ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
      }

      public DataSet SelectTop6ActiveActiveRoomForHome()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[1];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectTop6ActiveActiveRoomForHome");
              return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception ex)
          {
              ObjEx.PublishError("Error in procedure SelectTop6ActiveActiveRoomForHome()", ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
      }

      public DataSet SelectAllActiveRoomsForListing()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[1];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomsForListing");
              return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception ex)
          {
              ObjEx.PublishError("Error in procedure SelectAllActiveRoomsForBooking()", ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
      }

      public int SelectRoomIDbyRoomNameAlias(string RoomNameAlias)
      {
          int ID = 0;
          SqlParameter[] _SqlParameter = new SqlParameter[2];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectRoomIDbyRoomNameAlias");
              _SqlParameter[1] = new SqlParameter("@RoomNameAlias", RoomNameAlias);
              ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_RoomData", _SqlParameter));
              return ID;
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure SelectRoomIDbyRoomNameAlias()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ID;
      }

      public SqlDataReader SelectActiveRoomDataByRoomID()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[2];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveRoomDataByRoomID");
              _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
              return ObjSql.GetDatareaderProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception Ex)
          {
              ObjEx.PublishError("Error in procedure SelectActiveRoomDataByRoomID()", Ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDatareaderProc("Mst_Sp_RoomData", _SqlParameter);
      }

      public DataSet SelectTop6ActiveRoomsForRealted()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[2];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectTop6ActiveRoomsForRealted");
              _SqlParameter[1] = new SqlParameter("@RoomID", RoomID);
              return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception ex)
          {
              ObjEx.PublishError("Error in procedure SelectTop6ActiveRoomsForRealted()", ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
      }

      public DataSet SelectAllActiveRoomsForPackageForListing()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[1];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomsForPackageForListing");
              return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception ex)
          {
              ObjEx.PublishError("Error in procedure SelectAllActiveRoomsForPackageForListing()", ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
      }

      public DataSet SelectAllActiveRoomsForBooking()
      {
          SqlParameter[] _SqlParameter = new SqlParameter[3];
          try
          {
              _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveRoomsForBooking");
              _SqlParameter[1] = new SqlParameter("@BookingDate", BookingDate);
              _SqlParameter[2] = new SqlParameter("@UpdatedOn", UpdatedOn);
              return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
          }
          catch (Exception ex)
          {
              ObjEx.PublishError("Error in procedure SelectAllActiveRoomsForBooking()", ex);
          }
          finally
          {
              ObjSql.Disconnect();
          }
          return ObjSql.GetDsetProc("Mst_Sp_RoomData", _SqlParameter);
      }
      #endregion
  }
}
