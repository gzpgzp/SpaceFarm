using System.Collections;
using System.Collections.Generic;
using Core.Base;
using NormalTools;
using UnityEngine;

namespace Core.Plant
{
    public class PlantView : View,IClickable
    {
        public void OnGrowthUp()
        {
            transform.localScale += Vector3.one;
        }

        public void OnClick()
        {
            Debug.Log("plant Clicked");
        }
        
    }        
}