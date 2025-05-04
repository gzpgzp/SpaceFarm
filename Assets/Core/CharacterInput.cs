using UnityEngine;

namespace Core
{
    public abstract class CharacterInput
    {
        protected Vector2 movementInput = Vector2.zero;
        public abstract bool IsSprinting();
        public abstract Vector2 GetMovementInput();
    }
}