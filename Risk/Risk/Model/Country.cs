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
        string name;
        Color color;
        int troops;
        Player owner;
        List<Country> connections;
        Region region;
        Texture2D overlay;
    }
}
