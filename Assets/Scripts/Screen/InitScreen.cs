using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Las clases Screen son utilizadas para agrupar los elementos de la interfaz de usuario y programar las
/// animaciones
/// </summary>
public class InitScreen : MonoBehaviour
{
    [Tooltip("Botón para iniciar el servidor TCP")]
    public Button startServerButton;
    [Tooltip("Botón para detener el servidor TCP")]
    public Button stopServerButton;
    [Tooltip("Botón para indicarle al cliente que inicie el envio de datos")]
    public Button startButton;
    [Tooltip("Botón para indicarle al cliente que detenga el envio de datos")]
    public Button stopButton;
    [Tooltip("Texto para mostrar los datos recibidos")]
    public Text displayMessageText;
}
