using JeuDontOnEstLeHeros.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.Core.DataLayers
{
    public class QuestionDataLayer
    {
        public List<Question> GetAll()
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from q in context.Question
                        select q).ToList();
            }
        }

        public Question GetOne(int id)
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from q in context.Question
                        where q.Id == id
                        select q).Single();
            }
        }

        public List<Reponse> GetReponses(Question question)
        {
            using (JeuDontOnEstLeHerosEntities context = new JeuDontOnEstLeHerosEntities())
            {
                return (from r in context.Reponse
                        where question.Id == r.QuestionId
                        select r).ToList();
            }
        }
    }
}
