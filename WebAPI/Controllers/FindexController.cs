﻿using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindexController : ControllerBase
    {

        IFindexService _findexService;

        public FindexController(IFindexService findexService)
        {
            _findexService = findexService;
        }

     

    }
}
