using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class TileOnDisplay
    {
        private Tile tile;
        private Vector2 displayedPosition;
        private int cellPixel = 48;
        private String ImageFile;

        public TileOnDisplay(Tile tile)
        {
            cellPixel = 48;
            this.tile = tile;
            ImageFile = getImageFileName();
        }

        private String getImageFileName()
        {
            switch (tile.getType())
            {
                case TileType.GROUND:
                    return "Content" + "ground";
                default:
                    return "";
            }
        }

        public void setDisplay(GameTime gametime)
        {
            double currentX = tile.getPoint().X * cellPixel;
            double currentY = tile.getPoint().Y * cellPixel;
            displayedPosition = new Vector2((float)currentX, (float)currentY);
        }

        public Vector2 getDisplay()
        {
            return displayedPosition;
        }
    }

}
