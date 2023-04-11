using AutoMapper;
using POS.Application.Commons.Bases;
using POS.Application.Dtos.Provider.Request;
using POS.Application.Dtos.Provider.Response;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Infrastructure.Persistences.Repositories;
using POS.Utilities.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Services
{
    public class ProviderApplication : IProviderApplication
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public ProviderApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfwork = unitOfWork;
            _mapper = mapper;
        }       

        public async Task<BaseResponse<BaseEntityResponse<ProviderResponseDto>>> ListProviders(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ProviderResponseDto>>();
            var provider = await _unitOfwork.Provider.ListProviders(filters);

            if(provider is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<ProviderResponseDto>>(provider);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<ProviderResponseDto>> ProviderById(int id)
        {
            var response = new BaseResponse<ProviderResponseDto>();
            var provider = await _unitOfwork.Provider.GetByIdAsync(id);

            if(provider is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<ProviderResponseDto>(provider);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterProvider(ProviderRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var provider = _mapper.Map<Provider>(requestDto);

            response.Data = await _unitOfwork.Provider.RegisterAsync(provider);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;

        }

        public async Task<BaseResponse<bool>> EditProvider(int providerId, ProviderRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var providerEdit = await ProviderById(providerId);

            if (providerEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            var provider = _mapper.Map<Provider>(requestDto);
            provider.Id = providerId;
            response.Data = await _unitOfwork.Provider.EditAsync(provider);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveProvider(int providerId)
        {
            var response = new BaseResponse<bool>();
            var provider = await ProviderById(providerId);

            if (provider.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.Data = await _unitOfwork.Provider.RemoveAsync(providerId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }
    }
}
