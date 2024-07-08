using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : StateBase
{
    protected PlayerController playerController;

    protected PlayerModel playerModel;

    public override void Init(IStateMachineOwner stateMachineOwner)
    {
        playerController = stateMachineOwner as PlayerController;
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

    }
}
