using System;
using UnityEngine;

namespace NormalTools
{
    public class TouchHelper : MonoBehaviour
    {
        private Camera targetCamera;
        private Action<GameObject> touchAction;
        [SerializeField] private LayerMask ignoreLayerMask = ~0;
        [SerializeField] private string requiredTag = null;

        // ignoreLayer 忽视的层级，tagFilter直选中该tag，null为全部
        public void Init(Camera camera,Action<GameObject> action)
        {
            targetCamera = camera;
            touchAction = action;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, ignoreLayerMask);

                if (hit.collider != null)
                {
                    var hitObject = hit.collider.gameObject;

                    if (string.IsNullOrEmpty(requiredTag) || hitObject.CompareTag(requiredTag))
                    {
                        OnClickObject(hitObject);
                    }
                }
            }
        }

        private void OnClickObject(GameObject hitObject)
        {
            touchAction?.Invoke(hitObject);
        }
    }
}