using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Destroy : MonoBehaviour
{
    [SerializeField] private Animator exploAnim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            exploAnim.Play("Explosion");
            Destroy(this.gameObject, 0.6f);
        }
    }
}
