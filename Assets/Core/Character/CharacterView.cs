using UnityEngine;

namespace Core.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Vector3 characterViewOffset;
        private Vector2 tempVect = Vector2.zero;
        
        public void UpdateAnimation(Vector2 moveDir, bool isMoving,bool isSprinting)
        {
            transform.localScale = new Vector3(moveDir.x < 0 ? 1 : -1, 1, 1);

            animator.SetFloat("MoveX", moveDir.x);
            animator.SetFloat("MoveY", moveDir.y);
            animator.SetBool("IsMoving", isMoving);
            animator.SetBool("IsSprinting", isSprinting);
        }

        public Vector2 GetCharacterViewPos()
        {
            tempVect.x = Mathf.FloorToInt(transform.position.x + characterViewOffset.x);
            tempVect.y = Mathf.FloorToInt(transform.position.y + characterViewOffset.y);
            return tempVect;
        }
    }
}