using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Connect2Leads
{
    



    public partial class UploadImageWithAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //System.Threading.Thread.Sleep(3000);
        //    //FileUpload1.SaveAs(Server.MapPath("~/" + FileUpload1.FileName));
        //    FileUpload1.SaveAs("C:\\Connect2LeadsUploads\\" + FileUpload1.FileName);
        //    Label1.Text += "<br>Successfully Uploaded File name: " + FileUpload1.PostedFile.FileName + "<br>" +
        //                FileUpload1.PostedFile.ContentLength + "kb<br>" +
        //                "Content Type: " + FileUpload1.PostedFile.ContentType + "<br><hr><br>";
        //}



        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            if (FileUpload1.HasFile)
                try
                {
                    
                    FileUpload1.SaveAs("C:\\Connect2LeadsUploads\\" + FileUpload1.FileName);
                    Label1.Text += "<br>Successfully Uploaded File name: " + FileUpload1.PostedFile.FileName + "<br>" +
                        FileUpload1.PostedFile.ContentLength + "kb<br>" +
                        "Content Type: " + FileUpload1.PostedFile.ContentType + "<br><hr><br>";
                    //writeToLog(FileUpload1.PostedFile.FileName);
                    //sendEmail(FileUpload1.PostedFile.FileName, "FileUpload");
                }
                catch (Exception ex)
                {
                    Label1.Text += "ERROR: " + ex.Message.ToString() + "<br><hr><br>";
                    //writeToLog("ERROR: " + ex.Message.ToString() + "<br><hr><br>");
                    //sendEmail("ERROR: " + ex.Message.ToString(), "File Upload Error");
                }
            else
            {
                Label1.Text += "You Have Not Specified a File!" + "<br><hr><br>";
            }
        }
    }





}