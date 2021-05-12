using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _JumpHeight = 5f;
    private bool _JumpReset = false;
    [SerializeField]
    private float _speed = 5f;
    private PlayerAnimation _playAnim;
    private SpriteRenderer _sprite;

    public int Health { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playAnim = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetButtonDown("Fire1"))
        {
            _playAnim.Attack();
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            _sprite.flipX = false;
        }

        else if (horizontalInput < 0)
        {
            _sprite.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded() == true)
        {
            Debug.Log("Jump");
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpHeight);
            StartCoroutine(JumpResetRoutine());
        }
       
        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);
        _playAnim.Move(horizontalInput);
    }

    bool isGrounded()
    {
        //Raycast to send signal from player position, signal to go down for 1f
        RaycastHit2D _hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 1.75f, 1 << 8);
        
        if (_hitinfo.collider != null)
        {
            if (_JumpReset == false)
                return true;
        }

        return false;

    }

    IEnumerator JumpResetRoutine()
    {
        //Resets jump method, allowing character to jump again
        _JumpReset = true;
        yield return new WaitForSeconds(0.1f);
        _JumpReset = false;
    }

    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }

        Health--;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            _playAnim.Death();
        }
    }

}
