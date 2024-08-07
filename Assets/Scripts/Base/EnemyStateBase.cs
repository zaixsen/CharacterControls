using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Idle, Idle_AFK,
    Hurt,
    Patrol,
    Follow,
    Attack,
    Death
}

public class EnemyStateBase : StateBase
{
    protected EnemyController enemyController;

    protected EnemyModel enemyModel;

    protected AnimatorStateInfo animatorStateInfo;

    protected float statePlayingTime = 0;

    public override void Init(IStateMachineOwner stateMachineOwner)
    {
        enemyController = (EnemyController)stateMachineOwner;
        enemyModel = enemyController.enemyModel;
    }

    public override void Enter()
    {
        statePlayingTime = 0;
    }

    public override void Exit()
    {

    }

    public override void FixedUpdate()
    {

    }

    public override void LateUpdate()
    {

    }

    public override void UnInit()
    {

    }

    public override void Update()
    {
        statePlayingTime += Time.deltaTime;

    }

    public bool IsAnimationEnd()
    {
        //refresh animator state info 
        animatorStateInfo = enemyModel.animator.GetCurrentAnimatorStateInfo(0);
        return animatorStateInfo.normalizedTime >= 1.0f && !enemyModel.animator.IsInTransition(0);
    }

    public float NorlizedTime()
    {
        animatorStateInfo = enemyModel.animator.GetCurrentAnimatorStateInfo(0);
        return animatorStateInfo.normalizedTime;
    }
}
