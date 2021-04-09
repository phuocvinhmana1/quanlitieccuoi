using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelss.Framework;

namespace Modelss.Code
{
    public class ThongTinSanhModel
    {
        QLTCdbContext db = null;
        public ThongTinSanhModel()
        {
            db = new QLTCdbContext();

        }

        public List<ThongTinSanh> ListThongTinSanh()
        {
            return db.ThongTinSanhs.ToList();
        }


    }
}
