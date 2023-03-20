using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class FightCommand : Command
{
    protected Fighter _selectedFighter;
    protected Fighter _target;

    public TargetTypes PossibleTargets;

    protected FightCommand() { }

    protected FightCommand(Entity entity) : base(entity)
    {
        _selectedFighter = entity as Fighter;
    }

    public void SetTarget(Entity target)
    {
        _target = target as Fighter;
    }
}