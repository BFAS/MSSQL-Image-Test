using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace MSSQLImageTest.Web.UserControls
{
    public partial class UcFileUpload : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DataFile> dataFiles = DataFile.SelectDataFileList();

            foreach (var dataFile in dataFiles)
            {
                Image image = new Image();

                byte[] imgArray = dataFile.Data;
                image.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imgArray);

                plcDataFiles.Controls.Add(image);
                
                LiteralControl literalControl = new LiteralControl("<br />");
                plcDataFiles.Controls.Add(literalControl);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}