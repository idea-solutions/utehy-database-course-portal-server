﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UTEHY.DatabaseCoursePortal.Api.Data.Entities;
using UTEHY.DatabaseCoursePortal.Api.Data.EntityFrameworkCore;
using UTEHY.DatabaseCoursePortal.Api.Models.Banner;
using UTEHY.DatabaseCoursePortal.Api.Models.Common;
using UTEHY.DatabaseCoursePortal.Api.Services;

namespace UTEHY.DatabaseCoursePortal.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly BannerService _bannerService;

        public BannerController(BannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet("get")]
        public async Task<ApiResult<PagingResult<Banner>>> Get([FromQuery] GetBannerRequest request)
        {
            var result = await _bannerService.Get(request);

            return new ApiResult<PagingResult<Banner>>()
            {
                Status = true,
                Message = "Danh sách banner đã được lấy thành công!",
                Data = result
            };
        }

        [HttpPost("create")]
        public async Task<ApiResult<Banner>> Create([FromForm] CreateBannerRequest request)
        {
            var result = await _bannerService.Create(request);

            return new ApiResult<Banner>()
            {
                Status = true,
                Message = "Tạo mới banner thành công!",
                Data = result
            };
        }

        [HttpPost("edit")]
        public async Task<ApiResult<Banner>> Edit([FromForm] EditBannerRequest request)
        {
            var result = await _bannerService.Edit(request);

            return new ApiResult<Banner>()
            {
                Status = true,
                Message = "Cập nhật banner thành công!",
                Data = result
            };
        }

        [HttpPost("delete")]
        public async Task<ApiResult<Banner>> Delete([FromBody] int id)
        {
            var result = await _bannerService.Delete(id);

            return new ApiResult<Banner>()
            {
                Status = true,
                Message = "Xoá banner thành công!",
                Data = result
            };
        }

        [HttpPost("delete-multiple")]
        public async Task<ApiResult<List<Banner>>> DeleteMultiple([FromBody] List<int> ids)
        {
            var result = await _bannerService.DeleteMultiple(ids);

            return new ApiResult<List<Banner>>()
            {
                Status = true,
                Message = "Xoá nhiều banner thành công!",
                Data = result
            };
        }
    }
}
