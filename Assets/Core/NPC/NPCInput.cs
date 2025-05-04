using UnityEngine;

namespace Core.NPC
{
    public class NPCInput : CharacterInput
    {
        public override bool IsSprinting()
        {
            return false;
        }

        public override Vector2 GetMovementInput()
        {
            return movementInput;
        }
    }
}