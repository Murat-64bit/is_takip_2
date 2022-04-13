using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Forza_Metal
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=91.151.93.29;Initial Catalog=DboForzaMetal;User Id=mesutkomiserim; password=8wvkKQaGi.3NrD>CNOTAkxEn?15)ksN^Gaw9I;");
            baglan.Open();
            return baglan;
        }
    }
}
