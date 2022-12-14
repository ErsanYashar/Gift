using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace myPosGift.Infrastructure.Data.DateModels
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Credits { get; set; }

    }
}
