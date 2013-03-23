using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lemmingz
{
    public class UpdateManager
    {
        private LemmingzManager lemmingzManager;
        private List<LemmingOnDisplay> lemmingzOnDisplay;

        public UpdateManager(LemmingzManager lemmingzManager)
        {
            this.lemmingzManager = lemmingzManager;
            lemmingzOnDisplay = new List<LemmingOnDisplay>();
        }

        public void updateLemmingz(GameTime gameTime)
        {
            lemmingzOnDisplay.Clear();
            foreach (Lemming lemming in lemmingzManager.getLemmingzList())
            {
                LemmingOnDisplay lemmingOnDisplay = new LemmingOnDisplay(lemming, lemmingzManager);
                lemmingOnDisplay.setLemmingDisplay(gameTime, lemming);
                lemmingzOnDisplay.Add(lemmingOnDisplay);
            }
        }

        public List<LemmingOnDisplay> getLemmingzOnDisplay()
        {
            return lemmingzOnDisplay;
        }
    }
}
