using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [SerializeField] bool freezeZAxis = true;
    void Update()
    {
        if (freezeZAxis){
            transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, 0f);
        } else {
            transform.rotation = Camera.main.transform.rotation;
        }   
    }
}
