using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector3 _prevPosition;

    private enum PLAYER_STATE
    {
        PLAYER_IDLE,
        PLAYER_MOVE_RIGHT,
        PLAYER_MOVE_LEFT,
        PLAYER_MOVE_UP,
        PLAYER_MOVE_DOWN,
        PLAYER_NULL
    }

    private PLAYER_STATE playerState = PLAYER_STATE.PLAYER_IDLE;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = gameObject.transform.position;
        switch (playerState)
        {
            case PLAYER_STATE.PLAYER_IDLE:
                if(Input.GetKey(KeyCode.D)){
                    playerState = PLAYER_STATE.PLAYER_MOVE_RIGHT;
                }else if (Input.GetKey(KeyCode.A)){
                    playerState = PLAYER_STATE.PLAYER_MOVE_LEFT;
                }else if (Input.GetKey(KeyCode.W)){
                    playerState = PLAYER_STATE.PLAYER_MOVE_UP;
                }else if (Input.GetKey(KeyCode.S)){
                    playerState = PLAYER_STATE.PLAYER_MOVE_DOWN;
                }
                break;
            case PLAYER_STATE.PLAYER_MOVE_RIGHT:
                Debug.Log("migi");
                gameObject.transform.position = playerPos + new Vector3(Speed, 0.0f, 0.0f);
                //gameObject.transform.rotation = new Quaternion(0.0f, 90.0f, 0.0f, 0.0f);
                break;
            case PLAYER_STATE.PLAYER_MOVE_LEFT:
                Debug.Log("hidari");
                gameObject.transform.position = playerPos + new Vector3(-Speed, 0.0f, 0.0f);
                //gameObject.transform.rotation = new Quaternion(0.0f, -90.0f, 0.0f, 0.0f);
                break;
            case PLAYER_STATE.PLAYER_MOVE_UP:
                Debug.Log("ue");
                gameObject.transform.position = playerPos + new Vector3(0.0f, 0.0f, Speed);
                //gameObject.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
                break;
            case PLAYER_STATE.PLAYER_MOVE_DOWN:
                Debug.Log("sita");
                gameObject.transform.position = playerPos + new Vector3(0.0f, 0.0f, -Speed);
                //gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                break;
        }

        if (Input.GetKey(KeyCode.Space)){
            playerState = PLAYER_STATE.PLAYER_IDLE;
        }

        UpdateRot();
    }

    public void OnCollisionStay(Collision coll)
    {
        if(coll.gameObject.CompareTag("Wall"))
        {
            playerState = PLAYER_STATE.PLAYER_IDLE;
        }
    }







    private void UpdateRot()
    {
        // 現在フレームのワールド位置
        var position = transform.position;

        // 移動量を計算
        var delta = position - _prevPosition;

        // 次のUpdateで使うための前フレーム位置更新
        _prevPosition = position;

        // 静止している状態だと、進行方向を特定できないため回転しない
        if (delta == Vector3.zero)
            return;

        // 進行方向（移動量ベクトル）に向くようなクォータニオンを取得
        var rotation = Quaternion.LookRotation(delta, Vector3.up);

        // オブジェクトの回転に反映
        transform.rotation = rotation;
    }
}
