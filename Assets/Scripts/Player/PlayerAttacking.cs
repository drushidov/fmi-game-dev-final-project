using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerAttacking : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private NavMeshAgent agent;
    private Animator animator;
    private float attackCameraAngleCorrection = -40.0f;

    public bool canAttack = true;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.Attack.performed += Attack;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Attack.performed -= Attack;
        playerInputActions.Disable();
    }

    void Attack(InputAction.CallbackContext context)
    {
        if (!canAttack)
        {
            return;
        }

        // Look at mouse position
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Vector3.Distance(transform.position, Camera.main.transform.position);

        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        float angle = AngleBetweenPoints(mousePos, playerPos);
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + attackCameraAngleCorrection, 0));

        // Play attack animation
        animator.SetTrigger("attack");
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
