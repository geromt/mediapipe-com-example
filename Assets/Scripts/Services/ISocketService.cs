public interface ISocketService
{
    /// <summary>
    /// Regresa el mensaje recibido si se está esperando uno, si no regresa una cadena vacía.
    /// </summary>
    string Buffer { get; }
    
    /// <summary>
    /// Regresa verdadero si se está esperando a que un cliente se conecte.
    /// </summary>
    bool IsWaitingClient { get; }
    
    /// <summary>
    /// Inicia el servidor. Espera una conexión con el cliente 
    /// </summary>
    void StartServer();
    
    /// <summary>
    /// Si el servidor está corriendo, envía el mensaje "start" al cliente.
    /// </summary>
    void SendStartMessage();
    
    /// <summary>
    /// Si el servidor está corriendo, envía el mensaje "stop" al cliente.
    /// </summary>
    void SendStopMessage();
    
    /// <summary>
    /// Detiene el servidor TCP.
    /// </summary>
    void StopServer();
}