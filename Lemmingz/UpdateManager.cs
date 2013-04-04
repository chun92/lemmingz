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
        private List<ObstacleOnDisplay> obstaclesOnDisplay;
        private Map map;

        public UpdateManager(LemmingzManager lemmingzManager)
        {
            this.lemmingzManager = lemmingzManager;
            lemmingzOnDisplay = new List<LemmingOnDisplay>();
            map = lemmingzManager.getMap();
            obstaclesOnDisplay = new List<ObstacleOnDisplay>();
        }

        public void updateObstacle(GameTime gameTime)
        {    
            List<Tile> modifiedTiles = map.getModifiedTiles();

            foreach (Tile tile in modifiedTiles)
            {
                ObstacleOnDisplay obstacleOnDisplay;

                if (obstaclesOnDisplay.Exists(o => o.getTile().getPoint().X == tile.getPoint().X && o.getTile().getPoint().Y == tile.getPoint().Y))
                {
                    obstacleOnDisplay = obstaclesOnDisplay.Find(o => o.getTile().getPoint().X == tile.getPoint().X && o.getTile().getPoint().Y == tile.getPoint().Y);
                }
                else
                {
                    obstacleOnDisplay = new ObstacleOnDisplay(tile);
                    obstaclesOnDisplay.Add(obstacleOnDisplay);
                }
                map.modifyTile(tile);
            }
            modifiedTiles.Clear();

            foreach (ObstacleOnDisplay o in obstaclesOnDisplay)
            {
                o.setDisplay(gameTime);
            }
        }

        public void updateLemmingz(GameTime gameTime)
        {
            foreach (Lemming lemming in lemmingzManager.getLemmingzList())
            {
                // 삭제 작업 선수. 
                if (!lemming.isOnDisplay())
                {
                    LemmingOnDisplay lemmingOnDisplay = new LemmingOnDisplay(lemming);
                    lemmingzOnDisplay.Add(lemmingOnDisplay);
                }
            }
            foreach (LemmingOnDisplay l in lemmingzOnDisplay)
            {
                l.setDisplay(gameTime);
            }
        }

        public List<ObstacleOnDisplay> getObstaclesOnDisplay()
        {
            return obstaclesOnDisplay;
        }

        public List<LemmingOnDisplay> getLemmingzOnDisplay()
        {
            return lemmingzOnDisplay;
        }
    }
}
