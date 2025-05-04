using UnityEngine;

namespace Core.Character
{
    public class PlayerInput : CharacterInput
    {
        public override bool IsSprinting()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        public override Vector2 GetMovementInput()
        {
            movementInput.x = Input.GetAxis("Horizontal");
            movementInput.y = Input.GetAxis("Vertical");

            return movementInput;
        }
    }
}