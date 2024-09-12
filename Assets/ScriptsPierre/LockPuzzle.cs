using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockPuzzle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _digitTexts;
    [SerializeField] private int[] _digits = new int[4];
    [SerializeField] private ExitDoor _exitDoor;

    [SerializeField] private Image _lockImg;
    [SerializeField] private Sprite _lockOpened;
    private int _passWord = 1234;
    private bool _win = false;
    private PlayerBehaviour _player;

    void Start()
    {
        //GameObject newInstance = Instantiate(_passWordUi, Vector3.zero, Quaternion.identity);
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();

        for (int i = 0; i < _digits.Length; i++)
        {
            _digits[i] = 0;
            _digitTexts[i].text = _digits[i].ToString(); 
        }
    }

    public void IncrementDigit(int index)
    {
        _digits[index] = (_digits[index] + 1) % 10; // Incrémenter le chiffre, retourne à 0 si dépasse 9
        _digitTexts[index].text = _digits[index].ToString(); // Mettre à jour l'UI
        CheckCombination(); // Vérifier la combinaison après chaque changement
    }

    private void CheckCombination()
    {
        int enteredPassword = _digits[0] * 1000 + _digits[1] * 100 + _digits[2] * 10 + _digits[3];
        if (enteredPassword == _passWord)
        {
            _win = true;
            StartCoroutine(Win());
        }
    }

    private IEnumerator Win()
    {
        if (_win)
        {
            _exitDoor.Open();
            _lockImg.sprite = _lockOpened;
            yield return new WaitForSeconds(1f);
            _player.CanMove = true;
            Destroy(gameObject);
        }
    }
}
