using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity = 5;

    [SerializeField] private float _enemy1Probability = 0.5f;
    [SerializeField] private float _enemy2Probability = 0.3f;
    [SerializeField] private float _enemy3Probability = 0.2f;

    private List<EnemyMoverType1> _pool1 = new List<EnemyMoverType1>();    
    private List<EnemyMoverType2> _pool2 = new List<EnemyMoverType2>();
    private List<EnemyMoverType3> _pool3 = new List<EnemyMoverType3>();

    public void Create(EnemyMoverType1 prefab1, EnemyMoverType2 prefab2, EnemyMoverType3 prefab3)
    {
        for (int i = 0; i < _capacity; i++)
        {
            {
                float randomValue = Random.value;

                if (randomValue < _enemy1Probability)
                {
                    EnemyMoverType1 enemy1 = Instantiate(prefab1, _container.transform);
                    enemy1.gameObject.SetActive(false);
                    _pool1.Add(enemy1);
                }
                else if (randomValue < _enemy1Probability + _enemy2Probability)
                {
                    EnemyMoverType2 enemy2 = Instantiate(prefab2, _container.transform);
                    enemy2.gameObject.SetActive(false);
                    _pool2.Add(enemy2);
                }
                else
                {
                    EnemyMoverType3 enemy3 = Instantiate(prefab3, _container.transform);
                    enemy3.gameObject.SetActive(false);
                    _pool3.Add(enemy3);
                }
            }
        }
    }

    protected bool TryGetObject(out EnemyMoverType1 result1, out EnemyMoverType2 result2, out EnemyMoverType3 result3)
    {
        result1 = _pool1.FirstOrDefault(p => p.gameObject.activeSelf == false);
        result2 = _pool2.FirstOrDefault(p => p.gameObject.activeSelf == false);
        result3 = _pool3.FirstOrDefault(p => p.gameObject.activeSelf == false);

        if (result1 == null && result2 == null && result3 == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}