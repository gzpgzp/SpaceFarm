using System.Collections.Generic;
using Core.Base;
using Manager;

namespace Core
{
    public class EntityManager : ManagerBase
    {
        private int entityId;
        private List<Entity> entities = new List<Entity>();

        public List<Entity> Entities => entities; // 暴露出去只读访问

        /// <summary>
        /// 创建一个Entity并注册
        /// </summary>
        public T CreateEntity<T>(string prefabPath) 
            where T : Entity, new() 
        {
            entityId++;

            var obj = GameObjectPool.Instance.CreateGameObject(prefabPath);
            if (obj == null)
            {
                return null;
            }
            
            var v = obj.GetComponent<View>();
            if (v == null)
            {
                return null;
            }
            
            var e = new T();
            e.CreateEntity(entityId, v);
            
            entities.Add(e);
            return e;
        }
    }
}