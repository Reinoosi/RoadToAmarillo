using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move objects to the left until gameOver is true
        if (playerControllerScript.gameOver == false)
        {
            // Move objects to left
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Destroy objects with Obstacle-tag when they reach -15 x.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }   
}
