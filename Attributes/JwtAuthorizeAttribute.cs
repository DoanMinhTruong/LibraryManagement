using LibraryManagement.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Attributes
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {

        public JwtAuthorizeAttribute()
            : base(typeof(JwtAuthorizeFilter))
        {

        }
    }
}
