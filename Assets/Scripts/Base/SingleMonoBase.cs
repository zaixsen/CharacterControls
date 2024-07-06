using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ����ģʽ
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleMonoBase<T> : MonoBehaviour where T : SingleMonoBase<T>
{

    public static T Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError(this + "  this is not single mode , maybe create other instance");
        }

        Instance = this as T;
    }

    private void OnDestroy()
    {
        Destroy();
    }
    /// <summary>
    /// ������൥��
    /// </summary>
    public void Destroy()
    {
        Instance = null;
    }
}
