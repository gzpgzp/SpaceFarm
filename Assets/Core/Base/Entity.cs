using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Base
{
    public class Entity
    {
        public int id { get; protected set; }
        public View view { get; protected  set; }
        
        
        public virtual void CreateEntity(int id,View view)
        {
            this.id = id;
            this.view = view;
        }
    }    
}