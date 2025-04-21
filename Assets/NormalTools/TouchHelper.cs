using System;
using UnityEngine;

namespace NormalTools
{
    public class TouchHelper : MonoBehaviour
    {
        private Camera targetCamera;
        private Action<GameObject> touchAction;
        private LayerMask ignoreLayerMask = ~0;
        private string requiredTag = null;

        // ignoreLayer 忽视的层级，tagFilter直选中该tag，null为全部
        public void Init(Camera camera,Action<GameObject> action,LayerMask ignoreLayer = default, string tagFilter = null)
        {
            targetCamera = camera;
            touchAction = action;
            ignoreLayerMask = ~ignoreLayer;
            requiredTag = tagFilter;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = targetCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ignoreLayerMask))
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