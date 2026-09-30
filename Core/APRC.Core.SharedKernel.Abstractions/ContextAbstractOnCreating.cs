using APRC.Core.SharedKernel.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Common.EF.Abstract.Data.Storage;

abstract public partial class ContextAbstract : DbContext
{
    // Predicates
    static private Func<Type, bool> AnyHeirsIEntityBasePredicate = t
        => !t.IsInterface
            && t.GetTypeInfo().ImplementedInterfaces.Any(i => i.Name == "IEntityBase")
            && t.IsClass && !t.IsAbstract && !t.IsNested;

    static private Func<Type, bool> AnyImplementedInterfacesPredicate = t
        => t.GetInterfaces().Any(i => i.IsGenericType
                                    && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
                                    && typeof(IEntityBase).IsAssignableFrom(i.GenericTypeArguments[0]));

    protected override async void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //log.Called();
        modelBuilder.ApplyConfigurationsFromAssembly(asm, AnyImplementedInterfacesPredicate);
        //log.Setted(modelBuilder.Model.GetEntityTypes().Count());
        foreach (IMutableEntityType definetype in modelBuilder.Model.GetEntityTypes())
        {
            //log.Setted(definetype.Name);
            Type fileClrType = definetype.ClrType;
            //log.Setted( fileClrType);
            EntityTypeBuilder typeBuilder = modelBuilder.Entity(fileClrType);
            string filename = fileClrType.Name;
            //log.Setted(filename);
            string filepath = $"{Environ.ContentRootPath}\\Initial\\{filename}Initial.json";
            //log.Setted(filepath);
            await typeBuilder.InitialFromJsonAsync(fileClrType, filepath);
            typeBuilder.HasKey(PrimaryKeys);
            foreach (var key in PrimaryKeys) log.Setted(key);
            //log.Setted("value", typeBuilder.Metadata.Model.ToDebugString(MetadataDebugStringOptions.SingleLine));
            //foreach (var entity in typeBuilder.Metadata.Model.ToDebugString )
            //{
            //    foreach (var value in entity.Values) );
            //}
            base.OnModelCreating(modelBuilder);
        }
    }
}


