using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class View : MonoBehaviour
    {
        public Entity entity;

        public void Init(Entity entity)
        {
            this.entity = entity;
        }
    }    
}