using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFactory : MonoBehaviour
{
    public static int _totalEnemy = 1;
    public static int _summonValue = 1;
    public static Vector3 _size = Vector3.zero;
    public static int _maxValue = 64;

    // Start is called before the first frame update
    void Start()
    {
        _summonValue = 2;
        _size = transform.localScale;
    }

    public static void Multiply()
    {
        _summonValue *= 2;
        if(_summonValue > _maxValue) _summonValue -= _maxValue;
    }

    public static void AddTotalEnemy()
    {
        _totalEnemy++;
    }

    //public GameObject _enemy;

    //public float _coolTime;

    //private int _summonValue = 2;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(Summon());

    //    _summonValue = 2;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //NavMeshHit hit;
    //    //if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
    //    //{
    //    //    à íuÇNavMeshì‡Ç…ï‚ê≥
    //    //    transform.position = hit.position;
    //    //}


    //}

    //// è¢ä´
    //IEnumerator Summon()
    //{
    //    while (true)
    //    {
    //        for(int i = 0; i < _summonValue; i++)
    //        {
    //            float x = Random.Range(-transform.localScale.x, transform.localScale.x); //-4.5Ç©ÇÁ4.5ÇÃä‘Ç≈ÉâÉìÉ_ÉÄ
    //            float z = Random.Range(-transform.localScale.z, transform.localScale.z); //-4.5Ç©ÇÁ4.5ÇÃä‘Ç≈ÉâÉìÉ_ÉÄ

    //            _enemy.transform.position = new Vector3(x / 2, 1f, z / 2);

    //            Instantiate(_enemy);
    //        }

    //        _summonValue *= 2;
    //        yield return new WaitForSeconds(_coolTime);
    //    }
    //}
}
