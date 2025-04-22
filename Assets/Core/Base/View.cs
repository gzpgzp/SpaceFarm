using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Base
{
    public class View : MonoBehaviour
    {
        public Entity entity;

        public virtual void Init(Entity entity)
        {
            this.entity = entity;
        }
    }    
}