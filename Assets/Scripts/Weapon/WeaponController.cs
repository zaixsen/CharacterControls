using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //���˱�ǩ
    private List<string> enemyTagList;
    //���ι������ܻ��б�
    private List<IHurt> enemyHurtList = new List<IHurt>();

    // ����������
    [SerializeField] private Collider hitCollider;

    private Action<IHurt> onHitAction;
    /// <summary>
    /// ��ʼ��������ײ��
    /// </summary>
    /// <param name="enemyTagList">���б�ǩ�б�</param>
    /// <param name="onHitAction">��ײ�ص� ���ϴ���</param>
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
            //���������
            if (enemy != null && !enemyHurtList.Contains(enemy))
            {
                enemyHurtList.Add(enemy);
                #region �õ����ܻ�

                // ���������¼���֪ͨ�ϼ���������ܻ���
                onHitAction?.Invoke(enemy);

                #endregion
            }
            else if (enemy == null)
            {
                Debug.LogError("���ܻ�����" + other.name + "�������ܻ��ӿ�");
            }
        }
    }

}
