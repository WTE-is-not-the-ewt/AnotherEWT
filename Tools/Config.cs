using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnotherEWT.Tools
{
    public class Configs
    {
        public static Configs current;
        public string savedCookie;
        public string infoGetUrl;
        public string configFileSavePath = "\\Configs\\config.json";
    }

    public class ConfigReader
    {
        private static bool IsFirstStartupChecked = false;
        private static bool IsFirstStartup = true;
        public bool FirstStartup()
        {
            if(!IsFirstStartupChecked)
            {
                if (File.Exists("\\Configs\\config.json"))
                    IsFirstStartup = false;
                else IsFirstStartup = true;
            }
            
            IsFirstStartupChecked =true;
            return IsFirstStartup;
            
        }

        public void InitConfigs()
        {
            Configs configs;
            if(FirstStartup())
            {
                configs = new Configs();
                configs.configFileSavePath = "\\Configs\\config.json";
                configs.infoGetUrl = "https://raw.githubusercontent.com/WTE-is-not-the-ewt/AnotherEWT/master/Update/Info.json";
            }
            else
            {
                string configjson = File.ReadAllText("\\Configs\\config.json");
                configs = JsonSerializer.Deserialize<Configs>(configjson);
            }
            Configs.current = configs;

        }
    }

    public class ConfigSaver
    {
        public void SaveConfig()
        {
            string text = JsonSerializer.Serialize<Configs>(Configs.current);
            File.WriteAllText(Configs.current.configFileSavePath, text);
        }
    }

}
