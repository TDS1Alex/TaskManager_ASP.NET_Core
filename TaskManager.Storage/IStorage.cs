﻿using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Storage
{
    public interface IStorage
    {
        DbSet<Task> Task { get; set; }

        void SaveChange();
    }
}
