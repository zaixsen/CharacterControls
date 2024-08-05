using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalAttackState : PlayerStateBase
{
    private bool IsEnterNextAttack;
    private float minDistance;
    private GameObject enemy;

    public override void Enter()
    {
        enemy = null;
        minDistance = Mathf.Infinity;
        base.Enter();

        #region 寻找最近的敌人

        foreach (var enemyTag in playerController.enemyTagList)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            foreach (var e in enemies)
            {
                float dis = Vector3.Distance(playerModel.transform.position, e.transform.position);
                if (dis < minDistance)
                {
                    minDistance = dis;
                    enemy = e;
                }
            }
        }
        //计算方向
        Vector3 direction = enemy.transform.position - playerModel.transform.position;

        playerModel.transform.rotation = Quaternion.LookRotation(direction);

        #endregion


        IsEnterNextAttack = false;
        playerController.PlayerAnimation("Attack_Normal_" + playerModel.skillConfig.currentNormalAttackIndex);
    }

    public override void Update()
    {
        base.Update();

        #region 检测大招
        if (playerController.inputActions.Player.BigSkill.triggered)
        {
            playerController.SwitchState(PlayerState.BigSkillStart);
            return;
        }
        #endregion


        if (animatorStateInfo.normalizedTime >= 0.5f && playerController.inputActions.Player.Fire.triggered)
        {
            IsEnterNextAttack = true;
        }


        #region 判断动画是否结束

        if (IsAnimationEnd())
        {
            if (IsEnterNextAttack)
            {
                //累加攻击次数
                playerModel.skillConfig.currentNormalAttackIndex++;
                if (playerModel.skillConfig.currentNormalAttackIndex
                    > playerModel.skillConfig.normalAttackDamageMultiple.Length)
                {
                    playerModel.skillConfig.currentNormalAttackIndex = 1;
                }
                //切换攻击状态
                playerController.SwitchState(PlayerState.NormalAttack);
                return;
            }
            else
            {
                playerController.SwitchState(PlayerState.NormalAttackEnd);
                return;
            }
        }

        #endregion
    }

}
