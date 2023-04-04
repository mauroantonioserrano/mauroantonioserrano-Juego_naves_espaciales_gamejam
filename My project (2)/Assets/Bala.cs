using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]float daño;
    [SerializeField]float velocidad;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<Enemigo>().TomarDaño(daño);
            Destroy(gameObject);
        }
    }
}
