using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [HideInInspector] public int Damage = 0;
    [HideInInspector] public Transform Target = null;
    [SerializeField] private int speed = 20;

    private void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Enemy>().TakeDamage(Damage);
        Destroy(gameObject);
    }
}
