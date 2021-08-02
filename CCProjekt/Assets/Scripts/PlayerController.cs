using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public bool isFiring; 
    public float waterUsage = 7.5f;
    public float maxWater = 200;

    public Animator anim;
    public ParticleSystem bubbleParticles;
    public Rig blasterRig;
    public GameObject blaster;
    public TextMeshProUGUI waterText;


    public Image healthbar;
    public Image staminaBar;
    public Image waterBar;

    public bool isDead = false;

    private float water = 100;
    private Rigidbody playerRb;
    private StatusManager statusmanager;

    

    // Start is called before the first frame update
    void Start()
    {
        water = maxWater;
        playerRb = GetComponent<Rigidbody>();
        statusmanager = GetComponent<StatusManager>();
        bubbleParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Character Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move Character Foward
        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput);
        playerRb.velocity = new Vector3(movement.x * statusmanager.MovementSpeed, playerRb.velocity.y, movement.z * statusmanager.MovementSpeed);

        CheckShooting();

        // Check if Player presses the Sprintbutton
        if(Input.GetAxis("Sprint") > 0)
        {
            statusmanager.staminaRegenEnabled = false;
            // Sprint while Stamina is Available
            if(statusmanager.Stamina > 0)
            { 
                statusmanager.Stamina -= 20 * Time.deltaTime;
                statusmanager.movementspeedModifier = 1.4f;
                anim.speed = 1.4f;
            }
            else
            {
                statusmanager.movementspeedModifier = 1;
                anim.speed = 1;
            }
        }
        else
        {
            // Activate Stamina regen while not sprinting and reset Movement and Animation values
            statusmanager.staminaRegenEnabled = true;
            statusmanager.movementspeedModifier = 1;
            anim.speed = 1;
        }

        // Set Animations
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetFloat("Speed_f", 1);
        }
        else
        {
            anim.SetFloat("Speed_f", 0);
        }

        // Set Hp bar
        float hpPercentage = statusmanager.Hp / statusmanager.maxHp;
        healthbar.fillAmount = hpPercentage;

        // Set Stamina bar
        float staminaPercentage = statusmanager.Stamina / statusmanager.maxStamina;
        staminaBar.fillAmount = staminaPercentage;
    }

    /// <summary>
    /// Handle Player Shooting
    /// By Christian Scherzer and Shaina Milde
    /// </summary>
    private void CheckShooting()
    {
        isFiring = false;
        // If player is pressing the right mouse button and has water 
        if (Input.GetMouseButton(1) && Water > 0)
        {

            // drain water
            Water -= waterUsage * Time.deltaTime;
            isFiring = true;
            
            // Shoot particles
            if(!bubbleParticles.isEmitting)
            { 
                bubbleParticles.Play();
            }
            // Enable Animation rig
            blasterRig.weight = 1;
            // Set shooting Animation
            anim.SetBool("Is_Shooting", true);
            // Show blaster
            blaster.SetActive(true);
        }
        // Reset everthing if not shooting
        if (!isFiring)
        {
            anim.SetBool("Is_Shooting", false);
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

            float waterPercentage = water / maxWater;
            waterBar.fillAmount = waterPercentage;
        }
    }

    /// <summary>
    /// If the Player is dead the Game gets set to Game Over
    /// By Shaina Milde
    /// </summary>
    public void IsDead ()
    {
        isDead = true;
        GameManager.Instance.SetGameOver();
    }
}
