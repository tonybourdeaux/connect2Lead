using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Mail;


namespace Connect2Leads.DataAccess
{
    public class MySQLAccess
    {   //used as proxy to interact with MySQL database

        // Retrieves a connection string by name. Names are stored in the web.config file- and in the IIS config
        // Returns null if the name is not found.
        public string GetConnectionStringByName(string name)
         {
            //Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            //If found, return the connection string.
            if (settings != null)
            returnValue = settings.ConnectionString;

            return returnValue;
         }

        public MySqlConnection GetConnection(string connectstring)
        {
            try
            {

            MySqlConnection retCon = null;

            retCon = new MySql.Data.MySqlClient.MySqlConnection(connectstring);

            return retCon;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Int64 executeNonQuery(string theNonQuery,string theConnectStringName)
        {
            ///generic function to execute SQL command 
            Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
            try
            {
                //get the actual connection string stored in the applciation for this name
                string myCS = GetConnectionStringByName(theConnectStringName);

                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits. Use the connect string from above.
                using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
                {
                    myCON.Open();
                    //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    MySqlCommand myCommand = new MySqlCommand(theNonQuery, myCON);
                    recsAffected=myCommand.ExecuteNonQuery();
                    
                }

                return recsAffected;

            }
            catch (Exception e)
            {
                
                throw;
                
            }
            

        }
        public void getDataSet(string theQuery, string theConnectStringName)
        {
            //generic get data set 
             try
            {
                //get the actual connection string stored in the applciation for this name
                string myCS = GetConnectionStringByName(theConnectStringName);

                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits. Use the connect string from above.
                using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
                {
                    myCON.Open();
                    //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    MySqlCommand myCommand = new MySqlCommand(theQuery, myCON);
                    MySqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            myReader[0], myReader[1], myReader[2]);
                         Console.WriteLine(myReader.GetInt32(0) + ", " + myReader.GetString(1));
                    }
                    Console.ReadLine();
                }

                

            }
             catch (Exception e)
             {

                 throw;

             }
            
        }

        public string addClientLead(string theaccount_id,string thesecurity_key,string thecampaign_id,string therecord_id,string
thebill_first_name,string thebill_last_name,string thebill_address_1,string thebill_address_2 ,string
thebill_city_town,string thebill_state_province,string thebill_zip_postcode,string thebill_country_code,string theship_first_name,string
theship_last_name,string theship_address_1,string theship_address_2,string theship_city_town,string theship_state_province,string
 theship_zip_postcode,string thephone_1,string thephone_2,string theemail,string thedate_acquired,string thelast_contact_date,string
 theip_address,string thelanguage_code,string theproduct_name,string theproduct_desc,string theproduct_sku,string theproduct_price,string
 theproduct_website,string theopt1,string theopt2 ,string theopt3 ,string theopt4 ,string theopt5 ,string theopt6 ,string
 theopt7 ,string theopt8 ,string theopt9 ,string theopt10 ,string theConnectStringName)
        {   //adds lead record and returns the added leadid

            string theCommand = "sp_insert_client_lead_raw";
            string theclientleadsrawID = "";//this will hold the loginID of the recrod added
             
            try
            {
                //get the actual connection string stored in the applciation for this name
                string myCS = GetConnectionStringByName(theConnectStringName);

                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits. Use the connect string from above.
                using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
                {
                    myCON.Open();
                    //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    MySqlParameter myInParam = new MySqlParameter();
                    myInParam.ParameterName = "theaccount_id";
                    myInParam.Value = theaccount_id;
                    myCommand.Parameters.Add(myInParam);
                    myInParam.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam2 = new MySqlParameter();
                    myInParam2.ParameterName = "thesecurity_key";
                    myInParam2.Value = thesecurity_key;
                    myCommand.Parameters.Add(myInParam2);
                    myInParam2.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam3 = new MySqlParameter();
                    myInParam3.ParameterName = "thecampaign_id";
                    myInParam3.Value = thecampaign_id;
                    myCommand.Parameters.Add(myInParam3);
                    myInParam3.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam4 = new MySqlParameter();
                    myInParam4.ParameterName = "therecord_id";
                    myInParam4.Value = therecord_id;
                    myCommand.Parameters.Add(myInParam4);
                    myInParam4.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam5 = new MySqlParameter();
                    myInParam5.ParameterName = "thebill_first_name";
                    myInParam5.Value = thebill_first_name;
                    myCommand.Parameters.Add(myInParam5);
                    myInParam5.Direction = System.Data.ParameterDirection.Input;


                    //add
                    MySqlParameter myInParam6 = new MySqlParameter();
                    myInParam6.ParameterName = "thebill_last_name";
                    myInParam6.Value = thebill_last_name;
                    myCommand.Parameters.Add(myInParam6);
                    myInParam6.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam7 = new MySqlParameter();
                    myInParam7.ParameterName = "thebill_address_1";
                    myInParam7.Value = thebill_address_1;
                    myCommand.Parameters.Add(myInParam7);
                    myInParam7.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam8 = new MySqlParameter();
                    myInParam8.ParameterName = "thebill_address_2";
                    myInParam8.Value = thebill_address_2;
                    myCommand.Parameters.Add(myInParam8);
                    myInParam8.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam9 = new MySqlParameter();
                    myInParam9.ParameterName = "thebill_city_town";
                    myInParam9.Value = thebill_city_town;
                    myCommand.Parameters.Add(myInParam9);
                    myInParam9.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam10 = new MySqlParameter();
                    myInParam10.ParameterName = "thebill_state_province";
                    myInParam10.Value = thebill_state_province;
                    myCommand.Parameters.Add(myInParam10);
                    myInParam10.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam11 = new MySqlParameter();
                    myInParam11.ParameterName = "thebill_zip_postcode";
                    myInParam11.Value = thebill_zip_postcode;
                    myCommand.Parameters.Add(myInParam11);
                    myInParam11.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam12 = new MySqlParameter();
                    myInParam12.ParameterName = "thebill_country_code";
                    myInParam12.Value = thebill_country_code;
                    myCommand.Parameters.Add(myInParam12);
                    myInParam12.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam13 = new MySqlParameter();
                    myInParam13.ParameterName = "theship_first_name";
                    myInParam13.Value = theship_first_name;
                    myCommand.Parameters.Add(myInParam13);
                    myInParam13.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam14 = new MySqlParameter();
                    myInParam14.ParameterName = "theship_last_name";
                    myInParam14.Value = theship_last_name;
                    myCommand.Parameters.Add(myInParam14);
                    myInParam14.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam15 = new MySqlParameter();
                    myInParam15.ParameterName = "theship_address_1";
                    myInParam15.Value = theship_address_1;
                    myCommand.Parameters.Add(myInParam15);
                    myInParam15.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam16 = new MySqlParameter();
                    myInParam16.ParameterName = "theship_address_2";
                    myInParam16.Value = theship_address_2;
                    myCommand.Parameters.Add(myInParam16);
                    myInParam16.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam17 = new MySqlParameter();
                    myInParam17.ParameterName = "theship_city_town";
                    myInParam17.Value = theship_city_town;
                    myCommand.Parameters.Add(myInParam17);
                    myInParam17.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam18 = new MySqlParameter();
                    myInParam18.ParameterName = "theship_state_province";
                    myInParam18.Value = theship_state_province;
                    myCommand.Parameters.Add(myInParam18);
                    myInParam18.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam19 = new MySqlParameter();
                    myInParam19.ParameterName = "theship_zip_postcode";
                    myInParam19.Value = theship_zip_postcode;
                    myCommand.Parameters.Add(myInParam19);
                    myInParam19.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam20 = new MySqlParameter();
                    myInParam20.ParameterName = "thephone_1";
                    myInParam20.Value = thephone_1;
                    myCommand.Parameters.Add(myInParam20);
                    myInParam20.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam21 = new MySqlParameter();
                    myInParam21.ParameterName = "thephone_2";
                    myInParam21.Value = thephone_2;
                    myCommand.Parameters.Add(myInParam21);
                    myInParam21.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam22 = new MySqlParameter();
                    myInParam22.ParameterName = "theemail";
                    myInParam22.Value = theemail;
                    myCommand.Parameters.Add(myInParam22);
                    myInParam22.Direction = System.Data.ParameterDirection.Input;

                    //add
                    if (thedate_acquired == "") thedate_acquired = null;
                    MySqlParameter myInParam23 = new MySqlParameter();
                    myInParam23.ParameterName = "thedate_acquired";
                    myInParam23.Value = thedate_acquired;
                    myCommand.Parameters.Add(myInParam23);
                    myInParam23.Direction = System.Data.ParameterDirection.Input;

                    //add
                    if (thelast_contact_date == "") thelast_contact_date = null;
                    MySqlParameter myInParam24 = new MySqlParameter();
                    myInParam24.ParameterName = "thelast_contact_date";
                    myInParam24.Value = thelast_contact_date;
                    myCommand.Parameters.Add(myInParam24);
                    myInParam24.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam25 = new MySqlParameter();
                    myInParam25.ParameterName = "theip_address";
                    myInParam25.Value = theip_address;
                    myCommand.Parameters.Add(myInParam25);
                    myInParam25.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam26 = new MySqlParameter();
                    myInParam26.ParameterName = "thelanguage_code";
                    myInParam26.Value = thelanguage_code;
                    myCommand.Parameters.Add(myInParam26);
                    myInParam26.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam27 = new MySqlParameter();
                    myInParam27.ParameterName = "theproduct_name";
                    myInParam27.Value = theproduct_name;
                    myCommand.Parameters.Add(myInParam27);
                    myInParam27.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam28 = new MySqlParameter();
                    myInParam28.ParameterName = "theproduct_desc";
                    myInParam28.Value = theproduct_desc;
                    myCommand.Parameters.Add(myInParam28);
                    myInParam28.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam29 = new MySqlParameter();
                    myInParam29.ParameterName = "theproduct_sku";
                    myInParam29.Value = theproduct_sku;
                    myCommand.Parameters.Add(myInParam29);
                    myInParam29.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam30 = new MySqlParameter();
                    myInParam30.ParameterName = "theproduct_price";
                    myInParam30.Value = theproduct_price;
                    myCommand.Parameters.Add(myInParam30);
                    myInParam30.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam31 = new MySqlParameter();
                    myInParam31.ParameterName = "theproduct_website";
                    myInParam31.Value = theproduct_website;
                    myCommand.Parameters.Add(myInParam31);
                    myInParam31.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam32 = new MySqlParameter();
                    myInParam32.ParameterName = "theopt1";
                    myInParam32.Value = theopt1;
                    myCommand.Parameters.Add(myInParam32);
                    myInParam32.Direction = System.Data.ParameterDirection.Input;

                    //add
                    MySqlParameter myInParam33 = new MySqlParameter();
                    myInParam33.ParameterName = "theopt2";
                    myInParam33.Value = theopt2;
                    myCommand.Parameters.Add(myInParam33);
                    myInParam33.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam34 = new MySqlParameter();
                    myInParam34.ParameterName = "theopt3";
                    myInParam34.Value = theopt3;
                    myCommand.Parameters.Add(myInParam34);
                    myInParam34.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam35 = new MySqlParameter();
                    myInParam35.ParameterName = "theopt4";
                    myInParam35.Value = theopt4;
                    myCommand.Parameters.Add(myInParam35);
                    myInParam35.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam36 = new MySqlParameter();
                    myInParam36.ParameterName = "theopt5";
                    myInParam36.Value = theopt5;
                    myCommand.Parameters.Add(myInParam36);
                    myInParam36.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam37 = new MySqlParameter();
                    myInParam37.ParameterName = "theopt6";
                    myInParam37.Value = theopt6;
                    myCommand.Parameters.Add(myInParam37);
                    myInParam37.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam38 = new MySqlParameter();
                    myInParam38.ParameterName = "theopt7";
                    myInParam38.Value = theopt7;
                    myCommand.Parameters.Add(myInParam38);
                    myInParam38.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam39 = new MySqlParameter();
                    myInParam39.ParameterName = "theopt8";
                    myInParam39.Value = theopt8;
                    myCommand.Parameters.Add(myInParam39);
                    myInParam39.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam40 = new MySqlParameter();
                    myInParam40.ParameterName = "theopt9";
                    myInParam40.Value = theopt9;
                    myCommand.Parameters.Add(myInParam40);
                    myInParam40.Direction = System.Data.ParameterDirection.Input;
                    //add
                    MySqlParameter myInParam41 = new MySqlParameter();
                    myInParam41.ParameterName = "theopt10";
                    myInParam41.Value = theopt10;
                    myCommand.Parameters.Add(myInParam41);
                    myInParam41.Direction = System.Data.ParameterDirection.Input;
                    
                    
                    
                    //Create placeholder for return value
                    MySqlParameter myRetParam = new MySqlParameter();
                    myRetParam.Direction = System.Data.ParameterDirection.ReturnValue;

                    myRetParam.ParameterName = "theclientleadsrawID";
                    myCommand.Parameters.Add(myRetParam);


                    myCommand.ExecuteNonQuery();
                    theclientleadsrawID = myRetParam.Value.ToString();//myCommand.LastInsertedId;

                }

                return theclientleadsrawID;

            }
            catch (Exception e)
            {

                throw;

            }


        }

        //public string login(string theAgent, string theConnectStringName)
        //{   //adds agent login record for agent with current dattime from server- returns the agentloginid for the added record
        //    string theCommand = "agentlogin";
        //    string theAgentLoginID = "";//this will hold the loginID of the recrod added
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            MySqlParameter myInParam = new MySqlParameter();
        //            myInParam.ParameterName = "AgentName";
        //            myInParam.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam);
        //            myInParam.Direction = System.Data.ParameterDirection.Input;

        //            //Create placeholder for return value
        //            MySqlParameter myRetParam = new MySqlParameter();
        //            myRetParam.Direction = System.Data.ParameterDirection.ReturnValue;
                   
        //            myRetParam.ParameterName = "AgentLoginID";
        //            myCommand.Parameters.Add(myRetParam);


        //            myCommand.ExecuteNonQuery();
        //            theAgentLoginID = myRetParam.Value.ToString();//myCommand.LastInsertedId;

        //        }

        //        return theAgentLoginID;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }


        //}


        //public string login2(string theAgent, string theCallCenterID,string theConnectStringName)
        //{   //adds agent login record for agent with current dattime from server- returns the agentloginid for the added record
        //    string theCommand = "agentlogin2";
        //    string theAgentLoginID = "";//this will hold the loginID of the recrod added
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            MySqlParameter myInParam = new MySqlParameter();
        //            myInParam.ParameterName = "AgentName";
        //            myInParam.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam);
        //            myInParam.Direction = System.Data.ParameterDirection.Input;
        //            //add
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "CallCenterID";
        //            myInParam1.Value = theCallCenterID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;

        //            //Create placeholder for return value
        //            MySqlParameter myRetParam = new MySqlParameter();
        //            myRetParam.Direction = System.Data.ParameterDirection.ReturnValue;

        //            myRetParam.ParameterName = "AgentLoginID";
        //            myCommand.Parameters.Add(myRetParam);


        //            myCommand.ExecuteNonQuery();
        //            theAgentLoginID = myRetParam.Value.ToString();//myCommand.LastInsertedId;

        //        }

        //        return theAgentLoginID;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }


        //}

        //public string login3(string theAgent, string theCallCenterID,string theAgentFirstName,string theAgentLastName ,string theConnectStringName)
        //{   //adds agent login record for agent with current dattime from server- returns the agentloginid for the added record
            
          
        //    string theCommand = "agentlogin3";
        //    string theAgentLoginID = "";//this will hold the loginID of the recrod added
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            MySqlParameter myInParam = new MySqlParameter();
        //            myInParam.ParameterName = "AgentName";
        //            myInParam.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam);
        //            myInParam.Direction = System.Data.ParameterDirection.Input;
        //            //add
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "CallCenterID";
        //            myInParam2.Value = theCallCenterID;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;

        //            //add
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "AgentFirstName";
        //            myInParam3.Value = theAgentFirstName;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;

        //            //add
        //            MySqlParameter myInParam4 = new MySqlParameter();
        //            myInParam4.ParameterName = "AgentLastName";
        //            myInParam4.Value = theAgentLastName;
        //            myCommand.Parameters.Add(myInParam4);
        //            myInParam4.Direction = System.Data.ParameterDirection.Input;

        //            //Create placeholder for return value
        //            MySqlParameter myRetParam = new MySqlParameter();
        //            myRetParam.Direction = System.Data.ParameterDirection.ReturnValue;

        //            myRetParam.ParameterName = "AgentLoginID";
        //            myCommand.Parameters.Add(myRetParam);


        //            myCommand.ExecuteNonQuery();
        //            theAgentLoginID = myRetParam.Value.ToString();//myCommand.LastInsertedId;

        //        }

        //        return theAgentLoginID;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }


        //}
        //public string login4(string theAgent, string theCallCenterID, string theAgentFirstName, string theAgentLastName, string theLoginIPAddress,string theConnectStringName)
        //{   //adds agent login record for agent with current dattime from server- returns the agentloginid for the added record


        //    string theCommand = "agentlogin4";
        //    string theAgentLoginID = "";//this will hold the loginID of the recrod added
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            MySqlParameter myInParam = new MySqlParameter();
        //            myInParam.ParameterName = "AgentName";
        //            myInParam.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam);
        //            myInParam.Direction = System.Data.ParameterDirection.Input;
        //            //add
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "CallCenterID";
        //            myInParam2.Value = theCallCenterID;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;

        //            //add
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "AgentFirstName";
        //            myInParam3.Value = theAgentFirstName;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;

        //            //add
        //            MySqlParameter myInParam4 = new MySqlParameter();
        //            myInParam4.ParameterName = "AgentLastName";
        //            myInParam4.Value = theAgentLastName;
        //            myCommand.Parameters.Add(myInParam4);
        //            myInParam4.Direction = System.Data.ParameterDirection.Input;

        //            //add
        //            MySqlParameter myInParam5 = new MySqlParameter();
        //            myInParam5.ParameterName = "LoginIPAddress";
        //            myInParam5.Value = theLoginIPAddress;
        //            myCommand.Parameters.Add(myInParam5);
        //            myInParam5.Direction = System.Data.ParameterDirection.Input;

        //            //Create placeholder for return value
        //            MySqlParameter myRetParam = new MySqlParameter();
        //            myRetParam.Direction = System.Data.ParameterDirection.ReturnValue;

        //            myRetParam.ParameterName = "AgentLoginID";
        //            myCommand.Parameters.Add(myRetParam);


        //            myCommand.ExecuteNonQuery();
        //            theAgentLoginID = myRetParam.Value.ToString();//myCommand.LastInsertedId;

        //        }

        //        return theAgentLoginID;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }


        //}

        //public DataSet getCallCenters(string theConnectStringName)
        //{
        //    //get all active call centers
        //    string theCommand = "getActiveCallCenters";

        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    
        //            //create data adapter and assign the command object created above
        //            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        //            myAdapter.SelectCommand = myCommand;
        //            //create and fill a dataset from the stored procedure
        //            DataSet theCallCenters = new DataSet();
        //            myAdapter.Fill(theCallCenters);



        //            return theCallCenters;

        //        //returns:CallCenterID,CallCenterName,CallCenterNotes,LDAPConnectStringName,Active

                    
        //        }



        //    }
        //    catch (Exception e)
        //    {
        //        //if error then return null
        //        return null;

        //    }

        //}
       
        //public Int32 logout(string theAgentLoginID, string theConnectStringName)
        //{   //updates the current agentlogin record with the logout time from the server (current server time)
        //    string theCommand = "agentlogout";
        //    Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            MySqlParameter myInParam = new MySqlParameter();
        //            myInParam.ParameterName = "theAgentLoginID";
        //            myInParam.Value = theAgentLoginID;
        //            myCommand.Parameters.Add(myInParam);
        //            myInParam.Direction = System.Data.ParameterDirection.Input;

                    

        //            recsAffected=myCommand.ExecuteNonQuery();
                    

        //        }

        //        return recsAffected;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }


        //}
        
        //public string[] getExtension(string theAgentLoginID, string theAgent,string theCompany, string theConnectStringName)
        //{
        //    //`getPhoneExtension`(IN theAgentLoginID int,IN theAgentName varchar(45),IN theCallCenter varchar(45))
        //    //reserve a phone extension to use and return extension info- set session variables 
        //    string theCommand = "getPhoneExtension";
        //    string[] theReturnValues=new string[8];
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //           //add input parameters for stored procedure
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theAgentLoginID";
        //            myInParam1.Value = theAgentLoginID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters for stored procedure
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "theAgentName";
        //            myInParam2.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters for stored procedure
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "theCallCenter";
        //            myInParam3.Value = theCompany;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;

        //            //execute and return record to reader
        //            MySqlDataReader myReader = myCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {   //read the return record fields into the return array:
        //                theReturnValues[0] = myReader["PhoneExtensionAssignmentID"].ToString();
        //                theReturnValues[1] = myReader["PhoneExtensionID"].ToString();
        //                theReturnValues[2] = myReader["SwitchName"].ToString();
        //                theReturnValues[3] = myReader["SwitchAddress"].ToString();
        //                theReturnValues[4] = myReader["SwitchPort"].ToString();
        //                theReturnValues[5] = myReader["Extension"].ToString();
        //                theReturnValues[6] = myReader["UserName"].ToString();
        //                theReturnValues[7] = myReader["Password"].ToString();
                    
        //            }
        //            return theReturnValues;
        //        }



        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }

        //}
        
        //public Int64 releaseExtension(string thePhoneExtensionAssignmentID, string theConnectStringName)
        //{

        //    //updates the current Phone extension assignement record with the end time from the server (current server time)
        //    //this makes the extension available to be reserved by another agent
        //    string theCommand = "releasePhoneExtension";
        //    Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            MySqlParameter myInParam = new MySqlParameter();
        //            myInParam.ParameterName = "thePhoneExtensionAssignmentID";
        //            myInParam.Value = thePhoneExtensionAssignmentID;
        //            myCommand.Parameters.Add(myInParam);
        //            myInParam.Direction = System.Data.ParameterDirection.Input;



        //            recsAffected = myCommand.ExecuteNonQuery();


        //        }

        //        return recsAffected;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }


        //}

        //public Int64 updateExtension(string thePhoneExtensionAssignmentID, int theCallTime,string theConnectStringName)
        //{

        //    //updates the current Phone extension assignement record - adds 1 to call count, updates last calltime, adds the minutes to the total call time
        //    string theCommand = "updateExtensionCounts";
        //    Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "thePhoneExtensionAssignmentID";
        //            myInParam1.Value = thePhoneExtensionAssignmentID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "callTime";
        //            myInParam2.Value = theCallTime;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;


        //            recsAffected = myCommand.ExecuteNonQuery();


        //        }

        //        return recsAffected;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }


        //}


        //public Int64 addCallDetail(string theAgentLoginID, string thePhoneExtensionID, string thePhoneExtensionAssignmentID, string thePreviewCallID, string theAgent,
        //                            string thePhoneNumber, string theCallType, string theStartTime, string theConnectTime, string theDisconnectTime,
        //                            string theCallRecordingID, string IsDisconnectedBy, string theConnectStringName)
        //{

        //    //adds the phone call record to the db
        //    string theCommand = "addCallDetail";
        //    Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theAgentLoginID";
        //            myInParam1.Value = theAgentLoginID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "thePhoneExtensionID";
        //            myInParam2.Value = thePhoneExtensionID;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "thePhoneExtensionAssignmentID";
        //            myInParam3.Value = thePhoneExtensionAssignmentID;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam4 = new MySqlParameter();
        //            myInParam4.ParameterName = "thePreviewCallID";
        //            myInParam4.Value = thePreviewCallID;
        //            myCommand.Parameters.Add(myInParam4);
        //            myInParam4.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam5 = new MySqlParameter();
        //            myInParam5.ParameterName = "theAgent";
        //            myInParam5.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam5);
        //            myInParam5.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam6 = new MySqlParameter();
        //            myInParam6.ParameterName = "thePhoneNumber";
        //            myInParam6.Value = thePhoneNumber;
        //            myCommand.Parameters.Add(myInParam6);
        //            myInParam6.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam7 = new MySqlParameter();
        //            myInParam7.ParameterName = "theCallType";
        //            myInParam7.Value = theCallType;
        //            myCommand.Parameters.Add(myInParam7);
        //            myInParam7.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam8 = new MySqlParameter();
        //            myInParam8.ParameterName = "theStartTime";
        //            myInParam8.Value = theStartTime;
        //            myCommand.Parameters.Add(myInParam8);
        //            myInParam8.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam9 = new MySqlParameter();
        //            myInParam9.ParameterName = "theConnectTime";
        //            myInParam9.Value = theConnectTime;
        //            myCommand.Parameters.Add(myInParam9);
        //            myInParam9.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam10 = new MySqlParameter();
        //            myInParam10.ParameterName = "theDisconnectTime";
        //            myInParam10.Value = theDisconnectTime;
        //            myCommand.Parameters.Add(myInParam10);
        //            myInParam10.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam11 = new MySqlParameter();
        //            myInParam11.ParameterName = "theCallRecordingID";
        //            myInParam11.Value = theCallRecordingID;
        //            myCommand.Parameters.Add(myInParam11);
        //            myInParam11.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam12 = new MySqlParameter();
        //            myInParam12.ParameterName = "IsDisconnectedBy";
        //            myInParam12.Value = IsDisconnectedBy;
        //            myCommand.Parameters.Add(myInParam12);
        //            myInParam12.Direction = System.Data.ParameterDirection.Input;
                    

        //            recsAffected = myCommand.ExecuteNonQuery();
        //        }

        //        return recsAffected;

        //    }
        //    catch (Exception e)
        //    {

        //        return recsAffected;

        //    }


        //}


        //public DataSet getLead(string theAgent, string theAgentLoginID, string theCampaignID, string theConnectStringName)
        //{
        //    //pass a campaign name and get back the next lead info to call from a stored procedure
        //    //returns lead info, script, and product offers to sell
        //    //logic for lead priority in stored procedure
        //    //adds the preview call lead reservation record to the db
        //    string theCommand = "GetLead";

        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theAgentLoginID";
        //            myInParam1.Value = theAgentLoginID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
                    
        //            //add input parameters
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "theCampaignID";
        //            myInParam2.Value = theCampaignID;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;
                    
        //            //add input parameters
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "theAgent";
        //            myInParam3.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;



        //            //Create placeholder for return value theScriptName
        //            MySqlParameter myRetParam1 = new MySqlParameter();
        //            myRetParam1.Direction = System.Data.ParameterDirection.ReturnValue;
        //            myRetParam1.ParameterName = "theScriptName";
        //            myCommand.Parameters.Add(myRetParam1);

        //            //Create placeholder for return value theLeadID
        //            MySqlParameter myRetParam2 = new MySqlParameter();
        //            myRetParam2.Direction = System.Data.ParameterDirection.ReturnValue;
        //            myRetParam2.ParameterName = "theLeadID";
        //            myCommand.Parameters.Add(myRetParam2);

        //            //Create placeholder for return value thePreviewCallID
        //            MySqlParameter myRetParam3 = new MySqlParameter();
        //            myRetParam3.Direction = System.Data.ParameterDirection.ReturnValue;
        //            myRetParam3.ParameterName = "thePreviewCallID";
        //            myCommand.Parameters.Add(myRetParam3);

        //            //Create placeholder for return value theSalesPackageName
        //            MySqlParameter myRetParam4 = new MySqlParameter();
        //            myRetParam4.Direction = System.Data.ParameterDirection.ReturnValue;
        //            myRetParam4.ParameterName = "theSalesPackageName";
        //            myCommand.Parameters.Add(myRetParam4);

                   
        //            //create data adapter and assign the command object created above
        //            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        //            myAdapter.SelectCommand = myCommand;
        //            //create and fill a dataset from the stored procedure
        //            DataSet theLead = new DataSet();
        //            myAdapter.Fill(theLead);
                    
                    
        //            //can read the output parameters-like the following if needed (also returns all output parameters in recordset-easier to pass back to calling function)
        //            //this is just here for reference in case I want to change the way this works ever..
        //            //int theLeadIDret=0;
        //            //theLeadIDret= myAdapter.SelectCommand.Parameters.IndexOf("theLeadID");
        //            //MySqlParameter myRetParamTEST = new MySqlParameter();
        //            //myRetParamTEST =myAdapter.SelectCommand.Parameters["theLeadID"];
        //            ///////////////////////////////////////////////////////////////////
        //            //add relationship between the product offers table and the product codes table
        //            DataRelation relation = theLead.Relations.Add("prodCodes", theLead.Tables["Table1"].Columns["ProductOfferID"], theLead.Tables["Table2"].Columns["ProductOfferID"]);
        //            //return the filled dataset
        //            return theLead;


        //            //recordsets returned:
        //            //Table[1] the Lead Info
        //            //LeadID,CampaignCode,CampaignDesc,CallEndTime,CallID,CallDuration,ANI,BestPhoneNumber,PhoneType,ScriptID,Info411Name,Info411Address,Info411City,
        //            //Info411State,Info411Zip,AddedDateTime,FullNameRecordingFilename,ShipAddressRecordingFilename,DropOffPoint,EmailAddressRecordingFilename,AddedToPoolDateTime,
        //            //Active,NumberOfCalls,CallBackOn,CallBackAgent,LastCallDateTime,LastDispositionID,LastDisposition

        //            //Table[1] the product offers
        //            //SalesPackageName,ProductOfferID,SalePackageID,ProductOffer,SalesPosition,OfferType,RequirePrevious,RequireCore,IsCore

        //            //Table[2] the product codes that get added for each product offer
        //            //ProductOfferID,ProductOfferCode,Price,Shipping,Taxable,ShippingTaxable


        //            //Table[3] the parameter values
        //            //theScriptName,theLeadID,thePreviewCallID,theSalesPackageName
        //        }



        //    }
        //    catch (Exception e)
        //    {
        //        //if error then return null
        //        return null;

        //    }

        //}

        //public DataSet getLead2(string theAgent, string theAgentLoginID, string theConnectStringName)
        //{
        //    //get back the next lead info to call from a stored procedure
        //    //returns lead info, script, and product offers to sell
        //    //logic for lead priority in stored procedure
        //    //adds the preview call lead reservation record to the db
        //    string theCommand = "GetLead2";

        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theAgentLoginID";
        //            myInParam1.Value = theAgentLoginID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;

        //            //add input parameters
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "theAgent";
        //            myInParam3.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;

        //            //create data adapter and assign the command object created above
        //            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        //            myAdapter.SelectCommand = myCommand;
        //            //create and fill a dataset from the stored procedure
        //            DataSet theLead = new DataSet();
        //            myAdapter.Fill(theLead);


        //            //can read the output parameters-like the following if needed (also returns all output parameters in recordset-easier to pass back to calling function)
        //            //this is just here for reference in case I want to change the way this works ever..
        //            //int theLeadIDret=0;
        //            //theLeadIDret= myAdapter.SelectCommand.Parameters.IndexOf("theLeadID");
        //            //MySqlParameter myRetParamTEST = new MySqlParameter();
        //            //myRetParamTEST =myAdapter.SelectCommand.Parameters["theLeadID"];
        //            ///////////////////////////////////////////////////////////////////
        //            //add relationship between the product offers table and the product codes table
        //            DataRelation relation = theLead.Relations.Add("prodCodes", theLead.Tables["Table1"].Columns["ProductOfferID"], theLead.Tables["Table2"].Columns["ProductOfferID"]);
        //            //return the filled dataset
        //            return theLead;

        //            //recordsets returned:

        //            //Table[0] the Lead Info
        //            //LeadID,CampaignCode,CampaignDesc,CallEndTime,CallID,CallDuration,ANI,BestPhoneNumber,PhoneType,ScriptID,Info411Name,
        //            //Info411Address,Info411City,Info411State,Info411Zip,AddedDateTime,FullNameRecordingFilename,ShipAddressRecordingFilename,
        //            //DropOffPoint,EmailAddressRecordingFilename,AddedToPoolDateTime,Active,NumberOfCalls,CallBackOn,CallBackAgent,
        //            //LastCallDateTime,LastDispositionID,LastDisposition,TimeZone,NPAState,NPACity

        //            //Table[1] the product offers
        //            //SalesPackageName,ProductOfferID,SalePackageID,ProductOffer,
        //            //SalesPosition,OfferType,RequirePrevious,RequireCore,IsCore,
        //            //totalprice,totalshipping,totaltaxable,totalproducttaxable,totalshippingtaxable,
        //            //totalpriceNow,totalshippingNow,totalpriceDelayed,totalshippingDelayed,
        //            //totalpriceRecurring,totalshippingRecurring,DelayBeforeBill,DelayBeforeBillType,
        //            //RecurringPeriod,RecurringPeriodType,Continuity,NumberPaymentsPrice,NumberPaymentshipping,
        //            //totalpricePayments,totalshippingPayments

        //            //Table[2] the product codes that get added for each product offer
        //            //ProductOfferID,ProductOfferCode,Price,Shipping,Taxable,ShippingTaxable,
        //            //PriceInitial,ShippingInitial,PriceDelayed,ShippingDelayed,
        //            //DelayBeforeBill,DelayBeforeBillType,RecurringPeriod,RecurringPeriodType,
        //            //PriceRecurring,ShippingRecurring,Continuity,NumberPaymentsPrice,NumberPaymentsShipping

        //            //Table[3] the parameter values
        //            //theScriptName,theLeadID,thePreviewCallID,theSalesPackageName,theActiveLeads,
        //            //isAgentCallBack,theMatminScriptID,theDNIS,theCampaignID,theMACallID;

        //            //table[4] call dispositions for this campaign
        //            //CallDispositionID,CallDisposition,Dialed,NotDialed,ProcessedGood,ProcessedBad,NotProcessed
        //        }



        //    }
        //    catch (Exception e)
        //    {
        //        //if error then return null
        //        return null;

        //    }

        //}
        //public DataSet getLead3(string theAgent, string theAgentLoginID, string theConnectStringName)
        //{
        //    //get back the next lead info to call from a stored procedure
        //    //returns lead info, script, and product offers to sell
        //    //logic for lead priority in stored procedure
        //    //adds the preview call lead reservation record to the db
        //    string theCommand = "GetLead4";// change for targus   "GetLead3";

        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theAgentLoginID";
        //            myInParam1.Value = theAgentLoginID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;

        //            //add input parameters
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "theAgent";
        //            myInParam3.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;

        //            //create data adapter and assign the command object created above
        //            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
        //            myAdapter.SelectCommand = myCommand;
        //            //create and fill a dataset from the stored procedure
        //            DataSet theLead = new DataSet();
        //            myAdapter.Fill(theLead);


        //            //can read the output parameters-like the following if needed (also returns all output parameters in recordset-easier to pass back to calling function)
        //            //this is just here for reference in case I want to change the way this works ever..
        //            //int theLeadIDret=0;
        //            //theLeadIDret= myAdapter.SelectCommand.Parameters.IndexOf("theLeadID");
        //            //MySqlParameter myRetParamTEST = new MySqlParameter();
        //            //myRetParamTEST =myAdapter.SelectCommand.Parameters["theLeadID"];
        //            ///////////////////////////////////////////////////////////////////
        //            //add relationship between the product offers table and the product codes table
        //            DataRelation relation = theLead.Relations.Add("prodCodes", theLead.Tables["Table1"].Columns["ProductOfferID"], theLead.Tables["Table2"].Columns["ProductOfferID"]);
        //            //return the filled dataset
        //            return theLead;

        //            //recordsets returned:

        //            //Table[0] the Lead Info
        //            //LeadID,CampaignCode,CampaignDesc,CallEndTime,CallID,CallDuration,ANI,BestPhoneNumber,PhoneType,ScriptID,Info411Name,
        //            //Info411Address,Info411City,Info411State,Info411Zip,AddedDateTime,FullNameRecordingFilename,ShipAddressRecordingFilename,
        //            //DropOffPoint,EmailAddressRecordingFilename,AddedToPoolDateTime,Active,NumberOfCalls,CallBackOn,CallBackAgent,
        //            //LastCallDateTime,LastDispositionID,LastDisposition,TimeZone,NPAState,NPACity,TrackingID,OriginalOrderDate


        //            //Table[1] the product offers
        //            //SalesPackageName,ProductOfferID,SalePackageID,ProductOffer,SalesPosition,OfferType,RequirePrevious,RequireCore,IsCore,
        //            //totalprice,totalshipping, totalpriceDisplay, totalshippingDisplay,totaltaxable,totalproducttaxable,totalshippingtaxable,
        //            //totalpriceNow,totalshippingNow, totaltaxableNow, totaltaxableDelayed,totalpriceDelayed,totalshippingDelayed,totalpriceRecurring,
        //            //totalshippingRecurring,DelayBeforeBill, DelayBeforeBillType, RecurringPeriod,
        //            //RecurringPeriodType, Continuity,NumberPaymentsPrice,NumberPaymentshipping, totalpricePayments,totalshippingPayments


        //            //Table[2] the product codes that get added for each product offer
        //            //ProductOfferID,ProductOfferCode,Price,Shipping,Taxable,ShippingTaxable,
        //            //PriceInitial,ShippingInitial,PriceDelayed,ShippingDelayed,
        //            //DelayBeforeBill,DelayBeforeBillType,RecurringPeriod,RecurringPeriodType,
        //            //PriceRecurring,ShippingRecurring,Continuity,NumberPaymentsPrice,NumberPaymentsShipping

        //            //Table[3] the parameter values
        //            //theScriptName,theLeadID,thePreviewCallID,theSalesPackageName,theActiveLeads,
        //            //isAgentCallBack,theMatminScriptID,theDNIS,theCampaignID,theMACallID,theProductLine,theChannel;

        //            //table[4] call dispositions for this campaign
        //            //CallDispositionID,CallDisposition,Dialed,NotDialed,ProcessedGood,ProcessedBad,NotProcessed
        //        }



        //    }
        //    catch (Exception e)
        //    {
        //        //if error then return null
        //        return null;

        //    }

        //}
        //public string saveOrderData(string thePreviewCallID,string theSubmittedOrderID,string theFirstName,string theLastName,string theUserName,string theComment,
        //    string theCompany,string theAddress1,string theAddress2,string theCity,string theState,string theCountry,string theZip,string theFax,string thePhone,
        //    string thePhoneType,string theEmail,string theShipFirstName,string theShipLastName,string theShipCompany,string theShipAddress1 ,string theShipAddress2,
        //    string  theShipCity,string theShipState,string theShipCountry,string theShipZip,string theShipFax,string theShipPhone,string theShipPhoneType,
        //    string theShipEmail,string thePaymentMethod,string theCardNumber,string theCardCCV,string theCardExpMonth,string theCardExpYear,string theCheckRoutingNumber,
        //    string theCheckAccountNumber,string theShippingTotal,string theShippingMethod,string theTax,string theSubTotal,string theTotal,string theMatminOrderID,
        //    string theOrderStatus,string theOrderStatusText,string isProcessedSale,string theConnectStringName)
        //{





        //    //adds the order record to the db
        //    string theCommand = "addOrder";
        //    Int32 recsAffected1 = 0;//this will hold the number of records affected by the nonQuery command
        //   string theInsertedOrderID = "0"; //holds the orderID
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "thePreviewCallID";
        //            myInParam1.Value = thePreviewCallID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "theSubmittedOrderID";
        //            myInParam2.Value = theSubmittedOrderID;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "theFirstName";
        //            myInParam3.Value = theFirstName;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam4 = new MySqlParameter();
        //            myInParam4.ParameterName = "theLastName";
        //            myInParam4.Value = theLastName;
        //            myCommand.Parameters.Add(myInParam4);
        //            myInParam4.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam5 = new MySqlParameter();
        //            myInParam5.ParameterName = "theUserName";
        //            myInParam5.Value = theUserName;
        //            myCommand.Parameters.Add(myInParam5);
        //            myInParam5.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam6 = new MySqlParameter();
        //            myInParam6.ParameterName = "theComment";
        //            myInParam6.Value = theComment;
        //            myCommand.Parameters.Add(myInParam6);
        //            myInParam6.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam7 = new MySqlParameter();
        //            myInParam7.ParameterName = "theCompany";
        //            myInParam7.Value = theCompany;
        //            myCommand.Parameters.Add(myInParam7);
        //            myInParam7.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam8 = new MySqlParameter();
        //            myInParam8.ParameterName = "theAddress1";
        //            myInParam8.Value = theAddress1;
        //            myCommand.Parameters.Add(myInParam8);
        //            myInParam8.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam9 = new MySqlParameter();
        //            myInParam9.ParameterName = "theAddress2";
        //            myInParam9.Value = theAddress2;
        //            myCommand.Parameters.Add(myInParam9);
        //            myInParam9.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam10 = new MySqlParameter();
        //            myInParam10.ParameterName = "theCity";
        //            myInParam10.Value = theCity;
        //            myCommand.Parameters.Add(myInParam10);
        //            myInParam10.Direction = System.Data.ParameterDirection.Input;
                    
        //            //add input parameters
        //            MySqlParameter myInParam11 = new MySqlParameter();
        //            myInParam11.ParameterName = "theState";
        //            myInParam11.Value = theState;
        //            myCommand.Parameters.Add(myInParam11);
        //            myInParam11.Direction = System.Data.ParameterDirection.Input;

        //            //add input parameters
        //            MySqlParameter myInParam12 = new MySqlParameter();
        //            myInParam12.ParameterName = "theCountry";
        //            myInParam12.Value = theCountry;
        //            myCommand.Parameters.Add(myInParam12);
        //            myInParam12.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam13 = new MySqlParameter();
        //            myInParam13.ParameterName = "theZip";
        //            myInParam13.Value = theZip;
        //            myCommand.Parameters.Add(myInParam13);
        //            myInParam13.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam14 = new MySqlParameter();
        //            myInParam14.ParameterName = "theFax";
        //            myInParam14.Value = theFax;
        //            myCommand.Parameters.Add(myInParam14);
        //            myInParam14.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam15 = new MySqlParameter();
        //            myInParam15.ParameterName = "thePhone";
        //            myInParam15.Value = thePhone;
        //            myCommand.Parameters.Add(myInParam15);
        //            myInParam15.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam16 = new MySqlParameter();
        //            myInParam16.ParameterName = "thePhoneType";
        //            myInParam16.Value = thePhoneType;
        //            myCommand.Parameters.Add(myInParam16);
        //            myInParam16.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam17 = new MySqlParameter();
        //            myInParam17.ParameterName = "theEmail";
        //            myInParam17.Value = theEmail;
        //            myCommand.Parameters.Add(myInParam17);
        //            myInParam17.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam18 = new MySqlParameter();
        //            myInParam18.ParameterName = "theShipFirstName";
        //            myInParam18.Value = theShipFirstName;
        //            myCommand.Parameters.Add(myInParam18);
        //            myInParam18.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam19 = new MySqlParameter();
        //            myInParam19.ParameterName = "theShipLastName";
        //            myInParam19.Value = theShipLastName;
        //            myCommand.Parameters.Add(myInParam19);
        //            myInParam19.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam20 = new MySqlParameter();
        //            myInParam20.ParameterName = "theShipCompany";
        //            myInParam20.Value = theShipCompany;
        //            myCommand.Parameters.Add(myInParam20);
        //            myInParam20.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam21 = new MySqlParameter();
        //            myInParam21.ParameterName = "theShipAddress1";
        //            myInParam21.Value = theShipAddress1;
        //            myCommand.Parameters.Add(myInParam21);
        //            myInParam21.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam22 = new MySqlParameter();
        //            myInParam22.ParameterName = "theShipAddress2";
        //            myInParam22.Value = theShipAddress2;
        //            myCommand.Parameters.Add(myInParam22);
        //            myInParam22.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam23 = new MySqlParameter();
        //            myInParam23.ParameterName = "theShipCity";
        //            myInParam23.Value = theShipCity;
        //            myCommand.Parameters.Add(myInParam23);
        //            myInParam23.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam24 = new MySqlParameter();
        //            myInParam24.ParameterName = "theShipState";
        //            myInParam24.Value = theShipState;
        //            myCommand.Parameters.Add(myInParam24);
        //            myInParam24.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam25 = new MySqlParameter();
        //            myInParam25.ParameterName = "theShipCountry";
        //            myInParam25.Value = theShipCountry;
        //            myCommand.Parameters.Add(myInParam25);
        //            myInParam25.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam26 = new MySqlParameter();
        //            myInParam26.ParameterName = "theShipZip";
        //            myInParam26.Value = theShipZip;
        //            myCommand.Parameters.Add(myInParam26);
        //            myInParam26.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam27 = new MySqlParameter();
        //            myInParam27.ParameterName = "theShipFax";
        //            myInParam27.Value = theShipFax;
        //            myCommand.Parameters.Add(myInParam27);
        //            myInParam27.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam28 = new MySqlParameter();
        //            myInParam28.ParameterName = "theShipPhone";
        //            myInParam28.Value = theShipPhone;
        //            myCommand.Parameters.Add(myInParam28);
        //            myInParam28.Direction = System.Data.ParameterDirection.Input;
                    
        //            //add input parameters
        //            MySqlParameter myInParam29 = new MySqlParameter();
        //            myInParam29.ParameterName = "theShipPhoneType";
        //            myInParam29.Value = theShipPhoneType;
        //            myCommand.Parameters.Add(myInParam29);
        //            myInParam29.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam30 = new MySqlParameter();
        //            myInParam30.ParameterName = "theShipEmail";
        //            myInParam30.Value = theShipEmail;
        //            myCommand.Parameters.Add(myInParam30);
        //            myInParam30.Direction = System.Data.ParameterDirection.Input;

        //            //add input parameters
        //            MySqlParameter myInParam31 = new MySqlParameter();
        //            myInParam31.ParameterName = "thePaymentMethod";
        //            myInParam31.Value = thePaymentMethod;
        //            myCommand.Parameters.Add(myInParam31);
        //            myInParam31.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam32 = new MySqlParameter();
        //            myInParam32.ParameterName = "theCardNumber";
        //            myInParam32.Value = theCardNumber;
        //            myCommand.Parameters.Add(myInParam32);
        //            myInParam32.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam33 = new MySqlParameter();
        //            myInParam33.ParameterName = "theCardCCV";
        //            myInParam33.Value = theCardCCV;
        //            myCommand.Parameters.Add(myInParam33);
        //            myInParam33.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam34 = new MySqlParameter();
        //            myInParam34.ParameterName = "theCardExpMonth";
        //            myInParam34.Value = theCardExpMonth;
        //            myCommand.Parameters.Add(myInParam34);
        //            myInParam34.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam35 = new MySqlParameter();
        //            myInParam35.ParameterName = "theCardExpYear";
        //            myInParam35.Value = theCardExpYear;
        //            myCommand.Parameters.Add(myInParam35);
        //            myInParam35.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam36 = new MySqlParameter();
        //            myInParam36.ParameterName = "theCheckRoutingNumber";
        //            myInParam36.Value = theCheckRoutingNumber;
        //            myCommand.Parameters.Add(myInParam36);
        //            myInParam36.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam37 = new MySqlParameter();
        //            myInParam37.ParameterName = "theCheckAccountNumber";
        //            myInParam37.Value = theCheckAccountNumber;
        //            myCommand.Parameters.Add(myInParam37);
        //            myInParam37.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam38 = new MySqlParameter();
        //            myInParam38.ParameterName = "theShippingTotal";
        //            myInParam38.Value = theShippingTotal;
        //            myCommand.Parameters.Add(myInParam38);
        //            myInParam38.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam39 = new MySqlParameter();
        //            myInParam39.ParameterName = "theShippingMethod";
        //            myInParam39.Value = theShippingMethod;
        //            myCommand.Parameters.Add(myInParam39);
        //            myInParam39.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam40 = new MySqlParameter();
        //            myInParam40.ParameterName = "theTax";
        //            myInParam40.Value = theTax;
        //            myCommand.Parameters.Add(myInParam40);
        //            myInParam40.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam41 = new MySqlParameter();
        //            myInParam41.ParameterName = "theSubTotal";
        //            myInParam41.Value = theSubTotal;
        //            myCommand.Parameters.Add(myInParam41);
        //            myInParam41.Direction = System.Data.ParameterDirection.Input;
        //           //add input parameters
        //            MySqlParameter myInParam42 = new MySqlParameter();
        //            myInParam42.ParameterName = "theTotal";
        //            myInParam42.Value = theTotal;
        //            myCommand.Parameters.Add(myInParam42);
        //            myInParam42.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam43 = new MySqlParameter();
        //            myInParam43.ParameterName = "theMatminOrderID";
        //            myInParam43.Value = theMatminOrderID;
        //            myCommand.Parameters.Add(myInParam43);
        //            myInParam43.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam44 = new MySqlParameter();
        //            myInParam44.ParameterName = "theOrderStatus";
        //            myInParam44.Value = theOrderStatus;
        //            myCommand.Parameters.Add(myInParam44);
        //            myInParam44.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam45 = new MySqlParameter();
        //            myInParam45.ParameterName = "theOrderStatusText";
        //            myInParam45.Value = theOrderStatusText;
        //            myCommand.Parameters.Add(myInParam45);
        //            myInParam45.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam46 = new MySqlParameter();
        //            myInParam46.ParameterName = "isProcessedSale";
        //            myInParam46.Value = isProcessedSale;
        //            myCommand.Parameters.Add(myInParam46);
        //            myInParam46.Direction = System.Data.ParameterDirection.Input;


        //            //Create placeholder for return value
        //            MySqlParameter myRetParam = new MySqlParameter();
        //            myRetParam.Direction = System.Data.ParameterDirection.ReturnValue;
        //            myRetParam.ParameterName = "theOrderID";
        //            myCommand.Parameters.Add(myRetParam);

        //            //recsAffected1 = myCommand.ExecuteNonQuery();
        //            //if (recsAffected1 == 1) { 
        //                //theInsertedOrderID = myRetParam.Value.ToString(); //}
                    
        //                theInsertedOrderID = Convert.ToString(myCommand.ExecuteScalar());

        //        }

        //        return theInsertedOrderID;

        //    }
        //    catch (Exception e)
        //    {

        //        throw;//return theInsertedOrderID;

        //    }



        //}

        //public long saveOrderItemData(string theOrderID,MatminAddOrder.LineItem[] theLineItems,string theConnectStringName)
            
        //    //string theOrderID, string theItemNumber, string thePercentDiscount, string thePrice, string theQuantity, string theConnectStringName)
        //{
            
          

        //    //adds the order items  to the db
        //    string theCommand = "addOrderItem";
        //    Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    
        //            foreach (MatminAddOrder.LineItem theitem in theLineItems){
                    
        //                myCommand.Parameters.Clear();
        //             //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theOrderID";
        //            myInParam1.Value = theOrderID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "theItemNumber";
        //            myInParam2.Value = theitem.itemNumber;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "thePercentDiscount";
        //            myInParam3.Value = theitem.percentDiscount;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam4 = new MySqlParameter();
        //            myInParam4.ParameterName = "thePrice";
        //            myInParam4.Value = theitem.price;
        //            myCommand.Parameters.Add(myInParam4);
        //            myInParam4.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam5 = new MySqlParameter();
        //            myInParam5.ParameterName = "theQuantity";
        //            myInParam5.Value = theitem.quantity;
        //            myCommand.Parameters.Add(myInParam5);
        //            myInParam5.Direction = System.Data.ParameterDirection.Input;
        //            recsAffected = recsAffected+myCommand.ExecuteNonQuery();
        //            }

                  
                    
        //        }

        //        return recsAffected;

        //    }
        //    catch (Exception e)
        //    {

        //        throw; //return recsAffected;

        //    }



        //}



        //public long saveOrderItemData2(string theOrderID, Array theLineItems, string theConnectStringName)

        //   //string theOrderID, string theItemNumber, string thePercentDiscount, string thePrice, string theQuantity, string theConnectStringName)
        //{
            
            
            
        //    //adds the order items  to the db
        //    string theCommand = "addOrderItem";
        //    Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

        //            foreach (String[] theitem in theLineItems)
        //            {

        //                myCommand.Parameters.Clear();
        //                //add input parameters
        //                MySqlParameter myInParam1 = new MySqlParameter();
        //                myInParam1.ParameterName = "theOrderID";
        //                myInParam1.Value = theOrderID;
        //                myCommand.Parameters.Add(myInParam1);
        //                myInParam1.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam2 = new MySqlParameter();
        //                myInParam2.ParameterName = "theItemNumber";
        //                myInParam2.Value = theitem[0];
        //                myCommand.Parameters.Add(myInParam2);
        //                myInParam2.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam3 = new MySqlParameter();
        //                myInParam3.ParameterName = "thePercentDiscount";
        //                myInParam3.Value = theitem[1];
        //                myCommand.Parameters.Add(myInParam3);
        //                myInParam3.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam4 = new MySqlParameter();
        //                myInParam4.ParameterName = "thePrice";
        //                myInParam4.Value = theitem[2];
        //                myCommand.Parameters.Add(myInParam4);
        //                myInParam4.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam5 = new MySqlParameter();
        //                myInParam5.ParameterName = "theQuantity";
        //                myInParam5.Value = theitem[3];
        //                myCommand.Parameters.Add(myInParam5);
        //                myInParam5.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam6 = new MySqlParameter();
        //                myInParam6.ParameterName = "theSalesPackageID";
        //                myInParam6.Value = theitem[4];
        //                myCommand.Parameters.Add(myInParam6);
        //                myInParam6.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam7 = new MySqlParameter();
        //                myInParam7.ParameterName = "theProductOffer";
        //                myInParam7.Value = theitem[5];
        //                myCommand.Parameters.Add(myInParam7);
        //                myInParam7.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam8 = new MySqlParameter();
        //                myInParam8.ParameterName = "theSalesPosition";
        //                myInParam8.Value = theitem[6];
        //                myCommand.Parameters.Add(myInParam8);
        //                myInParam8.Direction = System.Data.ParameterDirection.Input;
        //                //add input parameters
        //                MySqlParameter myInParam9 = new MySqlParameter();
        //                myInParam9.ParameterName = "theOfferType";
        //                myInParam9.Value = theitem[7];
        //                myCommand.Parameters.Add(myInParam9);
        //                myInParam9.Direction = System.Data.ParameterDirection.Input;


        //                recsAffected = recsAffected + myCommand.ExecuteNonQuery();
        //            }



        //        }

        //        return recsAffected;

        //    }
        //    catch (Exception e)
        //    {

        //        return recsAffected;

        //    }



        //}

   
        //public Int64 dispositionCall(string theCallDispositionID,string theCallDisposition,string theLeadID,string thePreviewCallID,string theCallBackDateTime,string theAgent,
        //    string theCampaignID,string thePhoneType,string thePhoneNumber, string theLeadName, string theConnectStringName)
        //{


        //    //updates the lead, adds a DNC record if necessary, updates and releae the preview call record so lead is available to the pool again
        //    string theCommand = "dispositonCall";
        //    Int32 recsAffected = 0;//this will hold the number of records affected by the nonQuery command
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theCallDispositionID";
        //            myInParam1.Value = theCallDispositionID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam2 = new MySqlParameter();
        //            myInParam2.ParameterName = "theCallDisposition";
        //            myInParam2.Value = theCallDisposition;
        //            myCommand.Parameters.Add(myInParam2);
        //            myInParam2.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam3 = new MySqlParameter();
        //            myInParam3.ParameterName = "theLeadID";
        //            myInParam3.Value = theLeadID;
        //            myCommand.Parameters.Add(myInParam3);
        //            myInParam3.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam4 = new MySqlParameter();
        //            myInParam4.ParameterName = "thePreviewCallID";
        //            myInParam4.Value = thePreviewCallID;
        //            myCommand.Parameters.Add(myInParam4);
        //            myInParam4.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam5 = new MySqlParameter();
        //            myInParam5.ParameterName = "theCallBackDateTime";
        //            myInParam5.Value = theCallBackDateTime;
        //            myCommand.Parameters.Add(myInParam5);
        //            myInParam5.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam6 = new MySqlParameter();
        //            myInParam6.ParameterName = "theAgent";
        //            myInParam6.Value = theAgent;
        //            myCommand.Parameters.Add(myInParam6);
        //            myInParam6.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam7 = new MySqlParameter();
        //            myInParam7.ParameterName = "theCampaignID";
        //            myInParam7.Value = theCampaignID;
        //            myCommand.Parameters.Add(myInParam7);
        //            myInParam7.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam8 = new MySqlParameter();
        //            myInParam8.ParameterName = "thePhoneType";
        //            myInParam8.Value = thePhoneType;
        //            myCommand.Parameters.Add(myInParam8);
        //            myInParam8.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam9 = new MySqlParameter();
        //            myInParam9.ParameterName = "thePhoneNumber";
        //            myInParam9.Value = thePhoneNumber;
        //            myCommand.Parameters.Add(myInParam9);
        //            myInParam9.Direction = System.Data.ParameterDirection.Input;
        //            //add input parameters
        //            MySqlParameter myInParam10 = new MySqlParameter();
        //            myInParam10.ParameterName = "theLeadName";
        //            myInParam10.Value = theLeadName;
        //            myCommand.Parameters.Add(myInParam10);
        //            myInParam10.Direction = System.Data.ParameterDirection.Input;


        //            recsAffected = myCommand.ExecuteNonQuery();
        //        }

        //        return recsAffected;

        //    }
        //    catch (Exception e)
        //    {

        //        return recsAffected;

        //    }


        //}



        //public string[] getAgentStats(string theAgentLoginID, string theConnectStringName)
        //{
        //    //getAgentStats`(in theAgentLoginID long)
        //    //returns select theLeadSales.AgentLoginID,Leads,Contacts,processattempts,processedsales,Calls,TotalTalkTime,theCalls.AgentLoginID
        //    //get agent stats to display in interface
        //    string theCommand = "getAgentStats";
        //    string[] theReturnValues = new string[6];
            
        //    try
        //    {
        //        //get the actual connection string stored in the applciation for this name
        //        string myCS = GetConnectionStringByName(theConnectStringName);

        //        // Create and open the connection in a using block. This
        //        // ensures that all resources will be closed and disposed
        //        // when the code exits. Use the connect string from above.
        //        using (MySql.Data.MySqlClient.MySqlConnection myCON = GetConnection(myCS))
        //        {
        //            myCON.Open();
        //            //string InsertTme = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            MySqlCommand myCommand = new MySqlCommand(theCommand, myCON);
        //            myCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //            //add input parameters for stored procedure
        //            MySqlParameter myInParam1 = new MySqlParameter();
        //            myInParam1.ParameterName = "theAgentLoginID";
        //            myInParam1.Value = theAgentLoginID;
        //            myCommand.Parameters.Add(myInParam1);
        //            myInParam1.Direction = System.Data.ParameterDirection.Input;
        //            //theLeadSales.AgentLoginID,Leads,Contacts,processattempts,processedsales,Calls,TotalTalkTime,theCalls.AgentLoginID
        //            MySqlDataReader myReader = myCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {   //read the return record fields into the return array:
        //                theReturnValues[0] = myReader["Leads"].ToString();
        //                theReturnValues[1] = myReader["Contacts"].ToString();
        //                theReturnValues[2] = myReader["processattempts"].ToString();
        //                theReturnValues[3] = myReader["processedsales"].ToString();
        //                theReturnValues[4] = myReader["Calls"].ToString();
        //                theReturnValues[5] = myReader["TotalTalkTime"].ToString();
                        

        //            }

                    
                   
        //            return theReturnValues;
        //        }



        //    }
        //    catch (Exception e)
        //    {

        //        throw;

        //    }

        //}



    
    
    
    }



}