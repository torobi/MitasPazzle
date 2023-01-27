using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockViewFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    
    public GameObject GetBlockGameObject(Vector3 position, Vector3 scale)
    {
        var original = blocks[Random.Range(0, blocks.Length)];
        var block = Instantiate(original, position, new Quaternion(0, 0, 90 * Random.Range(0, 4), 0));
        block.transform.localScale = scale;
        return block;
    }
}
