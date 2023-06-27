using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public static float offsetY;
    private static float posY;

    void Update()
    {
        if(Player.instancia != null)
        {
            if (Player.instancia.estaVivo)
            {
                MueveCamara();
            }
        }
    }
    private void MueveCamara()
    {
        Vector3 temp = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime/(2 - PuntajeControlador.movCamara)), transform.position.z);
        transform.position = temp;
    }
}
