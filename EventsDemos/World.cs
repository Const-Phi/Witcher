using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EventsDemos
{
    public sealed class World
    {
        private readonly List<Unit> units;

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
                // it's bad practices but it changes order of calling event-handlers
                witcher.SpellCast += witcher.OnSpellCast;
            }
        }

        private static void Witcher_PropertyChanged(object sender, PropertyChangedEventArgs e)
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

        private static void OnSpellCast(object sender, Spell spell)
        {
            var witcher = sender as Witcher;
            if (witcher == null)
                return;

            Console.WriteLine($"{witcher.Name} cast spell \"{spell.Title}\".");
        }
    }
}
