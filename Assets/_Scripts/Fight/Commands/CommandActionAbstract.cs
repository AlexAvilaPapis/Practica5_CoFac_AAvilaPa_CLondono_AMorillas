using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandActionAbstract : MonoBehaviour, ICommand
{
    protected Fighter _selectedFighter;
    private void OnEnable()
    {
        ChooseTarget.OnSelected += GetFighter;
    }
    private void OnDisable()
    {
        ChooseTarget.OnSelected -= GetFighter;
    }

    private void GetFighter(Fighter entity)
    {
        _selectedFighter = entity;
    }

    public abstract void Excecute();
    public abstract void Undo();
}