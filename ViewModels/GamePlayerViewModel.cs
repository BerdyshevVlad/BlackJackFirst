using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class GamePlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int WinsNumbers { get; set; }
        public string Status { get; set; }
    }
}
