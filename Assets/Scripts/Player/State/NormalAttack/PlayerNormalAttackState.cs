using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttackState : PlayerStateBase
{

    public override void Enter()
    {
        base.Enter();
        playerController.PlayerAnimation("Attack_Normal_" + playerModel.skillConfig.currentNormalAttackIndex);
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

        #region ≈–∂œ∂Øª≠ «∑ÒΩ· ¯

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.NormalAttackEnd);
            return;
        }

        #endregion
    }

}
