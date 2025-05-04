using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Core.Character
{
    public class PredictSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private Vector3 tempVect = Vector3.one;
        private bool isWorking = false;

        private const float WorkingDis = 2.0f;

        public void SetPos(int x, int y, float dis)
        {
            tempVect.x = x + 0.5f;
            tempVect.y = y + 0.5f;
            transform.position = tempVect;

            if (!isWorking && dis < WorkingDis)
            {
                spriteRenderer.color = Color.green;
            }
            else
            {
                spriteRenderer.color = Color.red;
            }
        }
    }
}