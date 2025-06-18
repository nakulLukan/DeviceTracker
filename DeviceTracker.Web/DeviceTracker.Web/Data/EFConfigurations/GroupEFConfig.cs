using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceTracker.Web.Data.EFConfigurations;

public class GroupEFConfig : IEntityTypeConfiguration<DeviceTracker.Core.DomainModels.Group>
{
    public void Configure(EntityTypeBuilder<DeviceTracker.Core.DomainModels.Group> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();
    }
}
