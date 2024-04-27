using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;

    private Rigidbody _rb;

    private GameObject _target;

    private float _runAwayDistance = 10f;

    [SerializeField]
    private GameObject _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();

        _target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //カメラからプレイヤーの位置と自身までの距離を計算
        var playerTransform = _target.transform;
        var distance = Vector3.Distance(playerTransform.position, transform.position);
        //NavMeshの目的地を計算
        var direction = (transform.position - playerTransform.position).normalized;
        direction.y = 0;
        var destination = transform.position + direction * _runAwayDistance;

        _agent.SetDestination(destination);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Summon();
            Score.AddScore();

            Destroy(this.gameObject);
        }
    }

    // 死んだときに呼ぶ
    private void Summon()
    {
        if (EnemyFactory._totalEnemy > EnemyFactory._maxValue) return;

        for (int i = 0; i < EnemyFactory._summonValue; i++)
        {
            float x = Random.Range(-EnemyFactory._size.x, EnemyFactory._size.x); //-4.5から4.5の間でランダム
            float z = Random.Range(-EnemyFactory._size.z, EnemyFactory._size.z); //-4.5から4.5の間でランダム

            _enemy.transform.position = new Vector3(x / 2, 1f, z / 2);

            Instantiate(_enemy);
            EnemyFactory.AddTotalEnemy();
        }

        EnemyFactory.Multiply();
    }
}
