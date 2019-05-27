using System;
using System.ComponentModel.DataAnnotations;

namespace TM.Data
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}