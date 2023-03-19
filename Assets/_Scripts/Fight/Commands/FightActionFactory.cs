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
                Debug.Log("attack");
                return new CommandAttack(fighter);

            case FightCommandTypes.BoostAttack:
                Debug.Log("boost attack");
                return new CommandBoostAttack(fighter);

            case FightCommandTypes.BoostDefense:
                Debug.Log("boost def");
                return new CommandBoostDefense(fighter);

            case FightCommandTypes.Heal:
                Debug.Log("heal");
                return new CommandHeal(fighter);

            case FightCommandTypes.Shield:
                Debug.Log("shield");
                return new CommandShield(fighter);

            default:
                Debug.Log("na de na");
                throw new NotSupportedException();

        }
    }
}

