using UnityEngine;

public class BrickCreator : MonoBehaviour
{
    [SerializeField] private GameObject _normalBrickPrefab;

    [SerializeField] private GameObject _bombBrickPrefab;

    [SerializeField] private GameObject _rootBrickPrefab;

    [SerializeField] private Sprite _bomBrickSprite;

    private void Start()
    {

    }

    public GameObject GetBrickOfType(BRICK_TYPE type, Vector3 spawnPos, Transform parent)
    {
        GameObject newBrick = null;
        if (type == BRICK_TYPE.NORMAL)
        {
            newBrick = Instantiate(_normalBrickPrefab, spawnPos, Quaternion.identity, parent);
        }
        if (type == BRICK_TYPE.BOMB)
        {
            newBrick = Instantiate(_bombBrickPrefab, spawnPos, Quaternion.identity, parent);
        }
        if (type == BRICK_TYPE.ROOT)
        {
            newBrick = Instantiate(_rootBrickPrefab, spawnPos, Quaternion.identity, parent);
        }
        return newBrick;
    }
}