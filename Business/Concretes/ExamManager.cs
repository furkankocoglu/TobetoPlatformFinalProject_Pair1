﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Announcement;
using Business.Dtos.Requests.Exam;
using Business.Dtos.Responses.Announcement;
using Business.Dtos.Responses.Exam;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ExamManager : IExamService
    {
        IMapper _mapper;
        IExamDal _examDal;
        public ExamManager(IMapper mapper, IExamDal examDal)
        {
            _examDal = examDal;
            _mapper = mapper;
        }
        public async Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(createExamRequest);
            var createdExam = await _examDal.AddAsync(exam);
            CreatedExamResponse result = _mapper.Map<CreatedExamResponse>(exam);
            return result;
        }

        public async Task<DeletedExamResponse> DeleteAsync(DeleteExamRequest deleteExamRequest)
        {
            Exam exam = await _examDal.GetAsync(e => e.Id == deleteExamRequest.Id);
            var deletedExam = await _examDal.DeleteAsync(exam);
            DeletedExamResponse result = _mapper.Map<DeletedExamResponse>(deletedExam);
            return result;
        }

        public async Task<GetExamResponse> GetByIdAsync(GetExamRequest getExamRequest)
        {
            var result = await _examDal.GetAsync(a => a.Id == getExamRequest.Id);
            return _mapper.Map<GetExamResponse>(result);
        }

        public async Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest)
        {
            var result = await _examDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            return _mapper.Map<Paginate<GetListExamResponse>>(result);
        }

        public async Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(updateExamRequest);
            var updatedExam = await _examDal.UpdateAsync(exam);
            UpdatedExamResponse updatedExamResponse = _mapper.Map<UpdatedExamResponse>(updatedExam);
            return updatedExamResponse;
        }
    }
}