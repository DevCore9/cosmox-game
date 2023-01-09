using RiptideNetworking;
using RiptideNetworking.Utils;
using System;
using UnityEngine;

public enum ServerToClientId : ushort
{
    playerSpawned = 1,
}

public enum ClientToServerId : ushort
{
    name = 1,
}

public class NetworkManager : MonoBehaviour
{
    public GameObject ConnectedToServer;
    public GameObject contactUI;
    public GameObject MainUI;
    public GameObject MainUIBackground;
    public GameObject ConnectionFailed;
    public GameObject LostConnection;
    private static NetworkManager _singleton;
    public static NetworkManager Singleton
    

    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(NetworkManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    public Client Client { get; private set; }

    [SerializeField] private string ip;
    [SerializeField] private ushort port;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, true);

        Client = new Client();
        Client.Connected += DidConnect;
        Client.ConnectionFailed += FailedToConnect;
        Client.ClientDisconnected += PlayerLeft;
        Client.Disconnected += DidDisconnect;
        Client.Disconnected += DidDisconnectUI;
    }

    private void FixedUpdate()
    {
        Client.Tick();
    }

    private void OnApplicationQuit()
    {
        Client.Disconnect();
    }

    public void Connect()
    {
        Client.Connect($"{ip}:{port}");
    }

    private void DidConnect(object sender, EventArgs e)
    {
        ConnectedToServer.SetActive(true);contactUI.SetActive(false);MainUI.SetActive(true);MainUIBackground.SetActive(true);
        UIManager.Singleton.SendName();
    }

    private void FailedToConnect(object sender, EventArgs e)
    {
        ConnectionFailed.SetActive(true);ConnectedToServer.SetActive(false);
        UIManager.Singleton.BackToMain();
    }

    private void PlayerLeft(object sender, ClientDisconnectedEventArgs e)
    {
        Destroy(Player.list[e.Id].gameObject);
    }

    private void DidDisconnect(object sender, EventArgs e)
    {
        LostConnection.SetActive(true);ConnectedToServer.SetActive(false);MainUI.SetActive(false);
        UIManager.Singleton.BackToMain();
    }

    
    private void DidDisconnectUI(object sender, EventArgs e)
    {
        LostConnection.SetActive(true);ConnectedToServer.SetActive(false);
        UIManager.Singleton.BackToMain();
    }
}