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

        #region ºÏ≤‚…¡±‹

        if (playerController.inputActions.Player.Evade.IsPressed())
        {
            playerController.SwitchState(PlayerState.Evade_Back);
        }

        #endregion

        #region º‡Ã˝±º≈‹
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Run);
        }
        #endregion
    }
}
