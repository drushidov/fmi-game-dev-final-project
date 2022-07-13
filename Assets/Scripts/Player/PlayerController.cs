using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private NavMeshAgent agent;
    private Animator animator;

    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        playerHealth.OnDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        playerMovement.StopPlayerMovement();
        playerMovement.enabled = false;
        agent.enabled = false;
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("die");
    }
}
