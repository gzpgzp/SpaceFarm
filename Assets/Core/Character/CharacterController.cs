using System;
using UnityEngine;

namespace Core.Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterView view;
        [SerializeField] private Rigidbody2D rb;
        
        [Header("角色移动")]
        [SerializeField] private float moveSpeed = 3.5f;
        [SerializeField] private float sprintMultiplier = 1.5f;

        private Vector2 moveDir;
        private bool isSprinting = false;
        private bool isMoving => moveDir.sqrMagnitude > 0.01;

        private void Update()
        {
            HandleInput();
            view.UpdateAnimation(moveDir,isMoving,isSprinting);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void HandleInput()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            
            Vector2 inputDir = new Vector2(h, v);
            if (inputDir.magnitude > 0.1f)
            {
                inputDir.Normalize();    
            }

            moveDir = inputDir.normalized;
            
            isSprinting = Input.GetKey(KeyCode.LeftShift);
        }

        private void Move()
        {
            if (isMoving)
            {
                float finalSpeed = moveSpeed * (isSprinting ? sprintMultiplier : 1f);
                rb.velocity = moveDir * finalSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

        public void OnUseHandItem()
        {
            
        }
    }
}