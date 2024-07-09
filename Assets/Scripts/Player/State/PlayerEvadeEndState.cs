using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player Evade End State 
/// </summary>
public class PlayerEvadeEndState : PlayerStateBase
{

    public override void Enter()
    {
        base.Enter();

        #region ÅÐ¶ÏÇ°ºóÉÁ±Ü

        switch (playerModel.state)
        {
            case PlayerState.Evade_Front:
                playerController.PlayerAnimation("Evade_Front_End");
                break;
            case PlayerState.Evade_Back:
                playerController.PlayerAnimation("Evade_Back_End");
                break;
        }
        #endregion

    }

    public override void Update()
    {
        base.Update();

        #region ÒÆ¶¯¼ì²â
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Run);
        }
        #endregion


        #region ÅÐ¶Ï¶¯»­ÊÇ·ñ½áÊø
        if (animatorStateInfo.normalizedTime >= 1.0f && !playerModel.animator.IsInTransition(0))
        {
            playerController.SwitchState(PlayerState.Idle);
        }
        #endregion
    }

}
