using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAutomationFramework.Config.json
{
    /// <summary>
    /// Class Designed to Read JSON.Config present at Project Root dir
    /// </summary>
    class JsonConfigReader
    {

        public static void SetFrameworkSettings(TestEnvironment env)
        {
           Env testEnvironment = getEnvDetails(env);
            string baseUrl = testEnvironment.BaseUrl;
            string username = testEnvironment.Username;
            string password = testEnvironment.Password;
        }



        /// <summary>
        /// Data model to represent JSON Config
        /// </summary>
        public class Env
        {
            public string EnvName { get; set; }
            public string BaseUrl { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }



        /// <summary>
        /// Method to fetch Environment details based on Environment name  
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static Env getEnvDetails(TestEnvironment name)
        {
            Env testEnv = null;
            
            //Get config directory
            string projectPath = Environment.CurrentDirectory + @"\..\..\Config\json\";
            string configFilePath = projectPath + "Config.json";
            List<Env> Environments = LoadJsonConfig(configFilePath);

            foreach (Env environment in Environments)
            {
                if (name.ToString().ToLower().Equals(environment.EnvName.ToLower()))
                {
                    testEnv = environment;
                }
            }
            return testEnv;

        }

        /// <summary>
        /// Method to read config.json file and deserialize the same to Env class 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>

        static List<Env> LoadJsonConfig(string filename)
        {
            List<Env> Envs = null;
            if (File.Exists(filename))
            {
                using (StreamReader r = new StreamReader(filename))
                {
                    string json = r.ReadToEnd();
                    Envs = JsonConvert.DeserializeObject<List<Env>>(json);
                }

            }
            return Envs;
        }



        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Reading Properties");

        //    Env testEnv = getEnvDetails(TestEnvironment.Exp);
        //    Console.WriteLine("Environment details : {0}", testEnv.BaseUrl);
        //    Console.WriteLine(" \nUsername is {0}", testEnv.Username);

        //    Console.WriteLine("Using Test Context : {0} ", TestContext.CurrentContext.TestDirectory);
        //    Console.WriteLine("Current Directory : {0}", Directory.GetCurrentDirectory());
        //    Console.WriteLine("Current Directory : {0}", System.AppDomain.CurrentDomain.BaseDirectory);


        //    Console.ReadLine();


        //}

    }
}
