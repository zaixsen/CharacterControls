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

        #region ºÏ≤‚¥Û’–
        if (playerController.inputActions.Player.BigSkill.triggered)
        {
            playerController.SwitchState(PlayerState.BigSkillStart);
            return;
        }
        #endregion

        #region ºÏ≤‚π•ª˜

        if (playerController.inputActions.Player.Fire.triggered)
        {
            playerController.SwitchState(PlayerState.NormalAttack);
            return;
        }

        #endregion

        #region ºÏ≤‚…¡±‹

        if (playerController.inputActions.Player.Evade.triggered)
        {
            playerController.SwitchState(PlayerState.Evade_Back);
            return;
        }

        #endregion

        #region º‡Ã˝±º≈‹
        if (playerController.inputMoveVec2 != Vector2.zero)
        {
            playerController.SwitchState(PlayerState.Run);
            return;
        }
        #endregion
    }
}
