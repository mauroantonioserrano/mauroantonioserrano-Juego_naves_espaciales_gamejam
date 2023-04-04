using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 3f; // Tiempo de vida de la bala

    private void Start()
    {
        // Destruye la bala después del tiempo especificado
        Destroy(gameObject, lifetime);
        DontDestroyOnLoad(gameObject); // Evita que se destruya el prefab original
    }
}
