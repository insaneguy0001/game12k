using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform Orientation;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform groundcheck;
    public float speed = 3f;
    Vector3 direction;
    float SpeedMultiplier = 15f;
    float AirSpeedMultiplier = 3f;
    bool isPlayerGrounded;
    Rigidbody rb;
    float x;
    float z;
    float ForceJump = 10f;
    float rbdrag = 5f;
    float JumpDrag = 2f;
    float height = 2f;
    public Camera MainCam;
    public Camera GunCamera;
    float maxFov = 70f;
    float minFov = 60f;
    public float t = 10f;
    float groundDistance = 0.4f;
    RaycastHit HitSlope;
    Vector3 MoveSlopeDirection;
    public Transform GunContainer;
    AudioSource walkSfx;
    bool jumped = false;
    public Animator cameraAnimator;
    bool Sprint;
    public Vector3 normalPosition;
    public Vector3 aimPosition;
    public GameObject gunContainer;
    public bool IsGunEquiped;
    float normalFov = 60f;
    float aimFov = 40f;
    bool isAiming = false;
    public bool paused = false;



    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out HitSlope, height / 2 + 0, 5))
        {
            if(HitSlope.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        walkSfx = GetComponent<AudioSource>();
        rb.freezeRotation = true;
    }
    void Update()
    {

        if (!paused)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, aimFov, 10f * Time.deltaTime);
                GunCamera.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, aimFov, 10f * Time.deltaTime);
                isAiming = true;
                speed = 3f;
                Sprint = false;
            }
            else
            {
                if (!Sprint)
                {
                    MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, normalFov, 10f * Time.deltaTime);
                    GunCamera.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, normalFov, 10f * Time.deltaTime);
                }

                isAiming = false;
            }
        }


        if (Input.GetKeyDown("x"))
        {
            Screen.SetResolution(1280, 800, Screen.fullScreen);
        }



        isPlayerGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        
        if (!Sprint)
        {
            if (x != 0 || z != 0 && isPlayerGrounded)
            {
                
                walkSfx.volume = 0.25f;
                cameraAnimator.SetInteger("walk", 1);
            }
            else
            {
                walkSfx.volume = 0f;
                cameraAnimator.SetInteger("walk", 0);
            }
        }else if (Sprint)
        {
            
            if (x != 0 || z != 0 && isPlayerGrounded)
            {
                
                walkSfx.volume = 0.5f;
                cameraAnimator.SetInteger("walk", 2);
            }
            else
            {
                walkSfx.volume = 0f;
                cameraAnimator.SetInteger("walk", 0);
            }


            


            
        }


        

        InputSystemManager();
        rbDragControl();
        if (Input.GetKeyDown("space") && isPlayerGrounded)
        {
            jump();
            
        }
       


        

        MoveSlopeDirection = Vector3.ProjectOnPlane(direction, HitSlope.normal);

    }
    void InputSystemManager()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        direction = Orientation.forward * z + Orientation.right * x;

        
    }
    void rbDragControl()
    {
        if (isPlayerGrounded)
        {
            rb.drag = rbdrag;
        } 
        else if (!isPlayerGrounded)
        {
            rb.drag = JumpDrag;
        }
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
        sprint();
    }

    void sprint()
    {
        if (!isAiming)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 5f;
                Sprint = true;
                if (x != 0 || z != 0)
                {
                    MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, maxFov, 10f * Time.deltaTime);
                    GunCamera.fieldOfView = Mathf.Lerp(GunCamera.fieldOfView, maxFov, 10f * Time.deltaTime);


                }
                else
                {
                    MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, minFov, 10f * Time.deltaTime);
                    GunCamera.fieldOfView = Mathf.Lerp(GunCamera.fieldOfView, minFov, 10f * Time.deltaTime);

                }

            }
            else
            {
                speed = 3f;
                MainCam.fieldOfView = Mathf.Lerp(MainCam.fieldOfView, minFov, 10f * Time.deltaTime);
                GunCamera.fieldOfView = Mathf.Lerp(GunCamera.fieldOfView, minFov, 10f * Time.deltaTime);
                Sprint = false;

            }
        }
    }


    void MovePlayer()
    {
        if (isPlayerGrounded && !OnSlope())
        {
            rb.AddForce(direction.normalized * speed * SpeedMultiplier, ForceMode.Acceleration);
        }
        if (isPlayerGrounded && OnSlope())
        {
            rb.AddForce(MoveSlopeDirection.normalized * speed * SpeedMultiplier, ForceMode.Acceleration);
        }
        else if (!isPlayerGrounded)
        {
            rb.AddForce(direction.normalized * speed * AirSpeedMultiplier, ForceMode.Acceleration);
        }

    }
    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * ForceJump, ForceMode.Impulse);
        isPlayerGrounded = false;
        
    }

    


    
        
    
}
