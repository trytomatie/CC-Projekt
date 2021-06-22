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
    public float maxWater = 100;

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

        Vector3 movement = (transform.forward * verticalInput + transform.right * horizontalInput);
        playerRb.velocity = new Vector3(movement.x * statusmanager.MovementSpeed, playerRb.velocity.y, movement.z * statusmanager.MovementSpeed);

        CheckShooting();

        if(Input.GetAxis("Sprint") > 0 && statusmanager.Stamina > 0)
        {
            statusmanager.staminaRegenEnabled = false;
            statusmanager.Stamina -= 20 * Time.deltaTime;
            statusmanager.movementspeedModifier = 1.4f;
            anim.speed = 1.4f;
        }
        else
        {
            statusmanager.staminaRegenEnabled = true;
            statusmanager.movementspeedModifier = 1;
            anim.speed = 1;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetFloat("Speed_f", 1);
        }
        else
        {
            anim.SetFloat("Speed_f", 0);
        }

        float hpPercentage = statusmanager.Hp / statusmanager.maxHp;
        healthbar.fillAmount = hpPercentage;

        float staminaPercentage = statusmanager.Stamina / statusmanager.maxStamina;
        staminaBar.fillAmount = staminaPercentage;
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

            float waterPercentage = water / maxWater;
            waterBar.fillAmount = waterPercentage;
        }
    }

    public void IsDead ()
    {
        isDead = true;
        GameManager.Instance.SetGameOver();
    }
}
