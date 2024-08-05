using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Idle, Idle_AFK,
    Walk, Run, RunEnd,
    TurnBack,
    Evade_Front, Evade_Back, Evade_Front_End, Evade_Back_End,
    NormalAttack, NormalAttackEnd,
    BigSkillStart, BigSkill, BigSkillEnd,
    SwitchInNormal,
}
public class PlayerStateBase : StateBase
{
    protected PlayerController playerController;

    protected PlayerModel playerModel;

    protected AnimatorStateInfo animatorStateInfo;

    protected float statePlayingTime = 0;

    public override void Init(IStateMachineOwner stateMachineOwner)
    {
        playerController = (PlayerController)stateMachineOwner;
        playerModel = playerController.playerModel;
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
        //Add gravity
        playerModel.characterController.Move(new Vector3(0, playerModel.gravity * Time.deltaTime, 0));

        statePlayingTime += Time.deltaTime;

        #region ¼ì²â½ÇÉ«ÇÐ»»
        if (playerModel.currentState != PlayerState.BigSkillStart
            && playerModel.currentState != PlayerState.BigSkill
            && playerController.inputActions.Player.SwitchRole.triggered)
        {
            //ÇÐ»»½ÇÉ«
            playerController.SwitchNextModel();
        }

        #endregion
    }

    public bool IsAnimationEnd()
    {
        //refresh animator state info 
        animatorStateInfo = playerModel.animator.GetCurrentAnimatorStateInfo(0);
        return animatorStateInfo.normalizedTime >= 1.0f && !playerModel.animator.IsInTransition(0);
    }

    public float NorlizedTime()
    {
        animatorStateInfo = playerModel.animator.GetCurrentAnimatorStateInfo(0);
        return animatorStateInfo.normalizedTime;
    }
}
