using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public Text txtCreditos;
    void Start()
    {
        Time.timeScale = 1;
    }

    public void EmpiezaJuego()
    {
        SceneManager.LoadScene("Juego");
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
    public void EscribeCreditos()
    {
        txtCreditos.text = "Zabdiel E. M. Mendoza";
    }
}
