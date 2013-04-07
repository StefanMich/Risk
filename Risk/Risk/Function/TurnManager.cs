using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk
{
    public class TurnManager
    {
        public TurnManager()
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TurnManager"/> class.
        /// </summary>
        /// <param name="players">The players.</param>
        public TurnManager(PlayerColelction players) : base()
        {
            this.players = players;
            currentPlayer = players[0];
        }

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
        }

        private PlayerColelction players;

        public PlayerColelction Players
        {
            get { return players; }
        }        

        public void UpdatePlayers()
        { }

        public void TroopDeployment()
        {
        }

        public class PlayerColelction : IEnumerable<Player>, IList<Player>
        {
            private List<Player> players;

            public PlayerColelction(List<Player> players)
            {
                this.players = players;
            }

            // Probably not needed..
            public Player NextPlayer(Player player)
            {
                if (players.IndexOf(player) == -1)
                {
                    return players[0];
                }
                else
                {
                    return players[players.IndexOf(player) + 1];
                }
            }

            public int IndexOf(Player p)
            {
                return players.IndexOf(p);
            }

            public void Insert(int index, Player p)
            {
                players.Insert(index, p);
            }

            public void RemoveAt(int index)
            {
                players.RemoveAt(index);
            }

            public Player this[int index]
            {
                get
                {
                    return players[index];
                }
                set
                {
                    value = players[index];
                }
            }

            public void Add(Player p)
            {
                players.Add(p);
            }

            public void Clear()
            {
                players.Clear();
            }

            public bool Contains(Player p)
            {
                return players.Contains(p);
            }

            public void CopyTo(Player[] array, int arrayIndex)
            {
                players.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return players.Count; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public bool Remove(Player p)
            {
                return players.Remove(p);
            }

            public IEnumerator<Player> GetEnumerator()
            {
                return players.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
