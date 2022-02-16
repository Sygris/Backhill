using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private string _animationParameter;
    [SerializeField] private Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger(_animationParameter);
    }
}
