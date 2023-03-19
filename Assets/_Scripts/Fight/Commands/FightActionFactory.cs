using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FightActionFactory
{

    public ICommand GetCommand(FightCommandTypes type, Fighter fighter)//?
    {
        switch (type)
        {
            case FightCommandTypes.Attack:
                return new CommandAttack(fighter);

            case FightCommandTypes.BoostAttack:
                return new CommandBoostAttack(fighter);

            case FightCommandTypes.BoostDefense:
                return new CommandBoostDefense(fighter);

            case FightCommandTypes.Heal:
                return new CommandHeal(fighter);

            case FightCommandTypes.Shield:
                return new CommandShield(fighter);

            default:
                throw new NotSupportedException();

        }
    }
}

