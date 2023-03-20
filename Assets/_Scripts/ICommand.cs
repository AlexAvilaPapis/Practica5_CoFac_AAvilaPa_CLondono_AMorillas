using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public interface ICommand 
{
    public FightCommandTypes Type { get; }

    void Excecute();
    void Undo();
}
