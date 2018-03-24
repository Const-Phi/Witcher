using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EventsDemos
{
    public class World
    {
        List<Unit> units;

        public World()
        {
            units = new List<Unit>
            {
                new Witcher("Geralt"),
                new Witcher("Ciri"),
                new Witcher("Axcel"),
            };

            var witchers = units.OfType<Witcher>();
            foreach (var witcher in witchers)
            {
                witcher.PropertyChanged += Witcher_PropertyChanged;
                witcher.SpellCast += OnSpellCast;
            }
        }

        private void Witcher_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var witcher = sender as Witcher;
            if (witcher == null)
                return;

            Console.WriteLine(witcher);
        }

        public void Start()
        {
            var witchers = units.OfType<Witcher>();
            foreach (var witcher in witchers)
                witcher.Cast();
        }

        private void OnSpellCast(object sender, Spell spell)
        {
            var witcher = sender as Witcher;
            if (witcher == null)
                return;

            Console.WriteLine($"{witcher.Name} cast spell '{spell.Title}'.");
        }
    }
}
