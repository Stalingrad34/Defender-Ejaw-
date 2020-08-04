
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public EnemyType _enemyType = 0;
    [SerializeField] private int _health = 0;
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private int _damage = 0;
    [SerializeField] private int maxCoins = 0;
    [SerializeField] private int minCoins = 0;

    public int Health => _health;
    public float Speed => _speed;
    public int Damage => _damage;
    public int Coins => Random.Range(minCoins, maxCoins);

    public enum EnemyType
    {
        Skelet,
        Zombi
    }
    private void OnValidate()
    {
        if (_health < 0) _health = 0;
        if (_damage < 0) _damage = 0;
        if (_speed < 0) _speed = 0;
    }
}
