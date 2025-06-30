using DeviceTracker.Core.DomainModels.Mertrics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceTracker.Web.Data.Persistance.EFConfigurations.Metrics;

public class VoltageMetricEFConfig : IEntityTypeConfiguration<VoltageMetric>
{
    public void Configure(EntityTypeBuilder<VoltageMetric> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.V1).IsRequired();

        builder.HasOne(x => x.Device)
            .WithMany()
            .HasForeignKey(x => x.DeviceId)
            .HasPrincipalKey(x => x.Id);
    }
}
