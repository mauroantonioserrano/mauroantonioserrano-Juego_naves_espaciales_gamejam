using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento de la nave
    public float limiteDerecho = 7f; // L�mite derecho de la pantalla
    public float limiteIzquierdo = -7f; // L�mite izquierdo de la pantalla
    public float limiteSuperior = 4f; // L�mite superior de la pantalla
    public float limiteInferior = -4f; // L�mite inferior de la pantalla

    void Update()
    {
        // Obtener la posici�n actual de la nave
        Vector3 posicionActual = transform.position;

        // Movimiento horizontal de la nave
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        posicionActual.x += movimientoHorizontal * velocidadMovimiento * Time.deltaTime;

        // Limitar el movimiento horizontal de la nave
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);

        // Movimiento vertical de la nave
        float movimientoVertical = Input.GetAxis("Vertical");
        posicionActual.y += movimientoVertical * velocidadMovimiento * Time.deltaTime;

        // Limitar el movimiento vertical de la nave
        posicionActual.y = Mathf.Clamp(posicionActual.y, limiteInferior, limiteSuperior);

        // Establecer la nueva posici�n de la nave
        transform.position = posicionActual;
    }
}
