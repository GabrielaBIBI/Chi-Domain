using UnityEngine;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private Rigidbody rb;
    private Vector3 movePlayer;

    //private Vector3 moveVelocity;
    //private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movePlayer = new Vector3 (Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        movePlayer.Normalize();
        rb.linearVelocity = movePlayer * moveSpeed;
        //moveVelocity = movePlayer * moveSpeed * Time.deltaTime;

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
        //rb.velocity = moveVelocity;
    }
}
