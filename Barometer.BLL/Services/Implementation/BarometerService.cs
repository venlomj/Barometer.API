using AutoMapper;
using Barometer.BLL.Services.Interface;
using Barometer.DAL.Model;
using Barometer.DAL.Repositories.Interface;
using Barometer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.BLL.Services.Implementation
{
    public class BarometerService : IBarometerService
    {
        private readonly IBarometerRepository _barometerRepository;
        protected readonly IValidator<BarometerRequest> _barometerRequestValidator;
        IMapper _mapper;
        public BarometerService(IBarometerRepository barometerRepository, IValidator<BarometerRequest> barometerRequestValidator, IMapper mapper)
        {
            _barometerRepository = barometerRepository;
            _barometerRequestValidator = barometerRequestValidator;
            _mapper = mapper;
        }
        public async Task<Response<BarometerDto>> SaveBarometerAsync(BarometerRequest barometerRequest)
        {
            var response = new Response<BarometerDto>();

            try
            {
                // Validate the request using FluentValidation
                var validationResult = await _barometerRequestValidator.ValidateAsync(barometerRequest).ConfigureAwait(false);

                if (validationResult.IsValid)
                {
                    var newBarometer = _mapper.Map<BarometerModel>(barometerRequest);

                    var createdBarometer = await _barometerRepository.CreateBarometerAsync(newBarometer);

                    response.Data = _mapper.Map<BarometerDto>(createdBarometer);
                    response.Message = "Barometer created successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error creating Barometer: {ex.Message}";
            }

            return response;
        }


        public async Task<Response<IEnumerable<BarometerDto>>> GetAllBarometersAsync()
        {
            var response = new Response<IEnumerable<BarometerDto>>();

            try
            {
                var barometers = await _barometerRepository.GetAllBarometersAsync();

                response.Data = _mapper.Map<IEnumerable<BarometerDto>>(barometers);
                response.Message = "Barometers retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving Barometers: {ex.Message}";
            }

            return response;
        }


        public async Task<Response<BarometerDto>> GetBarometerByIdAsync(int id)
        {
            var response = new Response<BarometerDto>();

            try
            {
                var barometer = await _barometerRepository.GetBarometerByIdAsync(id);

                if (barometer == null)
                {
                    response.Message = "Barometer not found";
                    return response;
                }

                response.Data = _mapper.Map<BarometerDto>(barometer);
                response.Message = "Barometer retrieved successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error retrieving Barometer: {ex.Message}";
            }

            return response;
        }


        public async Task<Response<BarometerDto>> UpdateBarometerAsync(int id, BarometerRequest barometerRequest)
        {
            var response = new Response<BarometerDto>();

            try
            {
                // Validate the request using FluentValidation
                var validationResult = await _barometerRequestValidator.ValidateAsync(barometerRequest).ConfigureAwait(false);

                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = string.Join(", ", validationResult.Errors.Select(error => error.ErrorMessage));
                    return response;
                }

                var existingBarometer = await _barometerRepository.GetBarometerByIdAsync(id);

                if (existingBarometer == null)
                {
                    response.Success = false;
                    response.Message = "Barometer not found";
                    return response;
                }

                _mapper.Map(barometerRequest, existingBarometer);

                var updatedBarometer = await _barometerRepository.UpdateBarometerAsync(existingBarometer);

                response.Data = _mapper.Map<BarometerDto>(updatedBarometer);
                response.Message = "Barometer updated successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error updating Barometer: {ex.Message}";
            }

            return response;
        }


        public async Task<Response<bool>> DeleteBarometerAsync(int id)
        {
            var response = new Response<bool>();

            var isDeleted = await _barometerRepository.DeleteBarometerAsync(id);

            if (isDeleted)
            {
                response.Data = true;
                response.Message = "Barometer deleted successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Barometer not found";
            }

            return response;
        }
    }
}
