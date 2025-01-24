using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    public SpriteRenderer spriteRender;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        //Flip
        if (x != 0 && x < 0){
            spriteRender.flipX = true;
        } else if (x != 0 && x > 0){
            spriteRender.flipX = false;
        }
    }
}
