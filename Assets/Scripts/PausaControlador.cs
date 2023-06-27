using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausaControlador : MonoBehaviour
{
	public GameObject panelPausa, btnVolar;
	private bool estaPausado = false;
	public Button btnPusa;

	void Start()
	{
		Time.timeScale = 1;
		panelPausa.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			if (estaPausado)
			{
				CerrarPausa();
			}
			else
			{
				AbrirPausa();
			}
		}
	}
	private void CerrarPausa()
	{
		panelPausa.SetActive(false);
		Time.timeScale = 1;
		estaPausado = false;
		btnVolar.SetActive(true);
	}
	private void AbrirPausa()
	{
		panelPausa.SetActive(true);
		Time.timeScale = 0;
		estaPausado = true;
		btnVolar.SetActive(false);
	}
	public void CerrarMenuPausa()
	{
		CerrarPausa();
	}
	public void BotonPausa()
	{ //btnPausa
		if (estaPausado)
		{
			CerrarPausa();
		}
		else
		{
			AbrirPausa();
		}

	}
	public void IrMenu()
	{ //btnTerminarJuego
		CerrarPausa();
		SceneManager.LoadScene("Menu");
	}
	public void Reiniciar()
    {

		CerrarPausa();
		SceneManager.LoadScene("Juego");
	}
}
