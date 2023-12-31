﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
