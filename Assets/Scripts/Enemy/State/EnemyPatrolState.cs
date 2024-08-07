using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyStateBase
{
    Vector3 targetPathPos;
    float changeDis;

    public override void Enter()
    {
        base.Enter();
        enemyController.PlayerAnimation("Walk");
        changeDis = 0.1f;
        //���Ŀ���
        Vector2 v2 = Random.insideUnitCircle * 3;
        targetPathPos = enemyModel.transform.position + new Vector3(v2.x, 0, v2.y);
        enemyModel.transform.LookAt(targetPathPos);
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

        #region  ����Ŀ���ת��Idle
        Vector3 origin = new Vector3(enemyModel.transform.position.x, 0, enemyModel.transform.position.z);
        Vector3 target = new Vector3(targetPathPos.x, 0, targetPathPos.z);

        float dis = Vector3.Distance(origin, target);

        if (dis < changeDis)
        {
            enemyController.SwitchState(EnemyState.Idle_AFK);
        }

        #endregion

    }

}
