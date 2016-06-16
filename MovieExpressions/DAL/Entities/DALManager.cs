using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Entities
{
    public class DALManager
    {
        private PostContext db = new PostContext();

        public bool AddMovie(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
            return true;
        }
        
        public List<Film> GetAllMovies()
        {
            var query = db.Films.Select(s => s).OrderBy(s=>s.ID).ToList();
            query.Reverse();
            return query;
        }

        public bool DropDatabase()
        {
            return DropFilmsTable() && DropCommentsTable() ? true : false;
        }

        private bool DropFilmsTable()
        {
            try
            {
                foreach (var item in db.Films)
                    db.Films.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool DropCommentsTable()
        {
            try
            {
                foreach (var item in db.Comments)
                    db.Comments.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Film GetFilm(int id)
        {
             return db.Films.Find(id);
        }
        public void UpdateDb()
        {
            db.SaveChanges();
        }
    }
}
