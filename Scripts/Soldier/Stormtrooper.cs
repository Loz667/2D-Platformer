using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stormtrooper : Soldier
{
    private Vector3 _target;
    private float _facingRight;

    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _facingRight = transform.localScale.x;
        _anim = GetComponentInChildren<Animator>();        
    }

    // Update is called once per frame
    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Stormtrooper_Idle"))
        {
            return;
        }

        Movement();
    }

    void Movement()
    {
        if (_target == pointA.position)
        {
            transform.localScale = new Vector3(-_facingRight, transform.localScale.y);
        }
        else if (_target == pointB.position)
        {
            transform.localScale = new Vector3(_facingRight, transform.localScale.y);
        }

        if (transform.position == pointA.position)
        {
            _target = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _target = pointA.position;
            _anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, speed * Time.deltaTime);
    }
}
