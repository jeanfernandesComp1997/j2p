using j2p.Presentation.Api.ViewModels.AddViewModel;
using System;
using System.Collections.Generic;

namespace j2p.Presentation.Api.ViewModels
{
    public class EventViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public decimal Value { get; set; }

        public int LimitPlayers { get; set; }

        public LocalViewModel Local { get; set; }

        public PlayerViewModel Owner { get; set; }

        public string Status { get; set; }

        public IList<PlayerViewModel> Players { get; set; }
    }
}
