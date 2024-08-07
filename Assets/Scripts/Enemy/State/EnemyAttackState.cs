using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{

    public override void Enter()
    {
        base.Enter();
        enemyController.PlayerAnimation("Attack");
    }


    public override void Update()
    {
        base.Update();


        #region �ж϶����Ƿ����

        if (IsAnimationEnd())
        {
            enemyController.SwitchState(EnemyState.Idle);
            return;
        }

        #endregion
    }

}
