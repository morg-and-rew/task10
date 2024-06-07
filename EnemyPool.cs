using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity = 5;

    [SerializeField] private float _enemy1Probability = 0.5f;

    private List<EnemyMover> _pool1 = new List<EnemyMover>();    

    public void Create(EnemyMover prefab1)
    {
        for (int i = 0; i < _capacity; i++)
        {
            {
                float randomValue = Random.value;

                if (randomValue < _enemy1Probability)
                {
                    EnemyMover enemy1 = Instantiate(prefab1, _container.transform);
                    enemy1.gameObject.SetActive(false);
                    _pool1.Add(enemy1);
                }
            }
        }
    }

    protected bool TryGetObject(out EnemyMover result1)
    {
        result1 = _pool1.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result1 != null;
    }

}