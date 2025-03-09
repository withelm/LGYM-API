﻿using Lgym.Services.DTOs.GymService;
using Lgym.Services.Interfaces;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lgym.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class GymController : BaseController<GymDto, RegisterGymDto>
    {
        private readonly AppDbContext _context;
        private readonly IGymService _gymService;

        public GymController(AppDbContext context, IGymService gymService) : base(gymService)
        {
            _context = context;
            _gymService = gymService;
        }

    }
}
