using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseController : MonoBehaviour
{
    
    [SerializeField]
    public Vector3 speed; //speed

    [SerializeField]
    private float

            x_speed = 8f, //left right move speed
            z_Speed = 15; //forward speed

    [SerializeField]
    private float

            acceleretedSpeed = 15f, // accelerate
            deacceleretedSpeed = 10f; //de-accelerate

    protected float rotationSpeed = 10f; //rotation speed

    protected float maxAngle = 10f; //max angle

    [SerializeField]
    private float

            low_sound_pitch,
            normal_sound_pitch,
            high_sound_pitch;

    [SerializeField]
    private AudioClip

            engineOnSound,
            engineOffSound;

    private bool is_Slow;

    private AudioSource soundManager;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform bulletStartPosition;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private ParticleSystem fireEffect;
Animator sliderAnim;
[HideInInspector] public bool canShoot;
    Rigidbody myBody;

    void Awake()
    {
        soundManager = GetComponent<AudioSource>();
        myBody = GetComponent<Rigidbody>();
    }

 void Start()
 {
sliderAnim = GameObject.Find("Fire Bar").GetComponent<Animator>();
    GameObject.Find("ShootBtn").GetComponent<Button>().onClick.AddListener(ShootBullet);
    canShoot=true;
 }
     void Update()
    {
        ControlPlayerByButtons();

    }

    void LateUpdate()
    {
        RotatePlayer();
    }

    protected void MovePlayer()
    {
        myBody.MovePosition(myBody.position + speed * Time.deltaTime);
    }

    protected void MoveLeft()
    {
        speed = new Vector3(-x_speed / 2, 0, z_Speed);
    } //moveleft

    protected void MoveRight()
    {
        speed = new Vector3(x_speed / 2, 0f, z_Speed);
    } //moveright

    protected void MoveForward()
    {
        speed = new Vector3(0, 0, z_Speed);
    } //moveforward

    protected void MoveNormal()
    {
        if (is_Slow)
        {
            is_Slow = false;
            soundManager.Stop();
            soundManager.clip = engineOnSound;
            soundManager.volume = .3f;
            soundManager.Play();
        }

        speed = new Vector3(speed.x, 0f, z_Speed);
    } //movenormal

    protected void MoveSlow()
    {
        if (!is_Slow)
        {
            is_Slow = true;
            soundManager.Stop();
            soundManager.clip = engineOffSound;
            soundManager.volume = .5f;
            soundManager.Play();
        }
        speed = new Vector3(speed.x, 0f, deacceleretedSpeed);
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0f, acceleretedSpeed);
    }

     private void ControlPlayerByButtons()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveForward();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveForward();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
    }

    private void RotatePlayer()
    {
        if (speed.x > 0)
        {
            transform.rotation =
                Quaternion
                    .Slerp(transform.rotation,
                    Quaternion.Euler(0f, maxAngle, 0f),
                    Time.deltaTime * rotationSpeed);
        }
        else if (speed.x < 0)
        {
            transform.rotation =
                Quaternion
                    .Slerp(transform.rotation,
                    Quaternion.Euler(0f, -maxAngle, 0f),
                    Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation =
                Quaternion
                    .Slerp(transform.rotation,
                    Quaternion.Euler(0f, 0f, 0f),
                    Time.deltaTime * rotationSpeed);
        }
    }

      protected void ShootBullet()
    {
      if(Time.timeScale!=0)
      {
        if(canShoot)
        {
             var bulletClone =
                Instantiate(bulletPrefab,
                bulletStartPosition.position,
                Quaternion.identity);
            bulletClone.GetComponent<BulletScripts>().ShootBullet(bulletSpeed);
            fireEffect.Play();

           
sliderAnim.Play("Fill");
            canShoot = false;
             
        }
      }
    }

   
} //class
