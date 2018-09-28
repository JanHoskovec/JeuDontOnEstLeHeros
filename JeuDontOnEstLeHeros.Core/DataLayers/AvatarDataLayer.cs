using JeuDontOnEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.Core.DataLayers
{
    public class AvatarDataLayer
    {
        public void Save(Avatar avatar)
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                context.Avatar.Add(avatar);
                context.SaveChanges();
            }
        }

        public Avatar GetOne(int id)
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from a in context.Avatar
                        where a.Id == id
                        select a).Single();
            }
        }
    }
}
