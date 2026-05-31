using UnityEngine;
using UnityEngine.SceneManagement;

public class controlSecuencia : MonoBehaviour
{
    public static controlSecuencia instancia; // Instancia estática para acceso global
    public ControlTornillo[] SecuenciaTornillos;
    private int pasoActual = 0;
    public GameObject PanelInicio; 
    public GameObject PanelFalla; 
    public GameObject PanelSecuenciaCorrecta; 

    public void VerificarSecuencia(ControlTornillo tornillo)
    {
        if (tornillo == SecuenciaTornillos[pasoActual])
        {
            pasoActual++;
            if (pasoActual >= SecuenciaTornillos.Length)
            {
                Debug.Log("¡Secuencia correcta!");
                PanelSecuenciaCorrecta.SetActive(true); // Mostrar el panel de secuencia correcta
                pasoActual = 0; // Reiniciar la secuencia
            }
        }
        else
        {
            Debug.Log("¡Secuencia incorrecta! Reiniciando...");
            PanelFalla.SetActive(true); // Mostrar el panel de falla 
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0.0f; // Asegurar que el tiempo esté en su escala normal
        PanelInicio.SetActive(true); // Mostrar el panel de inicio al iniciar el juego
        PanelFalla.SetActive(false); // Ocultar el panel de falla al iniciar el juego
        PanelSecuenciaCorrecta.SetActive(false); // Ocultar el panel de secuencia correcta al iniciar el juego
        instancia = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarJuego()
    {
        PanelFalla.SetActive(false); // Ocultar el panel de falla
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena
        pasoActual = 0; // Reiniciar la secuencia
    }

    public void CerrarJuego()
    {
        Application.Quit(); // Cerrar la aplicación
    }

    public void ComenzarJuego()
    {
        PanelInicio.SetActive(false); // Ocultar el panel de inicio
        Time.timeScale = 1.0f; // Reanudar el tiempo para comenzar el juego
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene("Game_Play"); // Cambiar a la escena "Escena2"
    }
}
