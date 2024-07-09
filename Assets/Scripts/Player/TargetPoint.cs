using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��ɫĿ���  ��ֱ�ӹ���������� ����Ϊ ������Զ������� ������� ��������������
/// </summary>
public class TargetPoint : MonoBehaviour
{
    private Vector3 endPos;

    private void Awake()
    {
        endPos = new Vector3(0, transform.position.y, 0);
    }

    private void LateUpdate()
    {
        transform.position = PlayerController.Instance.playerModel.transform.position + endPos;
    }

}
