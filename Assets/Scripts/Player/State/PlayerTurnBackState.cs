using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 180 rad turn back
/// </summary>
public class PlayerTurnBackState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        playerController.PlayerAnimation("TurnBack", 0.1f);
    }

    public override void Update()
    {
        base.Update();

        #region ¼ì²â¶¯»­ÊÇ·ñ½áÊø

        if (animatorStateInfo.normalizedTime >= 1.0f && !playerModel.animator.IsInTransition(0))
        {
            playerController.SwitchState(PlayerState.Run);
        }

        #endregion

    }

}
