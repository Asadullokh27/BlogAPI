﻿using BlogAPI.Application.Services.PermissionServices;
using BlogAPI.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {

        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            try
            {
                var permissions = await _permissionService.GetAllPermissions();
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            try
            {
                var permission = await _permissionService.GetPermissionById(id);
                if (permission == null)
                    return NotFound();

                return Ok(permission);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission(PermissionDTO permissionDTO)
        {
            try
            {
                var permission = await _permissionService.CreatePermission(permissionDTO);
                return CreatedAtAction(nameof(GetPermissionById), new { id = permission.Id }, permission);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermissionById(int id,PermissionDTO permissionDTO)
        {
            try
            {
                var updatedPermission = await _permissionService.UpdatePermissionById(id, permissionDTO);
                if (updatedPermission == null)
                    return NotFound();

                return Ok(updatedPermission);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionById(int id)
        {
            try
            {
                var result = await _permissionService.DeletePermissionById(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
