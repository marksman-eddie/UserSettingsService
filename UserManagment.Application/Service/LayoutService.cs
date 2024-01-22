using UserManagment.Application.Interfaces;
using UserManagment.Application.Models;
using UserManagment.Application.Models.Requests;
using UserManagment.Core.Contracts;
using UserManagment.Core.Entities;

namespace UserManagment.Application.Service
{
    public class LayoutService : ILayoutService        
    {
        private readonly IUnitOfWork _unitOfWork;
        public LayoutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }

        private static Layout ConvertToEntity(LayoutDto dto)
        {
            var entity = new Layout
            {
                SchemaBody = dto.SchemaBody,
                UserLogin = dto.Login,
                InterfaceType = dto.InterfaceType,
            };
            return entity;
        }
        private static LayoutDto ConvertToDto(Layout entity)
        {
            var dto = new LayoutDto
            {
                SchemaBody = entity.SchemaBody,
                Login = entity.UserLogin,
                InterfaceType= entity.InterfaceType,
            };
            return dto;
        }

        public async Task<LayoutDto> GetLayoutAsync(LayoutsRequest request)
        {
            if(request.UserLogin is null)
                throw new ArgumentNullException(nameof(request.UserLogin));
            if (request.InterfaceType is null)
                throw new ArgumentNullException(nameof(request.InterfaceType));
            var entity = await _unitOfWork.LayoutRepository
                .GetOrDefaultAsync(request.UserLogin, request.InterfaceType);
            var dto = ConvertToDto(entity);
            return dto;
        }

        public async Task<int> SetLayoutAsync(LayoutDto item)
        {
            if (item.Login is null)
                throw new ArgumentNullException(nameof(item.Login));
            if (item.InterfaceType is null)
                throw new ArgumentNullException(nameof(item.InterfaceType));
            var entity = ConvertToEntity(item);
            var existingEntity = await _unitOfWork.LayoutRepository
                .GetAsync(item.Login, item.InterfaceType);
            if (existingEntity is null)
                return await _unitOfWork.LayoutRepository.CreateAsync(entity);
            var entry = await _unitOfWork.LayoutRepository.UpdateAsync(entity);
            return entry;
        }
    }

}
