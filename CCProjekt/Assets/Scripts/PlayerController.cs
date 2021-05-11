using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Animator anim;
    public GameObject bubbleParticles;

    private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Character Movement

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput);


        playerRb.velocity = new Vector3(movement.x * speed, movement.y, movement.z * speed);

        if (Input.GetMouseButtonDown(2))
        {
            Instantiate(bubbleParticles, transform.position, bubbleParticles.transform.rotation);
        }
    }
}
