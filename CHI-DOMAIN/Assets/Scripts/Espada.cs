using UnityEngine;

public class Espada : MonoBehaviour
{
    public float danoEspada = 100f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica se colidiu com um objeto que tem a tag "Inimigo"
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            // Acessa o script do inimigo para pegar o dano
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                //MatarInimigo(inimigo.vidaInimigo);
                Destroy (collision.gameObject);
                
                
            }
        }
    }

    /*
    public void MatarInimigo(float vidaInimigo)
    {
        if (vidaInimigo <= danoEspada)
        {
            Destroy (collision.gameObject);
        }
    } 
    */
}
