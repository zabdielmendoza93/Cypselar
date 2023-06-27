using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destructor : MonoBehaviour
{

    public GameObject camara;
    public Text txtPuntaje;  
    public AudioSource reproductor;
    public AudioClip punto;

    void Update()
    {
        MueveDestructor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ave")
        {
            Destroy(collision.gameObject);
            PuntajeControlador.puntuacion = PuntajeControlador.puntuacion + (1 * PuntajeControlador.multiplicador);
            EscribePuntaje();
            if(AudioControlador.statusAudio)
                reproductor.PlayOneShot(punto);
        }
    }
    public void MueveDestructor()
    {
        Vector3 temp = transform.position;
        temp.y = camara.transform.position.y;
        transform.position = temp;
        
    }

    private void EscribePuntaje()
    {
        txtPuntaje.text = PuntajeControlador.puntuacion.ToString();
    }

    
    
}
