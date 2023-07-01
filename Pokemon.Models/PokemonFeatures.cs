using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Models
{
    public class PokemonFeatures
    {
        public Damage_Relations damage_relations { get; set; }
    }

    public class Damage_Relations
    {
        private List<Damage> _double_damage_from;
        public List<Damage> double_damage_from
        {
            get
            {
                if (_double_damage_from == null)
                {
                    _double_damage_from = new List<Damage>();
                }
                return _double_damage_from;
            }
            set { _double_damage_from = value; }
        }

        private List<Damage> _double_damage_to;
        public List<Damage> double_damage_to
        {
            get
            {
                if (_double_damage_to == null)
                {
                    _double_damage_to = new List<Damage>();
                }
                return _double_damage_to;
            }
            set { _double_damage_to = value; }
        }

        private List<Damage> _half_damage_from;
        public List<Damage> half_damage_from
        {
            get
            {
                if (_half_damage_from == null)
                {
                    _half_damage_from = new List<Damage>();
                }
                return _half_damage_from;
            }
            set { _half_damage_from = value; }
        }

        private List<Damage> _half_damage_to;
        public List<Damage> half_damage_to
        {
            get
            {
                if (_half_damage_to == null)
                {
                    _half_damage_to = new List<Damage>();
                }
                return _half_damage_to;
            }
            set { _half_damage_to = value; }
        }

        private List<Damage> _no_damage_from;
        public List<Damage> no_damage_from
        {
            get
            {
                if (_no_damage_from == null)
                {
                    _no_damage_from = new List<Damage>();
                }
                return _no_damage_from;
            }
            set { _no_damage_from = value; }
        }

        private List<Damage> _no_damage_to;
        public List<Damage> no_damage_to
        {
            get
            {
                if (_no_damage_to == null)
                {
                    _no_damage_to = new List<Damage>();
                }
                return _no_damage_to;
            }
            set { _no_damage_to = value; }
        }

    }

    public class Damage
    {
        public string name { get; set; }
    }
}
