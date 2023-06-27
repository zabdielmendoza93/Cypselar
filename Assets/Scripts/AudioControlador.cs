using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioControlador : MonoBehaviour
{
	public AudioSource reproductor;
	public Button btnApagarSnd;
	public Sprite snd0, snd1;

	public static float volumen; //0-1
	public static bool statusAudio = true;// Endendido-Apagado
	void Start()
	{
		if (volumen == 0)
		{
			Debug.Log("Sin modificar");
		}
		else
		{
			reproductor.volume = volumen; //Asigna valores de vol al regresar del juego
		}
		if (!statusAudio)
		{
			reproductor.Stop();
			btnApagarSnd.image.sprite = snd1;
		}
		else
		{
			btnApagarSnd.image.sprite = snd0;
		}
	}

	public void ActivaAudio()
	{
		if (statusAudio)
		{
			reproductor.Stop();
			statusAudio = false;
			btnApagarSnd.image.sprite = snd1;
		}
		else
		{
			reproductor.Play();
			statusAudio = true;
			btnApagarSnd.image.sprite = snd0;
		}
	}
}
