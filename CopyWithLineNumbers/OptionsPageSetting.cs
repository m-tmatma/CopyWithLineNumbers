using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyWithLineNumbers
{
    [Guid("132F024B-4DC7-4B3B-9ABB-6EB1DED269A1")]
    public class OptionsPageSetting : DialogPage
    {
        private OptionsControl optionsControl;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                if (optionsControl == null)
                {
                    optionsControl = new OptionsControl();
                    optionsControl.Location = new Point(0, 0);
                    optionsControl.OptionsPage = this;
                }
                return optionsControl;
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (optionsControl != null)
                {
                    optionsControl.Dispose();
                    optionsControl = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
