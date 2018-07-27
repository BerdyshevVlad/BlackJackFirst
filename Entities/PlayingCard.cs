using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public enum Value
    {
        None=0,
        Ace=1,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9,
        Ten=10,
        Jack=11,
        Queen=12,
        King=13,
    }
    public class PlayingCard
    {
        [Key]
        public int Id { get; set; }
        public Value CardValue { get; set; }

    }
}
