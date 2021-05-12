using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _doDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision:  " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_doDamage == true)
            {
                hit.Damage();
                _doDamage = false;
                StartCoroutine(ResetDamage());
            }
        }
    }
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(10f);
        _doDamage = true;
    }
}
