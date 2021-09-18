using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewAppMVC2.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
