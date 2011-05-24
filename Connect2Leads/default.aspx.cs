using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Data;

namespace Connect2Leads
{
    public partial class _Default : System.Web.UI.Page
    {

        //logfile path info
        private static string theLogfilePath = Properties.Settings.Default.theLogfilePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["theAccounts"] == null)
            { return; }//not logged in }
            XmlDocument doc = new XmlDocument();
            doc = (XmlDocument)Session["theAccounts"];

            DataSet ds = new DataSet();
            ds.ReadXml(new XmlNodeReader(doc));
            



            GridView1.DataSource = ds;
            GridView1.DataBind();

           

        }

        protected void ButtonUploadFile_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    FileUpload1.SaveAs("C:\\Connect2LeadsUploads\\" + FileUpload1.FileName);
                    Label1.Text += "<br>Successfully Uploaded File name: " + FileUpload1.PostedFile.FileName + "<br>" +
                        FileUpload1.PostedFile.ContentLength + "kb<br>" +
                        "Content Type: " + FileUpload1.PostedFile.ContentType + "<br><hr><br>" ;
                    writeToLog(FileUpload1.PostedFile.FileName);
                    sendEmail(FileUpload1.PostedFile.FileName,"FileUpload");
                }
                catch (Exception ex)
                {
                    Label1.Text += "ERROR: " + ex.Message.ToString() + "<br><hr><br>";
                    writeToLog("ERROR: " + ex.Message.ToString() + "<br><hr><br>");
                    sendEmail("ERROR: " + ex.Message.ToString(), "File Upload Error");
                }
            else
            {
                Label1.Text += "You Have Not Specified a File!" + "<br><hr><br>";
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