using System;
using ResourceManger;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Character
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private CharacterView characterView;
        private PredictSlot predictSlot;
        private float cellSize = 1.0f;

        public void Start()
        {
            var obj = ResourcesManager.Instance.LoadAndInstantiate("Prefabs/PredictSlot/PredictSlot");
            predictSlot = obj.GetComponent<PredictSlot>();
        }

        public void Update()
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int cursorX = Mathf.FloorToInt(cursorPos.x);
            int cursorY = Mathf.FloorToInt(cursorPos.y);
            
            var dis = CalculateDis(cursorX,cursorY);
            
            predictSlot.SetPos(cursorX, cursorY,dis);
        }

        public void Init(CharacterView characterView)
        {
            this.characterView = characterView;
        }

        private float CalculateDis(int cursorX, int cursorY)
        {
            var characterPos = characterView.transform.position;
            var xDis = characterPos.x - cursorX;
            var yDis = characterPos.y - cursorY;
            var dis = Mathf.Sqrt(xDis*xDis+yDis*yDis);
            return dis;
        }
    }
}