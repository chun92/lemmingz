#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Lemmingz
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Map oneMap;
        LemmingzManager lemmingzManager;
        UpdateManager updateManager;
        Texture2D lemming;
        Texture2D ground;
        Texture2D soil;


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            oneMap = new Map(7, 7);
            lemmingzManager = new LemmingzManager(0.2, Direction.LEFT, Side.ALLY, new Vector2(0, 0), new Vector2(7, 7), oneMap, -1, 1000);
            updateManager = new UpdateManager(lemmingzManager);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            lemming = Content.Load<Texture2D>("Graphics\\lemming1");
            ground = Content.Load<Texture2D>("Graphics\\ground");
            soil = Content.Load<Texture2D>("Graphics\\soil");
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            lemmingzManager.createLemmingz(gameTime);
            lemmingzManager.moveLemmingz(gameTime);
            updateManager.updateLemmingz(gameTime);

            updateManager.updateObstacle(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (ObstacleOnDisplay o in updateManager.getObstaclesOnDisplay())
            {
                switch(o.getObstacle().getType())
                {
                    case ObstacleType.EMPTY:
                        spriteBatch.Draw(ground, o.getDisplay(), Color.White);
                        break;
                    case ObstacleType.SOIL:
                        spriteBatch.Draw(soil, o.getDisplay(), Color.White);
                        break;
                }
            }

            foreach (LemmingOnDisplay l in updateManager.getLemmingzOnDisplay())
                spriteBatch.Draw(lemming, l.getDisplay(), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
