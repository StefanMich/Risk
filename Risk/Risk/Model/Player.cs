using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Risk
{
    public class Player
    {
        public Player(string name)
        {
            this.name = name;
            countries = new CountryCollection();
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int regionBonus;

        public int RegionBonus
        {
            get { return regionBonus; }
            set { regionBonus = value; }
        }

        private int additionalTroops;

        public int AdditionalTroops
        {
            get { return additionalTroops; }
            set { additionalTroops = value; }
        }

        private int troops;

        public int Troops
        {
            get { return troops; }
            set { troops = value; }
        }
        
        private CountryCollection countries;

        public CountryCollection Countries
        {
            get { return countries; }
        }

        #region Nested Class CountryCollection
        public class CountryCollection : IEnumerable<Country>
        {
            List<Country> connections;

            public CountryCollection()
            {
                connections = new List<Country>();
            }

            public void Add(Country c)
            {
                connections.Add(c);
            }

            public void Remove(Country c)
            {
                connections.Remove(c);
            }

            public IEnumerable<Country> ReturnCountries()
            {
                foreach (Country c in connections)
                {
                    yield return c;
                }
            }

        }
        #endregion
    }
}
