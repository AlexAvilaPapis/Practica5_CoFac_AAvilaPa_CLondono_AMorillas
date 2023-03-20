using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;


namespace ReflectionFactory
{

    public class CommandAttack : FightCommand
    {
        public override FightCommandTypes Type => _TYPE;

        private const FightCommandTypes _TYPE = FightCommandTypes.Attack;

        float _currentHealth;

        public CommandAttack() { }

        public CommandAttack(Entity entity) : base(entity)
        {
            Console.WriteLine("Ataque");
            PossibleTargets = TargetTypes.Enemy;
        }

        public override void Excecute()
        {
            _currentHealth = _target.CurrentHealth;
            _target.TakeDamage(_selectedFighter.Attack);

        }

        public override void Undo()
        {
            _target.CurrentHealth = _currentHealth;
        }
    }


    public class CommandBoostAttack : FightCommand
    {
        public override FightCommandTypes Type => _TYPE;

        private const FightCommandTypes _TYPE = FightCommandTypes.BoostAttack;

        public CommandBoostAttack() { }

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
        public override FightCommandTypes Type => _TYPE;

        private const FightCommandTypes _TYPE = FightCommandTypes.BoostDefense;

        public CommandBoostDefense() { }

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
        public override FightCommandTypes Type => _TYPE;

        private const FightCommandTypes _TYPE = FightCommandTypes.Heal;

        public CommandHeal() { }

        public CommandHeal(Entity entity) : base(entity)
        {
            Console.WriteLine("Heal");
            PossibleTargets = TargetTypes.Friend;
        }

        public override void Excecute()
        {
            _target.CurrentHealth += 3;
        }
        public override void Undo()
        {
            _target.CurrentHealth -= 3;
        }
    }


    public class CommandShield : FightCommand
    {
        public override FightCommandTypes Type => _TYPE;

        private const FightCommandTypes _TYPE = FightCommandTypes.Shield;

        public CommandShield() { }

        public CommandShield(Entity entity) : base(entity)
        {
            Console.WriteLine("Shied");
            PossibleTargets = TargetTypes.FriendNotSelf;
        }

        public override void Excecute()
        {
            _target.AddDefense(5);
            _target.HasShield = true;
        }
        public override void Undo()
        {
            _target.AddDefense(-5);
            _target.HasShield = false;
        }
    }
    public class RemoveCommandShield : FightCommand
    {
        public override FightCommandTypes Type => _TYPE;

        private const FightCommandTypes _TYPE = FightCommandTypes.RemoveShield;

        public RemoveCommandShield() { }

        public RemoveCommandShield(Entity entity) : base(entity)
        {
            Console.WriteLine("Shied");
            PossibleTargets = TargetTypes.FriendNotSelf;
        }

        public override void Excecute()
        {
            _selectedFighter.AddDefense(-5);
            _selectedFighter.HasShield = false;
        }
        public override void Undo()
        {
            _selectedFighter.AddDefense(+5);
            _selectedFighter.HasShield = true;
        }
    }

    public class TestCommand : FightCommand
    {
        public override FightCommandTypes Type => _TYPE;

        private const FightCommandTypes _TYPE = FightCommandTypes.Test;

        public TestCommand() { }

        public TestCommand(Entity entity) : base(entity) { }

        public override void Excecute() { }

        public override void Undo() { }
    }

}