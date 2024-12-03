using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{
    public Transform[] segments; // Segmentos del fondo
    public float scrollSpeed; // Velocidad base del fondo
    public float segmentWidth; // Ancho de cada segmento

    void Update()
    {
        foreach (Transform segment in segments)
        {
            // Mueve cada segmento con el factor de paralaje
            if (Input.GetAxisRaw("Horizontal") > 0)
                segment.position += Vector3.left * scrollSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;

            // Si el segmento sale de la pantalla, recíclalo al final. -5 es un ajuste fino para que no se vea el cambio en cámara
            if (segment.position.x <= -segmentWidth - 5)
            {
                Vector3 newPos = segment.position;
                newPos.x += segmentWidth * segments.Length;
                segment.position = newPos;
            }
        }
    }
}
