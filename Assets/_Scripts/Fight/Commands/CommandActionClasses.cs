using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;


public class CommandAttack : FightCommand
{
    float _currentHealth;

    public CommandAttack(Entity entity) : base(entity)
    {
        Console.WriteLine("Ataque");
        PossibleTargets = TargetTypes.Enemy;
    }

    public override void Excecute()
    {
        _currentHealth = _selectedFighter.CurrentHealth;
        _selectedFighter.TakeDamage(5);
    }

    public override void Undo()
    {
        _selectedFighter.CurrentHealth = _currentHealth;
    }
}


public class CommandBoostAttack : FightCommand
{
    public CommandBoostAttack(Entity entity) : base(entity)
    {
        Console.WriteLine("BoostAtaque");
        PossibleTargets = TargetTypes.Self;
    }

    public override void Excecute()
    {
        _selectedFighter.AddAttack(1);
    }
    public override void Undo()
    {
        _selectedFighter.AddAttack(-1);
    }
}


public class CommandBoostDefense : FightCommand
{
    public CommandBoostDefense(Entity entity) : base(entity)
    {
        Console.WriteLine("BoostDef");
        PossibleTargets = TargetTypes.Self;
    }

    public override void Excecute()
    {
        _selectedFighter.AddDefensePermanent(1);
    }
    public override void Undo()
    {
        _selectedFighter.AddDefensePermanent(-1);
    }
}


public class CommandHeal : FightCommand
{
    public CommandHeal(Entity entity) : base(entity)
    {
        Console.WriteLine("Heal");
        PossibleTargets = TargetTypes.Friend;
    }

    public override void Excecute()
    {
        _selectedFighter.CurrentHealth += 3;
    }
    public override void Undo()
    {
        _selectedFighter.CurrentHealth -= 3;
    }
}


public class CommandShield : FightCommand
{
    public CommandShield(Entity entity) : base(entity)
    {
        Console.WriteLine("Shied");
        PossibleTargets = TargetTypes.FriendNotSelf;
    }

    public override void Excecute()
    {
        _selectedFighter.AddDefense(5);
    }
    public override void Undo()
    {
        _selectedFighter.AddDefense(-5);
    }
}

