using UnityEngine;
using UnityEngine.UI;

public class HealthBar3D : MonoBehaviour
{
    public Transform target;  // Objeto que a barra de vida seguirá
    public Vector3 offset = new Vector3(0, 2, 0); // Posição relativa ao alvo
    public Canvas healthBarCanvas; // Canvas que contém a barra de vida
    public Image healthBarFill;    // Imagem da barra de vida

        // Vida atual e máxima
    [Range(0, 100)]
    public float currentHealth = 100f;
    public float maxHealth = 100f;


    // outro codigo
    public float vida = 100f; // Vida inicial do jogador

    public Slider slider;
    public void AlterarVida(float vidaSlider){
        slider.value = vidaSlider;
    }

    
    private void Update()
    {
        // Atualiza a barra de vida
        UpdateHealthBar();

        // Faz o canvas seguir o alvo
        if (target != null && healthBarCanvas != null)
        {
            healthBarCanvas.transform.position = target.position + offset;
            healthBarCanvas.transform.forward = Camera.main.transform.forward; // Sempre voltado para a câmera
        }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Garante que a vida esteja no intervalo
    }

    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth; // Atualiza a proporção da barra
        }
    }



    // outro codigo
    void OnCollisionEnter(Collision collision)
    {
        // Verifica se colidiu com um objeto que tem a tag "Inimigo"
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            // Acessa o script do inimigo para pegar o dano
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                TakeDamage(inimigo.dano);
                // Subtrai a vida do jogador
                vida -= inimigo.dano;
                AlterarVida(vida);
                // Debug.Log("Vida do jogador: " + vida);
                // Verifica se o jogador morreu
                //if (vida <= 0)
                
                if (currentHealth <= 0)
                {
                    Morrer();
                }
            }
        }
    }
    void Morrer()
    {
        Debug.Log("Jogador morreu!");
        // Aqui você pode adicionar lógica para reiniciar o jogo, exibir uma tela de game over, etc.
    }
}




