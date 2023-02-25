using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class GridLogic<TGridObject>
{
    private int _width;
    private int _height;
    private TGridObject[,] _gridArray;
    private int _cellSize;
    private TextMesh[,] TextValueGridArray;
    private Vector3 _originPosition;
    public GridLogic(int width, int height, int cellSize, Vector3 originPosition, Func<GridLogic<TGridObject>, int, int, TGridObject> CreateGridObject)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _originPosition = originPosition;
        _gridArray = new TGridObject[_width, _height];
        TextValueGridArray = new TextMesh[_width, _height];
        
        for (int i = 0; i < _gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < _gridArray.GetLength(1); j++)
            {
                _gridArray[i, j] = CreateGridObject(this,i,j);
                TextValueGridArray[i,j]=DebugDraw( _gridArray[i, j]?.ToString(), GetCellPosition(i, j)+new Vector3(_cellSize,_cellSize)*.5f, 150, Color.black,
                    TextAnchor.MiddleCenter, TextAlignment.Left);
                Debug.DrawLine(GetCellPosition(i,j),GetCellPosition(i,j+1),Color.black,100f);
                Debug.DrawLine(GetCellPosition(i,j),GetCellPosition(i+1,j),Color.black,100f);
            }
        }
        Debug.DrawLine(GetCellPosition(0,_height),GetCellPosition(_width,_height),Color.black,100f);
        Debug.DrawLine(GetCellPosition(_width,0),GetCellPosition(_width,_height),Color.black,100f);
        
    }
    private Vector3 GetCellPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize +_originPosition;
    }
    private Vector2Int GetXYFromCellPosition(Vector3 CellPosition)
    {
        return new Vector2Int(Mathf.FloorToInt((CellPosition-_originPosition).x/ _cellSize),
            Mathf.FloorToInt((CellPosition-_originPosition).y/ _cellSize));
    }
    public TGridObject GetGridObject(int x, int y)
    {
        if (x>=0 && y>=0 && x<_width && y<_height)
        {
            return _gridArray[x, y];
        }
        else
        {
            return default;
        }
    }

    public TGridObject GetGridObject(Vector3 CellPosition)
    {
        Vector2Int result = GetXYFromCellPosition(CellPosition);
        return GetGridObject(result.x,result.y);
    }
    
    public int GetWidth() {
        return _width;
    }

    public int GetHeight() {
        return _height;
    }

    public float GetCellSize() {
        return _cellSize;
    }
    public void SetGridObject(int x, int y, TGridObject value)
    {
        if (x>=0 && y>=0 && x<_width && y<_height)
        {
            _gridArray[x, y] = value;
            TextValueGridArray[x, y].text = _gridArray[x, y].ToString();

        }
       
    }
    public void SetGridObject(Vector3 CellPosition, TGridObject Value)
    {
        Vector2Int result = GetXYFromCellPosition(CellPosition);
        SetGridObject(result.x,result.y,Value);
    }
    
    private static TextMesh DebugDraw( string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment) {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.position = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.characterSize = 0.03f;
        return textMesh;
    }
}
