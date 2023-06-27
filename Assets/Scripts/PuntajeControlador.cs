using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeControlador : MonoBehaviour
{
    public static int puntuacion;
    public static int multiplicador;
    public static float movCamara = 0;
    public static float salto = 0;

    private int multTemp = 1;
    void Start()
    {
        puntuacion = 0;
        multiplicador = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (multTemp < multiplicador)
        {
            movCamara = movCamara + 0.05f;
            salto = salto + 0.02f;
            multTemp = multiplicador;
        }

    }
}
