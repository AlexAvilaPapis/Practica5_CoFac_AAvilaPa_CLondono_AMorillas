using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonController : MonoBehaviour
{
   // public Color[] Colors;
    public ActionButton ActionButtonPrefab;

    public List<FightCommandTypes> PossibleCommands;

    public CombatManager CombatManager;

    private List<GameObject> CurrentButtons;

    private CanvasGroup _canvasGroup;

    public Action<FightCommandTypes> ButtonIsPressed;

    //private FightActionFactory _actionFactory;

    //public CubeColor Cube;

    // Start is called before the first frame update
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        //_actionFactory = new FightActionFactory();
    }

    private void Start()
    {
        MakeButtons();
    }

    internal void ChooseTarget(Entity activeEntity)
    {
        Hide();
    }

    void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    void MakeButtons()
    {
        var commandTypes = PossibleCommands; //Obtener nombres de la factory

        foreach(var command in commandTypes)
        {
            MakeOneButton(command);
        }
    }

    private void MakeOneButton(FightCommandTypes type)
    {
        var butt = Instantiate(ActionButtonPrefab) as ActionButton;//?
        butt.Init(type, this, Color.white);
        butt.transform.SetParent(transform);
    }

    public void OnButtonPressed(FightCommandTypes fightCommandType)
    {
        if (/*Botón atque presionado*/true)
        {
            //Do ataque
        }

        ButtonIsPressed?.Invoke(fightCommandType);

        //CombatManager.Factory.GetCommand(fightCommandType, (Fighter)CombatManager.EntityManager.ActiveEntity);

        //Debug.Log("el buton se ha preseao");
    }
}
