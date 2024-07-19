using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillBigState : PlayerStateBase
{
    public override void Enter()
    {
        base.Enter();
        //ÇÐ»»¾µÍ·
        playerModel.bigSkillStartShot.SetActive(false);
        playerModel.bigSkillShot.SetActive(true);

        playerController.PlayerAnimation("BigSkill", 0f);
    }


    public override void Update()
    {
        base.Update();


        #region ÅÐ¶Ï¶¯»­ÊÇ·ñ½áÊø

        if (IsAnimationEnd())
        {
            playerController.SwitchState(PlayerState.BigSkillEnd);
            return;
        }

        #endregion
    }

}
