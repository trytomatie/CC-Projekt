using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Animator anim;
    public ParticleSystem bubbleParticles;

    private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        bubbleParticles.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        // Character Movement

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput);


        playerRb.velocity = new Vector3(movement.x * speed, playerRb.velocity.y, movement.z * speed);

        if (Input.GetMouseButtonDown(1))
        {
            bubbleParticles.Play();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            bubbleParticles.Stop();
        }
    }
}
