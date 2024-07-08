using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Idle,
    Run,
}
public class PlayerModel : MonoBehaviour
{
    public Animator animator;

    [HideInInspector] public PlayerState state;

    private void Start()
    {

    }

    private void Update()
    {

    }

}
