using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBrick : MonoBehaviour
{
    [SerializeField] private int _rowInGrid, _columnInGrid;

    public int RowInGrid { get => _rowInGrid; set => _rowInGrid = value; }
    public int ColumnInGrid { get => _columnInGrid; set => _columnInGrid = value; }

    public delegate void BeingDestroyedHandler(BombBrick sender);

    public event BeingDestroyedHandler OnBeingDestroyed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        OnBeingDestroyed?.Invoke(this);
    }
}
