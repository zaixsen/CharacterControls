using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    [HideInInspector] public EnemyState currentState;

    [HideInInspector] public float rotateSpeed;

    [HideInInspector] public float playerDistance;

    [HideInInspector] public float followDistance;

    [HideInInspector] public float attackDistance;

    [HideInInspector] public Transform player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rotateSpeed = 20;
        followDistance = 5;
        attackDistance = 1.5f;
    }

    private void Update()
    {
        player = PlayerController.Instance.playerModel.transform;

        Vector3 origin = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 target = new Vector3(player.position.x, 0, player.position.z);
        playerDistance = Vector3.Distance(origin, target);
    }

}
