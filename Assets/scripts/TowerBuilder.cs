using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float towerSize;
    [SerializeField] private Transform SpawnPoint;

    [SerializeField] private BlockTower towerBlock;
    private List<BlockTower> towerBlocks;

    public List<BlockTower> Build()
    {
        towerBlocks = new List<BlockTower>();
        Transform currentPoint = SpawnPoint;

        for (int i = 0; i < towerSize; i++)
        {
            BlockTower newBlock = BuildTower(currentPoint);
            towerBlocks.Add(newBlock);
            currentPoint = newBlock.transform;
            
        }
        return towerBlocks;
    }

    private BlockTower BuildTower(Transform CSpawnPoint)
    {
        
        return Instantiate(towerBlock,GetSpawnPoint(CSpawnPoint), Quaternion.identity, SpawnPoint);

    }

    private Vector3 GetSpawnPoint(Transform curBlock)
    {
        
        return new Vector3(SpawnPoint.position.x,
            curBlock.position.y + curBlock.localScale.y*1.5f + towerBlock.transform.localScale.y/2,
            SpawnPoint.position.z);
    }
}
