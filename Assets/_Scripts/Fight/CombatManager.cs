using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class CombatManager : MonoBehaviour
{
    public EntityManager EntityManager;
    public ActionButtonController ActionButtonController;
    public ChooseTarget TargetChooser;
    public Invoker Invoker;
    public StatsUI Stats;

    private FightActionFactory _factory;

    

    // Start is called before the first frame update
    void Start()
    {
        _factory = new FightActionFactory();
        StartBattle();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Undo();
    }

    void StartBattle()
    {
        //var list = EntityManager.GetComponents<ISelectable>();
        //TargetChooser.StartChoose(list);

        //ActionButtonController.ChooseTarget(EntityManager.ActiveEntity);




    }

    public void DoAction(FightCommandTypes commandType)
    {
       

    }

    private void ChooseTarget(FightCommand _currentCommand)
    {
        var targetTypes = _currentCommand.PossibleTargets;

        Entity[] possibleTargets;

        switch (targetTypes)
        {
            case TargetTypes.Enemy:
                possibleTargets = EntityManager.Enemies;
                break;
            case TargetTypes.Friend:
                possibleTargets = EntityManager.Friends;
                break;
            case TargetTypes.FriendNotSelf:
                possibleTargets = EntityManager.FriendsNotSelf;
                break;
            case TargetTypes.Self:
                possibleTargets = new Entity[1];
                possibleTargets[0] = EntityManager.ActiveEntity;
                break;

            default:
                possibleTargets = EntityManager.Enemies;
                break;
        }
        ActionButtonController.ChooseTarget(EntityManager.ActiveEntity);
        TargetChooser.StartChoose(possibleTargets);
    }

    private void DoAction(Entity actor, Entity target, FightCommandTypes type)
    {
        
    }

    private void Undo()
    {
        
    }


    public void NextTurn()
    {
        
    }

    internal void TargetChosen(ISelectable entity)
    {
        if(!(entity is Entity))
        {
            Debug.LogError("Selected is not entity");
            return;
        }
    }
}
