using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArch.DAL.CustomValidation
{
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return (date < DateTime.Now) ? true : false;
            }
            return false;
        }
    }
}
