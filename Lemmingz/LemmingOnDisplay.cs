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
        private LemmingzManager lemmingzManager;
        private Vector2 displayedPosition;
        private int cellPixel = 48;
        private String lemmingImageFile;

        public LemmingOnDisplay(Lemming lemming, LemmingzManager lemmingzManager)
        {
            cellPixel = 48;
            this.lemming = lemming;
            this.lemmingzManager = lemmingzManager;
            getImageFileName();
        }

        private void getImageFileName()
        {
            lemmingImageFile = "Content" + "lemming" + "1";
        }

        public void setLemmingDisplay(GameTime gametime, Lemming lemming)
        {
            double lemmingSpeed = lemming.getSpeed();
            double ratio = ((double)gametime.TotalGameTime.TotalMilliseconds - lemmingzManager.getLastUpdatedMovingTime()) / lemmingSpeed;
            double currentX = (lemming.getPreviousPosition().X + (lemming.getCurrentPosition().X - lemming.getPreviousPosition().X) * ratio) * cellPixel;
            double currentY = (lemming.getPreviousPosition().Y + (lemming.getCurrentPosition().Y - lemming.getPreviousPosition().Y) * ratio) * cellPixel;
            displayedPosition = new Vector2((float)currentX, (float)currentY);
            lemming.putOnDisplay();
        }

        public Vector2 getLemmingDisplay()
        {
            return displayedPosition;
        }
    }
}
