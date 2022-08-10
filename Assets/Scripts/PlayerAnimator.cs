using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetSpeed(float _speed)
    {
        animator.SetFloat("Speed", _speed);
    }
}
