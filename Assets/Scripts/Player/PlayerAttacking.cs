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
    private Camera mainCamera;
    private float attackCameraAngleCorrection = -40.0f;

    public bool canAttack = true;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
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

        LookAtAttackPoint();

        // Play attack animation
        animator.SetTrigger("attack");
    }

    void LookAtAttackPoint()
    {
        // Look at point of contact, if available
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000.0f, LayerMask.GetMask("ClickToMove", "Enemy", "Environment")))
        {
            transform.LookAt(hit.point);
            return;
        }

        // If nothing is hit by the ray, do a calculation for the look rotation
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Vector3.Distance(transform.position, Camera.main.transform.position);

        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        float angle = AngleBetweenPoints(mousePos, playerPos);
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + attackCameraAngleCorrection, 0));
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
