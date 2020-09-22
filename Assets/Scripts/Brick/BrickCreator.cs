using UnityEngine;

public class BrickCreator : MonoBehaviour
{
    [SerializeField] private GameObject _brickPrefab;

    private void Start()
    {

    }

    public GameObject GetBrickOfType(BRICK_TYPE type, Vector3 spawnPos, Transform parent)
    {
        var newBrick = Instantiate(_brickPrefab, spawnPos, Quaternion.identity, parent);
        if (type == BRICK_TYPE.NORMAL)
        {

        }
        if (type == BRICK_TYPE.BOMB)
        {
            newBrick.GetComponent<SpriteRenderer>().color = Color.red;
            newBrick.AddComponent<BombBrick>();
        }
        if (type == BRICK_TYPE.ROOT)
        {
            newBrick.GetComponent<SpriteRenderer>().color = Color.green;
        }
        return newBrick;
    }
}