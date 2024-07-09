using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunEndState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();

        #region �ж����ҽ�

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
        #region �������

        if (playerController.inputActions.Player.Evade.IsPressed())
        {
            playerController.SwitchState(PlayerState.Evade_Back);
        }

        #endregion

        #region �ƶ����
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Run);
        }
        #endregion


        #region �ж϶����Ƿ����
        if (animatorStateInfo.normalizedTime >= 1.0f && !playerModel.animator.IsInTransition(0))
        {
            playerController.SwitchState(PlayerState.Idle);
        }

        #endregion

    }

}
