using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : StateBase
{
    protected PlayerController playerController;

    protected PlayerModel playerModel;

    protected AnimatorStateInfo animatorStateInfo;

    public override void Init(IStateMachineOwner stateMachineOwner)
    {
        playerController = (PlayerController)stateMachineOwner;
        playerModel = playerController.playerModel;
    }

    public override void Enter()
    {

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
        animatorStateInfo = playerModel.animator.GetCurrentAnimatorStateInfo(0);
    }
}
