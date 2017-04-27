using CoreAutomationFramework.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CoreAutomationFramework.Config
{
    public class ConfigReader
    {

        public static void SetFrameworkSettings()
        {

            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logPath;
            XPathItem appConnection;
            XPathItem browsertype;

            string strFilename = Environment.CurrentDirectory + @"\..\..\Config\GlobalConfig.xml";
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/LogPath");
            appConnection = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/ApplicationDb");
            browsertype = navigator.SelectSingleNode("CoreAutomationFramework/RunSettings/Browser");

            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();
            Settings.AppConnectionString = appConnection.Value.ToString();
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), browsertype.Value.ToString());


        }

    }
}
