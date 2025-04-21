using MoreMountains.Tools;
using ResourceManger;
using UnityEngine;

namespace Manager
{
    public class ApplicationManager : MMSingleton<ApplicationManager>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            AppLaunch();
        }

        private void AppLaunch()
        {
            ResourcesManager.Instance.Init();
            AudioManager.Instance.Init();
            
            //通用管理类
            DialogManager.Instance.Init();
            EffectManager.Instance.Init();
        }
    }
}
