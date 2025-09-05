using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    Ui_Manager ui;
    private void Start()
    {
        GameObject U = GameObject.Find("NetWorkUi");
        ui = U.GetComponent<Ui_Manager>();
        // NetworkManagerが初期化されていることを確認
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsClient)
        {
            ulong clientId = NetworkManager.Singleton.LocalClient.ClientId;
            Debug.Log("クライアントID: " + clientId);
            ui.Set(clientId);
        }
        else
        {
            Debug.LogWarning("NetworkManagerが初期化されていないか、クライアントとして接続されていません。");
        }
    }
    private void Update()
    {
        if (IsOwner == false)
        {
            return;
        }

        Vector2 direction = new Vector2()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical")
        };
        float moveSpeed = 3f;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}