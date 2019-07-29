using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebJoKenApi.Model
{
    [Table("PlayerDB")]
    public class Player
    {
        public Guid Id { get; set; }
        public int Points { get; set; }
        public string Name { get; set; }
        public int RoundPoints { get; set; }
    }
}
