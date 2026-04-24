using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Character mage;
    [SerializeField] private Character warrior;

    [SerializeField] private InputAction mageAttackAction;
    [SerializeField] private InputAction warriorAttackAction;

    private void OnEnable()
    {
        mageAttackAction.Enable();
        warriorAttackAction.Enable();
    }

    private void OnDisable()
    {
        mageAttackAction.Disable();
        warriorAttackAction.Disable();
    }

    private void Update()
    {
        if (mageAttackAction.WasPressedThisFrame())
        {
            mage.Attack();
            warrior.TakeDamage(15);
        }

        if (warriorAttackAction.WasPressedThisFrame())
        {
            warrior.Attack();
            mage.TakeDamage(20);
        }
    }
}