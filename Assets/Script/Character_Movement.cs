using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private float speed;
    [SerializeField] private float jump = 100f;
    [SerializeField] private Animator characterAnim;
    [SerializeField] private bool grounded = false;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private GameObject gunPositon;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumping, fire, run;
    [SerializeField] private bool crouchToggle;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (characterAnim.GetFloat("Horizontal") <= -0.01)
        {
            characterAnim.Play("Character_Run_Anim");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            crouchToggle = false;
        }
        if (characterAnim.GetFloat("Horizontal") >= 0.01)
        {
            characterAnim.Play("Character_Run_Anim");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            crouchToggle = false;
        }
        if (characterAnim.GetFloat("Horizontal") == 0 && crouchToggle == false)
        {
            crouchToggle = false;
            if(crouchToggle == false)
            {
                characterAnim.Play("Character_Idle");
            }
        }
        if (Input.GetKey(KeyCode.S) && characterAnim.GetFloat("Horizontal") == 0)
        {
            crouchToggle = true;
            if(crouchToggle == true)
            {
                characterAnim.Play("Character_Crouch");
                /*                this.gameObject.GetComponent<SpriteRenderer>().sprite = croundSprite;*/
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            crouchToggle = false;
            characterAnim.Play("Character_Idle");
            /*                this.gameObject.GetComponent<SpriteRenderer>().sprite = croundSprite;*/
        }


        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            characterAnim.Play("Character_Jump");
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jump);
            audioSource.PlayOneShot(jumping);
        }
        if (Input.GetButtonDown("Jump") && rigidbody2d.velocity.y > 0.5f)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetString("Player_Shoot", "RIGHT");
            Instantiate(bulletPrefabs, gunPositon.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(fire);
        }

/*        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerPrefs.SetString("Player_Shoot", "LEFT");
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(bulletPrefabs, gunPositon.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerPrefs.SetString("Player_Shoot", "UP");
            Instantiate(bulletPrefabs, gunPositon.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.SetString("Player_Shoot", "DOWN");
            Instantiate(bulletPrefabs, gunPositon.transform.position, Quaternion.identity);
        }*/
    }
    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        characterAnim.SetFloat("Horizontal", horizontal);
        if(horizontal >= 0.01 || horizontal <= -0.01)
        {
            rigidbody2d.velocity = new Vector2(speed * horizontal, rigidbody2d.velocity.y);
            audioSource.PlayOneShot(run);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
