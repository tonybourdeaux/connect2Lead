using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class fileUpload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddImage_Click(object sender, EventArgs e)
    {
        if (ImageFile.HasFile)  //if file uploaded
        {
            if (checkFileType(ImageFile.FileName))  //Check for file types
            {
                try
                {
                    //save file
                    ImageFile.SaveAs(MapPath("~/UploadImages/" + ImageFile.FileName));
                    //Response.Write("<script language =Javascript> alert('File Uploaded Successfully, Click Show Images');</script>");
                    System.Threading.Thread.Sleep(8000);
                    Label1.Text = "Upload successfull!";
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    createDir();
                }
            }
        }
        else
        {
            Response.Write("<script language =Javascript> alert('Invalid File Format, choose .gif,.png..jpg.jpeg');</script>");
        }
    }
    private bool checkFileType(string fileName)
    {
        string fileExt = Path.GetExtension(ImageFile.FileName);

        switch (fileExt.ToLower())
        {
            case ".gif":
                return true;
            case ".png":
                return true;
            case ".jpg":
                return true;
            case ".jpeg":
                return true;
            default:
                return false;
        }

    }
    private void createDir()
    {
        DirectoryInfo myDir = new DirectoryInfo(MapPath("~/UploadImages/"));
        myDir.Create();

        //Now save file
        ImageFile.SaveAs(MapPath("~/UploadImages/" + ImageFile.FileName));
        Response.Write("<script language =Javascript> alert('File Uploaded Successfully,Click Show Images');</script>");
    }
    protected void btnShowImage_Click(object sender, EventArgs e)
    {
        DirectoryInfo myDir = new DirectoryInfo(MapPath("~/UploadImages/"));
        try
        {

            dlImageList.DataSource = myDir.GetFiles();
            dlImageList.DataBind();

        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Response.Write("<script language =Javascript> alert('Upload File(s) First!');</script>");
        }
    }

}