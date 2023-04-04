using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento de la nave
    public float limiteDerecho = 7f; // Límite derecho de la pantalla
    public float limiteIzquierdo = -7f; // Límite izquierdo de la pantalla
    public float limiteSuperior = 4f; // Límite superior de la pantalla
    public float limiteInferior = -4f; // Límite inferior de la pantalla

    void Update()
    {
        // Obtener la posición actual de la nave
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

        // Establecer la nueva posición de la nave
        transform.position = posicionActual;
    }
}
