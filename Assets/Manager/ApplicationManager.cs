using MoreMountains.Tools;
using NormalTools;
using ResourceManger;
using UnityEngine;

namespace Manager
{
    public class ApplicationManager : MMSingleton<ApplicationManager>
    {
        [SerializeField] private TouchHelper touchHelper;
        protected override void Awake()
        {
            base.Awake();
            Debug.Log("Init");
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
            touchHelper.Init(CameraManager.Instance.GetCamera(CameraType.Main),ClickObject);
        }
        
        private void ClickObject(GameObject obj)
        {
            var clickable = obj.GetComponent<IClickable>();
            if (clickable != null)
            {
                clickable.OnClick();
            }
        }
    }
}
