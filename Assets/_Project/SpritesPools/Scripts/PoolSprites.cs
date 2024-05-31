using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolSprites : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCritAttack;
    [SerializeField] private GameObject _prefabDoubleAttack;
    [SerializeField] private GameObject _prefabGhost;
    private Queue<GameObject> _poolCritAttack = new Queue<GameObject>();
    private Queue<GameObject> _poolDoubleAttack = new Queue<GameObject>();
    private Queue<GameObject> _poolGhost = new Queue<GameObject>();


    public static PoolSprites Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public GameObject GetSptire(SpriteType type)
    {

        return type switch
        {
            SpriteType.CRIT => GetSprite(_poolCritAttack, _prefabCritAttack),
            SpriteType.DOUBLE => GetSprite(_poolDoubleAttack, _prefabDoubleAttack),
            SpriteType.GHOST => GetSprite(_poolGhost, _prefabGhost),
            _ => null,
        };
    }

    public void Deactivate(SpriteType type, GameObject obj)
    {
        switch (type)
        {
            case SpriteType.CRIT:
                ReturnInPool(_poolCritAttack, obj);
                break;
            case SpriteType.DOUBLE:
                ReturnInPool(_poolDoubleAttack, obj);
                break;
            case SpriteType.GHOST:
                ReturnInPool(_poolGhost, obj);
                break;
        }
    }

    private GameObject GetSprite(Queue<GameObject> pool, GameObject prefab)
    {
        if (pool.Count > 0)
        {
            var obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return Instantiate(prefab, transform);
        }
    }

    private void ReturnInPool(Queue<GameObject> pool, GameObject prefab)
    {
        prefab.SetActive(false);
        pool.Enqueue(prefab);
    }
}
