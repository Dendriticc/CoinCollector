using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class CastleArea : MonoBehaviour
{
    public List<GameObject> collectibles;
    public GameObject block;
    [Range(0, 5)]
    public float blockOffset = 5f;

    private Vector3 originalBlockPosition;
    private Quaternion originalBlockRotation;

    public float startingBlockPositionZ;


    private void Awake()
    {
        originalBlockPosition = block.transform.position;
        originalBlockRotation = block.transform.rotation;
        block.transform.position += Vector3.forward * Academy.Instance.EnvironmentParameters.GetWithDefault("block_offset", blockOffset);
        
    }

    public void ResetArea()
    {
        foreach (GameObject col in collectibles) col.SetActive(true);

        block.transform.position = originalBlockPosition + Vector3.forward * Academy.Instance.EnvironmentParameters.GetWithDefault("block_offset", blockOffset);
        block.transform.rotation = originalBlockRotation;
        startingBlockPositionZ = block.transform.position.z;
    }

    internal void Collect(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}