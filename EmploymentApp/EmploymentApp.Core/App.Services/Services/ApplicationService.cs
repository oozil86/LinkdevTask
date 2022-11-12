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
    public class ApplicantService : IApplicantService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ITypeMapper _mapper;
        public ApplicantService(IUnitofwork unitOfWork, IConfiguration configuration, ITypeMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }
        private List<string> ValidateApplication(JobApplicationDto application)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(application.Applicant.Name))
            {
                errors.Add("Job Name Can't Be Empty");
            }
            if (string.IsNullOrEmpty(application.Applicant.Email))
            {
                errors.Add("Job Email Can't Be Empty");
            }
            if (string.IsNullOrEmpty(application.Applicant.MobileNumber))
            {
                errors.Add("Job MobileNumber Can't Be Empty");
            }
            if (application.JobId == 0)
            {
                errors.Add("There is no Job Applied");
            }

            return errors;
        }
        public async Task<CommonResponse<string>> ApplyToJob(JobApplicationDto application)
        {
            var Response = new CommonResponse<string> { Errors = new List<string>() };
            try
            {
                var errors = ValidateApplication(application);

                if (errors.Count > 0)
                {
                    Response.Errors = errors;
                    Response.Result = EnumResponseResult.FailedWithoutExcption;
                    Response.Data = CommonMessages.FAILED_ADDING;
                }
                else
                {
                    var mappedapplication = _mapper.Map<JobApplicantDto, JobApplicantModel>(application.Applicant);
                    await _unitOfWork.JobApplicantRepository.AddAsync(mappedapplication);
                    await _unitOfWork.SaveAsync();
                    var mapApplication = new JobApplicationModel { JobId = application.JobId, ApplicantId = mappedapplication.Id };
                    await _unitOfWork.JobApplicationRepository.AddAsync(mapApplication);
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
    }
}
