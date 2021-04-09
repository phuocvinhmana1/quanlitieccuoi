using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelss.Framework;

namespace Modelss.Code
{
     [Serializable]
    public class GioHang
    {
       
        public ThucDon SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}
