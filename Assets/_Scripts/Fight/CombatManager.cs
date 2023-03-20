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

    
    private FightCommand currentCommand;


    void Start()
    {
        _factory = new FightActionFactory();
        StartBattle();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Undo();
        if (Input.GetKeyDown(KeyCode.R))
            Redo();
    }

    void StartBattle()
    {        
        var activeEntity = (Fighter)EntityManager.ActiveEntity;
        Stats.SetEntity(activeEntity);        

        ActionButtonController.SetNewCommands(activeEntity.PossibleCommands);
    }

    //public void DoAction(FightCommandTypes commandType)
    //{
    //    //DoAction(commandType + 2 parametros mas);
    //}

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

    public void DoAction(FightCommandTypes type) // (Entity actor, Entity target, FightCommandTypes type)
    {
         currentCommand = (FightCommand)_factory.GetCommand(type, (Fighter)EntityManager.ActiveEntity);
        if (currentCommand == null) throw new NotImplementedException();

        Debug.Log("el buton se ha preseao");

        ChooseTarget(currentCommand);

        //newCommand.SetTarget(currentTarget);
        
        /*
            - Elige target(?
            - Realiza acción
            - Next Turn                 
         */

    }

    private void OnEnable()
    {
        ActionButtonController.ButtonIsPressed += DoAction;
    }
    private void OnDisable()
    {
        ActionButtonController.ButtonIsPressed -= DoAction;
    }

    //private void DoAction(Entity actor, Entity target, FightCommandTypes type)
    //{

    //}

    private void Undo()
    {
        if (!Invoker.CanUndo()) return;

        Invoker.Undo();
        EntityManager.SetPreviousEntity();
        StartBattle();
    } 
    
    private void Redo()
    {
        if (!Invoker.CanRedo()) return;

        Invoker.Redo();
        EntityManager.SetNextEntity();
        StartBattle();
    }


    public void NextTurn()
    {
        EntityManager.SetNextEntity();
        StartBattle();
    }

    internal void TargetChosen(ISelectable entity)
    {
        if (!(entity is Entity))
        {
            Debug.LogError("Selected is not entity");
            return;
        }

        currentCommand.SetTarget(entity as Fighter);
        Invoker.AddCommand(currentCommand);

        if (((Fighter)EntityManager.ActiveEntity).HasShield)
        {
            var com = (FightCommand)_factory.GetCommand(FightCommandTypes.RemoveShield, (Fighter)EntityManager.ActiveEntity);
            if (currentCommand == null) throw new NotImplementedException();


            Invoker.AddCommand(com);
        }


        NextTurn();
    }
}
