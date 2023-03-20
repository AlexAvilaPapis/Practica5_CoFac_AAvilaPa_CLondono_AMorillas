using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FightCommandTypes
{
    Attack,
    BoostAttack,
    BoostDefense,
    Heal,
    Shield,
    RemoveShield,
}

public enum TargetTypes
{
    Enemy,
    Friend,
    Self,
    FriendNotSelf,

}