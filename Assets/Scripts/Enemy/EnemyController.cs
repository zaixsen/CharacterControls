using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : SingleMonoBase<EnemyController>, IHurt, IStateMachineOwner
{
    public EnemyModel enemyModel;

    private StateMachine stateMachine;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine(this);

    }
    private void Start()
    {
        SwitchState(EnemyState.Idle);
    }
    /// <summary>
    /// Switch state
    /// </summary>
    /// <param name="playerState">player state</param>
    public void SwitchState(EnemyState enemyState)
    {
        enemyModel.currentState = enemyState;
        switch (enemyState)
        {
            case EnemyState.Idle:
            case EnemyState.Idle_AFK:
                stateMachine.EnterState<EnemyIdleState>(true);
                break;
            case EnemyState.Hurt:
                stateMachine.EnterState<EnemyHurtState>();
                break;
            case EnemyState.Patrol:
                stateMachine.EnterState<EnemyPatrolState>();
                break;
            case EnemyState.Follow:
                stateMachine.EnterState<EnemyFollowState>();
                break;
            case EnemyState.Attack:
                stateMachine.EnterState<EnemyAttackState>();
                break;
            case EnemyState.Death:
                stateMachine.EnterState<EnemyDeathState>();
                break;
        }

    }

    /// <summary>
    /// Play Animation
    /// </summary>
    /// <param name="animationName">Animation Name</param>
    /// <param name="fixedTransitionDuration">Duration</param>
    public void PlayerAnimation(string animationName, float fixedTransitionDuration = 0.25f)
    {
        enemyModel.animator.CrossFadeInFixedTime(animationName, fixedTransitionDuration);
    }

}
