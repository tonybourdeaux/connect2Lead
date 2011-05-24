using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;



namespace Connect2LeadsLeadProcess
{
    class DataFeed
    {
        //logfile path info
        private static string theLogfilePath = Properties.Settings.Default.theLogfilePath;
        public string HttpPost(string uri, string parameters)
        {
            // parameters: name1=value1&name2=value2	
            WebRequest webRequest = WebRequest.Create(uri);
            //string ProxyString = 
            //   System.Configuration.ConfigurationManager.AppSettings
            //   [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            try
            { // send the Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message, "HttpPost: Request error",
                //   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
               // MessageBox.Show(ex.Message, "HttpPost: Response error",
                 //  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        } // end HttpPost 





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
        public static void sendEmail(string theMailMessage, string theSubject)
        {

            //send notification email
            DataAccess.EmailAccess mailObj = new DataAccess.EmailAccess();
            string thesubject = theSubject;
            string theMessage = theMailMessage;

            mailObj.sendMailMessage(thesubject, theMessage);
        }

    }
}
