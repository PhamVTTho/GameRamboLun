using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Background : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    void Update()
    {
        float horizontal_Move = Input.GetAxis("Horizontal");
        if(horizontal_Move >= 0.01)
        {
            this.transform.position = Vector2.right * speed;
        }
    }
}
