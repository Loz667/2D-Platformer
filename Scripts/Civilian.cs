using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Civilian : MonoBehaviour
{
    private Rigidbody2D _rb;
    //private SpriteRenderer _sprite;
    //[SerializeField]
    //private float _JumpHeight = 5f;
    [SerializeField]
    private float _speed = 5f;
    private PlayerAnimation _playAnim;
    private float _facingRight;
    private bool canHide;
    [SerializeField]
    private GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
        _facingRight = transform.localScale.x;
        _rb = GetComponent<Rigidbody2D>();
        //_sprite = GetComponentInChildren<SpriteRenderer>();
        _playAnim = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(_facingRight, transform.localScale.y);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-_facingRight, transform.localScale.y);
        }
        /*
        if (Input.GetButtonDown("Jump") && IsGrounded() == true)
        {
            Debug.Log("Jump");
            _rb.velocity = new Vector2(_rb.velocity.x, _JumpHeight);
        }
        */
        _rb.velocity = new Vector2(horizontalInput * _speed, _rb.velocity.y);
        _playAnim.Move(horizontalInput);

        foreach (Transform child in this.transform)
        {
            if (canHide && Input.GetKey("w"))
            {
                _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                this.gameObject.tag = "Untagged";
                child.gameObject.SetActive(false);                
            }
            else if (canHide && Input.GetKey("s"))
            {
                _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                this.gameObject.tag = "Player";
                child.gameObject.SetActive(true);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hide"))
        {
            canHide = true;
            uiObject.SetActive(true);
            StartCoroutine(RemoveUI());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hide"))
        {
            canHide = false;
        }
    }

    IEnumerator RemoveUI()
    {
        yield return new WaitForSeconds(0.5f);
        uiObject.SetActive(false);
    }

    /*bool IsGrounded()
    {
        RaycastHit2D _hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);

        if (_hitinfo.collider != null)
        {
            return true;
        }

        return false;
    }*/
}
