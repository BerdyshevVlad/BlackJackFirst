﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public abstract class GamePlayer
    {

        public GamePlayer()
        {
            this.PlayerCards = new HashSet<PlayingCard>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int WinsNumbers { get; set; }
        public string Status { get; set; }

        public virtual ICollection<PlayingCard> PlayerCards { get; set; }

    }
}
