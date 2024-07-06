using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed, gravityModifier, jumpPower, runSpeed = 12f;
    public CharacterController charCon;

    private Vector3 moveInput;

    public Transform camTrans;

    public float mouseSensitivity, buttonDelay = 2f;
    public bool invertX;
    public bool invertY;

    private bool canJump, canDoubleJump;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    public GameObject camera;

    //public GameObject bullet;
    public Transform firePoint;

    public Transform adsPoint, gunHolder;
    public Vector3 gunStartPosition;
    public float adsSpeed = 2f;
    //private GameManager gm = GameManager.instance;
    public Gun activeGun;

    public bool canShoot = true;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gunStartPosition = gunHolder.localPosition;
    }

    void Update()
    {
        if (GameManager.instance.pause == false)
        {
            //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            //store y velocity
            float yStore = moveInput.y;


            Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
            Vector3 horiMMove = transform.right * Input.GetAxis("Horizontal");

            moveInput = horiMMove + vertMove;
            moveInput.Normalize();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveInput = moveInput * runSpeed;
            }
            else
            {
                moveInput = moveInput * moveSpeed;
            }

            moveInput.y = yStore;

            moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

            if (charCon.isGrounded)
            {
                moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
            }

            canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, whatIsGround).Length > 0;

            //if(canDoubleJump)
            //{
            //    canDoubleJump = false;
            //}

            //Handle Jumping
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                moveInput.y = jumpPower;

                canDoubleJump = true;
            }
            else if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                moveInput.y = jumpPower;

                canDoubleJump = false;
            }


            charCon.Move(moveInput * Time.deltaTime);


            //control camera rotation
            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            if (invertX)
            {
                mouseInput.x = -mouseInput.x;
            }

            if (invertY)
            {
                mouseInput.y = -mouseInput.y;
            }

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

            camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));


            //Handle Shooting
            //single shots
            if (canShoot)
            {

                if (Input.GetMouseButtonDown(0) && activeGun.fireCounter <= 0)
                {

                    RaycastHit hit;
                    if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, 50f))
                    {
                        if (Vector3.Distance(camTrans.position, hit.point) > 2f)
                        {
                            firePoint.LookAt(hit.point);
                        }

                    }
                    else
                    {
                        firePoint.LookAt(camTrans.position + (camTrans.forward * 30f));
                    }

                    //Instantiate(bullet, firePoint.position, firePoint.rotation);
                    FireShot();
                }

                //repeating shots
                if (Input.GetMouseButton(0) && PlayerPrefs.GetInt("autoFire") == 1)
                {
                    if (activeGun.fireCounter <= 0)
                    {
                        FireShot();
                    }
                }

                if (Input.GetMouseButtonDown(1))
                {
                    CameraController.instance.ZoomIn(activeGun.zoomAmount);
                }

                if (Input.GetMouseButton(1))
                {
                    gunHolder.position = Vector3.MoveTowards(gunHolder.position, adsPoint.position, adsSpeed * Time.deltaTime);
                }
                else
                {
                    gunHolder.localPosition = Vector3.MoveTowards(gunHolder.localPosition, gunStartPosition, adsSpeed * Time.deltaTime);
                }

                if (Input.GetMouseButtonUp(1))
                {
                    CameraController.instance.ZoomOut();
                }
            }
        }

        if (Input.GetKeyDown("q"))
        {
            GameManager.instance.upgradeMenuOn();
        }

    }

    public void FireShot()
    {
        //Instantiate(activeGun.bullet, firePoint.position, firePoint.rotation);
        activeGun.GetComponent<Gun>().shoot();
        activeGun.fireCounter = PlayerPrefs.GetFloat("fireRate");
    }

    public void onTurret()
    {
        canShoot = false;
        canJump = false;
        charCon.enabled = false;
        GetComponent<raycastController>().enabled = false;
        activeGun.gameObject.SetActive(false);
    }

    public void offTurret()
    {
        canShoot = true;
        canJump = true;
        charCon.enabled = true;
        GetComponent<raycastController>().enabled = true;
        activeGun.gameObject.SetActive(true);
    }

}

        