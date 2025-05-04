using NormalTools;
using UnityEngine;

namespace Core.Plant
{
    public class Plant : MonoBehaviour,IClickable
    {
        private PlantEntity entity;
        
        public void BindEntity(PlantEntity entity)
        {
            this.entity = entity;
        }

        public void OnClick()
        {
            Debug.Log("plant clicked");
        }

        public void OnHarvested()
        {
            Debug.Log($"plant harvested");
        }
    }
}