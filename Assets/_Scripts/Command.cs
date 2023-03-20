using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class Command : ICommand
{
    public abstract FightCommandTypes Type { get; }

    protected Entity _entity;

    protected Command() 
    { 
    }

    protected Command(Entity entity)
    {
        _entity = entity;
    }

    public abstract void Excecute();
    public abstract void Undo();
}
