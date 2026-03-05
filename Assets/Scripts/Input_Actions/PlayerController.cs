using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Input_Direct
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

        void Update()
        {
            //Lue liikesyöte
            Vector2 moveInput = ReadMovementInput();

            //Käsittele hyökkäys syöte
            HandleAttack();

            //Käsittele hyppy syöte
            HandleJump();

            //Siirtää pelaajaa syötteen perusteella
            Move(moveInput);
        }

        Vector2 ReadMovementInput()
        {
            //Alusta liikesyöte nollaksi
            Vector2 moveInput = Vector2.zero;

            // GAMEPAD: Tarkista onko peliohjain kytkettynä
            if (Gamepad.current != null)
            {
                moveInput = Gamepad.current.leftStick.ReadValue();
            }

            // KEYBOARD: Jos peliohjain ei ole kytketty, tarkista onko näppäimistö käytettävissä
            if (Keyboard.current != null)
            {
                float x = 0f;
                float y = 0f;

                // Tarkista WASD-näppäimet ja päivitä liikesyötettä
                if (Keyboard.current.wKey.isPressed) y += 1;
                if (Keyboard.current.sKey.isPressed) y -= 1;
                if (Keyboard.current.aKey.isPressed) x -= 1;
                if (Keyboard.current.dKey.isPressed) x += 1;

                // Normalisoi liikesyöte, jotta diagonaaliset liikkeet eivät ole nopeampia
                if (x != 0f || y != 0f) moveInput = new Vector2(x, y).normalized;
            }

            // Palauta liikesyöte kutsujalle
            return moveInput;
        }
        void Move(Vector2 moveInput)
        {
            // Onko pelaaja maassa JA silti vielä putoamassa?
            if (characterController.isGrounded && verticalVelocity < 0f)
            {
                // hahmo pysyy maassa, ei leiju tai tärise
                verticalVelocity = -2f;
            }
            // Lisää painovoiman vaikutuksen nopeuteen. kaavana v = gravity * t
            verticalVelocity += gravity * Time.deltaTime;

            // Laske pelaajan liikesuunta
            Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y;

            // Laske pelaajan liikenopeus
            Vector3 velocity = direction * moveSpeed + Vector3.up * verticalVelocity;

            // Siirrä pelihahmoa CharacterControllerin avulla
            characterController.Move(velocity * Time.deltaTime);
        }

        void HandleAttack()
        {
            // GAMEPAD: Tarkista onko peliohjain kytkettynä
            if (Gamepad.current == null)
                return;
            // KEYBOARD: Jos peliohjain ei ole kytketty, tarkista onko näppäimistö käytettävissä
            if (Keyboard.current == null)
                return;
            // Tarkista onko x painettu
            if (Keyboard.current.xKey.wasPressedThisFrame)
            {
                Debug.Log("Hyökkäys aktivoitu");
            }
            // Tarkista onko peliohjaimen oikeaa liipaisinta painettu
            if (Gamepad.current.rightTrigger.wasPressedThisFrame)
            {
                Debug.Log("Hyökkäys aktivoitu");
            }
        }

        void HandleJump()
        {
            if (Gamepad.current == null) return;
            if (Keyboard.current == null) return;
            // Tarkista onko space painettu
            if (Keyboard.current.spaceKey.wasPressedThisFrame && characterController.isGrounded)
            {
                verticalVelocity = 5f; // Aseta hyppyvoima
            }
            if (Gamepad.current.buttonSouth.wasPressedThisFrame && characterController.isGrounded)
            {
                verticalVelocity = 5f; // Aseta hyppyvoima
            }
        }
    }
}