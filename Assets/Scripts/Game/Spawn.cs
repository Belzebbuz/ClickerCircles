using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Spawn : MonoBehaviour
{

    [SerializeField] private Arrow arrow;
    private float _spawnTimer;
    public static Spawn Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        transform.position = Border.Instance.GetSpawnPoint();
    }
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0f)
        {
            _spawnTimer = GameManager.Instance.spawnTime;
            Spawn_a();
        }
        
    }

    public void Spawn_a()
    {
        int value = Random.Range(1, 5);
        if (value == 1)
        {
            InitIcon(new Quaternion(1, 1, 0, 0), ArrowsType.Up);
        }
        else if (value == 2)
        {
            InitIcon(new Quaternion(0, 0, 0, 0), ArrowsType.Right);
        }
        else if (value == 3)
        {
            InitIcon(new Quaternion(0, 1, 0, 0), ArrowsType.Left);
        }
        else
        {
            InitIcon(new Quaternion(1, -1, 0, 0), ArrowsType.Down);
        }
    }
    private void InitIcon(Quaternion quaternion, ArrowsType arrowType)
    {
        Arrow t = Instantiate(arrow, transform.position, quaternion);
        t.arrT = arrowType;
    }


    
   
}
