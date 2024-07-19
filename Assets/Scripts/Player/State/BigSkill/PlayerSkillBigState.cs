using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillBigState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        //�л���ͷ
        playerModel.bigSkillStartShot.SetActive(false);
        playerModel.bigSkillShot.SetActive(true);

        playerController.PlayerAnimation("BigSkill", 0f);
    }


    public override void Update()
    {
        base.Update();


        #region �ж϶����Ƿ����

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.BigSkillEnd);
            return;
        }

        #endregion
    }

}
