using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceTracker.Web.Data.Persistance.EFConfigurations;

public class IotDeviceEFConfig : IEntityTypeConfiguration<Core.DomainModels.IotDevice>
{
    public void Configure(EntityTypeBuilder<Core.DomainModels.IotDevice> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.DeviceName).IsRequired();
        builder.Property(x => x.CreatedOn).IsRequired().HasDefaultValue(new DateTimeOffset(2025, 06, 18, 0, 0, 0, TimeSpan.Zero));

        builder.HasOne(x => x.Group)
            .WithMany(x => x.IotDevices)
            .HasForeignKey(x => x.GroupId)
            .HasPrincipalKey(x => x.Id);
    }
}
