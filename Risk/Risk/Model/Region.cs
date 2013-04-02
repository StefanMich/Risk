using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk
{
    public class Region
    {
        public Region(string name, int regionBonus, List<Country> countries)
        {
            this.name = name;
            this.regionBonus = regionBonus;
            this.countries = new CountryCollection(countries);
        }
        private CountryCollection countries;
        private int regionBonus;

        public int RegionBonus
        {
            get { return regionBonus; }
        }

        private Player owner;

        public Player Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public CountryCollection Countries
        {
            get { return countries; }
            set { countries = value; }
        }
        

        public class CountryCollection : IEnumerable<Country>, IList<Country>
        {
            List<Country> countries;

            public CountryCollection(List<Country> countries)
            {
                this.countries = countries;
            }

            public CountryCollection(params Country[] coutries)
            {
                countries = new List<Country>();

                foreach (var c in countries)
                {
                    countries.Add(c);
                }
            }

            public IEnumerator<Country> GetEnumerator()
            {
                return countries.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public int IndexOf(Country item)
            {
                return countries.IndexOf(item);
            }

            public void Insert(int index, Country item)
            {
                countries.Insert(index, item);
            }

            public void RemoveAt(int index)
            {
                countries.RemoveAt(index);
            }

            public Country this[int index]
            {
                get
                {
                    return countries[index];
                }
                set
                {
                    countries[index] = value;
                }
            }

            public void Add(Country item)
            {
                countries.Add(item);
            }

            public void Clear()
            {
                countries.Clear();
            }

            public bool Contains(Country item)
            {
                return countries.Contains(item);
            }

            public void CopyTo(Country[] array, int arrayIndex)
            {
                countries.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return countries.Count(); }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public bool Remove(Country item)
            {
                return countries.Remove(item);
            }
        }
    }
}
