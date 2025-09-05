using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class Ui_Manager : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Text text;
    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            text.text = "Server";
        });
        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            text.text = "Client";
        });
    }

    public void Set(ulong id)
    {
        text.text = id.ToString();
    }
}