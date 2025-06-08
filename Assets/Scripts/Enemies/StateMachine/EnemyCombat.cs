using UnityEngine;

namespace Enemies
{
    public class EnemyCombat : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _attackRange;

        public float AttackRange => _attackRange;
    }
}