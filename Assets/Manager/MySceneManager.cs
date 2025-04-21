using System;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class MySceneManager : MMSingleton<MySceneManager>
    {
        public void LoadScene(string sceneName,Action completeCallBack = null)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).completed += operation =>
            {
                completeCallBack?.Invoke();
            };
        }
    }
}