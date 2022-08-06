using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private GameObject enemy;
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetString("Player_Shoot").Equals("RIGHT"))
        {
            this.transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
            Destroy(this.gameObject, 1f);
        }
/*        if (PlayerPrefs.GetString("Player_Shooot").Equals("LEFT"))
        {
            this.transform.Translate(Vector2.left * bulletSpeed * Time.deltaTime);
            Destroy(this.gameObject, 1f);
        }
        if (PlayerPrefs.GetString("Player_Shoot").Equals("UP"))
        {
            this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
            Destroy(this.gameObject, 1f);
        }
        if (PlayerPrefs.GetString("Player_Shooot").Equals("DOWN"))
        {
            this.transform.Translate(Vector2.down * bulletSpeed * Time.deltaTime);
            Destroy(this.gameObject, 1f);
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Object"))
        {
            Destroy(this.gameObject);
        }
    }
}
