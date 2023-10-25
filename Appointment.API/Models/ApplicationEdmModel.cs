using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Diagnostics.Metrics;
using System.Drawing;
using System;
using Appointment.Application.Dtos;

namespace Appointment.API.Models
{
    public static class ApplicationEdmModel
    {
        public static IEdmModel GetEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.EntitySet<Customer>($"{nameof(Customer)}s");
            modelBuilder.EntitySet<AppointmentDto>("Appointments");

            modelBuilder.EnableLowerCamelCase();

            return modelBuilder.GetEdmModel();
        }
    }
}
