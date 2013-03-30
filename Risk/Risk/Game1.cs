using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace Risk
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Texture2D mouseMap;
        Texture2D Map;
        Texture2D overlay;

        Texture2D overlayRed;
        Texture2D overlayGreen;
        Texture2D overlayBlue;
        Texture2D overlayLightBlue;
        Texture2D overlayYellow;
        Texture2D overlayBlack;

        Texture2D defaultOverlay;

        RenderTarget2D render;

        Vector2 position = Vector2.Zero;
        Rectangle gameWindow = new Rectangle(0,0,800, 600);
        

        public Game1()
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

            base.Initialize();
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mouseMap = Content.Load<Texture2D>("mouseMap");
            Map = Content.Load<Texture2D>("Map");

            overlayRed = Content.Load<Texture2D>("overlayRed");
            overlayBlue = Content.Load<Texture2D>("overlayBlue");
            overlayLightBlue = Content.Load<Texture2D>("overlayLightBlue");
            overlayYellow = Content.Load<Texture2D>("overlayYellow");
            overlayBlack = Content.Load<Texture2D>("overlayBlack");
            overlayGreen= Content.Load<Texture2D>("overlayGreen");

            defaultOverlay = Content.Load<Texture2D>("defaultOverlay");

            overlay = defaultOverlay;
            render = new RenderTarget2D(graphics.GraphicsDevice, 1, 1);
            
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
            MouseState mousestate = Mouse.GetState();
            Point mouseposition = new Point(mousestate.X, mousestate.Y);

            KeyboardState keystate = Keyboard.GetState();
            // Allows the game to exit
            if (keystate.IsKeyDown(Keys.Escape))
                this.Exit();

            if (gameWindow.Contains(mouseposition) && mouseColor(mouseposition.X, mouseposition.Y) == Color.White)
            {
                overlay = defaultOverlay;
            }
            else if (gameWindow.Contains(mouseposition) && mouseColor(mouseposition.X, mouseposition.Y) == new Color(0,255,0,255))
                overlay = overlayGreen;
            else if (gameWindow.Contains(mouseposition) && mouseColor(mouseposition.X, mouseposition.Y) == new Color(255, 0, 0, 255))
                overlay = overlayRed;
       
            else if (gameWindow.Contains(mouseposition) && mouseColor(mouseposition.X, mouseposition.Y) == new Color(0, 0, 255, 255))
                overlay = overlayBlue;
            else if (gameWindow.Contains(mouseposition) && mouseColor(mouseposition.X, mouseposition.Y) == new Color(0, 0, 0, 255))
                overlay = overlayBlack;
            else if (gameWindow.Contains(mouseposition) && mouseColor(mouseposition.X, mouseposition.Y) == new Color(255, 255, 0, 255))
                overlay = overlayYellow;
            else if (gameWindow.Contains(mouseposition) && mouseColor(mouseposition.X, mouseposition.Y) == new Color(0, 255, 255, 255))
                overlay = overlayLightBlue;

          
            base.Update(gameTime);
        }

        private Color mouseColor(float x, float y)
        {
            graphics.GraphicsDevice.SetRenderTarget(render);
            graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.White, 0, 0);

            spriteBatch.Begin();
            spriteBatch.Draw(mouseMap, new Rectangle(0, 0, 1, 1),
                new Rectangle((int)(x), (int)(y), 1, 1), Color.White);
            spriteBatch.End();

            graphics.GraphicsDevice.SetRenderTarget(null);

            Color[] colors = new Color[1];
            render.GetData<Color>(colors);
            return colors[0];
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            spriteBatch.Draw(Map, gameWindow, Color.White);
            spriteBatch.Draw(overlay, gameWindow, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
