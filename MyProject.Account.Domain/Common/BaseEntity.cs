using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Account.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }

    }
}
