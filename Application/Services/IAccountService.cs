using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Account;

namespace Services
{
    public interface IAccountService
    {
        Task<AppUserSaveVM> RegisterAsync(AppUserSaveVM viewModel);
    }
}
