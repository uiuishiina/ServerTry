using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class Ui_Manager : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    private void Awake()
    {
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        clientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
}