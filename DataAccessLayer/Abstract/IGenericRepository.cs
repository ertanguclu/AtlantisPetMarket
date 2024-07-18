using EntityLayer.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericRepository<TContext, T, TId>
        where T : BaseEntity  // DbContext icerisindeki entity'i temsil eder
        where TContext : DbContext, new() // Dbcontext Nesnesi

    {
        public Task<int> AddAsync(T entity); //T tipindeki nesneyi veritabanına eklemek için kullanılır.
                                             //İşlem tamamlandığında bir tamsayı döner, genellikle etkilenen satır sayısını ifade eder.
        public Task<int> UpdateAsync(T entity);// T tipindeki nesneyi veritabanında güncellemek için kullanılır.
                                               // İşlem tamamlandığında bir tamsayı döner, genellikle etkilenen satır sayısını ifade eder.
        public Task<int> DeleteAsync(T entity);// T tipindeki nesneyi veritabanında silmek için kullanılır.
                                               // İşlem tamamlandığında bir tamsayı döner, genellikle etkilenen satır sayısını ifade eder.

        public Task<T?> GetByAsync(Expression<Func<T, bool>>? filter);//Verilen bir filtre koşulunu sağlayan T tipindeki nesneyi asenkron olarak getirmek için kullanılır.
                                                                      //Filtre null ise, tüm nesneleri getirir. Sonuç olarak T tipinde bir nesne veya null döner.
        public Task<T?> FindAsync(TId id);//TId tipindeki bir id değeriyle T tipindeki nesneyi bulmak için kullanılır.
                                          //Eğer id ile eşleşen bir nesne varsa, bu nesneyi döner, yoksa null döner.


        public Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>>? filter); //Verilen bir filtre koşulunu sağlayan tüm T tipindeki nesneleri asenkron olarak getirmek için kullanılır.
                                                                                     //Filtre null ise, tüm nesneleri getirir.Sonuç olarak IEnumerable<T> veya null döner.


        public Task<IEnumerable<T>> GetAllIncludeAsync(
            Expression<Func<T, bool>>? filter, // Burasi sorgu icin gerekli predicate
            params Expression<Func<T, object>>[] include); // join atilacak entity'lerin listesi);
        //Belirtilen filtre koşulunu ve ilişkili nesneleri (include listesi) kullanarak T tipindeki nesneleri asenkron olarak getirmek için kullanılır.
        //Bu genellikle ilişkili tablolarda (join işlemleri) veri almak için kullanılır. Sonuç olarak IEnumerable<T> döner.
    }
}
