using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    Ui_Manager ui;
    public override void OnNetworkSpawn()
    {
        // ホスト(サーバー)判定
        if (IsServer)
        {
            // ホスト(サーバー)側で、初期位置にtransformを書きかえる
            Debug.Log("IsServer");
        }

        // Prefabのオーナー判定
        if (IsOwner)
        {
            // クライアントがホスト(サーバー)に接続する度に、
            // Prefabが生成されOnNetworkSpawnが実行されるので、
            // オーナーのPrefabオブジェクトのみカメラを移動させるようにしている
            Debug.Log("IsOwner");
        }
    }
        /*private void Start()
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
        }*/
        private void Update()
        {
            if (IsClient == false)
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