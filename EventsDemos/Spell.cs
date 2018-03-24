using System;

namespace EventsDemos
{
    public class Spell
    {
        private string title;

        public string Title
        {
            get { return title; }

            protected set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException(nameof(Title));

                var tmp = value.Trim();
                if (tmp.IsEmpty())
                    throw new AggregateException(nameof(Title));

                title = tmp;
            }
        }

        private double manaCost;

        public double ManaCost
        {
            get { return manaCost; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(ManaCost));

                manaCost = value;
            }
        }

        public Spell (string title, double cost)
        {
            Title = title;
            ManaCost = cost;
        }

        public override string ToString() =>
            $"[-{ManaCost}] {Title}";
    }
}
