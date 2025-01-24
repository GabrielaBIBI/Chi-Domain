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

    void Start()
    {
        
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
}
