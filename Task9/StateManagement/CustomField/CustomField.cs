using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomField
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomField runat=server></{0}:CustomField>")]
    public class CustomField : TextBox
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Enter your text")]
        [Localizable(true)]
        public override string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            Page.RegisterRequiresControlState(this);
            base.OnInit(e);
        }

        protected override object SaveControlState()
        {
            object _obj = base.SaveControlState();
            if (_obj is CustomField)
            {
                CustomField _field = (CustomField)_obj;
                return _field.Text;
            }
            else
            {
                return null;
            }
        }

        protected override void LoadControlState(object savedState)
        {
            base.LoadControlState(savedState);
            if (savedState != null)
            {
                if (savedState is CustomField)
                {
                    CustomField _field = (CustomField)savedState;
                }


            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
}
