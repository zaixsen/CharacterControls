using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
/// <summary>
/// Evade state ÉÁ±Ü×´Ì¬
/// </summary>
public class PlayerEvadeState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();

        #region ÅÐ¶ÏÇ°ºóÉÁ±Ü

        switch (playerModel.state)
        {
            case PlayerState.Idle:
            case PlayerState.RunEnd:
                playerController.PlayerAnimation("Evade_Back");
                break;
            case PlayerState.Run:
                playerController.PlayerAnimation("Evade_Front");
                break;
        }

        #endregion
    }

    public override void Update()
    {
        base.Update();

        #region ÅÐ¶Ï¶¯»­ÊÇ·ñ½áÊø

        if (animatorStateInfo.normalizedTime >= 1.0f && !playerModel.animator.IsInTransition(0))
        {
            playerController.SwitchState(PlayerState.EvadeEnd);
        }

        #endregion

    }
}
