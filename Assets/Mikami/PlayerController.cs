using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;

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
                gameObject.transform.position = playerPos + new Vector3(Speed, 0.0f, 0.0f);
                gameObject.transform.rotation = new Quaternion(0.0f, 90.0f, 0.0f, 0.0f);
                break;
            case PLAYER_STATE.PLAYER_MOVE_LEFT:
                gameObject.transform.position = playerPos + new Vector3(-Speed, 0.0f, 0.0f);
                gameObject.transform.rotation = new Quaternion(0.0f, -90.0f, 0.0f, 0.0f);
                break;
            case PLAYER_STATE.PLAYER_MOVE_UP:
                gameObject.transform.position = playerPos + new Vector3(0.0f, 0.0f, Speed);
                gameObject.transform.rotation = new Quaternion(0.0f, 180.0f, 0.0f, 0.0f);
                break;
            case PLAYER_STATE.PLAYER_MOVE_DOWN:
                gameObject.transform.position = playerPos + new Vector3(0.0f, 0.0f, -Speed);
                gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
                break;
        }

        if (Input.GetKey(KeyCode.Space)){
            playerState = PLAYER_STATE.PLAYER_IDLE;
        }
    }

    public void OnCollisionStay(Collision coll)
    {
        if(coll.gameObject.CompareTag("Wall"))
        {
            playerState = PLAYER_STATE.PLAYER_IDLE;
        }
    }
}
