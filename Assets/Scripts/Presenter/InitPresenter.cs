using VContainer.Unity;

public class InitPresenter: IInitializable, ITickable
{
    private readonly InitScreen _initScreen;
    private readonly ISocketService _socketService;

    public InitPresenter(InitScreen initScreen, ISocketService socketService)
    {
        _initScreen = initScreen;
        _socketService = socketService;
    }

    public void Initialize()
    {
        _initScreen.startServerButton.onClick.AddListener(_socketService.StartServer);
        _initScreen.stopServerButton.onClick.AddListener(_socketService.StopServer);
        _initScreen.startButton.onClick.AddListener(_socketService.SendStartMessage);
        _initScreen.stopButton.onClick.AddListener(_socketService.SendStopMessage);
    }

    public void Tick()
    {
        _initScreen.displayMessageText.text = _socketService.Buffer;
    }
}
