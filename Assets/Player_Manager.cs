using UnityEngine;
using Unity.Netcode;
using System.Linq;
public class Player_Manager : NetworkBehaviour
{
    [SerializeField] private GameObject[] player = null;
    [SerializeField]
    private GameObject MyObject = null;
    Ui_Manager ui;
    private ulong clientId = 0;
    private void Start()
    {
        GameObject U = GameObject.Find("NetWorkUi");
        ui = U.GetComponent<Ui_Manager>();
        // NetworkManagerが初期化されていることを確認
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsClient)
        {
            clientId = NetworkManager.Singleton.LocalClient.ClientId;
            Debug.Log("クライアントID: " + clientId);
            ui.Set(clientId);
        }
        else
        {
            Debug.LogWarning("NetworkManagerが初期化されていないか、クライアントとして接続されていません。");
        }
        if (player.Count()>=2)
        {
            if(clientId < 3)
            {

                MyObject = NetworkBehaviour.Instantiate(player[clientId - 1], transform.position, Quaternion.identity);
                Debug.Log("生成");
            }
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
        MyObject.transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
