using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色目标点  不直接挂载玩家身上 是因为 相机会自动锁定到 玩家正后方 不利于自主调节
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
