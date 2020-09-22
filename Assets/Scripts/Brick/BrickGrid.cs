using UnityEngine;

public class BrickGrid : MonoBehaviour
{
    [SerializeField] private int NUM_OF_ROW, NUM_OF_COLUMN;

    [SerializeField] private GameObject _brickPrefab;

    [SerializeField] private float _brickRowSpacing, _brickColumnSpacing;

    [SerializeField] private float _brickWidth, _brickHeight;

    private GameObject[,] _brickGameObjs;

    private void Start()
    {
        var brickCollider = Instantiate(_brickPrefab).GetComponent<BoxCollider2D>();
        _brickWidth = brickCollider.bounds.size.x;
        _brickHeight = brickCollider.bounds.size.y;
        Destroy(brickCollider.gameObject);

        InitBrickGameObjs();
    }

    private void InitBrickGameObjs()
    {
        _brickGameObjs = new GameObject[NUM_OF_ROW, NUM_OF_COLUMN];

        for (int row = 0; row < NUM_OF_ROW; row++)
        {
            for (int column = 0; column < NUM_OF_COLUMN; column++)
            {
                _brickGameObjs[row, column] = Instantiate(
                    _brickPrefab,
                    new Vector3(
                        transform.position.x - (NUM_OF_COLUMN * _brickWidth + (NUM_OF_COLUMN - 1) * _brickColumnSpacing) / 2 + _brickWidth / 2 + column * (_brickWidth + _brickColumnSpacing),
                        transform.position.y + (NUM_OF_ROW * _brickHeight + (NUM_OF_ROW - 1) * _brickRowSpacing) / 2 - _brickHeight / 2 - row * (_brickHeight + _brickRowSpacing),
                        0
                    ),
                    transform.rotation,
                    transform
                );
            }
        }
    }
}