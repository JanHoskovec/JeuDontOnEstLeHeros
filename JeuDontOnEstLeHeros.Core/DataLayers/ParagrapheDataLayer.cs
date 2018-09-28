using JeuDontOnEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.Core.DataLayers
{
    public class ParagrapheDataLayer
    {
        public List<Paragraphe> GetAll()
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from para in context.Paragraphe
                        select para).ToList();
            }
        }

        public Paragraphe GetOne(int id)
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from para in context.Paragraphe
                        where para.Id == id
                        select para).Single();
            }
        }

        public Question GetQuestion(Paragraphe p)
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from q in context.Question
                        where p.Id == q.ParagrapheId
                        select q).Single();
            }
        }
    }
}
