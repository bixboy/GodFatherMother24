using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockPuzzle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _digitTexts;
    [SerializeField] private int[] _digits = new int[4];
    private int _passWord = 1234;
    private bool _win = false;

    void Start()
    {
        //GameObject newInstance = Instantiate(_passWordUi, Vector3.zero, Quaternion.identity);

        for (int i = 0; i < _digits.Length; i++)
        {
            _digits[i] = 0;
            _digitTexts[i].text = _digits[i].ToString(); 
        }
    }

    public void IncrementDigit(int index)
    {
        _digits[index] = (_digits[index] + 1) % 10; // Incr�menter le chiffre, retourne � 0 si d�passe 9
        _digitTexts[index].text = _digits[index].ToString(); // Mettre � jour l'UI
        CheckCombination(); // V�rifier la combinaison apr�s chaque changement
    }

    private void CheckCombination()
    {
        int enteredPassword = _digits[0] * 1000 + _digits[1] * 100 + _digits[2] * 10 + _digits[3];
        if (enteredPassword == _passWord)
        {
            _win = true;
            Win();
        }
    }

    private void Win()
    {
        if (_win)
        {
            NightDay.instance.OpenChangeDay();
            Destroy(gameObject);
        }
    }
}
