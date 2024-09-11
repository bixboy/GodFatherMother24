using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour
{
    private List<Painting> _allPaintings = new();

    [SerializeField] private List<int> _paintingOrder = new(4);
                     private List<int> _currentPaintingOrder = new();

    void Start()
    {
        _allPaintings = GetComponentsInChildren<Painting>().ToList();
    }

    public void CheckPuzzle(int newLightIndex)
    {
        _currentPaintingOrder.Add(newLightIndex);

        if (_currentPaintingOrder[^1] != _paintingOrder[_currentPaintingOrder.Count-1])
            ResetAll();

        if (_currentPaintingOrder.Count >= _paintingOrder.Count)
        {
            Win();
            return;
        }
    }

    private void ResetAll()
    {
        _currentPaintingOrder.Clear();

        foreach (var painting in _allPaintings)
        {
            painting.SwitchLight(false);
        }
    }
    private void Win()
    {
        // GO TO NEXT DAY
    }

}
