using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public abstract class GamePlayers
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int WinsNumbers { get; set; }
        public string Status { get; set; }
    }
}
