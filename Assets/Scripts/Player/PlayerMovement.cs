using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
     private Rigidbody rb;
     public Vector3 _input;
     private Camera cam;
    public LayerMask whatisGround;
    public LayerMask rayGround;
    public AnimationCurve animCurve;
    public float time;
    

    public float dashDistance = 5f; 
    public float dashTime = 0.5f; 
    public float dashCooldown = 2f; 
    public bool canDash = true;   
    public float obstacleCheckDistance = 1f;

    public bool dashVariant;

    public KeyCode dashKey;

    public static PlayerMovement instance;

    public float gravity;
    private Vector3 playerPos;

    public bool isGrounded = false;
    public Vector3 lastPos;

    public Texture2D mouseTex;
    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        playerPos.y = gravity;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        Cursor.SetCursor(PlayerSettings.defaultCursor, PlayerSettings.cursorHotspot, CursorMode.ForceSoftware);
        Cursor.visible = true;

       
       
    }

   
    void Update()
    {
       // AllignWithSurface();

        MovementInput();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f, whatisGround))
        {
            isGrounded = true;
            lastPos = transform.position;


        }
        else
        {
            isGrounded = false;
        }


        if (!isGrounded)
        {
            gravity = -91.8f;
            speed = 0.1f;
        }
        else
        {
            gravity = 0f;
            speed = 5;

        }

        if (Input.GetKeyDown(dashKey))
        {                

            if(_input.magnitude == 0 )
            {
                
                Dash();
            } 
            else
            {
                Dash2(_input, cam);
            }
            
        }
    }

    private void FixedUpdate()
    {

        


        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        Move();
        PlayerRotation();



    }


    public void MovementInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        

    }


    public void Move()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Keep the movement on the XZ plane
        cameraForward.Normalize();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = (horizontalInput * Camera.main.transform.right) + (verticalInput * cameraForward);
        movementDirection.Normalize();

         
        Vector3 velocity = movementDirection * speed;

        rb.AddForce(velocity, ForceMode.VelocityChange);
        float drag = 10f; // Change this value to adjust the player's drag
        rb.drag = drag;
    }

    public void PlayerRotation()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitinfo, maxDistance: 300f, rayGround))
        {
            var target = hitinfo.point;

            target.y = transform.position.y;
            transform.LookAt(target);
        }


    }

 

    public void Dash()
    {
        if (canDash)
        {
            canDash = false;
            StartCoroutine(DoDash());
        }
    }

    public void Dash2(Vector3 dashDirection, Camera camera)
    {
        if (canDash)
        {
            canDash = false;
            Vector3 cameraRelativeDirection = CamRelativeDirection(dashDirection, camera);
            Vector3 endPos = transform.position + cameraRelativeDirection.normalized * dashDistance;

            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, cameraRelativeDirection, out hit, obstacleCheckDistance))
            {
                Debug.Log(hit.point);
                endPos = hit.point;
            }
            StartCoroutine(DoDash2(endPos));
        }

        if(rb.velocity == new Vector3(0, 0, 0))
        {
            return;
        }
    }


    private IEnumerator DoDash()
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + transform.forward * dashDistance;

        while (elapsedTime < dashTime)
        {
            float t = elapsedTime / dashTime;

           
            float y = Mathf.Sin(t * Mathf.PI);
            Vector3 pos = Vector3.Lerp(startPos, endPos, t);
            pos.y += y * 0.5f; 
            transform.position = pos;           

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private IEnumerator DoDash2(Vector3 endPos)
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < dashTime)
        {
            float t = elapsedTime / dashTime;

            
            float y = Mathf.Sin(t * Mathf.PI);
            Vector3 pos = Vector3.Lerp(startPos, endPos, t);
            pos.y += y * 0.5f; 

            transform.position = pos;        
            

            elapsedTime += Time.deltaTime;
           
            yield return null;
        }

        transform.position = endPos;
        yield return new WaitForSeconds(dashCooldown);
      

        canDash = true;
    }

    private Vector3 CamRelativeDirection(Vector3 direction, Camera camera)
    {
        
        Vector3 cameraForward = camera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        
        Vector3 cameraRight = camera.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        
        Vector3 cameraRelativeDirection = cameraForward * direction.z + cameraRight * direction.x;
        cameraRelativeDirection.y = 0f;
        cameraRelativeDirection.Normalize();

        return cameraRelativeDirection;
    }

    public Vector3 MouseDirection()
    {
       
        Vector3 mousePos = Input.mousePosition;        
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));        
        Vector3 direction = (worldPos - Camera.main.transform.position).normalized;       
        return direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Reset"))
        {
            
            transform.position = lastPos ;
        }
    }

  
}
