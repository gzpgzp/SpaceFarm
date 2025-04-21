using System.Collections.Generic;
using MoreMountains.Tools;
using ResourceManger;
using UnityEngine;

namespace Manager
{
    public class DialogManager : MMSingleton<DialogManager>
    {
        [SerializeField] private Canvas dialog;
        [SerializeField] private Canvas worldUI;

        public Canvas Dialog => dialog;
        public Canvas WorldUI => worldUI;
        public Transform DialogTransform => dialog.transform;
        public Transform WorldUITransform => worldUI.transform;
        
        public void Init()
        {
            
        }

        public void Show<T>()
        {
            
        }

        public void ShowDialog(string dialogPath)
        {
            ResourcesManager.Instance.LoadAndInstantiate(dialogPath,DialogTransform);
        }
    }
}
