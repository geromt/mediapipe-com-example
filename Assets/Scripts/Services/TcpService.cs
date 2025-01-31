using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

class TcpService: ISocketService
{
    private readonly int _port;
    private TcpListener _server;
    private TcpClient _client;
    private NetworkStream _stream;
    private bool _isRunning;
    private bool _isWaitingMessage;
    private CancellationTokenSource _cancellationTokenSource;

    private string _buffer;
    public string Buffer => _isWaitingMessage ? _buffer : "";
    public bool IsWaitingClient { get; private set; }
    
    public TcpService(int port)
    {
        _port = port;
    }
    
    public async void StartServer()
    {
        int bytesRead;
        var buffer = new byte[1024];

        try
        {
            _server = new TcpListener(IPAddress.Any, _port);
            _server.Start();

            // Espera a que un cliente se conecte al servidor. En este momento se debe iniciar el programa de Python.
            // De preferencia revisar que IsWaitingClient sea verdadero antes de iniciar el programa de Python.
#if UNITY_EDITOR
            Debug.Log("Esperando cliente...");
#endif
            IsWaitingClient = true;
            _client = await _server.AcceptTcpClientAsync();
            IsWaitingClient = false;
#if UNITY_EDITOR
            Debug.Log("Se ha conectado un cliente.");
#endif

            _stream = _client.GetStream();
            _cancellationTokenSource = new CancellationTokenSource();
            _isRunning = true;

            // Mientras el servidor está corriendo y el cliente está conectado se debe de encontrar en este ciclo
            while (_isRunning)
            {
                // Esperamos a que llegue un mensaje del cliente y lo guardamos en el buffer. Este buffer luego
                // puede ser leído de Buffer.
                if ((bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, _cancellationTokenSource.Token)) != 0)
                    _buffer = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
        }
        catch (ObjectDisposedException)
        {
            Debug.Log("Se ha cerrado el servidor mientras no se esperaba el mensaje del cliente");
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
        finally
        {
            _isRunning = false;
            _isWaitingMessage = false;
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _stream?.Close();
            _client.Close();
            _server.Stop();
        }
    }
    
    public void SendStartMessage()
    {
        if (!_isRunning) return;
        
        SendMessage("start");
        _isWaitingMessage = true;
    }
    
    public void SendStopMessage()
    {
        if (!_isRunning) return;
        
        SendMessage("stop");
        _isWaitingMessage = false;
    }
    
    public void StopServer()
    {
        _cancellationTokenSource.Cancel();
        _stream.Close();
        _isRunning = false;
    }
    
    private async void SendMessage(string message)
    {
        var data = Encoding.UTF8.GetBytes(message);
        await _stream.WriteAsync(data, 0, data.Length);
    }
}