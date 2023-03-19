using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandAttack : CommandActionAbstract
{
    float _currentHealth;
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

public class CommandBoostAttack : CommandActionAbstract
{
    public override void Excecute()
    {
        _selectedFighter.AddAttack(1);
    }
    public override void Undo()
    {
        _selectedFighter.AddAttack(-1);
    }
}

public class CommandBoostDefense : CommandActionAbstract
{
    public override void Excecute()
    {
        _selectedFighter.AddDefensePermanent(1);
    }
    public override void Undo()
    {
        _selectedFighter.AddDefensePermanent(-1);
    }
}

public class CommandHeal : CommandActionAbstract
{
    public override void Excecute()
    {
        _selectedFighter.CurrentHealth += 3;
    }
    public override void Undo()
    {
        _selectedFighter.CurrentHealth -= 3;
    }
}

public class CommandShield : CommandActionAbstract
{
    public override void Excecute()
    {
        _selectedFighter.AddDefense(5);
    }
    public override void Undo()
    {
        _selectedFighter.AddDefense(-5);
    }
}