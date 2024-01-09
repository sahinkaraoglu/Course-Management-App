using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace coursemanagementapp.Data
{

  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Kurs> Kurslar => Set<Kurs>();
    public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
    public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();
    public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();



  }



}