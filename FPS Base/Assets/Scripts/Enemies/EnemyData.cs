using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float maxHealth;
    public float moveSpeed;
    public float detectionRadius;
    public float attackRange;
    public float attackDamage;
    public float attackCooldown;
}
