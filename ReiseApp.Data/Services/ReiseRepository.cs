using Microsoft.EntityFrameworkCore;
using ReiseApp.Data.Models;

namespace ReiseApp.Data.Services;

public class ReiseRepository : IRepository
{

    private string _path;

    public 
        ReiseRepository(string path)
    {
        this._path = path;
    }
    public bool AddDemoData()
    {
        try
        {
            using (var context = new ReiseContext(_path))
            {
                context.Add(new Reise(new DateOnly(2025, 6, 1), "Berlin", "Eckstein"));
               
                context.SaveChanges();
            }

            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public List<Reise> All()
    {
        try
        {
            using (var context = new ReiseContext(_path))
            {
                var Reise = context.Reisen
                    .FromSql($"SELECT * FROM Reise").ToList();


                return Reise;
            }

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return new List<Reise>();
        }
    }

    public bool Delete(Reise reise)
    {
        try
        {
            using (var context = new ReiseContext(_path))
            {
                var reisen = context.Reisen.FirstOrDefault(r =>
                    r.Ort == reise.Ort &&
                    r.Nachname == reise.Nachname &&
                    r.Datum == reise.Datum);

                if (reisen != null)
                {
                    context.Reisen.Remove(reisen); // hier die gefundene Instanz entfernen!
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }



    public bool DeleteAll()
    {
    
        try
        {
            using (var context = new ReiseContext(_path))
            {
                context.Database.ExecuteSqlRaw($"Delete *");
                context.SaveChanges();
                return true;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }
    

    public bool Insert(Reise reise)
    {
        try
        {
            using (var context = new ReiseContext(_path))
            {
                context.Add(reise);

                context.SaveChanges();
            }
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Count(Reise reise)
    {
        try
        {
            using (var context = new ReiseContext(_path))
            {
                // this.AnzahlReisen = AnzahlReisen



                context.SaveChanges();
            }
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }
}