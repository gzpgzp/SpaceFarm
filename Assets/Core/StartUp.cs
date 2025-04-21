using System.Collections;
using System.Collections.Generic;
using NormalTools;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    [SerializeField] private TouchHelper touchHelper;
    [SerializeField] private Camera mainCamera;
    
    public void Start()
    {
        touchHelper.Init(mainCamera,ClickObject);
    }

    private void ClickObject(GameObject obj)
    {
        var clickable = obj.GetComponent<IClickable>();
        if (clickable != null)
        {
            clickable.OnClick();
        }
    }
}
