using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceTracker.Web.Data.EFConfigurations;

public class IotDeviceEFConfig : IEntityTypeConfiguration<DeviceTracker.Core.DomainModels.IotDevice>
{
    public void Configure(EntityTypeBuilder<DeviceTracker.Core.DomainModels.IotDevice> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.DeviceName).IsRequired();

        builder.HasOne(x => x.Group)
            .WithMany(x => x.IotDevices)
            .HasForeignKey(x => x.GroupId)
            .HasPrincipalKey(x => x.Id);
    }
}
