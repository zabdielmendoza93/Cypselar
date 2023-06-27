using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instancia;
    public static int multiplicador = 1;
    public static bool regresando;

    public AudioSource reproductor;
    public AudioClip vuela, muerte;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    public GameObject camara,panelGameOver,panelBtnVolar, panelMarcador;
    public bool flotando, estaVivo;
    public float valorOffset = 0;
    
    private float fuerzaRebote = 1.3f;
    private Button btnVolar;

    public Text txtMultiplicador;
    public Text txtMultiplicadorGO, txtPuntosGO;
    private void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
        }
        estaVivo = true;
        regresando = false;
        flotando = false;
        btnVolar = GameObject.FindGameObjectWithTag("btnVolar").GetComponent<Button>();
        btnVolar.onClick.AddListener( () => FlotaSemilla() );
        
        AsignaPosYCamera();
    }
    void FixedUpdate()
    {
        if (estaVivo)
        {
            if (regresando)
            {
                rb.velocity = new Vector2(0,10);
                camara.transform.position = new Vector3(0, transform.position.y, -10);
            }
            else 
            { 
                if (flotando)
                {
                    flotando = false;
                    rb.velocity = new Vector2(0, (fuerzaRebote + PuntajeControlador.salto));
                    anim.SetBool("flota", true);
                }

                if (rb.velocity.y >= 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    anim.SetBool("flota", false);
                    float angulo = 0;
                    angulo = Mathf.Lerp(0, -90, -rb.velocity.y / 21);
                    transform.rotation = Quaternion.Euler(0, 0, angulo);
                }
            }
        }
    }
    private void AsignaPosYCamera()
    {
        Camara.offsetY = Camera.main.transform.position.y - transform.position.y - valorOffset;
    }

    public float ObtenPosY()
    {
        return transform.position.y;
    }
    public void FlotaSemilla()
    {
        flotando = true;
        if (AudioControlador.statusAudio)
        {
            reproductor.PlayOneShot(vuela);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ave")
        {
            Muerte();
            Debug.Log("AVE");
        }
        if(collision.tag == "BajoNivel")
        {
            AumentaMultiplicador();
            EscribeMulti();
            regresando = true;
        }
        if(collision.tag == "AltoNivel")
        {
            regresando = false;
            rb.velocity = new Vector2(0, 0);
            camara.transform.position = new Vector3(0, transform.position.y, -10);
            Debug.Log("ALTO NIVEL");
        }
        if(collision.tag == "LimiteMortal")
        {
            SubeSemilla();
            
            Debug.Log("CAIDA");
            if (!estaVivo)
            {
                Time.timeScale = 0;
            }
            Muerte();
        }
    }

    private void Muerte()
    {
        if (estaVivo)
        {
            anim.SetTrigger("muerte");
            estaVivo = false;
            panelGameOver.SetActive(true);
            panelBtnVolar.SetActive(false);
            panelMarcador.SetActive(false) ;

            if (AudioControlador.statusAudio)
            {
                reproductor.PlayOneShot(muerte);
            }

            txtMultiplicadorGO.text = "x" + PuntajeControlador.multiplicador.ToString();
            txtPuntosGO.text =  PuntajeControlador.puntuacion.ToString();
        }
        

    }
    private void AumentaMultiplicador()
    {
        if (PuntajeControlador.multiplicador <= 10)
        {
            PuntajeControlador.multiplicador++;

        }
        else
        {
            PuntajeControlador.multiplicador = PuntajeControlador.multiplicador + 10;
        }
        EscribeMulti();
    }
    private void EscribeMulti()
    {
        txtMultiplicador.text = "x" + PuntajeControlador.multiplicador.ToString();
    }

    private void SubeSemilla()
    {
        if (estaVivo)
        {

            float limite = transform.position.y + 4.0f;
            if (transform.position.y < limite)
            {
                rb.velocity = new Vector2(0, 3);
                rb.gravityScale = 0.2f;

            }
            else
            {
                Debug.Log("Cayendo");
                rb.velocity = new Vector2(0, 0);

            }
        } else
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
        }
    }
}
