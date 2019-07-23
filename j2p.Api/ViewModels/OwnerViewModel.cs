using j2p.Presentation.Api.ViewModels.AddViewModel;

namespace j2p.Presentation.Api.ViewModels
{
    public class OwnerViewModel : UserViewModel
    {
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
    }
}
