using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAddToGui
{
    [System.ComponentModel.DesignerCategory("")]
    public class PictureConverter : System.Windows.Forms.AxHost
    {
    public PictureConverter() : base("59EE46BA-677D-4d20-BF10-8D8067CB8B32")
        {
        }

    public static stdole.IPictureDisp ImageToPictureDisp(System.Drawing.Image image)
        {
            return (stdole.IPictureDisp)(GetIPictureDispFromPicture(image));
        }
    }
}
