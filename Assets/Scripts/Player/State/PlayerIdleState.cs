using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{

    public override void Enter()
    {
        base.Enter();

        playerController.PlayerAnimation("Idle");
    }

    public override void Update()
    {
        base.Update();

        #region ��������

        #endregion
    }
}