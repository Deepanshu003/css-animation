using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Component
{
    public class CouponData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public CouponData()
        {
        }

        private int _couponID = 0;
        private string _couponTitle = string.Empty;
        private string _couponCode = string.Empty;
        private string _couponType = string.Empty;
        private string _couponValue = string.Empty;
        private int _couponMinAmount = 0;
        private string _couponImage = string.Empty;
        private DateTime _couponStartDate = DateTime.UtcNow;
        private DateTime _couponExpiry = DateTime.UtcNow;
        private int _activeStatus = 0;
        private int _DisplayOnHome = 0;
        private int _CouponRoom = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;

        public int CouponID
        {
            get { return _couponID; }
            set { _couponID = value; }
        }
        public string CouponTitle
        {
            get { return _couponTitle; }
            set { _couponTitle = value; }
        }
        public string CouponCode
        {
            get { return _couponCode; }
            set { _couponCode = value; }
        }
        public string CouponType
        {
            get { return _couponType; }
            set { _couponType = value; }
        }
        public string CouponValue
        {
            get { return _couponValue; }
            set { _couponValue = value; }
        }
        public int CouponMinAmount
        {
            get { return _couponMinAmount; }
            set { _couponMinAmount = value; }
        }
        public string CouponImage
        {
            get { return _couponImage; }
            set { _couponImage = value; }
        }
        public DateTime CouponStartDate
        {
            get { return _couponStartDate; }
            set { _couponStartDate = value; }
        }
        public DateTime CouponExpiry
        {
            get { return _couponExpiry; }
            set { _couponExpiry = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public int DisplayOnHome
        {
            get { return _DisplayOnHome; }
            set { _DisplayOnHome = value; }
        }
        public int CouponRoom
        {
            get { return _CouponRoom; }
            set { _CouponRoom = value; }
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

        #region Admin Panel
        public void SelectAllCouponData(System.Web.UI.WebControls.GridView CouponGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCouponData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(CouponGrid, "Mst_Sp_Coupon", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllCouponData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectCouponByCouponID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCouponByCouponID");
                _SqlParameter[1] = new SqlParameter("@CouponID", CouponID);
                return ObjSql.GetDatareaderProc("Mst_Sp_Coupon", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCouponByCouponID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_Coupon", _SqlParameter);
        }

        public int SaveNewCoupon()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewCoupon");
                _SqlParameter[1] = new SqlParameter("@CouponTitle", CouponTitle);
                _SqlParameter[2] = new SqlParameter("@CouponCode", CouponCode);
                _SqlParameter[3] = new SqlParameter("@CouponType", CouponType);
                _SqlParameter[4] = new SqlParameter("@CouponValue", CouponValue);
                _SqlParameter[5] = new SqlParameter("@CouponImage", CouponImage);
                _SqlParameter[6] = new SqlParameter("@CouponMinAmount", CouponMinAmount);
                _SqlParameter[7] = new SqlParameter("@CouponStartDate", CouponStartDate);
                _SqlParameter[8] = new SqlParameter("@CouponExpiry", CouponExpiry);
                _SqlParameter[9] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[10] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[11] = new SqlParameter("@CouponRoom", CouponRoom);
                return ObjSql.ExcuteProce("Mst_Sp_Coupon", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewCoupon()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Coupon", _SqlParameter);
        }

        public int UpdateCouponByCouponID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[15];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCouponByCouponID");
                _SqlParameter[1] = new SqlParameter("@CouponID", CouponID);
                _SqlParameter[2] = new SqlParameter("@CouponTitle", CouponTitle);
                _SqlParameter[3] = new SqlParameter("@CouponCode", CouponCode);
                _SqlParameter[4] = new SqlParameter("@CouponType", CouponType);
                _SqlParameter[5] = new SqlParameter("@CouponValue", CouponValue);
                _SqlParameter[6] = new SqlParameter("@CouponImage", CouponImage);
                _SqlParameter[7] = new SqlParameter("@CouponMinAmount", CouponMinAmount);
                _SqlParameter[8] = new SqlParameter("@CouponStartDate", CouponStartDate);
                _SqlParameter[9] = new SqlParameter("@CouponExpiry", CouponExpiry);
                _SqlParameter[10] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[11] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[12] = new SqlParameter("@CouponRoom", CouponRoom);
                _SqlParameter[13] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[14] = new SqlParameter("@Updatedon", UpdatedOn);
                return ObjSql.ExcuteProce("Mst_Sp_Coupon", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCouponByCouponID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Coupon", _SqlParameter);
        }

        public int DeleteCouponByCouponID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteCouponByCouponID");
                _SqlParameter[1] = new SqlParameter("@CouponID", CouponID);
                return ObjSql.ExcuteProce("Mst_Sp_Coupon", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteCouponByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Coupon", _SqlParameter);
        }
        #endregion Admin Panel

        #region Front End
        public DataSet SelectAllActiveCouponCode()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveCouponCode");
                return ObjSql.GetDsetProc("Mst_Sp_Coupon", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveCouponCode()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Coupon", _SqlParameter);
        }

        public DataSet SelectTopOneActiveCouponCodeForHomePage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTopOneActiveCouponCodeForHomePage");
                return ObjSql.GetDsetProc("Mst_Sp_Coupon", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTopOneActiveCouponCodeForHomePage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Coupon", _SqlParameter);
        }
        #endregion
    }
}
