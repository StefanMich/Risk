using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Risk
{
    class Country
    {
        public Country(string name, Color color, Region region, Texture2D overlay)
        {
            this.name = name;
            this.color = color;
            this.region = region;
            this.overlay = overlay;
        }

        private string name;

        public string Name
        {
            get { return name; }
        }

        private Color color;

        public Color Color
        {
            get { return color; }
        }

        private int troops;

        public int Troops
        {
            get { return troops; }
            set { troops = value; }
        }

        private Player owner;

        public Player Owner
        {
            get { return owner; }
            set { owner = value; }
        }


        private Region region;

        public Region Region
        {
            get { return region; }
        }

        private Texture2D overlay;

        public Texture2D Overlay
        {
            get { return overlay; }
        }
    }
}
