using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    Rigidbody2D rb;
    public float speedMultiplier = 100f;
    void Start()
    {
        rb = Player.Instance.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputController();
    }

    public void InputController()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * speedMultiplier);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * speedMultiplier);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * speedMultiplier);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * speedMultiplier);
        }
        else
        {
            return;
        }
    }
}
