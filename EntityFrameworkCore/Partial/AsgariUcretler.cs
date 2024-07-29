using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore
{
    /// <summary>
    /// force işleminde entities içindeki yapılan değişiklikler veri tabanında olmadığı iin silinir özel kodlarımız aynı isimde
    /// partial bir claas oluşturup içine yazarız
    /// </summary>
    public partial class AsgariUcretler
    {
        public int benimCalismam { get; set; } 
    }
}
