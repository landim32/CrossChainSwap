using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Action
    {
        public Action()
        {
            ActionGoblins = new HashSet<ActionGoblin>();
        }

        public int Id { get; set; }
        public int ActionKey { get; set; }
        public DateTime DateAction { get; set; }
        public DateTime DateTerminate { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ActionGoblin> ActionGoblins { get; set; }
    }
}
