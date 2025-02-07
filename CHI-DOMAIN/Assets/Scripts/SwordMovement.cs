using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    public float AngleSword = 45f;
    public SpriteRenderer spriteRender;

    void Start()
    {

    }

    void Update()
    {
        //Flip
        float x = Input.GetAxis("Horizontal");

        if (x != 0 && x < 0){
            spriteRender.flipX = true;
            AngleSword = -45f;
        } else if (x != 0 && x > 0){
            spriteRender.flipX = false;
            AngleSword = 45f;          
        }
        


        if (Input.GetKey(KeyCode.Space)) 
        {
            transform.rotation = Quaternion.Euler(0,0, AngleSword);
        }
        
    }
  


}

