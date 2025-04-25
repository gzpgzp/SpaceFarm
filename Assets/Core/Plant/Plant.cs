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
            
        }
    }
}