using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Connect2Leads.WebServices
{
    /// <summary>
    /// Summary description for AddClientLead
    /// </summary>
    [WebService(Namespace = "http://connect2lead.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AddClientLead : System.Web.Services.WebService
    {
        
        [WebMethod]
        public string AddLead(string account_id, string security_key, string campaign_id, string record_id, string bill_first_name, string bill_last_name, string bill_address_1, string bill_address_2, string bill_city_town, string bill_state_province, string bill_zip_postcode, string bill_country_code, string ship_first_name, string ship_last_name, string ship_address_1, string ship_address_2, string ship_city_town, string ship_state_province, string ship_zip_postcode, string phone_1, string phone_2, string email, string date_acquired, string last_contact_date, string ip_address, string language_code, string product_name, string product_desc, string product_sku, string product_price, string product_website, string opt1, string opt2, string opt3, string opt4, string opt5, string opt6, string opt7, string opt8, string opt9, string opt10)
        {
            
            try{
            DataAccess.MySQLAccess myObj = new DataAccess.MySQLAccess();
            string theLeadID = "0";
            theLeadID = myObj.addClientLead (account_id, security_key, campaign_id, record_id, bill_first_name, bill_last_name, bill_address_1, bill_address_2,
bill_city_town, bill_state_province, bill_zip_postcode, bill_country_code, ship_first_name, ship_last_name, ship_address_1,
ship_address_2, ship_city_town, ship_state_province, ship_zip_postcode, phone_1, phone_2, email, date_acquired, last_contact_date,
ip_address, language_code, product_name, product_desc, product_sku, product_price, product_website, opt1, opt2, opt3, opt4, opt5, opt6,
opt7, opt8, opt9, opt10, "LocalMySqlServer");
            return theLeadID;
            
            }

            catch (Exception e)
            {

                return e.Message;

            }
            //throw new System.NotImplementedException();
        }


    }
}
