using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerData _towerData = null;
    [SerializeField] private GameObject bullet = null;
    private Transform target = null;
    private SphereCollider _collider = null;
    private int _damage = 0;
    private float _range = 0.0f;
    private float _shootInterval = 0.0f;
    private int _buildPrice = 0;
    private Coroutine shootCoroutine = null;
    public int BuildPrice => _buildPrice;

    private void Start()
    {
        _damage = _towerData.Damage;
        _range = _towerData.Range;
        _shootInterval = _towerData.ShootInterval;
        _collider = GetComponent<SphereCollider>();
        _collider.radius = _range;
        shootCoroutine = StartCoroutine(Shoot());
	}


    private void OnTriggerStay(Collider other)
    {
        if (target == null)
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        target = null;
    }

    private IEnumerator Shoot()
    {       
        while (true)
        {
            if (target != null)
            {
                GameObject go = Instantiate(bullet, transform.position, Quaternion.identity);
                Bullet bul = go.GetComponent<Bullet>();
                bul.Target = target;
                bul.Damage = _damage;
            }

            yield return new WaitForSeconds(_shootInterval);
        }       
    }

    private void OnDestroy()
    {
        StopCoroutine(shootCoroutine);
    }

}
