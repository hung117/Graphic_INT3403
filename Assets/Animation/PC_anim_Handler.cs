using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_anim_Handler : MonoBehaviour
{
    public Animator _animator;
    [SerializeField] protected PC_controller _PC;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        // _animator.SetFloat("foward", _PC.getFoward());
        _animator.SetInteger("foward", (int)_PC.getFoward());
        Debug.Log("FOWARD: " + _PC.getFoward().ToString());
    }
}
