using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float dano = 50f; // Dano que o inimigo causa
    public float danoPlayer = 100f; //Dano recebido pelo inimigo quando o player ataca
    public float vidaInimigo = 100f;

    public Transform player;  // Referência ao jogador
    public float speed = 5f;  // Velocidade de movimento do seguidor
    public float followDistance = 2f;  // Distância para seguir o jogador

    private Rigidbody rb;
    public float giroMorte = -90f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaInimigo > 0) 
        {
            if (player != null)
            {
                // Calcular a posição desejada para seguir o jogador
                Vector3 targetPosition = player.position - player.forward * followDistance;
                
                // Mover o seguidor em direção à posição desejada
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                
                // Opcional: Rotacionar o seguidor para olhar na direção do jogador
                Vector3 direction = player.position - transform.position;
                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
                }
            }
        }

    }

    
    // void  OnTriggerEnter (espadaNoInimigo) {
    void OnCollisionEnter (Collision collision) 
    {
        // Verifica se colidiu com um objeto que tem a tag "Espada"
        if (collision.gameObject.tag == "Player")
        {
            vidaInimigo -= danoPlayer;
            if (vidaInimigo <= 0) 
            {
                transform.rotation = Quaternion.Euler(0, 0, giroMorte);
                MatarInimigo();
            }
            
            // Acessa o script da espada para pegar o dano
            //Espada espada = collision.gameObject.GetComponent<Espada>();

            // Subtrai a vida do inimigo
            /*
            vidaInimigo -= espada.danoEspada;
            if (vidaInimigo <= 0){MatarInimigo();} 
            */
            
        }
    } 
    
    void MatarInimigo()
    {
        Destroy (this.gameObject, 1);
        // or (objclone, 1)
        // gameObject.Destroy ();
        // Destroy (espadaNoInimigo.gameObject);
    }
}
