using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Pengdylan.ACE.Data.Mapping
{
    public class AccountEntityTypeConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountEntityTypeConfiguration()
        {
            ToTable("Account");
        }
    }
}
