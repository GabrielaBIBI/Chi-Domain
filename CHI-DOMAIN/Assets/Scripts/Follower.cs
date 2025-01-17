using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform player;  // Referência ao jogador
    public float speed = 5f;  // Velocidade de movimento do seguidor
    public float followDistance = 2f;  // Distância para seguir o jogador

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
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