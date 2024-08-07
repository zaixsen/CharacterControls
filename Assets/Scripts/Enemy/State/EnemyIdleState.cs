using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyStateBase
{
    
    public override void Enter()
    {
        base.Enter();
        switch (enemyModel.currentState)
        {
            case EnemyState.Idle_AFK:
                enemyController.PlayerAnimation("Idle_AFK");
                break;
            case EnemyState.Idle:
                enemyController.PlayerAnimation("Idle");
                break;
        }

    }

    public override void Update()
    {
        base.Update();


        #region ��⹥��

        if (enemyModel.playerDistance < enemyModel.attackDistance)
        {
            enemyController.SwitchState(EnemyState.Attack);
            return;
        }

        #endregion

        #region ������

        if (enemyModel.playerDistance < enemyModel.followDistance)
        {
            enemyController.SwitchState(EnemyState.Follow);
            return;
        }

        #endregion

        #region ���һ�

        switch (enemyModel.currentState)
        {
            case EnemyState.Idle:
                if (statePlayingTime > 3)
                {
                    int randomState = Random.Range(1, 2);
                    if (randomState == 0)
                    {
                        enemyController.SwitchState(EnemyState.Idle_AFK);
                    }
                    else
                    {
                        enemyController.SwitchState(EnemyState.Patrol);
                    }
                }
                break;
            case EnemyState.Idle_AFK:
                if (IsAnimationEnd())
                {
                    enemyController.SwitchState(EnemyState.Idle);
                }
                break;
        }

        #endregion
    }


}
