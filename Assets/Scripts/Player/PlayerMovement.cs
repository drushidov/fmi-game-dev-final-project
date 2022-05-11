using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;
    private Animator animator;
    private PlayerInputActions playerInputActions;
    public bool canMove = true;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.ClickToMove.performed += Move;
    }

    private void OnDisable()
    {
        playerInputActions.Player.ClickToMove.performed -= Move;
        playerInputActions.Disable();
    }

    void Update()
    {
        if (!agent.pathPending
            && agent.remainingDistance <= agent.stoppingDistance
            && (!agent.hasPath || agent.velocity.sqrMagnitude == 0f))
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (!canMove)
        {
            return;
        }

        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000.0f, LayerMask.GetMask("ClickToMove")))
        {
            animator.SetBool("isMoving", true);
            agent.SetDestination(hit.point);
        }
    }

    public void StopPlayerMovement()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        agent.ResetPath();
        animator.SetBool("isMoving", false);
    }

    public void ResumePlayerMovement()
    {
        agent.isStopped = false;
    }
}