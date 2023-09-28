using CCA.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace AapnoGharWeb
{
    public partial class CCAVRequestHandler : System.Web.UI.Page
    {
        CCACrypto ccaCrypto = new CCACrypto();
        string workingKey = "0A4235891C342EF85ABBCA0682268EC3"; //URL:https://www.aapnoghar.com
        //string workingKey = "E8CBBBC8D9D203FEB2B4B15F1C0ACCFF"; //URL:https://www.aapnoghar.com
        //string workingKey = "F1B105730E9047B478110D664437A5E0"; //URL:http://localhost:1997

        string ccaRequest = "";
        public string strMerchantId = "2415379";
        public string strEncRequest = "";

        public string strAccessCode = "AVQO61KE28AQ42OQQA"; //URL:https://www.aapnoghar.com
        //public string strAccessCode = "AVAV68KE43BR62VARB"; //URL:https://www.aapnoghar.com
        //public string strAccessCode = "AVAV68KE43BR63VARB"; //URL:http://localhost:1997
        ICollection keys;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int ret = 0;
                    Hashtable ObjrecRecord = (Hashtable)Session["rechold"];
                    keys = ObjrecRecord.Keys;
                    foreach (string name in ObjrecRecord.Keys)
                    {
                        if (name != null)
                        {
                            if (!name.StartsWith("_"))
                            {
                                if (ret == 0)
                                    ccaRequest = ccaRequest + name + "=" + ObjrecRecord[name];
                                else
                                    ccaRequest = ccaRequest + "&" + name + "=" + ObjrecRecord[name];
                                ret = 1;
                            }
                        }
                    }
                    strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
                    strMerchantId = "2415379";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
    }
}