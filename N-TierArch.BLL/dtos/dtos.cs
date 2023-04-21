using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.BLL.dtos
{
    public record LoginDto(string Name, string Password);
    public record RegisterDto(string UserName,
    string Email,
    string Password,
    string FaviouritColor);

    public record userData(string? UserName, string? FaviouritColor, string? Email);
}
