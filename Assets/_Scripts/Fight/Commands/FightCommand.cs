using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FightCommand : Command
{
    protected Fighter _selectedFighter;
    protected Fighter _target;

    public TargetTypes PossibleTargets;

    protected FightCommand(Entity entity, Entity target) : base(entity)
    {
        //if (_entity is Fighter)
            _selectedFighter = entity as Fighter;
        _target = target as Fighter;
    }

    
    
    
    
    
    
    
    
    //private void OnEnable()
    //{
    //    ChooseTarget.OnSelected += GetFighter;
    //}
    //private void OnDisable()
    //{
    //    ChooseTarget.OnSelected -= GetFighter;
    //}
}