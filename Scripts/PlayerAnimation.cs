using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void Move(float Move)
    {
        _anim.SetFloat("Move", Mathf.Abs(Move));
    }

    public void Attack()
    {
        _anim.SetTrigger("Slash");
    }

    public void Death()
    {
        _anim.SetTrigger("Death");
    }
}
