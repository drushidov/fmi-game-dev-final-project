using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;
    private Animator animator;
    private PlayerInputActions playerInputActions;

    private Coroutine moveCoroutine;
    private float clickHoldTime;
    private float clickHoldDelay = 0.1f;

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
        playerInputActions.Player.ClickToMove.performed += OnMoveStarted;
        playerInputActions.Player.ClickToMove.canceled += OnMoveCanceled;
    }

    private void OnDisable() {
        playerInputActions.Player.ClickToMove.performed -= OnMoveStarted;
        playerInputActions.Player.ClickToMove.canceled -= OnMoveCanceled;
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

    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        clickHoldTime = 0f;
        moveCoroutine = StartCoroutine(Move());
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        if (clickHoldTime >= clickHoldDelay)
        {
            agent.ResetPath();
        }
    }

    public void StopPlayerMovement()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        agent.ResetPath();
        animator.SetBool("isMoving", false);
        canMove = false;
    }

    public void ResumePlayerMovement()
    {
        agent.isStopped = false;
        canMove = true;
    }

    IEnumerator Move()
    {
        while (canMove) {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000.0f, LayerMask.GetMask("ClickToMove")))
            {
                animator.SetBool("isMoving", true);
                agent.SetDestination(hit.point);
            }

            clickHoldTime += Time.deltaTime;
            yield return null;
        }
    }
}