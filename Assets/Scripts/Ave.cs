using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ave : MonoBehaviour
{
    public Rigidbody2D rb;
    public float offsetY;
    private GameObject generador;
    public float velocidad;

    public AudioSource reproductor;
    private float posY;
  
    void Start()
    {
        generador = GameObject.FindGameObjectWithTag("generador");
        transform.position = generador.transform.position;
        posY = Random.Range(-5.8f, 5.8f);

    }

    void Update()
    {
        if (Player.instancia != null)
        {
            MovimientoAve();
        }
        if (!AudioControlador.statusAudio)
        {
            reproductor.Stop();
        } else
        {
            reproductor.Play();
        }
        if (Player.regresando)
        {
            Destroy(gameObject);
        }
    }
    void MovimientoAve()
    {
        Vector3 temp = transform.position;
        if(PuntajeControlador.puntuacion<12)
            temp.x -= (velocidad + PuntajeControlador.puntuacion/5) *  (Time.deltaTime)  ;
        else
            temp.x -= (velocidad + 3) * (Time.deltaTime);
        temp.z = 0;
        temp.y = generador.transform.position.y + posY;
        transform.position = temp;
    }
}
