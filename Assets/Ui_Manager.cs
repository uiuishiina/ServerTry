using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class Ui_Manager : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button stopButton;

    [SerializeField] private Text text;
    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
            NetworkManager.Singleton.StartHost();
            text.text = "Server";
        });
        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            text.text = "Client";
        });
        stopButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            text.text = "Shutdown";
        });
    }
    private void OnClientConnected(ulong clientId)
    {
        Debug.Log("XXXX");
    }
    public void Set(ulong id)
    {
        text.text = id.ToString();
    }
}