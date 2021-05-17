using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public bool isFiring; 
    public float waterUsage = 7.5f;
    public float maxWater = 100;

    public Animator anim;
    public ParticleSystem bubbleParticles;
    public Rig blasterRig;
    public GameObject blaster;
    public TextMeshProUGUI waterText;
    
    private float water = 100;

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

        CheckShooting();

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetFloat("Speed_f", 1);
        }
        else
        {
            anim.SetFloat("Speed_f", 0);
        }
    }

    private void CheckShooting()
    {
        isFiring = false;
        if (Input.GetMouseButton(1) && Water > 0)
        {

            Water -= waterUsage * Time.deltaTime;
            isFiring = true;
            
            if(!bubbleParticles.isEmitting)
            { 
                bubbleParticles.Play();
            }
            blasterRig.weight = 1;
            blaster.SetActive(true);
        }
        if (!isFiring)
        {
            bubbleParticles.Stop();
            blasterRig.weight = 0;
            blaster.SetActive(false);
        }
    }

    public float Water 
    { get => water;
        set 
        {
            water = value;
            waterText.text = Water.ToString("N0") + " / " + maxWater.ToString("N0");
        }
    }

}
