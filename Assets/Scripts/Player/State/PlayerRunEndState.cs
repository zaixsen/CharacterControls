using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunEndState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();

        #region ÅÐ¶Ï×óÓÒ½Å

        switch (playerModel.foot)
        {
            case ModelFoot.Right:
                playerController.PlayerAnimation("Run_End_R");
                break;
            case ModelFoot.Left:
                playerController.PlayerAnimation("Run_End_L");
                break;
        }

        #endregion
    }

    public override void Update()
    {
        base.Update();
        #region ¼ì²âÉÁ±Ü

        if (playerController.inputActions.Player.Evade.IsPressed())
        {
            playerController.SwitchState(PlayerState.Evade_Back);
        }

        #endregion

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
