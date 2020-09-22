using UnityEngine;

public enum BRICK_TYPE
{
    NORMAL, BOMB, ROOT
}


public class BrickGrid : MonoBehaviour
{
    [SerializeField] private int NUM_OF_ROW, NUM_OF_COLUMN;

    [SerializeField] private GameObject _brickPrefab;

    [SerializeField] private float _brickRowSpacing, _brickColumnSpacing;

    [SerializeField] private float _brickWidth, _brickHeight;

    [SerializeField] private BrickCreator _brickCreator;

    private GameObject[,] _brickGameObjs;

    private void Start()
    {
        var brickCollider = Instantiate(_brickPrefab).GetComponent<BoxCollider2D>();
        _brickWidth = brickCollider.bounds.size.x;
        _brickHeight = brickCollider.bounds.size.y;
        Destroy(brickCollider.gameObject);

        InitFromBrickTypeGrid(new BRICK_TYPE[,] {
            { BRICK_TYPE.NORMAL, BRICK_TYPE.NORMAL, BRICK_TYPE.NORMAL },
            { BRICK_TYPE.NORMAL, BRICK_TYPE.BOMB, BRICK_TYPE.NORMAL },
            { BRICK_TYPE.NORMAL, BRICK_TYPE.NORMAL, BRICK_TYPE.ROOT }
        });
    }

    private void InitAllNormalBrickGrid()
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

    private void InitFromBrickTypeGrid(BRICK_TYPE[,] brickTypeGrid)
    {
        var gridRowSize = brickTypeGrid.GetLength(0);
        var gridColumnSize = brickTypeGrid.GetLength(1);

        _brickGameObjs = new GameObject[gridRowSize, gridColumnSize];

        for (int row = 0; row < gridRowSize; row++)
        {
            for (int column = 0; column < gridColumnSize; column++)
            {
                var newBrick = _brickCreator.GetBrickOfType(
                    brickTypeGrid[row, column],
                    new Vector3(
                        transform.position.x - (NUM_OF_COLUMN * _brickWidth + (NUM_OF_COLUMN - 1) * _brickColumnSpacing) / 2 + _brickWidth / 2 + column * (_brickWidth + _brickColumnSpacing),
                        transform.position.y + (NUM_OF_ROW * _brickHeight + (NUM_OF_ROW - 1) * _brickRowSpacing) / 2 - _brickHeight / 2 - row * (_brickHeight + _brickRowSpacing),
                        0
                    ),
                    transform
                );

                _brickGameObjs[row, column] = newBrick;

                if (brickTypeGrid[row, column] == BRICK_TYPE.BOMB)
                {
                    var bombBrick = newBrick.GetComponent<BombBrick>();
                    bombBrick.OnBeingDestroyed += DestroyBricksNearBombBrick;
                    bombBrick.RowInGrid = row;
                    bombBrick.ColumnInGrid = column;
                }
            }
        }
    }

    private void DestroyBricksNearBombBrick(BombBrick sender)
    {
        var row = sender.RowInGrid;
        var column = sender.ColumnInGrid;

        Destroy(GetBrickAt(row - 1, column));
        Destroy(GetBrickAt(row + 1, column));
        Destroy(GetBrickAt(row, column - 1));
        Destroy(GetBrickAt(row, column + 1));
        Destroy(GetBrickAt(row + 1, column + 1));
        Destroy(GetBrickAt(row - 1, column - 1));
        Destroy(GetBrickAt(row - 1, column + 1));
        Destroy(GetBrickAt(row + 1, column - 1));
    }

    private GameObject GetBrickAt(int row, int column)
    {
        if (_brickGameObjs.GetLength(0) > row && _brickGameObjs.GetLength(1) > column)
            return _brickGameObjs[row, column];
        return null;
    }
}