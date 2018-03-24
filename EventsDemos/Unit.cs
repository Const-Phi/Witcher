using System;

namespace EventsDemos
{
    public abstract class Unit
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(nameof(Name), $"{nameof(Name)} can not be null or empty.");

                var tmp = value.Trim();
                if (tmp.IsEmpty())
                    throw new ArgumentException(nameof(Name), $"{nameof(Name)} can not be full or whitespaces.");

                name = tmp;
            }
        }

        protected abstract void OnSpellCast(object sender, Spell spell);
    }
}
