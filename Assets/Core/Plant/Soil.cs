using NormalTools;
using Tools;
using UnityEngine;

namespace Core.Plant
{
    public struct SoilClickEvent
    {
        public Soil soil;
        public bool isPlanted;

        public SoilClickEvent(Soil soil,bool isPlanted)
        {
            this.soil = soil;
            this.isPlanted = false;
        }

        static SoilClickEvent e;

        public static void Trigger(Soil soil,bool isPlanted = false)
        {
            e.soil = soil;
            e.isPlanted = isPlanted;
            MMEventManager.TriggerEvent(e);
        }
    }

    public class Soil : MonoBehaviour,IClickable
    {
        private bool isPlanted = false;
        
        public void OnClick()
        {
            Debug.Log("Soil.onclick");
            SoilClickEvent.Trigger(this,isPlanted);
        }

        public void Planting(Plant plant)
        {
            isPlanted = true;
            plant.transform.SetParent(transform);
            plant.transform.localPosition = Vector3.zero;
        }
    }
}