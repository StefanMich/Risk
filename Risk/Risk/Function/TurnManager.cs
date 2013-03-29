using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk
{
    public class TurnManager
    {
        List<Player> players;

        private Player currentPlayer;

        /// <summary>
        /// Gets or sets the current player.
        /// </summary>
        /// <value>
        /// The current player.
        /// </value>
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnManager"/> class.
        /// </summary>
        /// <param name="players">The players.</param>
        public TurnManager(List<Player> players)
        {
            this.players = players;
            currentPlayer = players[0];
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TurnManager"/> class.
        /// </summary>
        /// <param name="players">The players.</param>
        public TurnManager(params Player[] players)
        {
            this.players = new List<Player>();
            foreach (var p in players)
            {
                this.players.Add(p);
            }
            currentPlayer = players[0];
        }

        /// <summary>
        /// Sets the current player to the next player to have a turn.
        /// </summary>
        public void NextPlayer()
        {
            int index = players.IndexOf(currentPlayer);
            if (index + 1 == players.Count)
            {
                currentPlayer = players[0];
            }
            else currentPlayer = players[index + 1];
        }

        public void UpdatePlayers()
        { }
    }
}
