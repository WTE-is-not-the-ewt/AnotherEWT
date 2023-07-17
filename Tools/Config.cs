using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AnotherEWT.Tools
{
    public class Configs
    {
        [Newtonsoft.Json.JsonIgnore]
        public static Configs current;

        public Configs()
        {
        }

        public Configs(string infoGetUrl, string configFileSavePath, TimeSpan versionCheckTime, TimeSpan cookieRefreshTime)
        {
            this.infoGetUrl = infoGetUrl;
            this.configFileSavePath = configFileSavePath;
            VersionCheckTime = versionCheckTime;
            CookieRefreshTime = cookieRefreshTime;
            LastCheckedTime = DateTime.Now;
            LastCookieRefreshTime = DateTime.Now;
        }

        public string savedCookie { get; set; }
        public string infoGetUrl { get; set; } = "https://raw.githubusercontent.com/WTE-is-not-the-ewt/AnotherEWT/master/Update/Info.json";
        public string configFileSavePath { get; set; } = FileSystem.AppDataDirectory ;
        public DateTime LastCheckedTime { get; set; }
        public DateTime LastCookieRefreshTime { get; set; }
        public TimeSpan VersionCheckTime { get; set; }
        public TimeSpan CookieRefreshTime { get; set; }
        public Exception Lasterror { get; set; }

        public bool ShouldCheckVersion()
        {
            if(DateTime.Now - LastCheckedTime > VersionCheckTime)
                return true;
            return false;
        }

        public bool ShouldRefreshCookie()
        {
            if(DateTime.Now - LastCookieRefreshTime > CookieRefreshTime) 
                return true;
            return false;
        }
    }

    public class ConfigReader
    {
        public static Configs DefaultConfig = new Configs("https://raw.githubusercontent.com/WTE-is-not-the-ewt/AnotherEWT/master/Update/Info.json", FileSystem.AppDataDirectory,TimeSpan.FromHours(6),TimeSpan.FromHours(12));
        private static bool IsFirstStartupChecked = false;
        private static bool IsFirstStartup = true;
        public static bool FirstStartup()
        {
            if (!IsFirstStartupChecked)
            {
                if (File.Exists(FileSystem.AppDataDirectory + "\\Configs\\config.json"))
                    IsFirstStartup = false;
                else IsFirstStartup = true;
                IsFirstStartupChecked = true;
            }
            return IsFirstStartup;

        }

        public void InitConfigs()
        {
            Configs configs;
            if (FirstStartup())
            {
                configs = DefaultConfig;
            }
            else
            {
                try
                {
                    string configjson = File.ReadAllText(FileSystem.AppDataDirectory + "\\Configs\\config.json");
                    configs = JsonConvert.DeserializeObject<Configs>(configjson);
                }
                catch (Exception e)
                {
                    IsFirstStartupChecked = IsFirstStartup = false;
                    InitConfigs(e);
                    return;
                }
                
            }
            Configs.current = configs;
        }

        public void InitConfigs(Exception ex)
        {
            Configs.current = DefaultConfig;
        }

    }
    public class ConfigSaver
    {
        public void SaveConfig()
        {
            string text = JsonConvert.SerializeObject(Configs.current);
            if (ConfigReader.FirstStartup())
            {
                Directory.CreateDirectory(Configs.current.configFileSavePath + "\\Configs\\");
                File.Create(Configs.current.configFileSavePath + "\\Configs\\config.json").Close();
            }
            File.WriteAllText(Configs.current.configFileSavePath + "\\Configs\\config.json", text);
        }
    }
}

