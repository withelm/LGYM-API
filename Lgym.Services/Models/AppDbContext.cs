using Lgym.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace Lgym.Services.Models
{
    public class AppDbContext : DbContext
    {
        private readonly IBaseCurrentUserService _currentUserService;

        public AppDbContext(DbContextOptions<AppDbContext> options, IBaseCurrentUserService baseCurrentUserService) : base(options)
        {
            _currentUserService = baseCurrentUserService;


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanDay> PlanDays { get; set; }
        public DbSet<PlanDayExercise> PlanDayExercises { get; set; }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            PopulateEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            PopulateEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Przykład konwerterów do UTC
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? v.Value.ToUniversalTime() : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

            // Iterujemy po wszystkich encjach i właściwościach
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Jeżeli używasz EF Core < 5.0, to istniała koncepcja "QueryType". 
                // Dla wersji 5.0+ entityType.IsKeyless() (lub po prostu pominąć).
                if (entityType.IsKeyless)
                {
                    continue;
                }

                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(BaseModel.Version)).HasDefaultValue(0).IsConcurrencyToken();

                    // Stwórz wyrażenie parametru: (e => ...)
                    var parameter = Expression.Parameter(entityType.ClrType, "e");

                    // Odwołaj się do właściwości IsDeleted: e.IsDeleted
                    var prop = Expression.Property(parameter, nameof(BaseModel.IsDeleted));

                    // Warunek: e.IsDeleted == false
                    var condition = Expression.Equal(prop, Expression.Constant(false));

                    // Lambda: (e => e.IsDeleted == false)
                    var lambda = Expression.Lambda(condition, parameter);

                    // Ustaw filtr
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }

                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(dateTimeConverter);
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(nullableDateTimeConverter);
                    }
                }
            }

            // Wyszukujemy wszystkie właściwości typu enum
            var enumProperties = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType.IsEnum);

            // Dla każdej z nich ustawiamy konwerter na string
            foreach (var property in enumProperties)
            {
                var enumType = property.ClrType;
                var converterType = typeof(EnumToStringConverter<>).MakeGenericType(enumType);
                var converter = (ValueConverter)Activator.CreateInstance(converterType);
                property.SetValueConverter(converter);
            }

            modelBuilder.Entity<User>(entity =>
            {
                // Dla CreatedBy
                entity.HasOne(b => b.CreatedBy)
                      .WithMany()               // brak właściwości nawigacji po stronie User
                      .HasForeignKey("CreatedById")
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);

                // Dla ModifiedBy
                entity.HasOne(b => b.ModifiedBy)
                      .WithMany()               // brak właściwości nawigacji po stronie User
                      .HasForeignKey("ModifiedById")
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
            });
        }


        private void PopulateEntities()
        {
            // Pobieramy wpisy w ChangeTrackerze, które dotyczą klas dziedziczących po BaseModel
            // i zostały dodane lub zmodyfikowane.
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel &&
                           (e.State == EntityState.Added || e.State == EntityState.Modified));

            // Wczytanie encji User na podstawie aktualnie zalogowanego użytkownika (jeśli jest dostępny)
            // Zakładam, że w bazie jest DbSet<User> Users.
            User currentUser = null;
            if (_currentUserService.UserId.HasValue)
            {
                // Uwaga: Jeśli chcesz uniknąć mieszania kontekstu do ładowania użytkownika w tym samym obiegu,
                // możesz założyć, że istnieje jakiś cache lub inny serwis, który zwróci Ci tę encję bezpośrednio.
                currentUser = Users.Find(_currentUserService.UserId.Value);
            }

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseModel baseModel)
                {
                    // Ustawiamy zawsze ModifiedDate i ModifiedBy
                    baseModel.ModifiedDate = DateTime.UtcNow;
                    baseModel.ModifiedBy = currentUser;

                    if (entry.State == EntityState.Added)
                    {
                        baseModel.CreatedDate = DateTime.UtcNow;
                        baseModel.CreatedBy = currentUser;
                    }
                    else
                    {
                        baseModel.ModifiedDate = DateTime.UtcNow;
                        baseModel.ModifiedBy = currentUser;
                    }
                    ++baseModel.Version;
                }
            }


        }

    }
}
