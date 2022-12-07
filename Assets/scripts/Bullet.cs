using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;
    [SerializeField] private float bounseForce;
    [SerializeField] private float bounseDistance;

    private Vector3 moveDirection;

    void Start()
    {
        moveDirection = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out BlockTower block))
            {
                block.Break();
                Destroy(gameObject);
            }
      if (other.TryGetComponent(out ObstacleChapter obstacleChapter))
        {
            moveDirection = Vector3.right + Vector3.up;
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(bounseForce, transform.position + new Vector3(0,-1,1),bounseDistance);
        }
    }

}
