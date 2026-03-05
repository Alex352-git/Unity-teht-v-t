using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private float gravity = -9.81f;
        private float verticalVelocity;

        private CharacterController characterController;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            HandleAttack();

            // lue liikesyöte
            Vector2 moveInput = ReadMovementInput();

            HandleJump();
            Move(moveInput);

        }

        private void Move(Vector2 moveInput)
        {
            if (characterController.isGrounded && verticalVelocity < 0f)
            {
                verticalVelocity = -2f;
            }
            verticalVelocity += gravity * Time.deltaTime;
            Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y;

            Vector3 velocity = direction * moveSpeed + Vector3.up * verticalVelocity;

            characterController.Move(velocity * Time.deltaTime);

        }

        Vector2 ReadMovementInput()
        {
            Vector2 moveInput = Vector2.zero;

            // GAMEPAD
            if (Gamepad.current != null)
            {
                moveInput = Gamepad.current.leftStick.ReadValue();
            }
            // KEYBOARD (WASD)
            else if (Keyboard.current != null)
            {
                float x = 0f;
                float y = 0f;

                if (Keyboard.current.aKey.isPressed) x -= 1f;
                if (Keyboard.current.dKey.isPressed) x += 1f;
                if (Keyboard.current.wKey.isPressed) y += 1f;
                if (Keyboard.current.sKey.isPressed) y -= 1f;

                if (x != 0f || y != 0f) moveInput = new Vector2(x, y).normalized;
            }

            return moveInput;
        }

        void HandleAttack()
        {
            // GAMEPAD ATTACK
            if (Gamepad.current != null &&
                Gamepad.current.rightTrigger.wasPressedThisFrame)
            {
                Debug.Log("Hyökkäys (Gamepad)");
            }

            // KEYBOARD ATTACK (esim. ´leftclick)
           if (Mouse.current != null &&
                Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("Hyökkäys (Keyboard)");
            }
        }
        void HandleJump()
        {
            if (Gamepad.current == null) return;

            if (Gamepad.current.buttonSouth.wasPressedThisFrame && characterController.isGrounded)
            {
                verticalVelocity = 5f;

            }
            if (Keyboard.current == null) return;

           if (Keyboard.current.spaceKey.wasPressedThisFrame && characterController.isGrounded)
            {
                verticalVelocity = 5f;

            }
        }
    }
}
