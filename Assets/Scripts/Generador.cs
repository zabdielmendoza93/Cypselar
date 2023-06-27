using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject camara;
    public GameObject ave;
    public static float offsetY;
    public static float spawn;
    
    private int moduloAparicion = 9;
    private int cantidadAparicion = 1;


    private float randomSpawn;
    private float randomSpawnX;
    private int corrector;
    void Update()
    {
        if (Player.instancia != null)
        {
            if (Player.instancia.estaVivo)
            {
                MueveGenerador();
            }
        }
        if (!Player.regresando) { 
            if((int)(Time.time + corrector) % moduloAparicion == 1)
            {
                if (GameObject.FindGameObjectsWithTag("ave").Length < cantidadAparicion)
                {

                    if (Player.instancia.estaVivo)
                    {
                        GeneraAve();
                        if(PuntajeControlador.puntuacion>15)
                            corrector++;
                    }

                }
            }
        }
        if (PuntajeControlador.puntuacion < 15)
        {
            cantidadAparicion = 1;
            moduloAparicion = 7;
        } else if (PuntajeControlador.puntuacion >= 15 && PuntajeControlador.puntuacion < 30){
            cantidadAparicion = 2;
            moduloAparicion = 5;
        } else if(PuntajeControlador.puntuacion >= 30){
            cantidadAparicion=3;
            moduloAparicion = 3;
        }

    }
    void MueveGenerador()
    {
        Vector3 temp = transform.position;
        temp.y = camara.transform.position.y;
        transform.position = temp;
    }

    void GeneraAve()
    {
        randomSpawn = Random.Range(-5.0f,5.0f);
        spawn = transform.position.y - randomSpawn;
        Instantiate(ave,new Vector3(transform.position.x,
                                    spawn,
                                    0),
                                    Quaternion.Euler(0, 0, 0) );

    }
}
