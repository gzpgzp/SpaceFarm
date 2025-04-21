using System.Collections.Generic;
using Core.Base;

namespace Core
{
    public class EntityManager : ManagerBase
    {
        private int entityId;
        private List<Entity> entities = new List<Entity>();
        
        public void CreateEntity<T>() where T : Entity,new()
        {
            entityId++;
            
            
            var e = new T();
        }
    }
}