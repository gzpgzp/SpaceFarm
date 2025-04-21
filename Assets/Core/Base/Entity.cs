using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Base
{
    public class Entity
    {
        public int id { get; private set; }
        public View view { get; private set; }

        public void CreateEntity(int id,View view)
        {
            this.id = id;
            this.view = view;
        }
    }    
}