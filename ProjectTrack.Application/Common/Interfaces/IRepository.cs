﻿using ProjectTrack.Domain;

namespace ProjectTrack.Application.Common.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> SaveAsync(T entity);
    Task<T> GetById(int id);
}