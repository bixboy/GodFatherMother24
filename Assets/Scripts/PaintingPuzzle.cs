using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour
{
    private List<Painting> _allPaintings = new();

    [SerializeField] private ExitDoor _exitDoor;
    [SerializeField] private List<int> _paintingOrder = new(4);
                     private List<int> _currentPaintingOrder = new();

    void Start()
    {
        _allPaintings = GetComponentsInChildren<Painting>().ToList();
    }

    public bool CheckPuzzle(int newLightIndex)
    {
        _currentPaintingOrder.Add(newLightIndex);

        if (_currentPaintingOrder[^1] != _paintingOrder[_currentPaintingOrder.Count - 1])
        {
            ResetAll(newLightIndex);
            return false;
        }

        if (_currentPaintingOrder.Count >= _paintingOrder.Count)
        {
            Win();
            return true;
        }

        return true;
    }

    private void ResetAll(int failedLightID)
    {
        _currentPaintingOrder.Clear();

        foreach (Painting painting in _allPaintings)
        {
            if(painting.PaintingIndex != failedLightID)
                painting.SwitchLight(Painting.LightAnimState.OFF);
        }
    }
    private void Win()
    {
        _exitDoor.Open();
    }

}
