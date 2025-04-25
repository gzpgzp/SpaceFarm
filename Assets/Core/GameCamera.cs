using System;
using UnityEngine;

namespace Core
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private Transform followTarget;
        
        public void LateUpdate()
        {
            transform.position = followTarget.position + Vector3.back;
        }
    }
}