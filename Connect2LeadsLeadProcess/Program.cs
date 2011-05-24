using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Net.Mail;

namespace Connect2LeadsLeadProcess
{
    class Program
    {
        
        //database info
        private static string theConnectString = Properties.Settings.Default.theConnectString;

        //logfile path info
        private static string theLogfilePath = Properties.Settings.Default.theLogfilePath;
      
        //lead Post URL
        private static string theLeadPostURL = Properties.Settings.Default.theLeadPostURL;

        //control arguments to run each component
        private static string RunAddLeads = "1";
        //private static string RunPickUpSoundFiles = "1";
        //private static string RunLoadCSVFiles = "1";
        //private static string RunScoreLeads = "1";
        //private static string RunAddNewLeadsTPool = "1";
        //private static string RunPickupCallRecordings = "1";


        static void Main(string[] args)
        {

            if (args.Length > 0)
            {

                RunAddLeads = args[0];
                //RunPickUpSoundFiles = args[1];
                //RunLoadCSVFiles = args[2];
                //RunScoreLeads = args[3];
                //RunAddNewLeadsTPool = args[4];
                //RunPickupCallRecordings = args[5];

            }
            


            //create objects

            DataAccess.MySQLAccess theDataObject = new DataAccess.MySQLAccess();  //used to conect to database
            string exitMessage = "ok";
            Int32 theLeadsPOSTED = 0; ; //the leads POSTED



            if (RunAddLeads == "1")//add new leads to connect first
            {
                string thePostString = "";
                DataFeed thePoster = new DataFeed();
                string thePostResult="";
                string isSuccess = "";
                
                try
                {
                    //get the leads to add
                    DataSet theLeads = theDataObject.getLeadsToPost(theConnectString);
                    //post the leads to the URL
                    foreach (DataRow theRow in theLeads.Tables[0].Rows)
                    {
                        try
                        {
                            thePostString = "";
                            isSuccess = "0";
                            thePostString = "security_key=" + theRow["security_key"].ToString();
                            thePostString += "&campaign_id=" + theRow["campaign_id"].ToString();
                            thePostString += "&phone=" + theRow["phone"].ToString();
                            thePostString += "&extern_id=" + theRow["extern_id"].ToString();
                            thePostString += "&de_dupe=" + theRow["de_dupe"].ToString();
                            thePostString += "&list_name=" + theRow["list_name"].ToString();
                            thePostString += "&first_name=" + theRow["first_name"].ToString();
                            thePostString += "&middle_name=" + theRow["middle_name"].ToString();
                            thePostString += "&last_name=" + theRow["last_name"].ToString();
                            thePostString += "&address1=" + theRow["address1"].ToString();
                            thePostString += "&address2=" + theRow["address2"].ToString();
                            thePostString += "&city=" + theRow["city"].ToString();
                            thePostString += "&state=" + theRow["state"].ToString();
                            thePostString += "&zip=" + theRow["zip"].ToString();
                            thePostString += "&aux_data1=" + theRow["aux_data1"].ToString(); 
                            thePostString += "&aux_data2=" + theRow["aux_data2"].ToString(); 
                            thePostString += "&aux_data3=" + theRow["aux_data3"].ToString(); 
                            thePostString += "&aux_data4=" + theRow["aux_data4"].ToString(); 
                            thePostString += "&aux_data5=" + theRow["aux_data5"].ToString();
                            thePostString += "&email=" + theRow["email"].ToString();
                            thePostString += "&gate_keeper=" + theRow["gate_keeper"].ToString();
                            //,campaign_id,phone,extern_id,de_dupe,list_name,
                            //first_name,middle_name,last_name,address1,address2,city,
                            //state,zip,aux_data1,aux_data2,aux_data3,aux_data4,aux_data5 ,email,gate_keeper
                            thePostResult = thePoster.HttpPost(theLeadPostURL, thePostString);
                            if (thePostResult == "OK") { isSuccess = "1"; }

                            theLeadsPOSTED+=theDataObject.savePostResult(theRow["clientleadsrawID"].ToString(),thePostResult,isSuccess,theConnectString);
                        }

                        catch
                        {
                            throw;

                        }



                    }
                    //security_key,campaign_id,phone,extern_id,de_dupe,list_name,
                    //first_name,middle_name,last_name,address1,address2,city,
                    //state,zip,aux_data1,aux_data2,aux_data3,aux_data4,aux_data5 ,email,gate_keeper
                    //The HTTP service will return text based results in the following format.
                    //If the processing was successful:
                    //OK
                    //If the processing failed for any reason:
                    //FAILURE : [message] : [detail]
                    
                    
                    
                    
                    
                    //add leads in csv files that are missing from feed to main lead table
                    //theMissingLeadsAdded = theDataObject.addMissingCSVLeads(ACMGConnectString);
                    //writeToLog("Missing Leads added from CSV = " + theLeadsAdded.ToString());
                }
                catch (Exception e)
                {

                    //writeToLog("Missing Leads Add Error: " + e.Message);
                    //exitMessage = exitMessage + "Missing Leads Add Error: " + e.Message + "\n"; ;
                }


                

                
            }

            
            

            



            if (exitMessage != "ok")
            {//if there was an error send email

                //send notification email
                DataAccess.EmailAccess mailObj = new DataAccess.EmailAccess();
                string thesubject = "Connect2Lead Add Leads Error ";

                string theMessage = exitMessage;

                mailObj.sendMailMessage(thesubject, theMessage);
            }









        }


        public static void writeToLog(string theLogData)
        {


            string strLogText = theLogData;

            // Create a writer and open the file:
            StreamWriter log;

            if (!File.Exists(theLogfilePath))
            {
                log = new StreamWriter(theLogfilePath);
            }
            else
            {
                log = File.AppendText(theLogfilePath);
            }

            // Write to the file:
            log.WriteLine(DateTime.Now);
            log.WriteLine(strLogText);
            log.WriteLine();

            // Close the stream:
            log.Close();

        }


    }
}
