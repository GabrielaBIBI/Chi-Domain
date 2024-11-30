using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float groundDistance;

    private Rigidbody rb;
    private Vector3 movePlayer;

    public LayerMask terrainLayer;
    public SpriteRenderer spriteRender;



    /* private Camera mainCamera; */

 
    void Start()
    {
        rb = GetComponent<Rigidbody>(); /* ou rb = gameObject.GetComponent<Rigidbody>(); */ 
        /* mainCamera = FindObjectOfType<Camera>(); */
    }


    void Update()
    {
        // Movimento Basico                     ou /* Vector3 movePlayer = new Vector3 (Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); */
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movePlayer = new Vector3(x, 0, y);
        movePlayer.Normalize();
        rb.linearVelocity = movePlayer * moveSpeed; /* * Time.deltaTime; */

        //Flip Player
        if (x != 0 && x < 0){
            spriteRender.flipX = true;
        } else if (x != 0 && x > 0){
            spriteRender.flipX = false;
        }


        // Ajustar Player a altura do chao
        RaycastHit hitGround;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hitGround, Mathf.Infinity, terrainLayer))
        {
            if (hitGround.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hitGround.point.y + groundDistance;
                transform.position = movePos;
            }
        }

        /*Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        PlayerController groundPlane = new PlayerController (Vector3.up, Vector3.zero);
        float ray Length;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetComponent(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }*/

        /*if (movePlayer != Vector3.zero)
        {
            float angle = Mathf.Atan2(movePlayer.y, movePlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler (0,0, angle);
        }*/
    }

    void FixedUpdate()
    {
    }
}

