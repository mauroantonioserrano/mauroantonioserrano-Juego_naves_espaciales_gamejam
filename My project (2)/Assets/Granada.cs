using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    public GameObject efectoExplosion;


    public float daley = 2f;
    public float ForceExplosion = 10f;
    public float radius = 20f;

    public AudioSource audioSource;
    public AudioClip sonidoExplosion;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("ExplosionGranada", daley);
    }

    void ExplosionGranada()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider x in colliders)
        {
            Rigidbody rb = x.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(ForceExplosion, transform.position, radius, 1f, ForceMode.Impulse);
   
            }
        }
        Instantiate(efectoExplosion, transform.position, transform.rotation);
        ReproducirSonido(sonidoExplosion);
        Destroy(gameObject,2);
    }

    void ReproducirSonido(AudioClip exposionclip)
    {
        audioSource.clip = exposionclip;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

  
}
