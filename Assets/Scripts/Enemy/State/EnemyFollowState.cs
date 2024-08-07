using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyStateBase
{
    public override void Enter()
    {
        base.Enter();
        enemyController.PlayerAnimation("Walk");
    }

    public override void Update()
    {
        base.Update();

        enemyModel.transform.LookAt(enemyModel.player);


        #region ��⹥��

        if (enemyModel.playerDistance < enemyModel.attackDistance)
        {
            enemyController.SwitchState(EnemyState.Attack);
            return;
        }

        #endregion


        #region ȡ������

        if (enemyModel.playerDistance > enemyModel.followDistance)
        {
            enemyController.SwitchState(EnemyState.Idle);
            return;
        }

        #endregion

    }

}
