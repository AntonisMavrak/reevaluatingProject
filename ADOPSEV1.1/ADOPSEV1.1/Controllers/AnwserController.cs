﻿using ADOPSEV1._1.Data;
using Microsoft.AspNetCore.Mvc;

namespace ADOPSEV1._1.Controllers
{

    public class AnwserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AnwserController(ApplicationDbContext db)
        {
            _db = db;
        }


    }
}
