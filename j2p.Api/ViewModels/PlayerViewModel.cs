using System.Collections.Generic;

namespace j2p.Presentation.Api.ViewModels.AddViewModel
{
    public class PlayerViewModel : UserViewModel
    {
        public string Picture { get; set; }

        public IList<EventViewModel> Events { get; set; }
    }
}
