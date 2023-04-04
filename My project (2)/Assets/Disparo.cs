using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip navedisparo;
    public AudioClip navetransmision;
    [SerializeField] private Transform controlador_disparo;
    [SerializeField] private GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ReproducirSonido(navetransmision)", 5f);

        StartCoroutine("Contador");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
            ReproducirSonido(navedisparo);
            
        }

       
    }
    private void Disparar()
    {
        bala.transform.position = controlador_disparo.position;
        bala.transform.rotation = controlador_disparo.rotation;
        Instantiate(bala);
    }
    public void ReproducirSonido(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private IEnumerator Contador() {
        yield return new WaitForSeconds(20f);

        ReproducirSonido(navetransmision);
    }


}
