using System;
using System.ComponentModel;

namespace EventsDemos
{
    public class Witcher : Unit, INotifyPropertyChanged
    {
        public event EventHandler<Spell> SpellCast;

        public event PropertyChangedEventHandler PropertyChanged;

        public Witcher(string name)
        {
            Name = name;
            
            //SpellCast += OnSpellCast;
        }

        public override void OnSpellCast(object sender, Spell spell)
        {
            if (ReferenceEquals(this, sender))
            {
                ManaLevel -= spell.ManaCost;
            }
        }

        private double manaLevel = 100;

        public double ManaLevel
        {
            get { return manaLevel; }

            protected set
            {
                manaLevel = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ManaLevel)));
            }
        }

        public void Cast()
        {
            var spell = new Spell("Aarand", 10);
            SpellCast?.Invoke(this, spell);
        }

        public override string ToString() => 
            $"{Name} has {manaLevel} points of mana.";
    }
}
