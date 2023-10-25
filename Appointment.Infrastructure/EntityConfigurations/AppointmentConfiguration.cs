using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appointment.Infrastructure.EntityConfigurations
{
    internal class AppointmentConfiguration: IEntityTypeConfiguration<Data.Entities.Appointment>
    {
        public AppointmentConfiguration() { }

        public void Configure(EntityTypeBuilder<Data.Entities.Appointment> builder)
        {
            builder.ToTable(nameof(Data.Entities.Appointment));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(255);
        }
    }
}
