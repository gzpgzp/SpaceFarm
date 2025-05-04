using NormalTools;
using UnityEngine;

namespace Core
{
    public class GameWorld : MonoBehaviour
    {
        private WorldSimulator worldSimulator;

        public void Start()
        {
            Init();
        }

        public void Init()
        {
            worldSimulator =  new WorldSimulator();
        
            var worldContext = new WorldContext()
            {
                day = 1,
                time = 0,
            };
            worldSimulator.InitWorld(worldContext);
            
            StartGameWorld();
        }

        public void StartGameWorld()
        {
            GlobalTimer.Instance.AddListener(worldSimulator.Update,1);
            GlobalTimer.Instance.StartTimer();
        }

        public void StopGameWorld()
        {
            GlobalTimer.Instance.RemoveListener(worldSimulator.Update);
        }
    } 
}
