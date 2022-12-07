using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder towerBuilder;
    private List<BlockTower> blocks;
    public event UnityAction<int> SizeUpdated;
    void Start()
    {
        towerBuilder = GetComponent<TowerBuilder>();
         blocks = towerBuilder.Build();

        foreach (var block in blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeUpdated?.Invoke(blocks.Count);
    }

    private void OnBulletHit(BlockTower hitblock)
    {
        hitblock.BulletHit -= OnBulletHit;

        blocks.Remove(hitblock);

        foreach (var block in blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y*2, block.transform.position.z);
        }
        SizeUpdated?.Invoke(blocks.Count);
    }

}
