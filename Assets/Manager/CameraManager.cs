using MoreMountains.Tools;
using UnityEngine;

namespace Manager
{
    public enum CameraType
    {
        Main,
        UI
    }

    public class CameraManager : MMSingleton<CameraManager>
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Camera uiCamera;


        public Camera GetCamera(CameraType cameraType)
        {
            switch (cameraType)
            {
                case CameraType.Main:
                    return mainCamera;
                case CameraType.UI:
                    return uiCamera;
            }

            return mainCamera;
        }
    }
}