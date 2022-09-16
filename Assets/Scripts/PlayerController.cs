using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 3f;

    public GameObject gameWonPanel;

    private bool isGameWon = false;
     
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (isGameWon == true)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space)) //Player won't move while space key is pressed.
        {
            body.velocity = new Vector2(0f, 0f);
        }
        else
        {
            if (Input.GetAxis("Horizontal") > 0) //positive X axis
            {   
                body.velocity = new Vector2(speed, 0f);
            }
            else if (Input.GetAxis("Horizontal") < 0) //negative X axis
            {
                body.velocity = new Vector2(-speed, 0f);
            }
            else if (Input.GetAxis("Vertical") > 0) //positive Y axis
            {
                body.velocity = new Vector2(0f, speed);
            }
            else if (Input.GetAxis("Vertical") < 0) //negative Y axis
            {
                body.velocity = new Vector2(0f, -speed);
            }
            else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //stop
            {
                body.velocity = new Vector2(0f, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Complete !!!");
            gameWonPanel.SetActive(true);
            isGameWon = true;
        }     
    }
}
