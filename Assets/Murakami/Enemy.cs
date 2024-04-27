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
}
