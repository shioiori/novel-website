using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Base
{
    public class GenericService<T, TDto> : IService<TDto> where T : class
    {
        protected readonly IGenericRepository<T> _repository;
        protected readonly IMapper _mapper;
        public virtual async Task<TDto> AddAsync(TDto obj)
        {
            T entity = await _repository.InsertAsync(await MapEntityAsync(obj));
            _repository.SaveAsync();
            return await MapDtosAsync(entity);
        }
        public virtual async Task<TDto> UpdateAsync(TDto obj)
        {
            T entity = await _repository.UpdateAsync(await MapEntityAsync(obj));
            _repository.SaveAsync();
            return await MapDtosAsync(entity);
        }

        public virtual async Task DeleteAsync(TDto obj)
        {
            _repository.Delete(await MapEntityAsync(obj));
            _repository.SaveAsync();
        }

        public virtual Task DeleteAsync(object id)
        {
            _repository.DeleteAsync(id);
            _repository.SaveAsync();
            return Task.CompletedTask;
        }

        protected async Task<TDto> MapDtosAsync(T entity) {
            var dto = _mapper.Map<TDto>(entity);
            return await Task.FromResult(dto);
        }
        protected async Task<IEnumerable<TDto>> MapDtosAsync(IEnumerable<T> entities)
        {
            var dtos = _mapper.Map<IEnumerable<TDto>>(entities);
            return await Task.FromResult(dtos);
        }

        protected async Task<T> MapEntityAsync(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            return await Task.FromResult(entity);
        }

        protected async Task<IEnumerable<T>> MapEntitiesAsync(IEnumerable<TDto> dtos)
        {
            var entities = _mapper.Map<IEnumerable<T>>(dtos);
            return await Task.FromResult(entities);
        }
    }
}
