using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace NormalTools
{
    public class GlobalTimer : MonoBehaviour
    {
        private static GlobalTimer instance;

        public static GlobalTimer Instance
        {
            get
            {
                if (instance == null)
                {
                    var go = new GameObject("GlobalTimer");
                    DontDestroyOnLoad(go);
                    instance = go.AddComponent<GlobalTimer>();
                }

                return instance;
            }
        }

        private class ListenerInfo
        {
            public Action action;
            public float interval; // 每隔几秒触发
            public float elapsedTime; // 当前累计时间
        }

        private List<ListenerInfo> listeners = new List<ListenerInfo>();

        private CancellationTokenSource cts;
        private bool isRunning = false;
        private bool isPaused = false;
        private const float tickStep = 0.1f; // 每0.1秒检查一次，不用每帧

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void StartTimer()
        {
            if (isRunning) return;

            isRunning = true;
            isPaused = false;
            cts = new CancellationTokenSource();
            TimerLoopAsync(cts.Token).Forget();
        }

        public void PauseTimer()
        {
            if (!isRunning || isPaused) return;

            isPaused = true;
            isRunning = false;

            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }

        public void ResumeTimer()
        {
            if (!isPaused) return;

            isPaused = false;
            isRunning = true;

            cts = new CancellationTokenSource();
            TimerLoopAsync(cts.Token).Forget();
        }

        public void StopTimer()
        {
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }

            isRunning = false;
            isPaused = false;
            listeners.Clear();
        }

        /// <summary>
        /// 添加一个监听器，指定多少秒回调一次
        /// </summary>
        public void AddListener(Action action, float intervalSeconds)
        {
            if (action == null) return;

            listeners.Add(new ListenerInfo
            {
                action = action,
                interval = Mathf.Max(0.01f, intervalSeconds), // 最小0.01s
                elapsedTime = 0f
            });
        }

        public void RemoveListener(Action action)
        {
            listeners.RemoveAll(info => info.action == action);
        }

        private async UniTaskVoid TimerLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                float delta = tickStep;

                for (int i = 0; i < listeners.Count; i++)
                {
                    var info = listeners[i];
                    info.elapsedTime += delta;

                    if (info.elapsedTime >= info.interval)
                    {
                        try
                        {
                            info.action?.Invoke();
                        }
                        catch (Exception ex)
                        {
                            Debug.LogError($"GlobalTimer listener error: {ex}");
                        }

                        info.elapsedTime = 0f; // 重置
                    }
                }

                await UniTask.Delay(TimeSpan.FromSeconds(tickStep), cancellationToken: token);
            }
        }

        private void OnDestroy()
        {
            StopTimer();
        }
    }
}
