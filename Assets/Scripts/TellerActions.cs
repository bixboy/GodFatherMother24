using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Painting;
using static UnityEngine.GraphicsBuffer;

public class TellerActions : MonoBehaviour
{
    [SerializeField] private List<Action> _tellerActions = new();
    private static TellerActions instance = null;
    public static TellerActions Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    [Serializable]
    private struct Action
    {
        public enum ActionType
        {
            DISPLAY,
            DISAPPEAR
        }
        public GameObject Target;
        public ActionType Type;
    }

    public void NextTellerAction()
    {
        if(_tellerActions.Count <= 0) 
            return;

        Action currentAction = _tellerActions[0];
        switch (_tellerActions[0].Type)
        {
            case Action.ActionType.DISPLAY:
                currentAction.Target.SetActive(true);
                break;
            case Action.ActionType.DISAPPEAR:
                currentAction.Target.SetActive(false);
                break;
        }
        _tellerActions.RemoveAt(0);
    }
}
