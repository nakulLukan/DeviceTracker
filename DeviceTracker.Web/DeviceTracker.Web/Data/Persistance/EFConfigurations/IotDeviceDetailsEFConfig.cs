using DeviceTracker.Core.DomainModels.Device;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceTracker.Web.Data.Persistance.EFConfigurations;

public class IotDeviceDetailsEFConfig : IEntityTypeConfiguration<IotDeviceDetails>
{
    public void Configure(EntityTypeBuilder<IotDeviceDetails> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(x => x.Device)
            .WithOne()
            .HasForeignKey<IotDeviceDetails>(x => x.DeviceId)
            .HasPrincipalKey<IotDevice>(x => x.Id);
    }
}
