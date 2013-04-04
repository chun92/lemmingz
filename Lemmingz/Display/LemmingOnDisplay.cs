using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lemmingz
{
    public class LemmingOnDisplay
    {
        private Lemming lemming;
        private Vector2 displayedPosition;
        private int cellPixel = 48;
        private String ImageFile;

        public LemmingOnDisplay(Lemming lemming)
        {
            cellPixel = 48;
            this.lemming = lemming;
            ImageFile = getImageFileName();
        }

        private String getImageFileName()
        {
            return "Content" + "lemming" + "1";
        }

        public Lemming getLemming()
        {
            return lemming;
        }

        public void setDisplay(GameTime gametime)
        {
            double ratio = lemming.getMovedDistance() / 1000;
            double currentX = (lemming.getPreviousPosition().X + (lemming.getCurrentPosition().X - lemming.getPreviousPosition().X) * ratio) * cellPixel;
            double currentY = (lemming.getPreviousPosition().Y + (lemming.getCurrentPosition().Y - lemming.getPreviousPosition().Y) * ratio) * cellPixel;
            displayedPosition = new Vector2((float)currentX, (float)currentY);
            lemming.putOnDisplay();
        }

        public Vector2 getDisplay()
        {
            return displayedPosition;
        }
    }
}
