using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ReflectionFactory
{
    public class FightActionFactory
    {
        
        //public ICommand GetCommand(FightCommandTypes type, Fighter fighter)//?
        //{
        //    switch (type)
        //    {
        //        case FightCommandTypes.Attack:
        //            Debug.Log("attack");
        //            return new CommandAttack(fighter);

        //        case FightCommandTypes.BoostAttack:
        //            Debug.Log("boost attack");
        //            return new CommandBoostAttack(fighter);

        //        case FightCommandTypes.BoostDefense:
        //            Debug.Log("boost def");
        //            return new CommandBoostDefense(fighter);

        //        case FightCommandTypes.Heal:
        //            Debug.Log("heal");
        //            return new CommandHeal(fighter);

        //        case FightCommandTypes.Shield:
        //            Debug.Log("shield");
        //            return new CommandShield(fighter);

        //        case FightCommandTypes.RemoveShield:
        //            Debug.Log("shield");
        //            return new RemoveCommandShield(fighter);

        //        default:
        //            Debug.Log("na de na");
        //            throw new NotSupportedException();

        //    }
        //}

        private Dictionary<FightCommandTypes, Type> _fightCommandsByType;

        public FightActionFactory()
        {
            var fightCommands = Assembly.GetAssembly(typeof(ICommand)).GetTypes()
                .Where(x => !x.IsInterface && typeof(ICommand).IsAssignableFrom(x) && !x.IsAbstract);            

            _fightCommandsByType = new Dictionary<FightCommandTypes, Type>();

            foreach (var item in fightCommands)
            {                
                Debug.Log(item.ToString());
                //object[] args = { Fighter.testInstance };

                var tempCommand = Activator.CreateInstance(item /*args*/);
                _fightCommandsByType.Add(((ICommand)tempCommand).Type, item);

            }
        }

        public ICommand GetCommand(FightCommandTypes type, Fighter fighter)
        {
            if (_fightCommandsByType.ContainsKey(type))
            {
                object[] args = { fighter};

                Type type1 = _fightCommandsByType[type];
                return Activator.CreateInstance(type1, args) as ICommand; 
            }
            return null;
        }
    }
}