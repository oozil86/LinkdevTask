using EmploymentApp.Contracts.BusinessObjects;
using EmploymentApp.Contracts.CommonObjects;
using EmploymentApp.Contracts.Enums;
using EmploymentApp.Domain.IMapping;
using EmploymentApp.Domain.IUnitofWork;
using EmploymentApp.Domain.Models;
using EmploymentApp.Services.Abstractions.IServices;
using Microsoft.Extensions.Configuration;

namespace EmploymentApp.Services.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ITypeMapper _mapper;
        public JobService(IUnitofwork unitOfWork, IConfiguration configuration, ITypeMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }
        private List<string> ValidateJob(JobCreateDto Job)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(Job.Name))
            {
                errors.Add("Job Name Can't Be Empty");
            }
            if (string.IsNullOrEmpty(Job.Description))
            {
                errors.Add("Job Description Can't Be Empty");
            }
            if (string.IsNullOrEmpty(Job.Responsibilities))
            {
                errors.Add("Job Responsibilities Can't Be Empty");
            }
            if (string.IsNullOrEmpty(Job.Skills))
            {
                errors.Add("Job Skills Can't Be Empty");
            }
            if (string.IsNullOrEmpty(Job.Category))
            {
                errors.Add("Job Category Can't Be Empty");
            }
            return errors;
        }
        public async Task<CommonResponse<string>> InsertNewJob(JobCreateDto Job)
        {
            var Response = new CommonResponse<string> { Errors = new List<string>() };
            try
            {
                var errors = ValidateJob(Job);

                if (errors.Count > 0)
                {
                    Response.Errors = errors;
                    Response.Result = EnumResponseResult.FailedWithoutExcption;
                    Response.Data = CommonMessages.FAILED_ADDING;
                }
                else
                {
                    var mappedJob = _mapper.Map<JobCreateDto, JobModel>(Job);
                    await _unitOfWork.JobRepository.AddAsync(mappedJob);
                    await _unitOfWork.SaveAsync();

                    Response.Result = EnumResponseResult.Successed;
                    Response.Data = CommonMessages.SUCCESSFULLY_ADDING;


                }
            }
            catch
            {
                Response.Data = CommonMessages.FAILED_ADDING;
                Response.Result = EnumResponseResult.FailedWithExcption;
                Response.Errors.Add(CommonMessages.EXCEPTION_MESSAGE);
            }
            return Response;
        }

        public async Task<CommonResponse<string>> UpdateJob(JobDto Job)
        {
            var Response = new CommonResponse<string> { Errors = new List<string>() };
            try
            {
                var ValidatedJob = _mapper.Map<JobDto, JobCreateDto>(Job);
                var errors = ValidateJob(ValidatedJob);

                if (errors.Count > 0)
                {
                    Response.Errors = errors;
                    Response.Result = EnumResponseResult.FailedWithoutExcption;
                    Response.Data = CommonMessages.FAILED_UPDATING;
                }
                else
                {
                    var mappedJob = _mapper.Map<JobDto, JobModel>(Job);
                    await _unitOfWork.JobRepository.UpdateJob(mappedJob);
                    await _unitOfWork.SaveAsync();
                    Response.Result = EnumResponseResult.Successed;
                    Response.Data = CommonMessages.SUCCESSFULLY_UPDATING;


                }
            }
            catch
            {
                Response.Data = CommonMessages.FAILED_ADDING;
                Response.Result = EnumResponseResult.FailedWithExcption;
                Response.Errors.Add(CommonMessages.EXCEPTION_MESSAGE);
            }
            return Response;
        }

        public async Task<CommonResponse<string>> DeleteJob(int Id)
        {
            var Response = new CommonResponse<string> { Errors = new List<string>() };
            try
            {

                await _unitOfWork.JobRepository.RemoveAsync(Id);
                await _unitOfWork.SaveAsync();

                Response.Result = EnumResponseResult.Successed;
                Response.Data = CommonMessages.SUCCESSFULLY_DELETING;
            }
            catch
            {
                Response.Data = CommonMessages.FAILED_DELETING;
                Response.Result = EnumResponseResult.FailedWithExcption;
                Response.Errors.Add(CommonMessages.EXCEPTION_MESSAGE);
            }
            return Response;
        }

        public async Task<CommonResponse<PagedEntity<JobDto>>> GetFilteredJobs(PagationFilter filter)
        {
            var Response = new CommonResponse<PagedEntity<JobDto>> { Errors = new List<string>() };
            try
            {
                Response.Result = EnumResponseResult.Successed;
                Response.Data = await _unitOfWork.JobRepository.GetFilteredJobtData(filter);
            }
            catch
            {
                Response.Result = EnumResponseResult.FailedWithExcption;
                Response.Errors.Add(CommonMessages.EXCEPTION_MESSAGE);
            }
            return Response;
        }
    }
}
