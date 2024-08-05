using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //敌人标签
    private List<string> enemyTagList;
    //单次攻击的受击列表
    private List<IHurt> enemyHurtList = new List<IHurt>();

    // 武器触发器
    [SerializeField] private Collider hitCollider;

    private Action<IHurt> onHitAction;
    /// <summary>
    /// 初始化武器碰撞器
    /// </summary>
    /// <param name="enemyTagList">所有标签列表</param>
    /// <param name="onHitAction">碰撞回调 向上传递</param>
    public void Init(List<string> enemyTagList, Action<IHurt> onHitAction)
    {
        hitCollider.enabled = false;
        this.enemyTagList = enemyTagList;
        this.onHitAction = onHitAction;
    }

    public void StartHit()
    {
        hitCollider.enabled = true;
    }

    public void StopHit()
    {
        hitCollider.enabled = false;
        enemyHurtList.Clear();
    }

    private void OnTriggerStay(Collider other)
    {
        if (enemyTagList.Contains(other.tag))
        {
            IHurt enemy = other.GetComponent<IHurt>();
            //避免多次添加
            if (enemy != null && !enemyHurtList.Contains(enemy))
            {
                enemyHurtList.Add(enemy);
                #region 让敌人受击

                // 触发命中事件（通知上级处理敌人受击）
                onHitAction?.Invoke(enemy);

                #endregion
            }
            else if (enemy == null)
            {
                Debug.LogError("该受击对象" + other.name + "不包含受击接口");
            }
        }
    }

}
