using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceTracker.Web.Data.Persistance.EFConfigurations;

public class GroupEFConfig : IEntityTypeConfiguration<Core.DomainModels.Group>
{
    public void Configure(EntityTypeBuilder<Core.DomainModels.Group> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
    }
}
