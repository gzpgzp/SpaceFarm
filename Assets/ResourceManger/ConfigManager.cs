using System.Collections.Generic;
using System.IO;
using Tools;

namespace ResourceManger
{
    public class ConfigManager : Singleton<ConfigManager> 
    {
        public Dictionary<int,int> configs = new Dictionary<int,int>();
    }
}
