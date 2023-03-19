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

    //public CubeColor Cube;

    // Start is called before the first frame update
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
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

   

  

    
    public void OnButtonPressed(FightCommandTypes fightCommandType)
    {
        
    }
}
