using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAutomationFramework.Base
{
    public abstract class BaseStep : Base
    {

        public virtual void NavigateSite()
        {
            //DriverContext.Browser.GoToUrl(Settings.AUT);
            //LogHelpers.Write("Opened the browser !!!");
        }
    }
}
