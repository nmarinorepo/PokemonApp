using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Dtos
{
    public class PokemonDto
    {
        public string name { get; set; }

        private List<string> _weaknesses;
        public List<string> weaknesses 
        { 
            get { 
                if (_weaknesses == null) 
                {
                    _weaknesses = new List<string>();
                }
                return _weaknesses;
            }
            set { _weaknesses = value; } 
        }

        private List<string> _strengths;
        public List<string> strengths
        {
            get
            {
                if (_strengths == null)
                {
                    _strengths = new List<string>();
                }
                return _strengths;
            }
            set { _strengths = value; }
        }
    }
}
