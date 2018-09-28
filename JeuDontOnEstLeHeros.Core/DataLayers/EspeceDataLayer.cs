using JeuDontOnEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.Core.DataLayers
{
    public class EspeceDataLayer
    {
        public List<Espece> GetAll()
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from e in context.Espece select e).ToList();
            }
        }
    }
}
